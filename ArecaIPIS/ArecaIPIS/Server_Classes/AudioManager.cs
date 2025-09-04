using ArecaIPIS.Classes;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ArecaIPIS.Server_Classes
{
    public static class AudioManager
    {
        private static WaveOutEvent _outputDevice;
        private static BufferedWaveProvider _buffer;
        private static readonly WaveFormat _playbackFormat = new WaveFormat(44100, 16, 2);

        private static CancellationTokenSource _cts;
        private static Task _workerTask;
        private static readonly object _sync = new object();

        private static volatile bool _isPaused;
        private static TaskCompletionSource<bool> _pauseTcs;

        // Bounded queue to cap memory usage
        private static BlockingCollection<string> _audioQueue;

        private const int BUFFER_SECONDS = 2;
        private const int PRODUCER_CHUNK_MS = 40;
        private const int DEVICE_LATENCY_MS = 100;

        private static Action _onAllCompleted;

        public static void PauseAllAudio() => Pause();
        public static void ResumeAllAudio() => Resume();
        public static void StopAllAudio() => Stop();

        public static void Start(CancellationToken externalToken = default)
        {
            lock (_sync)
            {
                if (_workerTask != null && !_workerTask.IsCompleted)
                    return;

                _cts = externalToken.CanBeCanceled
                    ? CancellationTokenSource.CreateLinkedTokenSource(externalToken)
                    : new CancellationTokenSource();

                // fresh queue each time
                _audioQueue = new BlockingCollection<string>(128);

                if (_outputDevice == null)
                {
                    _outputDevice = new WaveOutEvent { DesiredLatency = DEVICE_LATENCY_MS };
                    _buffer = new BufferedWaveProvider(_playbackFormat)
                    {
                        BufferDuration = TimeSpan.FromSeconds(BUFFER_SECONDS),
                        DiscardOnBufferOverflow = true
                    };
                    _outputDevice.Init(_buffer);
                    _outputDevice.Play();
                }

                _workerTask = Task.Factory.StartNew(
                    () => ProducerLoop(_cts.Token),
                    _cts.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
            }
        }

        public static void PlayAudioSet(List<string> audioPaths, int playCount, CancellationToken externalToken, Action onAllCompleted = null)
        {
            if (audioPaths == null || audioPaths.Count == 0)
                return;

            _onAllCompleted = onAllCompleted;

            // Start the producer BEFORE filling queue to avoid deadlock
            Start(externalToken);

            Task.Run(() =>
            {
                try
                {
                    for (int i = 0; i < playCount && !externalToken.IsCancellationRequested; i++)
                    {
                        foreach (var file in audioPaths)
                        {
                            if (externalToken.IsCancellationRequested) break;
                            if (File.Exists(file))
                                _audioQueue.Add(file, externalToken);
                        }
                    }
                }
                catch (OperationCanceledException) { }
                finally
                {
                    _audioQueue.CompleteAdding(); // signal producer no more items
                }
            });
        }

        private static void ProducerLoop(CancellationToken token)
        {
            try
            {
                Thread.CurrentThread.Priority = ThreadPriority.AboveNormal;

                while (!token.IsCancellationRequested)
                {
                    if (!_audioQueue.TryTake(out var path, 50, token))
                    {
                        // if no items left and queue closed, wait for buffer to drain then exit
                        if (_audioQueue.IsCompleted && (_buffer?.BufferedBytes ?? 0) == 0)
                        {
                            SafeReportCompleted();
                            break;
                        }
                        continue;
                    }

                    if (!File.Exists(path)) continue;

                    try
                    {
                        using (var reader = new AudioFileReader(path))
                        {
                            ISampleProvider provider = reader;
                            if (provider.WaveFormat.Channels == 1)
                                provider = new MonoToStereoSampleProvider(provider);
                            if (provider.WaveFormat.SampleRate != _playbackFormat.SampleRate)
                                provider = new WdlResamplingSampleProvider(provider, _playbackFormat.SampleRate);

                            var waveProvider16 = new SampleToWaveProvider16(provider);
                            WriteToBufferContinuously(waveProvider16, token);
                        }
                    }
                    catch (Exception ex)
                    {
                        Server.LogError("Audio file error: " + path + " => " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Server.LogError("Audio producer fatal: " + ex.Message);
            }
        }

        private static void SafeReportCompleted()
        {
            try
            {
                AnnouncementController.UpdateAudioPlayStatus("Completed");
            }
            catch (Exception ex)
            {
                Server.LogError("UpdateAudioPlayStatus failed: " + ex.Message);
            }

            try
            {
                _onAllCompleted?.Invoke();
            }
            catch (Exception ex)
            {
                Server.LogError("onAllCompleted failed: " + ex.Message);
            }
            finally
            {
                _onAllCompleted = null;
            }
        }

        public static void Pause()
        {
            lock (_sync)
            {
                if (_outputDevice != null && !_isPaused && _outputDevice.PlaybackState == PlaybackState.Playing)
                {
                    _isPaused = true;
                    _pauseTcs = new TaskCompletionSource<bool>();
                    _outputDevice.Pause();
                }
            }
        }

        public static void Resume()
        {
            lock (_sync)
            {
                if (_outputDevice != null && _isPaused)
                {
                    _isPaused = false;
                    _pauseTcs?.TrySetResult(true);
                    _outputDevice.Play();
                }
            }
        }

        public static void Stop()
        {
            lock (_sync)
            {
                try { _cts?.Cancel(); } catch { }
                _workerTask = null;

                try { _outputDevice?.Stop(); } catch { }
                try { _outputDevice?.Dispose(); } catch { }
                _outputDevice = null;

                _buffer = null;
                _isPaused = false;

                _pauseTcs?.TrySetCanceled();
                _pauseTcs = null;

                _audioQueue?.Dispose();
                _audioQueue = null;

                _onAllCompleted = null;
            }
        }

        private static void WriteToBufferContinuously(IWaveProvider waveProvider16, CancellationToken token)
        {
            if (_buffer == null) return;

            int bytesPerSecond = _playbackFormat.AverageBytesPerSecond;
            int chunkBytes = Math.Max(1024, (bytesPerSecond * PRODUCER_CHUNK_MS) / 1000);
            byte[] temp = BufferPool.Rent(chunkBytes);

            try
            {
                while (!token.IsCancellationRequested)
                {
                    if (_isPaused)
                    {
                        try { _pauseTcs?.Task.Wait(token); }
                        catch (OperationCanceledException) { return; }
                        catch { }
                    }

                    if (_buffer != null && _buffer.BufferedBytes > _buffer.BufferLength - chunkBytes)
                    {
                        Thread.Sleep(5);
                        continue;
                    }

                    int read;
                    try { read = waveProvider16.Read(temp, 0, temp.Length); }
                    catch { break; }

                    if (read <= 0) break;

                    try { _buffer?.AddSamples(temp, 0, read); }
                    catch { break; }
                }
            }
            finally
            {
                BufferPool.Return(temp);
            }
        }

        private static class BufferPool
        {
            private static readonly ConcurrentBag<byte[]> _pool = new ConcurrentBag<byte[]>();

            public static byte[] Rent(int size)
            {
                if (_pool.TryTake(out var buffer) && buffer.Length >= size)
                    return buffer;
                return new byte[size];
            }

            public static void Return(byte[] buffer)
            {
                if (buffer != null)
                    _pool.Add(buffer);
            }
        }
    }
}
