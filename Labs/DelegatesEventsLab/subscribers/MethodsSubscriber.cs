using DelegatesEventsLab.interfaces;
using DelegatesEventsLab.model;
using System;

namespace DelegatesEventsLab.subscribers
{
    class MethodsSubscriber : ICountdownNotifier
    {
        private readonly string _name = "Method Subscriber";
        public MethodsSubscriber(Timer timer)
        {

            timer.InitTimerEvent += Init;
            timer.RunTimerEvent += Run;
            timer.EndTimerEvent += End;
        }

        public virtual void Init(object sender, TimerEventArgs e)
        {
            Console.WriteLine("{0} countdown initiated", sender.ToString());
            Console.WriteLine("{0} seconds total wait time", e.CountDownLength);
            Console.WriteLine("Event handled by " + _name);
        }
        // Define what actions to take when the event is raised.
        public virtual void Run(object sender, TimerEventArgs e)
        {
            Console.WriteLine("Event handled by " + _name + ". Timer name: {0}. Countdown: {1}", sender.ToString(), e.Message);
        }

        public virtual void End(object sender, TimerEventArgs e)
        {
            Console.WriteLine("Event handled by " + _name + ". Timer _name: {0}. Countdown complete", sender.ToString());
            Console.WriteLine("{0} seconds passed", e.CountDownLength);
        }
    }
}
