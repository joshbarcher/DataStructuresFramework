using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Exceptions
{
    /// <summary>
    /// Represents an exception thrown when the current system reachs
    /// an illegal state due to user input or programmer error.
    /// </summary>
    public class IllegalStateException : Exception
    {
        /// <summary>
        /// Constructor sets up the exception with a message to display for the user.
        /// </summary>
        /// <param name="the_message">the exception message.</param>
        public IllegalStateException(string the_message)
            : base(the_message)
        {
            //do nothing
        }
    }
}
