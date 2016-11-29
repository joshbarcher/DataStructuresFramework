using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStructures.Interfaces;
using DataStructures.HelperClasses;

namespace DataStructures.Basic
{
    /// <summary>
    /// Map class that uses hashing to store key/value
    /// pairs in roughly constant time.
    /// </summary>
    /// <typeparam name="K">the key reference type.</typeparam>
    /// <typeparam name="V">the value reference type.</typeparam>
    public class HashMap<K, V> : Map<K, V> where K : class
                                           where V : class
    {
        private const int DEFAULT_KEY_NUMBER = 10;

        private Set<KeyValue<K, V>> my_keys = new HashSet<KeyValue<K, V>>();
        
        /// <summary>
        /// Sets up the map with the default settings.
        /// </summary>
        public HashMap()
        {
            setupMap(DEFAULT_KEY_NUMBER);
        }

        /// <summary>
        /// Sets up the map with an expected space internally.
        /// </summary>
        /// <param name="the_number_of_elements">the initial
        /// space.</param>
        public HashMap(int the_number_of_elements)
        {
            setupMap(the_number_of_elements);
        }

        /// <summary>
        /// Sets up the map with initial key/value pairs.
        /// </summary>
        /// <param name="the_keys"></param>
        /// <param name="the_values"></param>
        public HashMap(K[] the_keys, V[] the_values)
        {
            setupMap(the_keys.Length);

            //copy across pairs
            for (int i = 0; i < the_keys.Length; i++)
            {
                put(the_keys[i], the_values[i]);
            }
        }

        /// <summary>
        /// Shows whether the map contains any key/value pairs.
        /// </summary>
        /// <returns>true if the map contains pairs, otherwise false.</returns>
        public bool isEmpty()
        {
            return my_keys.size() == 0;
        }

        /// <summary>
        /// Shows whether the map contains a key.
        /// </summary>
        /// <param name="the_check">the key to search for.</param>
        /// <returns>true if the key is in the map, otherwise false.</returns>
        public bool containsKey(K the_check)
        {
            return my_keys.contains(new KeyValue<K, V>(the_check, null));
        }

        /// <summary>
        /// Returns the value stored under a key.
        /// </summary>
        /// <param name="the_key">the key that will "find" the value.</param>
        /// <returns>the value associated with the specified key, 
        /// or null if not found.</returns>
        public V get(K the_key)
        {
            KeyValue<K, V> entry = my_keys.getElement(new KeyValue<K, V>(the_key, null));
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
        /// Puts a key/value pair into the map.
        /// </summary>
        /// <param name="the_key">the key to add.</param>
        /// <param name="the_value">the value to add.</param>
        /// <returns>the old value associated with the
        /// key or null if the key/value pair did not exist.</returns>
        public V put(K the_key, V the_value)
        {
            KeyValue<K, V> entry = my_keys.getElement(new KeyValue<K, V>(the_key, the_value));
            my_keys.add(new KeyValue<K, V>(the_key, the_value));

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
        /// <param name="the_key">the key to search for.</param>
        /// <returns>the value removed from the map or
        /// null if the key/value pair was not found.</returns>
        public V remove(K the_key)
        {
            KeyValue<K, V> find = new KeyValue<K, V>(the_key, null);
            KeyValue<K, V> entry = my_keys.getElement(find);
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
        /// Clears the map of all key/value pairs.
        /// </summary>
        public void clear()
        {
            my_keys.clear();
        }

        /// <summary>
        /// Returns the set of keys stored in the map.
        /// </summary>
        /// <returns>a set of keys.</returns>
        public Set<K> keyset()
        {
            Set<K> return_value = new HashSet<K>();

            //pull out all keys from the pairs
            Iterator<KeyValue<K, V>> it = my_keys.iterator();
            while (it.hasNext())
            {
                return_value.add(it.next().key);
            }

            return return_value;
        }

        /// <summary>
        /// Returns an iterable collection of values
        /// stored in the map.
        /// </summary>
        /// <returns>a collection of values.</returns>
        public Collection<V> values()
        {
            Collection<V> return_value = new ArrayList<V>();

            //pull out all values from the pairs
            Iterator<KeyValue<K, V>> it = my_keys.iterator();
            while (it.hasNext())
            {
                return_value.add(it.next().value);
            }

            return return_value;
        }
        
        /// <summary>
        /// Returns the number of key/value pairs in the map.
        /// </summary>
        /// <returns>the number of key/value pairs in the map.</returns>
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

        //------------------ HELPER METHODS ------------------
        
        //sets up the inner set of key/value pairs.
        private void setupMap(int the_initial_elements)
        {
            my_keys = new HashSet<KeyValue<K, V>>(the_initial_elements);
        }
    }
}
