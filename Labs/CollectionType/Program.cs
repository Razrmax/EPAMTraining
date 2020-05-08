using System;
using CollectionsLab.models;
using CollectionsLab.models.shapes;

namespace CollectionsLab
{
    class Program
    {
        static void Main()
        {
            bool exit = false;
            CollectionType<GeometricShape>[] collectionsArr = RandomCollectionGenerator();
            
            while (!exit)
            {
                string input = Console.ReadLine();
                string[] inputLine = input.Split(" ");
                string command = inputLine[0];
                switch (command)
                {
                    case "gen":
                        collectionsArr = RandomCollectionGenerator();
                        break;
                    case "elements":
                        var twoElements = collectionsArr.Count() == 2;

                }
            }

            #region Collections Generator
            
            #endregion


        }

        static CollectionType<GeometricShape>[] RandomCollectionGenerator()
        {
            CollectionType<GeometricShape>[] collections = new CollectionType<GeometricShape>[5];

            for (int counter = 0; counter < collections.Length; counter++)
            {
                Random rnd = new Random();
                CollectionType<GeometricShape> collection = new CollectionType<GeometricShape>();
                int i = rnd.Next(2, 5);
                for (int k = 0; k < i; k++)
                {
                    int j = rnd.Next(1, 3);
                    double sideA;
                    double sideB;
                    double sideC;
                    double height;
                    switch (j)
                    {
                        case 1:
                            collection.Add(new Circle("circle", new double[] { rnd.Next(1, 10) }));
                            break;
                        case 2:
                            sideA = rnd.Next(1, 5);
                            sideB = rnd.Next(1, 5);
                            collection.Add(new Rectangular("rectangular", new double[] { sideA, sideB, sideA, sideB }));
                            break;
                        case 3:
                            sideA = rnd.Next(1, 5);
                            sideB = rnd.Next(1, 5);
                            sideC = rnd.Next(1, 5);
                            height = rnd.Next(1, 5);
                            double[] dimensions = new double[4];
                            dimensions[0] = sideA;
                            dimensions[1] = sideB;
                            dimensions[2] = sideC;
                            dimensions[3] = height;

                            Array.Reverse(dimensions, 0, 3);
                            double temp = dimensions[0];
                            dimensions[0] = dimensions[1];
                            dimensions[1] = temp;
                            collection.Add(new Triangle("triangle", dimensions));
                            break;
                        default:
                            break;
                    }
                }

                collections[counter] = collection;
            }
            

            return collections;
        }
    }
}
