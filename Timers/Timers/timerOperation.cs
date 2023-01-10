using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timers.Entities;




namespace Timers
{
    public  class TimerOperation // работа таймера
    {
        static TimeValueInProgram valuesTamer = new TimeValueInProgram(0, 0, 0);
        static TimeValueInDataBase valuesFile = new TimeValueInDataBase(0, 0, 0);

        public int AllHours()
        {
            Reedfiles(ref valuesFile);
            int d = valuesFile.hourInDataBase;
            return d;
        }



        public void SaveTimer()
        {
            Reedfiles(ref valuesFile);
            SumTimes(ref valuesFile, ref valuesTamer);
            WriteInFile(ref valuesFile);
        }

        int TimeRecalculation(int values, ref int valuesFile)// пересчет времени
        {
            if (values > 60)
            {
                valuesFile = (values / 60) + Convert.ToInt32(valuesFile);
                values = values % 60;
            }
            return values;
        }
        void Reedfiles(ref TimeValueInDataBase valuesFile)  // считывние времени из файла
        {
            using (Context reed = new Context()) // reed values file
            {
                var times = reed.timeValueInFiles.ToList();
                foreach (TimeValueInFile u in times)
                {
                    valuesFile.hourInDataBase = u.Hours;
                    valuesFile.minuteInDataBase = u.Minute;
                    valuesFile.secondInDataBase = u.Second;
                }
            }
        }

        TimeValueInDataBase SumTimes(ref TimeValueInDataBase valuesFile, ref TimeValueInProgram valuesTamer) // суммирование времени таймера
        {
            valuesFile.hourInDataBase = valuesFile.hourInDataBase + valuesTamer.hourInProgram;
            valuesFile.minuteInDataBase = TimeRecalculation(valuesFile.minuteInDataBase, ref valuesFile.hourInDataBase) + valuesTamer.minuteInProgram;
            valuesFile.secondInDataBase = TimeRecalculation(valuesFile.secondInDataBase, ref valuesFile.minuteInDataBase) + valuesTamer.secondInProgram;
            return valuesFile;
        }

        void WriteInFile(ref TimeValueInDataBase valuesFile) // записть времени в файл
        {
            using (Context update = new Context())
            {
                TimeValueInFile? timeValueInFile = update.timeValueInFiles.FirstOrDefault();
                if (timeValueInFile != null)
                {
                    timeValueInFile.Hours = valuesFile.hourInDataBase;
                    timeValueInFile.Minute = valuesFile.minuteInDataBase;
                    timeValueInFile.Second = valuesFile.secondInDataBase;
                    update.timeValueInFiles.Update(timeValueInFile);
                    update.SaveChanges();
                }
            }
        }

        public void timerСounting(Label label, Label label2, Label label3)
        {

            TimeCounting(ref valuesTamer, label, label2, label3);
        }

        void TimeValues(ref int valuestime, Label label) 
        {
            valuestime++;
            if (valuestime < 10)
            {
                label.Text = "0" + valuestime.ToString();
            }
            else
                label.Text = valuestime.ToString();
        }


        void TimeCounting(ref TimeValueInProgram valuesTamer, Label labelOne, Label labelTwo, Label labelTree) // общий счетчик
        {
            if (valuesTamer.secondInProgram < 59)
            {
                TimeValues(ref valuesTamer.secondInProgram, labelOne);
            }
            else
            {
                if (valuesTamer.minuteInProgram < 59)
                {
                    TimeValues(ref valuesTamer.minuteInProgram, labelTwo);
                    valuesTamer.secondInProgram = 0;
                    labelOne.Text = "00";
                    
                }
                else
                {
                    TimeValues(ref valuesTamer.hourInProgram, labelTree);
                    valuesTamer.minuteInProgram = 0;
                    labelTwo.Text = "00";
                }
            }
        }
    }  
}
