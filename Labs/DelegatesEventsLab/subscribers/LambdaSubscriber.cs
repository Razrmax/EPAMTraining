using DelegatesEventsLab.interfaces;
using DelegatesEventsLab.model;
using System;

namespace DelegatesEventsLab.subscribers
{
    class LambdaSubscriber : ICountdownNotifier
    {
        private readonly string _name = "Lambda Subscriber";
        private readonly Timer _timer;

        public LambdaSubscriber(Timer timer)
        {
            this._timer = timer;

            timer.EndTimerEvent += (sender, e) =>
                Console.WriteLine("Event handled by {0}\nTimer _name: {1}. Countdown complete. {2} seconds passed", _name, sender.ToString(), e.CountDownLength);
        }


        public void Init()
        {
            _timer.InitTimerEvent += (sender, e) =>
                Console.WriteLine("{0} countdown initiated\n{1} seconds total wait time\nEvent handled by {2}", sender.ToString(), e.Message, _name);
        }

        public void Run()
        {
            _timer.RunTimerEvent += (sender, e) =>
                Console.WriteLine("Event handled by {0}\nTimer _name: {1}. Countdown: {2}", _name, sender.ToString(), e.Message);
        }

        public void End()
        {
            _timer.EndTimerEvent += (sender, e) =>
                Console.WriteLine("Event handled by {0}\nTimer _name: {1}. Countdown complete. {2} seconds passed", _name, sender.ToString(), e.CountDownLength);
        }
    }
}
