using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Interfaces
{
    /// <summary>
    /// Represents the methods in any heap class.
    /// </summary>
    /// <typeparam name="T">the reference type of elements in the heap.</typeparam>
    public interface BasicHeap<T>
    {
        T deleteMin();
        bool add(T the_addition);
        T peek();
        int size();
        bool isEmpty();
        void clear();
        bool contains(T the_item);
        bool min_heap { get; }
    }
}
