using System;
using CollectionsLab.models;
using CollectionsLab.models.shapes;

namespace CollectionsLab
{
    class Program
    {
        static void Main()
        {
            CollectionType<GeometricShape> geometricShapesCollection = new CollectionType<GeometricShape>
            {
                new Triangle("triangle", new Double[] { 2, 2, 2, 3 }),
                new Triangle("triangle", new Double[] { 3, 3, 3, 3 }),
                new Triangle("triangle", new Double[] { 4, 2, 1, 3 })
            };
            Console.WriteLine(geometricShapesCollection.ToString());
        }
    }
}
