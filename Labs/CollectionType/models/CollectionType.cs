using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CollectionsLab.models
{
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
            var element = _container.FirstOrDefault(s => s == shape);
            if (element != null)
            {
                _container.Remove(element);
                return element;
            }

            throw new NullReferenceException();
        }

        public override string ToString()
        {
            string str = "";
            foreach (var item in _container)
            {
                str += item.ToString();
            }

            return str;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public IEnumerator<T> GetEnumerator()
        {
            return _container.GetEnumerator();
        }

        ~CollectionType()
        {
            Console.WriteLine("Destructor has been called"  );
        }
    }
}
