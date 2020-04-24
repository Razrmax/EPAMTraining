using System;
using DelegatesEventsLab2.interfaces;
using DelegatesEventsLab2.model;

namespace DelegatesEventsLab.subscribers 
{
    public delegate void StartTimer();
    class MethodsSubscriber : ICountdownNotifier
    {
        private readonly string name = "Method Subscriber";
        private readonly Timer timer;
        private readonly StartTimer starter;

        public MethodsSubscriber(Timer t)
        {
            // Subscribe to the event using C# 2.0 syntax
            this.timer = t;
            timer.InitTimerEvent += Init;
            timer.RunTimerEvent += Run;
            timer.EndTimerEvent += End;
            starter = timer.StartCountdown;
        }

        public void Init(object sender, TimerEventArgs e)
        {
            OnStarterEvent();
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

        private void OnStarterEvent()
        {
            starter?.Invoke();
        }
    }
}
