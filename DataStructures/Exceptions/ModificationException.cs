using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Exceptions
{
    /// <summary>
    /// Represents an exception thrown when an iterator advances
    /// over a collection that was changed during the iteration.
    /// </summary>
    public class ModificationException : Exception
    {
        /// <summary>
        /// Constructor sets up the exception with a message to display for the user.
        /// </summary>
        /// <param name="the_message">the exception message.</param>
        public ModificationException(string the_message)
            : base(the_message)
        {
            //do nothing
        }
    }
}
