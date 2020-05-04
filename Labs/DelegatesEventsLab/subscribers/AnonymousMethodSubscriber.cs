using DelegatesEventsLab.interfaces;
using DelegatesEventsLab.model;
using System;

namespace DelegatesEventsLab.subscribers
{
    class AnonymousMethodSubscriber : ICountdownNotifier
    {
        private readonly string _name = "Anonymous Methods Subscriber";

        public AnonymousMethodSubscriber(Timer timer)
        {
            timer.InitTimerEvent += delegate (Object sender, TimerEventArgs e)
            {
                Console.WriteLine("{0} countdown initiated", sender.ToString());
                Console.WriteLine("{0} seconds total wait time", e.CountDownLength);
                Console.WriteLine("Event handled by " + _name);
            };

            timer.RunTimerEvent += delegate (Object sender, TimerEventArgs e)
            {
                Console.WriteLine("Event handled by " + _name + ". Timer name: {0}. Countdown: {1}", sender.ToString(), e.Message);
            };

            timer.EndTimerEvent += delegate (Object sender, TimerEventArgs e)
            {
                Console.WriteLine("Event handled by " + _name + ". Timer _name: {0}. Countdown complete", sender.ToString());
                Console.WriteLine("{0} seconds passed", e.CountDownLength);
            };
        }

        public void Init(object sender, TimerEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Run(object sender, TimerEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void End(object sender, TimerEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
