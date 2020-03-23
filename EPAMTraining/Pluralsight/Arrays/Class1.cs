using System;
using System.Collections.Generic;

namespace EPAMTraining.Pluralsight.Arrays
{
    class Class1
    {
        static void Main()
        {
            var variable = 13.7;
            var y = 2;
            var result = y + variable;
            var somearr = new int[] { 1, 2, 3 };
            List<Car> cars = new List<Car>();
            cars.Add(new Car("Opel"));
            cars.Add(new Car("Volkswagen"));
            cars.Add(new Car("Ford"));


            foreach (var c in cars)
            {
                Console.WriteLine(c.ToString());
                System.Console.WriteLine(cars.Count);
            }
        }
    }

    class Car
    {
        public string name;

        public Car(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
