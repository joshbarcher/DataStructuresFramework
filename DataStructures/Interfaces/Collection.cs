using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Interfaces
{
    /// <summary>
    /// Collection interface represents the basic collection
    /// structure and how to query the structure and the elements
    /// it holds.
    /// </summary>
    /// <typeparam name="T">the reference type of elements stored
    /// in the collection.</typeparam>
    public interface Collection<T> where T : class 
    {
        bool isEmpty();
        int size();
        T getElement(T the_check);
        bool add(T the_new_element);
        bool contains(T the_check);
        bool remove(T the_removal);
        void clear();
        T[] toArray();
        Iterator<T> iterator();
    }
}
