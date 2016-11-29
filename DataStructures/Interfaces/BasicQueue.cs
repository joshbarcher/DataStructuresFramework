using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Interfaces
{
    /// <summary>
    /// Represents the methods included for an queue class.
    /// </summary>
    /// <typeparam name="T">the reference type of elements added to the queue.</typeparam>
    public interface BasicQueue<T> where T : class 
    {
        bool enqueue(T the_addition);
        T dequeue();
        T poll();
        bool isEmpty();
        int size();
        bool add(T the_new_element);
        bool contains(T the_check);
        void clear();
    }
}
