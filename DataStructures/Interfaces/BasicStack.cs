using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Interfaces
{
    /// <summary>
    /// The methods included with any stack class.
    /// </summary>
    /// <typeparam name="T">the reference type of elements added to a stack.</typeparam>
    public interface BasicStack<T> where T : class 
    {
        bool push(T the_addition);
        T pop();
        T peek();
        bool isEmpty();
        int size();
        bool add(T the_new_element);
        bool contains(T the_check);
        void clear();
    }
}
