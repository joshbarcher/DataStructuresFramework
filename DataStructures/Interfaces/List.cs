using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Interfaces
{
    /// <summary>
    /// List interface which governs the outer contracts of
    /// how lists allow for element access.
    /// </summary>
    /// <typeparam name="T">the reference type of elements stored in the list.</typeparam>
    public interface List<T> : Collection<T> where T : class
    {
        T get(int the_index);
        void set(int the_index, T the_new_value);
        T removeAt(int the_index);
        bool insertAt(int the_index, T the_new_value);
        T first();
        T last();
        T removeLast();
        T removeFirst();
        bool addLast(T the_new_value);
        bool addFirst(T the_new_value);
        ListIterator<T> listIterator();
    }
}
