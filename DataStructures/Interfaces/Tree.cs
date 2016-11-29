using System;
using System.Linq;
using System.Text;

namespace DataStructures.Interfaces
{
    /// <summary>
    /// Represents the outer contract of a standard tree in
    /// memory. The tree is searchable from the root of the
    /// tree and is a standard collection.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface Tree<T> : TreeSearchable<T>, GraphSearchable<T>, Collection<T> where T : class 
    {
    }
}
