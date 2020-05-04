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
            ICountdownNotifier methodSubscriber = new MethodsSubscriber(timer);
            ICountdownNotifier anonymousMethodsSubscriber = new AnonymousMethodSubscriber(timer);

            timer.StartCountdown();
        }
    }
}
