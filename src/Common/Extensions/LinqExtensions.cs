using System;
using System.Collections.Generic;

namespace PropertyCore.Common.Extensions
{
    /// <summary>
    /// Class that contains LINQ extension methods
    /// </summary>
    public static class LinqExtensions
    {
        /// <summary>
        /// Creates a LINQ DistinctBy method.
        /// </summary>
        /// <typeparam name="TSource">The source object</typeparam>
        /// <typeparam name="TKey">The key selector</typeparam>
        /// <param name="source">The source <see cref="IEnumerable{TSource}"/></param>
        /// <param name="keySelector">A lambda function containing the sorting expression./></param>
        /// <returns></returns>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
    }
}
