using System;

namespace _17_04_20_Delegates
{
    delegate int LengthLogin(string s);
    delegate bool BoolPassword(string s1, string s2);
    delegate void Capcha(string s1, string s2);

    class Program
    {
        static void Main(string[] args)
        {
            SetLogin();
            Console.Write("Enter password: ");
            string password1 = Console.ReadLine();
            Console.Write("Repeat password: ");
            string password2 = Console.ReadLine();
            // Используем лямбда выражение 
            BoolPassword bp = (s1, s2) => s1 == s2;

            if (bp(password1, password2))
                Console.WriteLine("Registration succes!");
            else
                Console.WriteLine("Registration failed. Passwords don't match");
            Console.ReadLine();
        }

        private static void SetLogin()

        {
            Console.Write("Enter login: ");
            string login = Console.ReadLine();

            // Используем лямбда-выражение 

            LengthLogin lengthLoginDelegate = s => s.Length;

            int lengthLogin = lengthLoginDelegate(login);
            if (lengthLogin > 25)

            {
                Console.WriteLine("Login too long\n");
                // Рекурсия на этот же метод, чтобы ввести заново логин 
                SetLogin();
            }
        }
    }
}
