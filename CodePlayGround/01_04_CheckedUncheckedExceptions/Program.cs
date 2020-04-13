using System;

namespace _01_04_CheckedUncheckedExceptions
{
    class Program
    {
        static void Main()
        {
            MyArr myObject1 = new MyArr(x: 4, z: 5, y: 12);
            MyArr myObject2 = new MyArr(x: 4, z: 5, y: 12);

            if (myObject1 == myObject2)
                Console.WriteLine("Объекты равны");

            if (myObject1)
                Console.WriteLine("Все координаты объекта myObject1 положительны");

            Console.ReadLine();
        }
    }

    class MyArr
    {
        // Координаты точки в трехмерном пространстве
        public int x, y, z;

        public MyArr(int x = 0, int y = 0, int z = 0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        // Перегружаем логический оператор ==
        public static bool operator ==(MyArr obj1, MyArr obj2)
        {
            if ((obj1.x == obj2.x) && (obj1.y == obj2.y) && (obj1.z == obj2.z))
                return true;
            return false;
        }

        // Теперь обязательно нужно перегрузить логический оператор !=
        public static bool operator !=(MyArr obj1, MyArr obj2)
        {
            if ((obj1.x != obj2.x) || (obj1.y != obj2.y) || (obj1.z != obj2.z))
                return false;
            return true;
        }

        // Перегружаем оператор false
        public static bool operator false(MyArr obj)
        {
            if ((obj.x <= 0) || (obj.y <= 0) || (obj.z <= 0))
                return true;
            return false;
        }

        // Обязательно перегружаем оператор true
        public static bool operator true(MyArr obj)
        {
            if ((obj.x > 0) && (obj.y > 0) && (obj.z > 0))
                return true;
            return false;
        }
    }
}
