using System.Collections;

namespace Ipr.Linq.LinqMethods
{
    internal class MyWhereEnumerator<TIn> : IEnumerator<TIn>
    {
        private readonly IEnumerator<TIn> _enumerator;

        private readonly Func<TIn, bool> _selector;

        public MyWhereEnumerator(IEnumerable<TIn> enumerable, Func<TIn, bool> selector)
        {
            _enumerator = enumerable.GetEnumerator();
            _selector = selector;
        }

        public TIn Current => _enumerator.Current;

        object IEnumerator.Current => Current!;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            while (_enumerator.MoveNext())
            {
                if(_selector(_enumerator.Current))
                    return true;
            }

            return false;
        }

        public void Reset()
        {
            _enumerator.Reset();
        }
    }

    public class MyWhereEnumerable<TIn> : IEnumerable<TIn>
    {
        private readonly IEnumerable<TIn> _enumerable;

        private readonly Func<TIn, bool> _selector;

        public MyWhereEnumerable(IEnumerable<TIn> enumerable, Func<TIn, bool> selector)
        {
            _enumerable = enumerable;
            _selector = selector;
        }

        public IEnumerator<TIn> GetEnumerator()
        {
            return new MyWhereEnumerator<TIn>(_enumerable, _selector);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
