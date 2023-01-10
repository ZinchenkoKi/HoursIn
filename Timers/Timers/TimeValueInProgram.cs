using System;


namespace Timers
{
    struct TimeValueInProgram // значение времени таймера
    {
        public int hourInProgram, minuteInProgram, secondInProgram;

        public TimeValueInProgram(int hourInProgram, int minuteInProgram, int secondInProgram)
        {
            this.hourInProgram = hourInProgram;
            this.minuteInProgram = minuteInProgram;
            this.secondInProgram = secondInProgram;
        }
    }
}
