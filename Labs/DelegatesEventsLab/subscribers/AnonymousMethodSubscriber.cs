using DelegatesEventsLab.interfaces;
using DelegatesEventsLab.model;
using System;

namespace DelegatesEventsLab.subscribers
{
    class AnonymousMethodSubscriber : ICountdownNotifier
    {
        private readonly string _name = "Anonymous Methods Subscriber";
        private readonly Timer _timer;

        public AnonymousMethodSubscriber(Timer timer)
        {
            _timer = timer;        
        }

        public void Init()
        {
            _timer.InitTimerEvent += delegate (Object sender, TimerEventArgs e)
            {
                Console.WriteLine("{0} countdown initiated", sender.ToString());
                Console.WriteLine("{0} seconds total wait time", e.CountDownLength);
                Console.WriteLine("Event handled by " + _name);
            };
        }

        public void Run()
        {
            _timer.RunTimerEvent += delegate (Object sender, TimerEventArgs e)
            {
                Console.WriteLine("Event handled by " + _name + ". Timer name: {0}. Countdown: {1}", sender.ToString(), e.Message);
            };
        }

        public void End()
        {
            _timer.EndTimerEvent += delegate (Object sender, TimerEventArgs e)
            {
                Console.WriteLine("Event handled by " + _name + ". Timer _name: {0}. Countdown complete", sender.ToString());
                Console.WriteLine("{0} seconds passed", e.CountDownLength);
            };
        }
    }
}
