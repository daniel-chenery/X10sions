using System;

namespace X10sions
{
    public static class FuncExtensions
    {
        /// <summary>
        /// Inverts the current function
        /// </summary>
        /// <param name="func">The function to invert</param>
        /// <returns>A new function, which is the negated version of the current function</returns>
        /// <include file="FunctionExtensions.xml" path="common"/>
        public static Func<bool> Invert(this Func<bool> func)
        {
            if (func is null)
            {
                throw new ArgumentNullException(nameof(func));
            }

            return () => !func();
        }
    }
}