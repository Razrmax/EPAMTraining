using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CollectionsLab.models
{
    /// <summary>
    /// CollectionType class with T GeometricShape elements
    /// </summary>
    /// <typeparam name="T">GeometricShape</typeparam>
    [Serializable]
    public class CollectionType<T> : ICollection, IEnumerable<T> where T : GeometricShape
    {
        #region Fields
        public readonly List<T> Container;
        #endregion

        #region Constructors
        public CollectionType()
        {
            Container = new List<T>();
        }
        #endregion

        #region Properties

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return Container.Count; }
        }

        public bool IsSynchronized
        {
            get { return false; }
        }
        
        public object SyncRoot
        {
            get { return this; }
        }

        #endregion

        #region Indexers

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException();
                return Container[index];
            }

            set
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException();
                Container[index] = value;
            }
        }


        #endregion

        #region Methods
        public void ObjectType()
        {
            Console.WriteLine("Object type: " + typeof(T));
        }

        public void Add(T shape)
        {
            Container.Add(shape);
        }

        public T Remove(T shape)
        {
            var element = Container.FirstOrDefault(s => s.Equals(shape));
            if (element != null)
            {
                Container.Remove(element);
                return element;
            }

            throw new NullReferenceException();
        }

        public override string ToString()
        {
            Console.WriteLine("Total elements: {0}\nElements:", Count);
            Console.WriteLine("Total perimeter of all elements of collection: " + Container.Sum(shape => shape.Perimeter));
            Console.WriteLine("Total area of all elements of collection: " + Container.Sum(shape => shape.Area));
            string str = string.Join("\n", Container.Select(shape => shape.ToString()));
            
            return str;
        }
        #endregion

        #region Enumerators
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Container.GetEnumerator();
        } 
        #endregion

        #region Deconstructor
        ~CollectionType()
        {
            Console.WriteLine("Destructor has been called");
        }
        #endregion
    }
}
