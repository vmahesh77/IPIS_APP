using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArecaIPIS.Forms;

namespace ArecaIPIS
{
    static class Program
    {
        // Define a unique name for the mutex to identify this application
        private static Mutex mutex = new Mutex(true, "ArecaIPIS_UniqueMutexName");

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Check if the mutex is already acquired by another instance
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                BaseClass.ManualStart = true;
                Application.Run(new frmIndex()); // Start your main form
               // Application.Run(new frmClientMode());
                // mutex is automatically released when the application exits
            }
            else
            {
                // Show message if another instance is already running
                MessageBox.Show("The application is already running.", "Application Running", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
