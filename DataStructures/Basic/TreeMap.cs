using System;
using System.Linq;
using System.Text;
using DataStructures.Interfaces;
using DataStructures.HelperClasses;

namespace DataStructures.Basic
{
    /// <summary>
    /// Represents a sorted map with an underlying tree structure.
    /// </summary>
    /// <typeparam name="K">the reference type of key elements.</typeparam>
    /// <typeparam name="V">the reference type of value elements.</typeparam>
    public class TreeMap<K, V> : Map<K, V> 
        where K : class, Comparable<K>
        where V : class
    {
        private Set<TreeKeyValue<K, V>> my_keys;
        private Comparator<K> my_comparator;
        
        /// <summary>
        /// Sets up the map with the default settings.
        /// </summary>
        public TreeMap()
        {
            my_keys = new TreeSet<TreeKeyValue<K, V>>();
        }

        /// <summary>
        /// Sets up the map with initial key/value pairs.
        /// </summary>
        /// <param name="the_keys"></param>
        /// <param name="the_values"></param>
        public TreeMap(K[] the_keys, V[] the_values)
            : this()
        {
            //copy across pairs
            for (int i = 0; i < the_keys.Length; i++)
            {
                put(the_keys[i], the_values[i]);
            }
        }

        /// <summary>
        /// Sets up the map with a comparator.
        /// </summary>
        public TreeMap(Comparator<K> the_comparator)
            : this()
        {
            my_comparator = the_comparator;
        }

        /// <summary>
        /// Sets up the map with a comparator and initial key/value pairs.
        /// </summary>
        /// <param name="the_keys"></param>
        /// <param name="the_values"></param>
        public TreeMap(Comparator<K> the_comparator, K[] the_keys, V[] the_values)
            : this(the_keys, the_values)
        {
            my_comparator = the_comparator;
        }

        /// <summary>
        /// Shows whether elements exist in the map or not.
        /// </summary>
        /// <returns>true if there are no elements in the map, otherwise false.</returns>
        public bool isEmpty()
        {
            return my_keys.size() == 0;
        }

        /// <summary>
        /// Shows whether the map contains a key.
        /// </summary>
        /// <param name="the_check">the key to search for.</param>
        /// <returns>true if the key is found, otherwise false.</returns>
        public bool containsKey(K the_check)
        {
            //equals with key/value pairs only compare keys
            return my_keys.contains(new TreeKeyValue<K, V>(the_check, null, null));
        }

        /// <summary>
        /// Gets a value from the map given a key.
        /// </summary>
        /// <param name="the_key">the key to search with.</param>
        /// <returns>the value linked to the key, or null if the key does not exist.</returns>
        public V get(K the_key)
        {
            //look for the element
            TreeKeyValue<K, V> entry = my_keys.getElement(new TreeKeyValue<K, V>(the_key, null, null));
            if (entry == null)
            {
                return null;
            }
            else
            {
                return entry.value;
            }
        }

        /// <summary>
        /// Puts a key/value pair in the map.
        /// </summary>
        /// <param name="the_key">the key.</param>
        /// <param name="the_value">the value.</param>
        /// <returns>the value that was previously associated with the key, otherwise null if
        /// no key/value pair was in the map before this method call.</returns>
        public V put(K the_key, V the_value)
        {
            //get the element that was previously in this tree location,add the new element and return the old
            TreeKeyValue<K, V> entry = my_keys.getElement(new TreeKeyValue<K, V>(the_key, the_value, null));
            my_keys.add(new TreeKeyValue<K, V>(the_key, the_value, my_comparator)); //add the comparator if given

            if (entry == null)
            {
                return null;
            }
            else
            {
                return entry.value;
            }
        }

        /// <summary>
        /// Removes a key/value pair from the map.
        /// </summary>
        /// <param name="the_key">the key to search with.</param>
        /// <returns>a previous value associated with the key, or null if no key/value pair existed.</returns>
        public V remove(K the_key)
        {
            //get the element that is currently in the tree location and then remove the element and return it
            TreeKeyValue<K, V> find = new TreeKeyValue<K, V>(the_key, null, null);
            TreeKeyValue<K, V> entry = my_keys.getElement(find);
            my_keys.remove(find);

            if (entry == null)
            {
                return null;
            }
            else
            {
                return entry.value;
            }
        }

        /// <summary>
        /// Clears the map of entries.
        /// </summary>
        public void clear()
        {
            my_keys.clear();
        }

        /// <summary>
        /// Gets the set of keys in the map.
        /// </summary>
        /// <returns>a set of keys.</returns>
        public Set<K> keyset()
        {
            Set<K> return_value = new TreeSet<K>();
            Iterator<TreeKeyValue<K, V>> it = my_keys.iterator();

            //add each key to the set
            while (it.hasNext())
            {
                TreeKeyValue<K, V> entry = it.next();
                return_value.add(entry.key);
            }

            return return_value;
        }

        /// <summary>
        /// Gets a collection of values in the map.
        /// </summary>
        /// <returns>a collection of values.</returns>
        public Collection<V> values()
        {
            Collection<V> return_value = new ArrayList<V>();
            Iterator<TreeKeyValue<K, V>> it = my_keys.iterator();

            //add each value to the collection
            while (it.hasNext())
            {
                TreeKeyValue<K, V> entry = it.next();
                return_value.add(entry.value);
            }

            return return_value;
        }

        /// <summary>
        /// Shows the number of entries in the map.
        /// </summary>
        /// <returns>the number of entries in the map.</returns>
        public int entrySize()
        {
            return my_keys.size();
        }

        /// <summary>
        /// Returns a string representation of the keys and values in the map.
        /// </summary>
        /// <returns>a string representation.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            //print key/value pairs
            builder.Append("Keys: ");
            builder.Append(my_keys.ToString());

            return builder.ToString();
        }
    }
}
