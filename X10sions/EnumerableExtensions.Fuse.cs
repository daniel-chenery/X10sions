using System;
using System.Collections.Generic;

namespace X10sions
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Fuses the two sequences together.
        /// </summary>
        /// <typeparam name="T1">The type of elements in the first sequence.</typeparam>
        /// <typeparam name="T2">The type of elements in the second sequence.</typeparam>
        /// <param name="first">The first sequence to return in the tuple.</param>
        /// <param name="second">The second sequence to return in the tuple.</param>
        /// <returns>A <see cref="ValueTuple{T1, T2}"/> that contains both sequences.</returns>
        /// <exception cref="ArgumentNullException">first or second is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">first or second are different lengths</exception>
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

        /// <summary>
        /// Fuses the three sequences together.
        /// </summary>
        /// <typeparam name="T1">The type of elements in the first sequence.</typeparam>
        /// <typeparam name="T2">The type of elements in the second sequence.</typeparam>
        /// <typeparam name="T3">The type of elements in the third sequence.</typeparam>
        /// <param name="first">The first sequence to return in the tuple.</param>
        /// <param name="second">The second sequence to return in the tuple.</param>
        /// <param name="third">The third sequence to return in the tuple.</param>
        /// <returns>A <see cref="ValueTuple{T1, T2, T3}"/> that contains both sequences.</returns>
        /// <exception cref="ArgumentNullException">first, second or third is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">first, second or third are different lengths</exception>
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
