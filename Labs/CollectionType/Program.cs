using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using CollectionsLab.exceptions;
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
            FileManager fileManager = new FileManager();
            
            while (!exit)
            {
                string input = Console.ReadLine();
                if (input != null)
                {
                    input.ToLower().Trim();
                    string[] inputLine = input.Split(" ");
                    string command = inputLine[0];
                    switch (command)
                    {
                        case "save":
                            fileManager.SaveCollection(collectionsArr);
                            break;
                        case "load":
                            collectionsArr = fileManager.LoadCollection();
                            break;
                        case "sort":
                            if (inputLine.Length >= 3)
                            {
                                if (inputLine[1] == "asc")
                                {
                                    if (inputLine[2] == "area" || inputLine[2] == "perim")
                                    {
                                        collectionsArr = SortCollectionByFieldAscending(collectionsArr, inputLine[2]);
                                    }
                                    
                                }
                                else if (inputLine[1] == "desc")
                                {
                                    if (inputLine[2] == "area" || inputLine[2] == "perim")
                                    {
                                        collectionsArr = SortCollectionByFieldDescending(collectionsArr, inputLine[2]);
                                    }
                                }
                            }
                            break;
                        case "gen":
                            collectionsArr = RandomCollectionGenerator();
                            break;
                        case "display":
                            foreach (var v in collectionsArr)
                            {
                                DisplayCollectionContents(v);
                            }
                            break;
                        case "count":
                            try
                            {
                                if (inputLine.Length >= 2)
                                {
                                    int length = GetArgument(inputLine[1]);
                                    var count = from elements in collectionsArr
                                        where elements.Count == length
                                        select elements;
                                    Console.WriteLine(count.Count());
                                }
                            }
                            catch (WrongArgumentException e)
                            {
                                Console.WriteLine("Try again");
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine("Not a number: " + inputLine[1]);
                            }
                            break;
                        case "find":
                            if (inputLine.Length >= 3)
                            {
                                CollectionType<GeometricShape> result = null;
                                if (inputLine[1] == "max")
                                {
                                    if (inputLine[2] == "area" || inputLine[2] == "perim")
                                    {
                                        result = FindMaxCollectionByField(collectionsArr, inputLine[2]);
                                        Console.WriteLine("The collection with {0}. {1} values: ", inputLine[1], inputLine[2]);
                                        DisplayCollectionContents(result);
                                    }
                                }

                                else if (inputLine[1] == "min")
                                {
                                    if (inputLine[2] == "area" || inputLine[2] == "a" || inputLine[2] == "perim" || inputLine[2] == "p")
                                    {
                                        result = FindMinCollectionByField(collectionsArr, inputLine[2]);
                                        Console.WriteLine("The collection with {0}. {1} values: ", inputLine[1], inputLine[2]);
                                        DisplayCollectionContents(result);
                                    }
                                }
                            }
                            break;
                        case "exit":
                            exit = true;
                            break;
                        case "help":
                            DisplayHelpMenu();
                            break;
                    }
                }
            }

            #region Collections Generator
            
            #endregion


        }

        private static void DisplayHelpMenu()
        {
            Console.WriteLine("General commands:\ngen\t\tGenerates a random array of collections with random Geometric Shape generics, each with a random value of elements\n" +
                              "display\t\tDisplays values of the collection of elements\ncount + x\t\tDisplay the number of elements of a collection contains 'x' elements in them\n" +
                              "find max field\t\tfinds the collection with a maximum aggregate value of elements based on a specified field ('perimeter' or 'area')\n" +
                              "find min field\t\tfinds the collection with a minimum aggregate value of elements based on a specified field ('perimeter' or 'area')\n"
                              + "save\t\tsaves current collection of elements to a save file\n"
                              + "load\t\tloads an existing collection of elements from a saved file"
                              + "sort asc area (or perim)\t\tSorts the whole collection of elements in ascending order from the lowest field (area or perim"
                              + "sort desc area (or perim)\t\tSorts the whole collection of elements in descending order from the lowest field (area or perim"
                              + "exit\t\texits the application.\n\n");
        }

        #region CollectionSortAndFindMinMax
        private static CollectionType<GeometricShape>[] SortCollectionByFieldDescending(CollectionType<GeometricShape>[] collectionsArr, string fieldName)
        {
            CollectionType<GeometricShape>[] result = fieldName == "area" ? collectionsArr.OrderByDescending(c => c.Sum(s => s.Area)).ToArray()
                : collectionsArr.OrderByDescending(c => c.Sum(s => s.Perimeter)).ToArray();
            return result;
        }

        private static CollectionType<GeometricShape>[] SortCollectionByFieldAscending(
            CollectionType<GeometricShape>[] collectionsArr, string fieldName)
        {
            CollectionType<GeometricShape>[] result = fieldName == "area" ? collectionsArr.OrderBy(c => c.Sum(s => s.Area)).ToArray()
                : collectionsArr.OrderBy(c => c.Sum(s => s.Perimeter)).ToArray();
            return result;
        }
        
        static CollectionType<GeometricShape> FindMaxCollectionByField(CollectionType<GeometricShape>[] collectionTypeArr, string fieldName)
        {
            CollectionType<GeometricShape> maxFieldValueCollection = fieldName == "area" ? collectionTypeArr.OrderByDescending(collection => collection.Max(shape => shape.Area)).ToArray().First() : collectionTypeArr.OrderByDescending(collection => collection.Max(shape => shape.Perimeter)).ToArray().First();

            return maxFieldValueCollection;
        }

        static CollectionType<GeometricShape> FindMinCollectionByField(CollectionType<GeometricShape>[] collectionTypeArr, string fieldName)
        {
            CollectionType<GeometricShape> maxFieldValueCollection = fieldName == "area" ? collectionTypeArr.OrderByDescending(collection => collection.Max(shape => shape.Area)).ToArray().Last() : collectionTypeArr.OrderByDescending(collection => collection.Max(shape => shape.Perimeter)).ToArray().Last();

            return maxFieldValueCollection;
        }
        #endregion

        #region CollectionGenerator
        /// <summary>
        /// Generates a CollectionType collection with random (from 2 to 5) number of elements, filled with random types (circle, rectangular, triangle)
        /// with random length of sides (from 1 to 10)
        /// </summary>
        /// <returns></returns>
        static CollectionType<GeometricShape>[] RandomCollectionGenerator()
        {
            CollectionType<GeometricShape>[] collections = new CollectionType<GeometricShape>[5];

            for (int counter = 0; counter < collections.Length; counter++)
            {
                Random rnd = new Random();
                CollectionType<GeometricShape> collection = new CollectionType<GeometricShape>();
                int i = rnd.Next(2, 5);                                                     // Generate No. of elements for the collection
                for (int k = 0; k < i; k++)
                {
                    int j = rnd.Next(1, 3);                                                 // Generate 1 to 3 int values. 1 - circle, 2 - rect, 3 - triangle
                    double sideA;
                    double sideB;

                    switch (j)
                    {
                        case 1:
                            collection.Add(new Circle("circle", new double[] { rnd.Next(1, 10) }));
                            break;
                        case 2:
                            sideA = rnd.Next(1, 5);
                            sideB = rnd.Next(1, 5);
                            collection.Add(new Rectangular("rectangular", new [] { sideA, sideB, sideA, sideB }));
                            break;
                        case 3:
                            sideA = rnd.Next(1, 5);
                            sideB = rnd.Next(1, 5);
                            double sideC = rnd.Next(1, 5);                                  //Additional arguments for a triangle: 3rd side and height
                            double height = rnd.Next(1, 5);
                            double[] dimensions = new double[4];
                            dimensions[0] = sideA;
                            dimensions[1] = sideB;
                            dimensions[2] = sideC;
                            dimensions[3] = height;

                            Array.Reverse(dimensions, 0, 3);                      //Reverse the sides and change the 1st (greatest) element with sideB
                            double temp = dimensions[0];                                    //so that b is always the longest side of a triangle for area calc.
                            dimensions[0] = dimensions[1];
                            dimensions[1] = temp;
                            collection.Add(new Triangle("triangle", dimensions));
                            break;
                    }
                }

                collections[counter] = collection;
            }


            return collections;
        } 
        #endregion

        static void DisplayCollectionContents(CollectionType<GeometricShape> collection)
        {
            Console.WriteLine("Collection");
            Console.WriteLine(collection.ToString());
            Console.WriteLine("\n");
        }

        static int GetArgument(string arg)
        {
            int n = int.Parse(arg);
            if (n <= 0 || n >= 6)
            {
                throw new WrongArgumentException(arg);
            }

            return n;
        }
    }

    class FileManager
    {
        private readonly string _filePath =
            @"C:\Users\Maxim\Desktop\Programming\EPAMTraining\Labs\CollectionType\save\collection.sav";
        
        

        internal void SaveCollection(CollectionType<GeometricShape>[] colllectionArr)
        {
            
            FileStream fileStream = new FileStream(_filePath, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fileStream, colllectionArr);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed saving file");
            }
            finally
            {
                fileStream.Close();
            }
        }

        internal CollectionType<GeometricShape>[] LoadCollection()
        {
            FileStream fileStream = new FileStream(_filePath, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            CollectionType<GeometricShape>[] collectionArr = null;
            try
            {
                collectionArr = (CollectionType<GeometricShape>[]) formatter.Deserialize(fileStream);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed loading file");
            }
            finally
            {
                fileStream.Close();
            }
            return collectionArr;
        }
    }
}
