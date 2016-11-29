using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Interfaces
{
    /// <summary>
    /// Represents a sorted collection which will allow
    /// access to its elements in sorted order.
    /// </summary>
    /// <typeparam name="T">the reference type of elements stored
    /// in the collection.</typeparam>
    public interface SortedCollection<T> where T : class
    {
        T first();
        T last();
    }
}
