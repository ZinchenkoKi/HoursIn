using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timers.Entities;

namespace Timers
{
    //public class InteractionInDataBase
    //{
    //    static TimeValueInProgram valuesTamer = new TimeValueInProgram(0, 0, 0);
    //    static TimeValueInDataBase valuesFile = new TimeValueInDataBase(0, 0, 0);


    //    public int AllHours()
    //    {
    //        Reedfiles(ref valuesFile);
    //        int d = valuesFile.hourInDataBase;
    //        return d;
    //    }



    //    public void SaveTimer()
    //    {
    //        Reedfiles(ref valuesFile);
    //        SumTimes(ref valuesFile, ref valuesTamer);
    //        WriteInFile(ref valuesFile);
    //    }

    //    int TimeRecalculation(int values, ref int valuesFile)// пересчет времени
    //    {
    //        if (values > 60)
    //        {
    //            valuesFile = (values / 60) + Convert.ToInt32(valuesFile);
    //            values = values % 60;
    //        }
    //        return values;
    //    }
    //    void Reedfiles(ref TimeValueInDataBase valuesFile)  // считывние времени из файла
    //    {
    //        using (Context reed = new Context()) // reed values file
    //        {
    //            var times = reed.timeValueInFiles.ToList();
    //            foreach (TimeValueInFile u in times)
    //            {
    //                valuesFile.hourInDataBase = u.Hours;
    //                valuesFile.minuteInDataBase = u.Minute;
    //                valuesFile.secondInDataBase = u.Second;
    //            }
    //        }
    //    }

    //    TimeValueInDataBase SumTimes(ref TimeValueInDataBase valuesFile, ref TimeValueInProgram valuesTamer) // суммирование времени таймера
    //    {
    //        valuesFile.hourInDataBase = valuesFile.hourInDataBase + valuesTamer.hourInProgram;
    //        valuesFile.minuteInDataBase = TimeRecalculation(valuesFile.minuteInDataBase, ref valuesFile.hourInDataBase) + valuesTamer.minuteInProgram;
    //        valuesFile.secondInDataBase = TimeRecalculation(valuesFile.secondInDataBase, ref valuesFile.minuteInDataBase) + valuesTamer.secondInProgram;
    //        return valuesFile;
    //    }

    //    void WriteInFile(ref TimeValueInDataBase valuesFile) // записть времени в файл
    //    {
    //        using (Context update = new Context())
    //        {
    //            TimeValueInFile? timeValueInFile = update.timeValueInFiles.FirstOrDefault();
    //            if (timeValueInFile != null)
    //            {
    //                timeValueInFile.Hours = valuesFile.hourInDataBase;
    //                timeValueInFile.Minute = valuesFile.minuteInDataBase;
    //                timeValueInFile.Second = valuesFile.secondInDataBase;
    //                update.timeValueInFiles.Update(timeValueInFile);
    //                update.SaveChanges();
    //            }
    //        }
    //    }
    //}
}
