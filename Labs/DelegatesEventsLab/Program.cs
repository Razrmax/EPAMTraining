using System;
using System.Diagnostics.Tracing;
using System.Security.Cryptography.X509Certificates;
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
            Timer timer = new Timer(name, seconds);
            MethodsSubscriber methodsSubscriber = new MethodsSubscriber(timer);
            timer.StartCountdown();
        }
    }
}
