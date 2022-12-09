using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timers.Entities;




namespace Timers
{
    public  class timerOperation // работа таймера
    {
        static valuesTamer valuesTamer = new valuesTamer(0, 0, 0);
        static valuesDatabase valuesDatabase = new valuesDatabase(0, 0, 0);

        public int totalHours()
        {
            datarReading(ref valuesDatabase);
            int numberHours = valuesDatabase.hourFile;
            return numberHours;
        }

        public void savingTimerValues() // сохранение времени
        {
            datarReading(ref valuesDatabase);
            sumTimes(ref valuesDatabase, ref valuesTamer);
            writeInFile(ref valuesDatabase);
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
        void datarReading(ref valuesDatabase valuesFile)  // считывние времени из файла
        {
            using (Context reed = new Context()) // reed values file
            {
                var times = reed.timeValueInFiles.ToList();
                foreach (timeValueInFile u in times)
                {
                    valuesFile.hourFile = u.Hours;
                    valuesFile.minuteFile = u.Minute;
                    valuesFile.secondFile = u.Second;
                }
            } 
        }

        valuesDatabase sumTimes(ref valuesDatabase valuesFile, ref valuesTamer valuesTamer) // суммирование времени таймера
        {
            valuesFile.hourFile = valuesFile.hourFile + valuesTamer.hourTimer;
            valuesFile.minuteFile = timeRecalculation(valuesFile.minuteFile,ref valuesFile.hourFile) + valuesTamer.minuteTimer;
            valuesFile.secondFile = timeRecalculation(valuesFile.secondFile, ref valuesFile.minuteFile) + valuesTamer.secondTimer;
            return valuesFile;
        }

        void writeInFile(ref valuesDatabase valuesFile) // записть времени в файл
        {
            using (Context update = new Context())
            {
                timeValueInFile? timeValueInFile = update.timeValueInFiles.FirstOrDefault();
                if (timeValueInFile != null)
                {
                    timeValueInFile.Hours = valuesFile.hourFile;
                    timeValueInFile.Minute = valuesFile.minuteFile;
                    timeValueInFile.Second = valuesFile.secondFile;
                    update.timeValueInFiles.Update(timeValueInFile);
                    update.SaveChanges();
                }
            }
        }
    }  
}
