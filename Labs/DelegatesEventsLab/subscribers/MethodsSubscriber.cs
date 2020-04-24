using System;
using DelegatesEventsLab.model;
using DelegatesEventsLab.interfaces;

namespace DelegatesEventsLab.subscribers 
{
    class MethodsSubscriber : ICountdownNotifier
    {
        private readonly string name = "Method Subscriber";
        public MethodsSubscriber(Timer timer)
        {
            // Subscribe to the event using C# 2.0 syntax
            timer.InitTimerEvent += Init;
            timer.RunTimerEvent += Run;
            timer.EndTimerEvent += End;
        }

        public void Init(object sender, TimerEventArgs e)
        {
            Console.WriteLine("{0} countdown initiated", sender.ToString());
            Console.WriteLine("{0} seconds total wait time", e.CountDownLength);
        }
        // Define what actions to take when the event is raised.
        public void Run(object sender, TimerEventArgs e)
        {
            Console.WriteLine("Event handled by " + name + ". Timer name: {0}. Countdown: {1}", sender.ToString(), e.Message);
        }

        public void End(object sender, TimerEventArgs e)
        {
            Console.WriteLine("Event handled by " + name + ". Timer name: {0}. Countdown complete", sender.ToString());
            Console.WriteLine("{0} seconds passed", e.CountDownLength);
        }
    }
}
