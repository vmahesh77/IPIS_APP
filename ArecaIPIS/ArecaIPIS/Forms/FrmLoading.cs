using System;
using System.Windows.Forms;

namespace ArecaIPIS.Forms
{
    public partial class FrmLoading : Form
    {
        private int remainingTime; // Time in seconds
        private Timer countdownTimer;




        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            if (remainingTime > 0)
            {
                remainingTime--;
                lblCountdown.Text = FormatTime(remainingTime);
            }
            else
            {
                countdownTimer.Stop();
                // MessageBox.Show("Time is up!", "Countdown Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string FormatTime(int totalSeconds)
        {
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;
            return $"{minutes:D2}:{seconds:D2}";
        }








        public FrmLoading()
        {
            InitializeComponent();
        }
        public FrmLoading(frmIndex parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
        }
        private frmIndex parentForm;
        private int elapsedMilliseconds = 0;

        private void timerProgressBar_Tick(object sender, EventArgs e)
        {
            elapsedMilliseconds += timerProgressBar.Interval; // Track total elapsed time

            if (elapsedMilliseconds <= 30000) // Total duration = 30 seconds (30,000 ms)
            {
                // Calculate and set the progress bar value
                PrgLoadiingBar.Value = (elapsedMilliseconds * 100) / 30000; // Scale to 100
            }
            else
            {
                timerProgressBar.Stop(); // Stop the timer when done
                PrgLoadiingBar.Value = 100; // Ensure progress bar is at max

            }
        }

        private void FrmLoading_Load(object sender, EventArgs e)
        {
            countdownTimer = new Timer { Interval = 1000 }; // Tick every second
            countdownTimer.Tick += CountdownTimer_Tick;
            elapsedMilliseconds = 0;
            remainingTime = 30; // Set countdown time in seconds (e.g., 1 minute)
            lblCountdown.Text = FormatTime(remainingTime);
            countdownTimer.Start();
            // Configure the ProgressBar
            PrgLoadiingBar.Maximum = 100; // Progress bar goes from 0% to 100%
            PrgLoadiingBar.Value = 0;

            // Configure the Timer
            timerProgressBar.Interval = 30; // Update every 30 ms for smooth progress
            timerProgressBar.Start();
        }

        private void BtnApplicationExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
     "Do you want to close the application?",
     "Confirm Exit",
     MessageBoxButtons.YesNo,
     MessageBoxIcon.Question
 );

            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Closes the application
            }
        }

        private void btnMinize_Click(object sender, EventArgs e)
        {
            frmIndex IndexForm;
            Form mainForm = Application.OpenForms["frmIndex"];

            if (mainForm != null)
            {
                IndexForm = (frmIndex)mainForm;

            }
            else
            {
                IndexForm = new frmIndex();

            }
            IndexForm.miniMizeWindow();
        }
    }
}
