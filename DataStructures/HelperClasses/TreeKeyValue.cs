using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStructures.Interfaces;

namespace DataStructures.HelperClasses
{
    /// <summary>
    /// Represents a key/value pair in a tree map.
    /// </summary>
    /// <typeparam name="K">the reference type of key elements.</typeparam>
    /// <typeparam name="V">the reference type of value elements.</typeparam>
    internal class TreeKeyValue<K, V> : KeyValue<K, V>, Comparable<TreeKeyValue<K, V>>
        where K : class
        where V : class
    {
        private Comparator<K> my_comparator;

        /// <summary>
        /// Sets up the pair with a key and value.
        /// </summary>
        /// <param name="the_key">the key.</param>
        /// <param name="the_value">the value.</param>
        public TreeKeyValue(K the_key, V the_value, Comparator<K> the_comparator)
            : base(the_key, the_value)
        {
            my_comparator = the_comparator;
        }

        public int compareTo(TreeKeyValue<K, V> the_other)
        {
            if (my_comparator == null)
            {
                return ((Comparable<K>)key).compareTo(the_other.key);
            }
            else
            {
                return my_comparator.compare(this.key, the_other.key);
            }
        }
    }
}
