namespace X10sions
{
    public static class BooleanExtensions
    {
        /// <summary>
        /// Inverts the current boolean.
        /// </summary>
        /// <param name="value">The boolean to invert</param>
        /// <returns>False when true. True when false</returns>
        public static bool Invert(this bool value) => !value;
    }
}