using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Template.Shared.Extensions.Collection
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<TSource> WhereIf<TSource>(this IEnumerable<TSource> source, bool condition, Func<TSource, bool> predicate)
        {
            if (!condition)
                return source;
            else
                return source
                    .Where(predicate);
        }
    }
}
