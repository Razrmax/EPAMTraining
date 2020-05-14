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
    class CollectionType<T> : IEnumerable<T> where T : GeometricShape
    {
        #region Fields
        private readonly List<T> _container;
        #endregion

        #region Constructors
        public CollectionType()
        {
            _container = new List<T>();
        }
        #endregion

        #region Properties

        public int Count
        {
            get { return _container.Count; }
        }
        #endregion

        #region Indexers

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException();
                return _container[index];
            }

            set
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException();
                _container[index] = value;
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
            _container.Add(shape);
        }

        public T Remove(T shape)
        {
            var element = _container.FirstOrDefault(s => s.Equals(shape));
            if (element != null)
            {
                _container.Remove(element);
                return element;
            }

            throw new NullReferenceException();
        }

        public override string ToString()
        {
            Console.WriteLine("Total elements: {0}\nElements:", Count);
            Console.WriteLine("Total perimeter of all elements of collection: " + _container.Sum(shape => shape.Perimeter));
            Console.WriteLine("Total area of all elements of collection: " + _container.Sum(shape => shape.Area));
            string str = string.Join("\n", _container.Select(shape => shape.ToString()));
            
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
            return _container.GetEnumerator();
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
