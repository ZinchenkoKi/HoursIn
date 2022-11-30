using System;

namespace Timers
{
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

