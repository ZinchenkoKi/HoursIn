using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Timers
{
    public  class timerOperation // работа таймера
    {
        static valuesTamer valuesTamer = new valuesTamer(0, 0, 0);
        static valuesFile valuesFile = new valuesFile(0, 0, 0);
        
        public string filepath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "time.txt"); // относительный путь файла

        public int allHours()
        {
          reedfiles(ref valuesFile);
            int d = valuesFile.hourFile;
            return d;
        }

        ///Автосэйв доработать

        //public void avtoSave(Label label)  // автосохранение времени 
        //{
        //    if (label.Text == "30")
        //    {
        //        saveTimer();
        //    }
        //}


        public void saveTimer() // сохранение времени
        {
            reedfiles(ref valuesFile);
            sumTimes(ref valuesFile, ref valuesTamer);
            writeInFile(ref valuesFile);
        }

        public  void timerСounting(Label label, Label label2, Label label3)
        {
            timeCounting(ref valuesTamer, label, label2, label3);
        }

        void timevalues(ref int valuestime, Label label) // элимент счетчика
        {
            valuestime++;
            if (valuestime < 10)
            {
                label.Text = "0" + valuestime.ToString();
            }
            else
                label.Text = valuestime.ToString();
        }


        void timeCounting(ref valuesTamer valuesTamer, Label labelOne, Label labelTwo, Label labelTree) // общий счетчик
        {
            if (valuesTamer.secondTimer < 59)
            {
                timevalues(ref valuesTamer.secondTimer, labelOne);
                //avtoSave(labelOne);
            }
            else
            {
                if (valuesTamer.minuteTimer < 59)
                {
                    timevalues(ref valuesTamer.minuteTimer, labelTwo);
                    valuesTamer.secondTimer = 0;
                    labelOne.Text = "00";
                    
                }
                else
                {
                    timevalues(ref valuesTamer.hourTimer, labelTree);
                    valuesTamer.minuteTimer = 0;
                    labelTwo.Text = "00";
                }
            }
        }

        int timeRecalculation(int values, ref int valuesFile)// пересчет времени
        {
            if (values > 60)
            {
                valuesFile = (values / 60) + Convert.ToInt32(valuesFile);
                values = values % 60;
            }
            return values;
        }
        void reedfiles(ref valuesFile valuesFile)  // считывние времени из файла
        {
            using (FileStream stream = new FileStream(filepath, FileMode.OpenOrCreate))
            using (StreamReader reed = new StreamReader(stream))
            {
                valuesFile.hourFile = Convert.ToInt32(reed.ReadLine());
                valuesFile.minuteFile = Convert.ToInt32(reed.ReadLine());
                valuesFile.secondFile = Convert.ToInt32(reed.ReadLine());
            }
        }




        valuesFile sumTimes(ref valuesFile valuesFile, ref valuesTamer valuesTamer) // суммирование времени таймера
        {
            valuesFile.hourFile = valuesFile.hourFile + valuesTamer.hourTimer;
            valuesFile.minuteFile = timeRecalculation(valuesFile.minuteFile,ref valuesFile.hourFile) + valuesTamer.minuteTimer;
            valuesFile.secondFile = timeRecalculation(valuesFile.secondFile, ref valuesFile.minuteFile) + valuesTamer.secondTimer;
            return valuesFile;
        }



        void writeInFile(ref valuesFile valuesFile) // записть времени в файл
        {
            using (FileStream stream = new FileStream(filepath, FileMode.Create))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.WriteLine(valuesFile.hourFile);
                writer.WriteLine(valuesFile.minuteFile);
                writer.WriteLine(valuesFile.secondFile);
            }
        }
    }



    //Helleo World();


   


    struct valuesTamer // значение времени таймера
    {
        public int hourTimer, minuteTimer, secondTimer;

        public valuesTamer(int hourTimer, int minuteTimer, int secondTimer)
        {
            this.hourTimer = hourTimer;
            this.minuteTimer = minuteTimer;
            this.secondTimer = secondTimer;
        }
    }

    struct valuesFile //заначение времени в файле
    {
        public int hourFile, minuteFile, secondFile;

        public valuesFile(int hourFile, int minuteFile, int secondFile)
        {
            this.hourFile = hourFile;
            this.minuteFile = minuteFile;
            this.secondFile = secondFile;
        }
    }
}
