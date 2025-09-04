using System;
using System.Windows.Forms;

namespace ArecaIPIS
{
    public partial class frmClientMode : Form
    {
        private frmIndex parentForm;
        //private int elapsedMilliseconds = 0;

        public frmClientMode(frmIndex parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
        }

        public frmClientMode()
        {
            InitializeComponent();
        }

        private void frmClientMode_Load(object sender, EventArgs e)
        {

            //// Initialize Timer
            //countdownTimer = new Timer { Interval = 1000 }; // Tick every second
            //countdownTimer.Tick += CountdownTimer_Tick;
            //remainingTime = 60; // Set countdown time in seconds (e.g., 1 minute)
            //lblCountdown.Text = FormatTime(remainingTime);
            //countdownTimer.Start();
        }

        private int remainingTime; // Time in seconds
        private Timer countdownTimer;

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





        //private void CountdownTimer_Tick(object sender, EventArgs e)
        //{
        //    if (remainingTime > 0)
        //    {
        //        remainingTime--;
        //        lblCountdown.Text = FormatTime(remainingTime);
        //    }
        //    else
        //    {
        //        countdownTimer.Stop();
        //      //  MessageBox.Show("Time is up!", "Countdown Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

        //private string FormatTime(int totalSeconds)
        //{
        //    int minutes = totalSeconds / 60;
        //    int seconds = totalSeconds % 60;
        //    return $"{minutes:D2}:{seconds:D2}";
        //}


    }
}
