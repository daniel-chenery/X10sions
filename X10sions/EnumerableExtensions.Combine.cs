using System;
using System.Collections.Generic;

namespace X10sions
{
    public static partial class EnumerableExtensions
    {
        public static IEnumerable<ValueTuple<T1, T2>> Combine<T1, T2>(this IEnumerable<T1> first, IEnumerable<T2> second)
        {
            if (first is null)
            {
                throw new ArgumentNullException(nameof(first));
            }

            if (second is null)
            {
                throw new ArgumentNullException(nameof(second));
            }

            var firstEnumerator = first.GetEnumerator();
            var secondEnumerator = second.GetEnumerator();

            while (true)
            {
                var firstHasValue = firstEnumerator.MoveNext();
                var secondHasValue = secondEnumerator.MoveNext();

                if (!firstHasValue && !secondHasValue)
                {
                    break;
                }

                if (firstHasValue && !secondHasValue)
                {
                    throw new ArgumentOutOfRangeException(nameof(second));
                }

                if (!firstHasValue && secondHasValue)
                {
                    throw new ArgumentOutOfRangeException(nameof(first));
                }

                yield return (firstEnumerator.Current, secondEnumerator.Current);
            }
        }
    }
}
