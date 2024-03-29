using Ipr.Linq.LinqMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ipr.Linq
{
    public static class MyLinqExtensions
    {
        public static IEnumerable<TOut> MySelect<TIn, TOut>(this IEnumerable<TIn> enumerable, Func<TIn, TOut> selector)
        {
            return new MySelectEnumerable<TIn, TOut>(enumerable, selector);
        }

        public static IEnumerable<TIn> MyWhere<TIn>(this IEnumerable<TIn> enumerable, Func<TIn, bool> selector)
        {
            return new MyWhereEnumerable<TIn>(enumerable, selector);
        }

        public static IEnumerable<IGrouping<TKey, TSource>> MyGroupBy<TSource, TKey>(this IEnumerable<TSource> enumerable, Func<TSource, TKey> selector)
        {
            return new MyGroupEnumerable<TSource, TKey>(enumerable, selector);
        }
    }
}
