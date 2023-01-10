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
    public  class TimerOperation 
    {

        public void TimerTick(int valuestime, Label label)
        {
            valuestime++;
            if (valuestime < 10)
            {
                label.Text = "0" + valuestime.ToString();
            }
            else
                label.Text = valuestime.ToString();
        }

       public void TimeCounting(TimeValueInProgram valuesTamer, Label labelOne, Label labelTwo, Label labelTree) // общий счетчик
        {
            if (valuesTamer.secondInProgram < 59)
            {
                TimerTick(valuesTamer.secondInProgram, labelOne);
            }
            else
            {
                if (valuesTamer.minuteInProgram < 59)
                {
                    TimerTick(valuesTamer.minuteInProgram, labelTwo);
                    valuesTamer.secondInProgram = 0;
                    labelOne.Text = "00";
                    
                }
                else
                {
                    TimerTick(valuesTamer.hourInProgram, labelTree);
                    valuesTamer.minuteInProgram = 0;
                    labelTwo.Text = "00";
                }
            }
        }


        //int timeRecalculation(int values, ref int valuesFile)// пересчет времени
        //{
        //    if (values > 60)
        //    {
        //        valuesFile = (values / 60) + Convert.ToInt32(valuesFile);
        //        values = values % 60;
        //    }
        //    return values;
        //}
      
    }  
}
