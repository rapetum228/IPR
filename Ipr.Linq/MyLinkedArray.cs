using System;
using System.Collections;
using System.Drawing;

namespace Ipr.Linq
{
    public unsafe class MyLinkedArray<T> : IEnumerable<T>, ICollection<T>
    {
        private T[] _arrayItems;

        private int _length;

        public MyLinkedList<T>? LinkedListItems;

        int ICollection<T>.Count => Count();

        public bool IsReadOnly => throw new NotImplementedException();

        public MyLinkedArray(int length)
        {
            _arrayItems = new T[length];
            _length = 0;
            LinkedListItems = null;
        }

        public MyLinkedArray(MyLinkedArray<T> values)
        {
            _arrayItems = values._arrayItems;
            _length = values._length;
            LinkedListItems = values.LinkedListItems;
        }

        public int Count()
        {
            if (LinkedListItems == null)
                return _arrayItems.Length;

            return _arrayItems.Length + LinkedListItems.Count;
        }

        public IEnumerator<T> GetEnumerator() => new MyEnumerator<T>(this);

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new MyEnumerator<T>(this);
        }

        public void Add(T item)
        {
            if (_arrayItems.Length <= _length)
            {
                if (LinkedListItems == null)
                    LinkedListItems = new MyLinkedList<T>(item);
                else
                    LinkedListItems.Add(item);
            }
            else
            {
                _arrayItems[_length] = item;
            }
            _length++;
        }

        public void Clear()
        {
            for (int i = 0; i < _arrayItems.Length && i <= _length; i++)
            {
                _arrayItems[i] = default;
            }
            if (LinkedListItems != null)
                LinkedListItems.Clear();
        }

        public bool Contains(T item)
        {
            var contains = _arrayItems.Contains(item);
            if (contains)
                return true;

            if (LinkedListItems != null)
                return LinkedListItems.Contains(item);

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException("Мне влом ((");
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index > Count())
                    throw new IndexOutOfRangeException();

                if (index < _arrayItems.Length)
                    return _arrayItems[index];

                if (LinkedListItems == null)
                    throw new Exception("Что-то пошло не так");

                return LinkedListItems[index - _arrayItems.Length - 1];
            }
            set
            {
                if (index < 0 || index >= Count())
                    throw new IndexOutOfRangeException();


                if (index < _arrayItems.Length)
                {
                    _arrayItems[index] = value;
                    return;
                }

                if (LinkedListItems == null)
                    throw new Exception("Что-то пошло не так");

                LinkedListItems[index - _arrayItems.Length] = value;
            }
        }
    }
}