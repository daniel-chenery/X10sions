using System;
using System.Collections.Generic;
using System.Linq;

namespace Extensions
{
    public static class EnumerableExtensions
    {
        public static bool AnyAndNotNull<T>(this IEnumerable<T> enumerable)
            => enumerable?.Any() == true;

        public static bool Empty<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable is null)
            {
                throw new ArgumentNullException(nameof(enumerable));
            }

            return !enumerable.Any();
        }
    }
}