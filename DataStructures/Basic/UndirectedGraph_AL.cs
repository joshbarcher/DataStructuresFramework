using System;
using System.Linq;
using System.Text;
using DataStructures.HelperClasses;
using DataStructures.Interfaces;
using DataStructures.Exceptions;

namespace DataStructures.Basic
{
    /// <summary>
    /// Represents a graph with undirected edges.
    /// </summary>
    /// <typeparam name="T">the reference type of elements that are stored
    /// as vertex labels in the graph.</typeparam>
    public class UndirectedGraph_AL<T> : DirectedGraph_AL<T>, UndirectedGraph<T> where T: class 
    {
        /// <summary>
        /// Sets up the the undirected graph with default settings.
        /// </summary>
        public UndirectedGraph_AL()
            : base()
        {
            //do nothing
        }

        /// <summary>
        /// Sets up the graph with an expected number of vertices.
        /// </summary>
        /// <param name="the_number_of_vertices">the expected number
        /// of vertices in the graph.</param>
        public UndirectedGraph_AL(int the_number_of_vertices)
            : base(the_number_of_vertices)
        {
            //do nothing
        }

        /// <summary>
        /// Sets up the graph with a number of vertices in the graph.
        /// </summary>
        /// <param name="the_vertices">the vertices to place in the graph.</param>
        public UndirectedGraph_AL(T[] the_vertices)
            : base(the_vertices)
        {
            //do nothing
        }

        /// <summary>
        /// Adds an edge to the graph.
        /// </summary>
        /// <param name="the_first_vertex">the first vertex of the edge.</param>
        /// <param name="the_second_vertex">the second vertex of the edge.</param>
        /// <param name="the_edge_cost">the cost of the edge.</param>
        public override void addEdge(T the_first_vertex, T the_second_vertex, double the_edge_cost)
        {
            Vertex<T> first = getVertex(the_first_vertex);
            Vertex<T> second = getVertex(the_second_vertex);

            //add two edges since this graph is undirected.
            if (first.addEdge(second, the_edge_cost))
            {
                edge_size++;
            }

            if (second.addEdge(first, the_edge_cost))
            {
                edge_size++;
            }
        }

        /// <summary>
        /// Removes an edge from the graph.
        /// </summary>
        /// <param name="the_first_vertex">the first vertex of the edge.</param>
        /// <param name="the_second_vertex">the second vertex of the edge.</param>
        /// <returns>true if the edge was found and removed, otherwise false.</returns>
        public override bool removeEdge(T the_first_vertex, T the_second_vertex)
        {
            Vertex<T> first = getVertex(the_first_vertex);
            Vertex<T> second = getVertex(the_second_vertex);

            //removes both edges because this graph is undirected
            bool removed = first.removeEdge(second);
            if (removed)
            {
                edge_size--;
            }

            removed = second.removeEdge(first);
            if (removed)
            {
                edge_size--;
            }

            return removed;
        }

        /// <summary>
        /// Shows the number of edges in the graph.
        /// </summary>
        /// <returns>the number of edges</returns>
        public override int edgeSize()
        {
            //return half the edges because the graph is undirected
            return edge_size / 2;
        }

        /// <summary>
        /// Shows the degree of a given vertex.
        /// </summary>
        /// <param name="the_vertex">the specified vertex.</param>
        /// <returns>the degree of the specified vertex.</returns>
        public override int degree(T the_vertex)
        {
            int total = inDegree(the_vertex) + outDegree(the_vertex);

            //in an undirected graph reduce the redundant edge counts
            total /= 2;
            return total;
        }

        /// <summary>
        /// Shows whether the graph is connected.
        /// </summary>
        /// <returns>true if the graph is connected, otherwise false.</returns>
        public bool isConnected()
        {
            return getComponentCount() == 1;
        }

        /// <summary>
        /// Returns the components of the graph as a list.
        /// </summary>
        /// <returns>a list of components in the graph.</returns>
        public List<List<T>> getComponents()
        {
            List<List<T>> return_value = new ArrayList<List<T>>();
            getComponents(return_value);
            return return_value;
        }

        /// <summary>
        /// Returns the number of components in the graph.
        /// </summary>
        /// <returns>the number of components in the graph.</returns>
        public int getComponentCount()
        {
            return getComponents(null);
        }

        /// <summary>
        /// Returns all edges in the graph.
        /// </summary>
        /// <returns>all edges in the graph.</returns>
        public List<SimpleEdge<T>> getEdges()
        {
            return new ArrayList<SimpleEdge<T>>(getEdgesInternal());
        }

        //-------------------------- ALGORITHMS --------------------------

        /// <summary>
        /// Returns the minimum spanning tree of an undirected graph using kruskals algorithm.
        /// </summary>
        /// <typeparam name="T">the reference type of the graph's vertex labels.</typeparam>
        /// <param name="the_graph">the graph to perform the operation on.</param>
        /// <returns>a new graph with the minimum spanning tree.</returns>
        public UndirectedGraph<T> kruskals()
        {
            if (!isConnected())
            {
                throw new IllegalStateException("You cannot perform kruskal's algorithm on an unconnected graph.");
            }

            T[] verts = my_vertices.keyset().toArray();

            //minimum spanning tree
            UndirectedGraph<T> mst = new UndirectedGraph_AL<T>(verts);

            //queue to constantly pick the lowest cost edge (adds the edges into the constructor)
            BasicQueue<Edge<T>> queue = new PriorityQueue<Edge<T>>(true, getEdgesInternal(), new EdgeCostComparator<T>());

            //disjoint sets to determine which vertex belongs to which forest
            DisjointSets<T> sets = new DisjointSets<T>(verts);

            int edges_added = 0;
            while (edges_added < vertexSize() - 1) //n-1 edges in a tree with n vertices
            {
                //see if the edge joins two of the forests
                Edge<T> edge = queue.dequeue();
                if (sets.find(edge.first_vertex.value) != sets.find(edge.second_vertex.value))
                {
                    //connect the forests and add the edge to the minimum spanning tree
                    sets.union(edge.first_vertex.value, edge.second_vertex.value);
                    mst.addEdge(edge.first_vertex.value, edge.second_vertex.value, edge.edge_cost);
                    edges_added++;
                }
            }

            return mst;
        }

        //-------------------------- HELPER METHODS ------------------------

        //gets the number/list of components (no list is calculated if not given i.e. null)
        private int getComponents(List<List<T>> the_components)
        {
            //clear previous algorithm variables
            clearAll();

            int count = 0;

            //iterate across all vertices
            Iterator<Vertex<T>> it = my_vertices.values().iterator();
            while (it.hasNext())
            {
                Vertex<T> next = it.next();

                //if the vertex has not been visited then perform a breadth-first search
                if (!next.visited)
                {
                    count++;
                    if (the_components == null)
                    {
                        breadthFirstSearch(next.value, false);
                    }
                    else
                    {
                        the_components.add(breadthFirstSearch(next.value, false));
                    }
                }
            }

            return count;
        }

        //gets a list of all edges in the graph
        private Edge<T>[] getEdgesInternal()
        {
            Iterator<Vertex<T>> it = my_vertices.values().iterator();
            Set<Edge<T>> edges = new HashSet<Edge<T>>();
            while (it.hasNext())
            {
                List<Edge<T>> list = it.next().edge_list;
                for (int i = 0; i < list.size(); i++)
                {
                    Edge<T> edge = list.get(i);
                    //if the opposite edge has not already been added (cost of edge not considered)
                    if (!edges.contains(new Edge<T>(edge.second_vertex, edge.first_vertex, 0.0)))
                    {
                        edges.add(list.get(i));
                    }
                }
            }

            return edges.toArray();
        }
    
        /// <summary>
        /// Edge comparer to sort edges with.
        /// </summary>
        /// <typeparam name="T">the reference type of vertex labels in the edge.</typeparam>
        internal class EdgeCostComparator<T> : Comparator<Edge<T>> where T : class 
        {
            public int compare(Edge<T> the_one, Edge<T> the_two)
            {
                return (int)(the_two.edge_cost - the_one.edge_cost);
            }
        }
    }
}
