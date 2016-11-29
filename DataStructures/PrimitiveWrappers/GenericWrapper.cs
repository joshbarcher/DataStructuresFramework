using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.PrimitiveWrappers
{
    /// <summary>
    /// Provides the basis for other primitive wrappers. This class
    /// simply stores a value of any type.
    /// </summary>
    /// <typeparam name="T">the type of element stored in the class.</typeparam>
    public abstract class GenericWrapper<T>
    {
        private T my_value;

        /// <summary>
        /// Sets up the wrapper with a value.
        /// </summary>
        /// <param name="the_value">the value.</param>
        public GenericWrapper(T the_value)
        {
            value = the_value;
        }

        /// <summary>
        /// Access to the value.
        /// </summary>
        public T value
        {
            get { return my_value; }
            set { my_value = value; }
        }
    }
}
