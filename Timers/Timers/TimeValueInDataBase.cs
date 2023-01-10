using System;

namespace Timers
{
    struct TimeValueInDataBase //заначение времени в файле
    {
        public int hourInDataBase, minuteInDataBase, secondInDataBase;

        public TimeValueInDataBase(int hourInDataBase, int minuteInDataBase, int secondInDataBase)
        {
            this.hourInDataBase = hourInDataBase;
            this.minuteInDataBase = minuteInDataBase;
            this.secondInDataBase = secondInDataBase;
        }
    }
}

