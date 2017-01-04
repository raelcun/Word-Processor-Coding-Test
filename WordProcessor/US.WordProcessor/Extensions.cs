using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;

namespace US.WordProcessor
{
    public static class Extensions
    {
        /// <summary>
        /// Flatten array of elements one level
        /// </summary>
        /// <example>
        /// [[1,2],[2]] -> [1,2,2]
        /// </example>
        public static IEnumerable<TElement> Flatten<TElement>(this IEnumerable<IEnumerable<TElement>> sequences) =>
            sequences.SelectMany(sequence => sequence);
    }
}
