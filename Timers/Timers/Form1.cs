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
            timerOperation t = new timerOperation();
            label7.Text = t.allHours() + "�. �����";
            using (var context = new Context())
            {

            }

            using (Context addTimes = new Context())
            {
                fileTime programing = new fileTime { Hours = 8, Minute = 34, Second = 5 };
                addTimes.fileTimes.Add(programing);
                addTimes.SaveChanges();
            }

            using (Context reedContext = new Context())
            {
                var filetimeq = reedContext.fileTimes.ToList();
               label1.Text= filetimeq.Count.ToString();
            }


        }




        private void button1_Click(object sender, EventArgs e)  // strart timer
        {
           timervalues(button1);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            timerOperation t = new timerOperation();
            t.saveTimer();
            this.Close();
        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            timerOperation t = new timerOperation();
            t.timer�ounting(label5, label3, label1);
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
    } 
}