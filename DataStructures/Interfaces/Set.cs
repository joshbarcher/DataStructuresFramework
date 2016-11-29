using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Interfaces
{
    /// <summary>
    /// Set interface, which is simply a collection.
    /// </summary>
    /// <typeparam name="T">the reference type of elements stored in 
    /// the set.</typeparam>
    public interface Set<T> : Collection<T> where T : class
    {
    }
}
