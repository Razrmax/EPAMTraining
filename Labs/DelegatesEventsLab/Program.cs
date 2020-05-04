using DelegatesEventsLab.interfaces;
using DelegatesEventsLab.model;
using DelegatesEventsLab.subscribers;
using System;


namespace DelegatesEventsLab
{

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter timer's name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter timer length (in seconds): ");
            int seconds = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter notification threshold: ");
            int notificationThreshold = Convert.ToInt32(Console.ReadLine());

            Timer timer = new Timer(name, seconds, notificationThreshold);
            //ICountdownNotifier methodsSubscriber = new MethodsSubscriber(timer);
            ICountdownNotifier lambdaSubscriber = new LambdaSubscriber(timer);
            ICountdownNotifier methodsSubscriber = new MethodsSubscriber(timer);
            ICountdownNotifier anonymousMethodSubscriber = new AnonymousMethodSubscriber(timer);
            ICountdownNotifier[] countdownNotifiers = new ICountdownNotifier[3];
            countdownNotifiers[0] = methodsSubscriber;
            countdownNotifiers[1] = anonymousMethodSubscriber;
            countdownNotifiers[2] = lambdaSubscriber;
                     
            TimerSubscriberInit(countdownNotifiers);
            TimerSubscriberRun(countdownNotifiers);
            TimerSubscriberEnd(countdownNotifiers);
            
            timer.StartCountdown();
        }

        public static void TimerSubscriberInit(ICountdownNotifier[] countdownNotifiers)
        {
            foreach (var v in countdownNotifiers)
            {
                v.Init();
            }
        }

        public static void TimerSubscriberRun(ICountdownNotifier[] countdownNotifiers)
        {
            foreach (var v in countdownNotifiers)
            {
                v.Run();
            }
        }

        public static void TimerSubscriberEnd(ICountdownNotifier[] countdownNotifiers)
        {
            foreach (var v in countdownNotifiers)
            {
                v.End();
            }
        }
    }
}
