using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Interfaces
{
    /// <summary>
    /// Class that can compare elements of any type.
    /// </summary>
    /// <typeparam name="T">the reference type of the elements being compared.</typeparam>
    public interface Comparator<T> where T : class
    {
        int compare(T the_one, T the_two);
    }
}
