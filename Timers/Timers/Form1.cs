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
            label6.Text = t.allHours() + "÷. âñåãî";
            //using (var context = new Context())
            //{

            //}

            //using (Context addTimes = new Context())
            //{
            //    fileTime programing = new fileTime { Hours = 8, Minute = 34, Second = 5 };
            //    addTimes.fileTimes.Add(programing);
            //    addTimes.SaveChanges();
            //}

            //using (Context reedContext = new Context())
            //{
            //    var filetimeq = reedContext.fileTimes.ToList();
            //   label1.Text= filetimeq.Count.ToString();
            //}


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timerOperation t = new timerOperation();
            t.timerÑounting(label3, label2, label1);
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

        }

        private void button1_Click_1(object sender, EventArgs e) // strart timer
        {
            timervalues(button1);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            timerOperation t = new timerOperation();
            t.saveTimer();
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    } 
}