using System;


namespace Timers
{
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
}
