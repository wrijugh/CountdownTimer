using System;
using System.Drawing;
using System.Windows.Forms;

namespace CountDownTimer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int iSeconds = 60; //default 60 seconds 
        private void btnStart_Click(object sender, EventArgs e)
        {
            iSeconds = Convert.ToInt32(numDDL.Value);
            timer1.Enabled = true;
            timer1.Interval = 1000; //One second interval 
            timer1.Tick += Timer1_Tick;
            lblTimer.Text = ConvertSecondsToHHMM(iSeconds);
            lblTimer.ForeColor = Color.Black;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            iSeconds = iSeconds - 1;
            ShakeForm();
            if(iSeconds < 0) //if it goes below zero then make the font RED
                lblTimer.ForeColor = Color.Red;

            lblTimer.Text = this.Text = ConvertSecondsToHHMM(iSeconds);
        }

        private void ShakeForm()
        {
            int iLoop = 1000;

            if (iSeconds == 0) //Shake it 
            {
                do
                {
                    this.Left -= 4;
                    this.Left += 4;
                    iLoop--;
                } while (iLoop > 1);
                iLoop = 1000;
            }
        }

        //Get a Second and convert it to hh:mm:ss format
        public string ConvertSecondsToHHMM(int _iSconds)
        {
            TimeSpan ts = new TimeSpan(0, 0, 0, iSeconds);
            return ts.ToString();
        }
    }
}
