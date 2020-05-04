using DelegatesEventsLab.interfaces;
using DelegatesEventsLab.model;
using System;

namespace DelegatesEventsLab.subscribers
{
    class MethodsSubscriber : ICountdownNotifier
    {
        private readonly string _name = "Method Subscriber";
        private readonly Timer _timer;
        public MethodsSubscriber(Timer timer)
        {
            _timer = timer;
        }

        public virtual void Init()
        {
            _timer.InitTimerEvent += OnInit;
        }
        // Define what actions to take when the event is raised.
        public virtual void Run()
        {
            _timer.RunTimerEvent += OnRun;
        }

        public virtual void End()
        {
            _timer.EndTimerEvent += OnEnd;
        }

        public void OnInit(object sender, TimerEventArgs e)
        {
            Console.WriteLine("{0} countdown initiated", sender.ToString(), e.Message);
            Console.WriteLine("{0} seconds total wait time", e.CountDownLength);
            Console.WriteLine("Event handled by " + _name);
        }
        
        public void OnRun(object sender, TimerEventArgs e)
        {
            Console.WriteLine("Event handled by " + _name + ". Timer name: {0}. Countdown: {1}", sender.ToString(), e.Message);
        }

        public void OnEnd(object sender, TimerEventArgs e)
        {
            Console.WriteLine("Event handled by " + _name + ". Timer _name: {0}. Countdown complete", sender.ToString());
            Console.WriteLine("{0} seconds passed", e.CountDownLength);
        }
    }
}
