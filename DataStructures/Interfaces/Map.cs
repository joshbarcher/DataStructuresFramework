using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Interfaces
{
    /// <summary>
    /// Represents the methods guaranteed to be accessible in any map collection.
    /// </summary>
    /// <typeparam name="K">the reference type of keys in the map.</typeparam>
    /// <typeparam name="V">the reference type of values in the map.</typeparam>
    public interface Map<K, V> where K : class
                               where V : class
    {
        bool isEmpty();
        bool containsKey(K the_check);
        V get(K the_key);
        V put(K the_key, V the_value);
        V remove(K the_key);
        void clear();
        Set<K> keyset();
        Collection<V> values();
        int entrySize();
    }
}
