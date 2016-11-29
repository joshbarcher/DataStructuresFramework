using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Interfaces
{
    /// <summary>
    /// The methods guaranteed to exist for an iterator class.
    /// This iterator allows for iteration in only one direction.
    /// </summary>
    /// <typeparam name="T">the reference type of elements being iterated over.</typeparam>
    public interface Iterator<T> where T : class
    {
        T next();
        bool hasNext();
        T remove();
    }
}
