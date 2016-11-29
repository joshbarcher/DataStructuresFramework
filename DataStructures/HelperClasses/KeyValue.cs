using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.HelperClasses
{
    /// <summary>
    /// Represents a key/value pair in a map.
    /// </summary>
    /// <typeparam name="K">the reference type of the key.</typeparam>
    /// <typeparam name="V">the reference type of the value.</typeparam>
    internal class KeyValue<K, V>
        where K : class
        where V : class
    {
        private K my_key;
        private V my_value;

        /// <summary>
        /// Sets up the pair with a key and value.
        /// </summary>
        /// <param name="the_key">the key.</param>
        /// <param name="the_value">the value.</param>
        public KeyValue(K the_key, V the_value)
        {
            my_key = the_key;
            my_value = the_value;
        }

        /// <summary>
        /// Compares this key/value pair with another object for equality.
        /// </summary>
        /// <param name="the_other">the object to compare this key/value pair with.</param>
        /// <returns>true if the objects are logically equal, otherwise false.</returns>
        public override bool Equals(object the_other)
        {
            if (the_other == null || !(the_other is KeyValue<K, V>))
            {
                return false;
            }
            return my_key.Equals(((KeyValue<K, V>)the_other).key);
        }

        /// <summary>
        /// Gives a hashcode for the key/value pair. This method bases the hash
        /// value on the key only.
        /// </summary>
        /// <returns>an integer hash value.</returns>
        public override int GetHashCode()
        {
            return my_key.GetHashCode();
        }

        /// <summary>
        /// Provides a string representation of the key/value pair.
        /// </summary>
        /// <returns>a string representation.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            //print the key/value pair
            Helpers.printElementIfNull(builder, "Key", key);
            builder.Append(", ");
            Helpers.printElementIfNull(builder, "Value", value);

            return builder.ToString();
        }

        //------------------ HELPER METHODS ---------------------

        /// <summary>
        /// Access to key.
        /// </summary>
        public K key
        {
            get { return my_key; }
            set { my_key = value; }
        }

        /// <summary>
        /// Access to value.
        /// </summary>
        public V value
        {
            get { return my_value; }
            set { my_value = value; }
        }
    }
}
