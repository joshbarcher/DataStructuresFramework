using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Interfaces
{
    /// <summary>
    /// Represents the outer contract of searches on a tree structure.
    /// All searches are expected to begin at the root of the tree.
    /// </summary>
    /// <typeparam name="T">the reference type of elements in the tree.</typeparam>
    public interface TreeSearchable<T> : GraphSearchable<T> where T : class
    {
        //these searches are begun implicitly at the root
        List<T> preOrderSearch();
        List<T> inOrderSearch();
        List<T> postOrderSearch();

        List<T> breadthFirstSearch();
        List<T> depthFirstSearch();

        Iterator<T> iterator(GraphTraversals the_traversal_method);
    }
}
