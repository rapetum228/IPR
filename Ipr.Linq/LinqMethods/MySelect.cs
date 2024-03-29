using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ipr.Linq.LinqMethods
{
    public class MySelectEnumerator<TIn, TOut> : IEnumerator<TOut>
    {
        private readonly IEnumerator<TIn> _enumerator;

        private readonly Func<TIn, TOut> _selector;

        public MySelectEnumerator(IEnumerable<TIn> enumerable, Func<TIn, TOut> selector)
        {
            _enumerator = enumerable.GetEnumerator();
            _selector = selector;
        }

        public TOut Current => _selector(_enumerator.Current);

        object IEnumerator.Current => Current!;

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            return _enumerator.MoveNext();
        }

        public void Reset()
        {
            _enumerator.Reset();
        }
    }

    public class MySelectEnumerable<TIn, TOut> : IEnumerable<TOut>
    {
        private readonly IEnumerable<TIn> _enumerable;

        private readonly Func<TIn, TOut> _selector;

        public MySelectEnumerable(IEnumerable<TIn> enumerable, Func<TIn, TOut> selector)
        {
            _enumerable = enumerable;
            _selector = selector;
        }

        public IEnumerator<TOut> GetEnumerator()
        {
            return new MySelectEnumerator<TIn, TOut>(_enumerable, _selector);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
