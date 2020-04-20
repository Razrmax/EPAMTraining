using System;
using System.Timers;

namespace DelegatesEventsLab.model
{
    class Timer
    {
        private int countdownInSeconds;

        public Timer(int countdownInSeconds)
        {
            this.countdownInSeconds = countdownInSeconds;
        }

        public void TimerEventHandler(Object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
                              e.SignalTime);
        }
    }   
}
