using System;

namespace EPAMTraining
{
    class Classes
    {
        static void Main(string[] args)
        {
             class MyMathOperation 
             {
                  public double r;
                  public string s;
                   public double sqrCircle()
                   {
                       return Math.PI * r * r;
                   }
                    public void writeResult()
                    {
                        Console.WriteLine("Вычислить площадь или длину? s/l:");
                        s = Console.ReadLine();
                        s = s.ToLower();
                        if (s == "s")
                        {
                            Console.WriteLine("Площадь круга равна {0:#.###}",sqrCircle());
                            return;
                        }
                        else if (s == "l")
                        
                        {
                            Console.WriteLine("Длина окружности равна {0:#.##}",longCircle());
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Вы ввели не тот символ");
                        } 
                    }
                     
             }           
        }
    }
}