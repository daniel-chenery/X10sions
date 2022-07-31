﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace X10sions
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