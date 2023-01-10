using Microsoft.VisualBasic.ApplicationServices;
using System.IO;
using Timers.Entities;


namespace Timers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000;
        }
            private void timer1_Tick(object sender, EventArgs e)
        {
            TimerOperation t = new TimerOperation();
            t.timer—ounting(label3, label2, label1);
        }


        public  void timervalues(Button one) //timer start stop
        {

            if (timer1.Enabled == false)
            {
                one.Text = "Stop";

                timer1.Enabled = true;
            }
            else
            {
                one.Text = "Start";
                timer1.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TimerOperation t = new TimerOperation();
            label7.Text = t.AllHours() + "";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            timervalues(button1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TimerOperation t = new TimerOperation();
            t.SaveTimer();
            this.Close();
        }
    } 
}