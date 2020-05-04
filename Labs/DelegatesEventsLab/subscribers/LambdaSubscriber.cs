using DelegatesEventsLab.interfaces;
using DelegatesEventsLab.model;
using System;

namespace DelegatesEventsLab.subscribers
{
    class LambdaSubscriber : ICountdownNotifier
    {
        private readonly string _name = "Lambda Subscriber";

        public LambdaSubscriber(Timer timer)
        {
            timer.InitTimerEvent += (sender, e) =>
                Console.WriteLine("{0} countdown initiated\n{1} seconds total wait time\nEvent handled by {2}", sender.ToString(), e.Message, _name);
            timer.RunTimerEvent += (sender, e) =>
                Console.WriteLine("Event handled by {0}\nTimer _name: {1}. Countdown: {2}", _name, sender.ToString(), e.Message);
            timer.EndTimerEvent += (sender, e) =>
                Console.WriteLine("Event handled by {0}\nTimer _name: {1}. Countdown complete. {2} seconds passed", _name, sender.ToString(), e.CountDownLength);
        }


        public void Init(object sender, TimerEventArgs e)
        {
            //_timer.InitTimerEvent += (sender, e) =>
            //    Console.WriteLine("{0} countdown initiated\n{1} seconds total wait time\nEvent handled by {2}", sender.ToString(), e.Message, _name);
        }

        public void Run(object sender, TimerEventArgs e)
        {
            //_timer.RunTimerEvent += (sender, e) =>
            //    Console.WriteLine("Event handled by {0}\nTimer _name: {1}. Countdown: {2}", _name, sender.ToString(), e.Message);
        }

        public void End(object sender, TimerEventArgs e)
        {
            //_timer.RunTimerEvent += (sender, e) =>
            //    Console.WriteLine("Event handled by {0}\nTimer _name: {1}. Countdown complete. {2} seconds passed", _name, sender.ToString(), e.CountDownLength);
        }
    }
}
