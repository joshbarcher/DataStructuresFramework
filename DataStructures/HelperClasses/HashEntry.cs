using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.HelperClasses
{
    /// <summary>
    /// Represents an entry in a hash table.
    /// </summary>
    /// <typeparam name="T">the reference type of elements in the table.</typeparam>
    internal class HashEntry<T> where T : class
    {
        private T my_entry;
        private bool my_active;

        /// <summary>
        /// Sets up the hash entry with a value.
        /// </summary>
        /// <param name="the_entry"></param>
        public HashEntry(T the_entry)
        {
            entry = the_entry;
            active = true;
        }

        /// <summary>
        /// Returns a string representation of the hash entry.
        /// </summary>
        /// <returns>a string representation.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            //the entry value
            Helpers.printElementIfNull(builder, "Entry", entry);

            //active status
            builder.Append(", Active: ");
            builder.Append(active);

            return builder.ToString();
        }

        /// <summary>
        /// Access to the entry value.
        /// </summary>
        public T entry
        {
            get { return my_entry; }
            set { my_entry = value; }
        }

        /// <summary>
        /// Access to active status. Determines whether a lazy removal was made or not.
        /// </summary>
        public bool active
        {
            get { return my_active; }
            set { my_active = value; }
        }
    }
}
