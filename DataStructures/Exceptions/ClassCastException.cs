using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Exceptions
{
    /// <summary>
    /// Represents an exception thrown when a cast is performed
    /// on an illegal object.
    /// </summary>
    public class ClassCastException : Exception
    {
        /// <summary>
        /// Constructor sets up the exception with a message to display for the user.
        /// </summary>
        /// <param name="the_message">the exception message.</param>
        public ClassCastException(string the_message)
            : base(the_message)
        {
            //do nothing
        }
    }
}
