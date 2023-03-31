using System;
using System.Collections.Generic;
using System.Linq;

namespace X10sions
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Determines if an enumerable is not null and contains any elements
        /// </summary>
        /// <returns>True if not null or contains elements, false when null or an empty enumerable</returns>
        /// <include file='EnumerableExtensions.xml' path='common'/>
        public static bool AnyAndNotNull<T>(this IEnumerable<T> enumerable)
            => enumerable?.Any() == true;

        /// <summary>
        /// Determines if an enumerable is empty or not
        /// </summary>
        /// <returns>True if no items are in the enumerable, otherwise false</returns>
        /// <exception cref="ArgumentNullException">Thrown when the enumerable passed in is null</exception>
        /// <seealso cref="EmptyOrNull{T}(IEnumerable{T})" />
        /// <include file='EnumerableExtensions.xml' path='common'/>

        public static bool Empty<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable is null)
            {
                throw new ArgumentNullException(nameof(enumerable));
            }

            return !enumerable.Any();
        }

        /// <summary>
        /// Determines if an enuerable is empty or null
        /// </summary>
        /// <returns>True when null or empty, otherwise false</returns>
        /// <seealso cref="Empty{T}(IEnumerable{T})"/>
        /// <include file='EnumerableExtensions.xml' path='common'/>
        public static bool EmptyOrNull<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable is null)
            {
                return true;
            }

            return !enumerable.Any();
        }
    }
}