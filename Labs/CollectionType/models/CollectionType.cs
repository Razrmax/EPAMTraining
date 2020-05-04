using System;
using System.Collections.Generic;

namespace CollectionType.models
{
    class CollectionType<T>
    {
        private List<T> objects;

        public CollectionType(T obj)
        {
            objects.Add(obj);
        }

        public void ObjectType()
        {
            Console.WriteLine("Object type: " + typeof(T));
        }

        public void Add(T obj)
        {
            if (objects.GetType().Equals(obj))
            {
                objects.Add(obj);
            }
        }

        public void Remove(T obj)
        {
            if (objects.Contains(obj))
            {
                objects.Remove(obj);
            }
        }

        public override string ToString()
        {
            string str = "";
            foreach (var item in objects)
            {
                str += item.ToString();
            }

            return str;
        }


        ~CollectionType()
        {
            Console.WriteLine("Destructor has been called"  );
        }
    }
}
