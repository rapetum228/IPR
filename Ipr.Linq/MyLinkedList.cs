using System.Collections;

namespace Ipr.Linq
{
    public class Node<T>
    {
        public T? Value { get; set; }
        public Node<T>? Next { get; set; }
    }

    public class MyLinkedList<T> : ICollection<T>, IList<T>
    {
        public Node<T> Head { get; private set; }

        public Node<T> Tail { get; private set; }

        private int _count;

        public int Count => _count;

        public bool IsReadOnly => false;

        public T this[int index]
        {
            get
            {
                var temp = Head;

                for (var i = 0; i <= index && temp.Next != null; i++)
                {
                    temp = temp.Next!;
                }

                return temp.Value!;
            }
            set
            {
                var temp = Head;

                for (var i = 0; i < index; i++)
                {
                    temp = temp.Next!;
                }

                temp.Value = value;
            }
        }

        public MyLinkedList(T value)
        {
            Head = new Node<T>
            {
                Value = value,
            };
            Tail = Head;
            Tail.Next = null;
            _count = 1;
        }

        public void Add(T value)
        {
            var item = new Node<T>
            {
                Value = value,
                Next = null
            };

            Tail.Next = item;
            Tail = Tail.Next;
            _count++;
        }

        public void Clear()
        {
            Head.Value = default;
            Tail.Next = null;
            Tail = Head;
            _count = 0;
        }

        public bool Contains(T item)
        {
            var temp = Head;
            while (temp.Next != null)
            {
                if (temp.Value!.Equals(item))
                    return true;

                temp = temp.Next;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            var temp = Head;
            while (temp.Next != null)
            {
                if (temp.Next.Value!.Equals(item))
                {
                    if (temp.Next.Next != null)
                    {
                        temp.Next = temp.Next.Next;
                    }
                    else
                    {
                        temp.Next = null;
                        Tail = temp;
                    }
                    _count--;
                    return true;
                }
                temp = temp.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var temp = Head;
            while (temp.Next != null)
            {
                yield return temp.Value!;
                temp = temp.Next;
            }
            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public int IndexOf(T item)
        {
            var index = 0;
            var temp = Head;

            while (temp.Next != null)
            {
                if (temp.Value!.Equals(item))
                    return index;

                temp = temp.Next;
                index++;
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 )
                throw new ArgumentOutOfRangeException("index");
            var newItem = new Node<T>
            {
                Value = item
            };
            if (index == 0)
            {
                newItem.Next = Head;
                Head = newItem;
                _count++;
                return;
            }
            else if(index >= _count-1)
            {
                newItem.Next = null;
                Tail.Next = newItem;
                Tail = newItem;
                _count++;
                return;
            }
            var temp = Head;
            
            for(var i = 0; i < index-1; i++)
            {
                temp = temp.Next!;
            }

            newItem.Next = temp.Next;
            temp.Next = newItem;
            _count++;

        }

        public void RemoveAt(int index)
        {
            if (index < 0 || _count == 0)
                throw new ArgumentOutOfRangeException("index");
            
            var temp = Head;
            
            if (index == 0 || temp.Next == null)
            {
                Head = Head.Next!;
                return;
            }

            if(temp.Next == null)
            {
                Clear();
                return;
            }

            for (var i = 1; i < index && temp.Next.Next != null; i++)
            {
                temp = temp.Next!;

            }

            temp.Next = temp.Next.Next;
            if (temp.Next == null)
                Tail = temp;
            _count--;
        }
    }
}