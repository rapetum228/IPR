using System.Collections;

namespace Ipr.Linq.LinqMethods
{
    public record class PersonAndCompany(string Name, string Company, int age);

    public class Pupil 
    { 
        public int Id { get; set; }
        public string Name { get; set; }
    
    }

    public class MyGroupEnumerable<TSource, TKey> : IEnumerable<IGrouping<TKey, TSource>>
    {
        private readonly IEnumerable<TSource> _source;
        private readonly Func<TSource, TKey> _keySelector;

        public MyGroupEnumerable(IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            _source = source;
            _keySelector = keySelector;
        }

        public IEnumerator<IGrouping<TKey, TSource>> GetEnumerator()
        {
            return MyLookup<TKey, TSource>.Create(_source, _keySelector).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    internal class MyLookup<TKey, TElement> : ILookup<TKey, TElement>
    {
        private readonly IEqualityComparer<TKey> _comparer;
        private MyLinkedArray<MyGrouping<TKey, TElement>> _groupings;
        private MyGrouping<TKey, TElement>? _lastGrouping;
        private int _count;

        public MyLookup()
        {
            _comparer = EqualityComparer<TKey>.Default;
            _groupings = new MyLinkedArray<MyGrouping<TKey, TElement>>(7);
        }

        public IEnumerable<TElement> this[TKey key] => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public bool Contains(TKey key) => false;

        public static MyLookup<TKey, TElement> Create(IEnumerable<TElement> source, Func<TElement, TKey> keySelector)
        {
            MyLookup<TKey, TElement> lookup = new MyLookup<TKey, TElement>();
            foreach (TElement item in source)
            {
                lookup.GetGrouping(keySelector(item))!.Add(item);
            }

            return lookup;
        }

        private int InternalGetHashCode(TKey? key)
        {
            //возвращает хэш-код 
            return (key == null) ? 0 : _comparer.GetHashCode(key) & 0x7FFFFFFF;
        }

        private MyGrouping<TKey, TElement> GetGrouping(TKey? key)
        {
            int hashCode = InternalGetHashCode(key);

            for (MyGrouping<TKey, TElement>? group = _groupings[hashCode % _groupings.Count()]; group != null; group = group._hashNext)
            {
                if (group._hashCode == hashCode && _comparer.Equals(group._key, key))
                {
                    return group;
                }
            }

            int index = hashCode % _groupings.Count();
            MyGrouping<TKey, TElement> newGroup = new MyGrouping<TKey, TElement>(key, hashCode);
            newGroup._hashNext = _groupings[index];
            _groupings[index] = newGroup;
            if (_lastGrouping == null)
            {
                newGroup._next = newGroup;
            }
            else
            {
                newGroup._next = _lastGrouping._next;
                _lastGrouping._next = newGroup;
            }

            _lastGrouping = newGroup;
            _count++;
            return newGroup;
        }

        /*
        private void Resize()
        {
            int newSize = checked((_count * 2) + 1);
            MyLinkedArray<MyGrouping<TKey, TElement>> newGroupings = new MyLinkedArray<MyGrouping<TKey, TElement>>(newSize);
            MyGrouping<TKey, TElement> g = _lastGrouping!;
            do
            {
                g = g._next!;
                int index = g._hashCode % newSize;
                g._hashNext = newGroupings[index];
                newGroupings[index] = g;
            }
            while (g != _lastGrouping);

            _groupings = newGroupings;
        }
        */

        public IEnumerator<IGrouping<TKey, TElement>> GetEnumerator()
        {
            MyGrouping<TKey, TElement>? g = _lastGrouping;
            if (g != null)
            {
                do
                {
                    g = g._next;

                    yield return g;
                }
                while (g != _lastGrouping);
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class MyGrouping<TKey, TElement> : IGrouping<TKey, TElement>
    {
        internal readonly TKey _key;
        internal readonly int _hashCode;
        internal MyLinkedArray<TElement> _elements;
        internal int _count;
        internal MyGrouping<TKey, TElement>? _hashNext;
        internal MyGrouping<TKey, TElement>? _next;

        internal MyGrouping(TKey key, int hashCode)
        {
            _key = key;
            _hashCode = hashCode;
            _elements = new MyLinkedArray<TElement>(1);
        }

        internal void Add(TElement element)
        {
            _elements.Add(element);
            _count++;
        }


        public IEnumerator<TElement> GetEnumerator()
        {
            for (int i = 0; i < _count; i++)
            {
                yield return _elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public TKey Key => _key;

        /*
        //internal void Trim()
        //{
        //    //if (_elements.Length != _count)
        //    //{
        //    //    Array.Resize(ref _elements, _count);
        //    //}
        //}
        
        //int ICollection<TElement>.Count => _count;

        //bool ICollection<TElement>.IsReadOnly => true;

        //void ICollection<TElement>.Add(TElement item) => throw new NotSupportedException();

        //void ICollection<TElement>.Clear() => throw new NotSupportedException();

        //bool ICollection<TElement>.Contains(TElement item) => throw new NotImplementedException();

        //void ICollection<TElement>.CopyTo(TElement[] array, int arrayIndex) =>
        //    throw new NotSupportedException();

        //bool ICollection<TElement>.Remove(TElement item) => false;

        //int IList<TElement>.IndexOf(TElement item) => throw new NotImplementedException();

        //void IList<TElement>.Insert(int index, TElement item) => throw new NotSupportedException();

        //void IList<TElement>.RemoveAt(int index) => throw new NotSupportedException();

        //TElement IList<TElement>.this[int index]
        //{
        //    get
        //    {
        //        if (index < 0 || index >= _count)
        //        {
        //            throw new ArgumentOutOfRangeException("index");
        //        }

        //        return _elements[index];
        //    }

        //    set { }
        //}
        */
    }
}
