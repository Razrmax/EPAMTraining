using System;
using DelegatesEventsLab.model;
using DelegatesEventsLab.subscribers;


namespace DelegatesEventsLab
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter timer's name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter timer length (in seconds): ");
            int seconds = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter notification threshold: ");
            int notificationThreshold = Convert.ToInt32(Console.ReadLine());
            Timer timer = new Timer(name, seconds, notificationThreshold);
            MethodsSubscriber methodsSubscriber = new MethodsSubscriber(timer);
            timer.StartCountdown();
        }
    }
}
