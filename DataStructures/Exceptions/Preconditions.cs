using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Exceptions
{
    /// <summary>
    /// Provides helper methods to confirm initial state when entering a method.
    /// </summary>
    public class Preconditions
    {
        /// <summary>
        /// Checks for a null argument to a method.
        /// </summary>
        /// <param name="the_argument">the argument given to a method.</param>
        public static void checkNull(object the_argument)
        {
            if (the_argument == null)
            {
                throw new ArgumentException("Null argument given to method.");
            }
        }

        /// <summary>
        /// Checks to make sure an argument is non-negative.
        /// </summary>
        /// <param name="the_argument">the argument given to a method.</param>
        public static void checkNonNegative(int the_argument)
        {
            if (the_argument < 0)
            {
                throw new ArgumentException("Negative argument given to method.");
            }
        }
    }
}
