using System;
using System.Collections.Generic;

namespace X10sions
{
    public static partial class EnumerableExtensions
    {
        public static IEnumerable<ValueTuple<T1, T2>> Fuse<T1, T2>(this IEnumerable<T1> first, IEnumerable<T2> second)
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

        public static IEnumerable<ValueTuple<T1, T2, T3>> Fuse<T1, T2, T3>(this IEnumerable<T1> first, IEnumerable<T2> second, IEnumerable<T3> third)
        {
            if (first is null)
            {
                throw new ArgumentNullException(nameof(first));
            }

            if (second is null)
            {
                throw new ArgumentNullException(nameof(second));
            }

            if (third is null)
            {
                throw new ArgumentNullException(nameof(third));
            }

            var firstEnumerator = first.GetEnumerator();
            var secondEnumerator = second.GetEnumerator();
            var thirdEnumerator = third.GetEnumerator();

            while (true)
            {
                var firstHasValue = firstEnumerator.MoveNext();
                var secondHasValue = secondEnumerator.MoveNext();
                var thirdHasValue = thirdEnumerator.MoveNext();

                if (!firstHasValue && !secondHasValue && !thirdHasValue)
                {
                    break;
                }

                if (!thirdHasValue && firstHasValue && secondHasValue)
                {
                    throw new ArgumentOutOfRangeException(nameof(third));
                }

                if (!secondHasValue && firstHasValue && thirdHasValue)
                {
                    throw new ArgumentOutOfRangeException(nameof(second));
                }

                if (!firstHasValue && secondHasValue && thirdHasValue)
                {
                    throw new ArgumentOutOfRangeException(nameof(first));
                }

                yield return (firstEnumerator.Current, secondEnumerator.Current, thirdEnumerator.Current);
            }
        }
    }
}
