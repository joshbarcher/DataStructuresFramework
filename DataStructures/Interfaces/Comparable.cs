using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Interfaces
{
    /// <summary>
    /// Makes an class able to compare itself with another
    /// class of the same type.
    /// </summary>
    /// <typeparam name="T">the reference type of elements being compared.</typeparam>
    public interface Comparable<T> where T : class
    {
        int compareTo(T the_other);
    }
}
