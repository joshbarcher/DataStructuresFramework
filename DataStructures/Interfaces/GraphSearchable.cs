using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Interfaces
{
    /// <summary>
    /// Represents the searchable contract of the graph classes
    /// in this assembly. Searches can begin at any arbitrary
    /// vertex in the graph.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface GraphSearchable<T> where T: class 
    {
        List<T> breadthFirstSearch(T the_source_vertex);
        List<T> depthFirstSearch(T the_source_vertex);

        List<T> preOrderSearch(T the_source_vertex);
        List<T> inOrderSearch(T the_source_vertex);
        List<T> postOrderSearch(T the_source_vertex);

        Iterator<T> iterator(GraphTraversals the_traversal_method, T the_source_vertex);
    }

    /// <summary>
    /// Represents the standard types of traversal in a graph structure.
    /// </summary>
    public enum GraphTraversals
    {
        PreOrder,
        InOrder,
        PostOrder,
        BreadthFirst,
        DepthFirst
    }
}
