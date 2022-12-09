using System;

namespace Timers
{
    struct valuesDatabase //заначение времени в файле
    {
        public int hourFile, minuteFile, secondFile;

        public valuesDatabase(int hourFile, int minuteFile, int secondFile)
        {
            this.hourFile = hourFile;
            this.minuteFile = minuteFile;
            this.secondFile = secondFile;
        }
    }
}

