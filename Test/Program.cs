using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Residence myHouse = new Residence(ResidenceType.House, 2);
            Residence anotherHouse = new Residence(ResidenceType.House, 2);
            if (myHouse == anotherHouse)
            {
                Console.WriteLine("They are the same house");
            }
            else
            {
                Console.WriteLine("They are different houses");
            }

        }
    }


    

    public enum ResidenceType
    {
        House, Flat, Bungalow, Apartment
    };

    public class Residence
    {
        public ResidenceType type;
        public int numberOfBedrooms;

        public Residence(ResidenceType type, int numberOfBedrooms)
        {
            this.type = type; this.numberOfBedrooms = numberOfBedrooms;
        }
    }

}
