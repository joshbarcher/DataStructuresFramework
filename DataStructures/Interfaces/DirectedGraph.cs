using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStructures.PrimitiveWrappers;
using DataStructures.HelperClasses;

namespace DataStructures.Interfaces
{
    /// <summary>
    /// Interface for directed graphs. This class also represents a 
    /// partial interface for the UndirectedGraph interface.
    /// </summary>
    /// <typeparam name="T">the reference type for elements stored as vertex labels
    /// in the graph.</typeparam>
    public interface DirectedGraph<T> : GraphSearchable<T> where T : class
    {
        void addVertex(T the_value);
        void addEdge(T the_first_vertex, T the_second_vertex, double the_edge_cost);
        void clear();
        void clearEdges();
        int vertexSize();
        int edgeSize();
        int inDegree(T the_vertex);
        int outDegree(T the_vertex);
        int degree(T the_vertex);
        List<SimpleEdge<T>> getEdgesIncidentTo(T the_vertex);
        double getEdgeCost(T the_first_vertex, T the_second_vertex);
        void setEdgeCost(T the_first_vertex, T the_second_vertex, double the_new_cost);
        bool removeVertex(T the_vertex);
        bool removeEdge(T the_first_vertex, T the_second_vertex);
        bool containsVertex(T the_vertex);
        bool containsEdge(T the_first_vertex, T the_second_vertex);
        List<SimpleEdge<T>> getEdges();
        List<T> getVertices();

        //helpful methods
        bool isTree();
        bool containsCycle();

        //traversal
        Iterator<T> vertexIterator();

        //algorithms
        void unweighted(T the_base_vertex);
        void dijkstras(T the_base_vertex);
        List<T> getShortestPath(T the_end_point);
        double getShortestPathLength(T the_end_point);

        //searchs
        List<T> topologicalSearch();
    }
}
