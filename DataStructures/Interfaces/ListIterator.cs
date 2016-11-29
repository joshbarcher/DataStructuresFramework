using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Interfaces
{
    /// <summary>
    /// Two-way iterator interface that allows for traversal over
    /// a data structure both forward and backward.
    /// </summary>
    /// <typeparam name="T">the reference type of elements in the data structured
    /// being iterated over.</typeparam>
    public interface ListIterator<T> : Iterator<T> where T : class 
    {
        T previous();
        bool hasPrevious();
    }
}
