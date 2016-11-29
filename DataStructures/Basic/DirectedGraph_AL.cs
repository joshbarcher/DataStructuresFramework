using System;
using System.Linq;
using System.Text;
using DataStructures.PrimitiveWrappers;
using DataStructures.Interfaces;
using DataStructures.Exceptions;
using DataStructures.HelperClasses;

namespace DataStructures.Basic
{
    /// <summary>
    /// This is a directed graph with an underlying adjacency list implementation. This graph works
    /// best with sparse edges and heavy amounts of vertices.
    /// </summary>
    /// <typeparam name="T">the reference type of vertex labels.</typeparam>
    public class DirectedGraph_AL<T> : DirectedGraph<T> where T : class
    {
        private const int DEFAULT_NUM_OF_VERTICES = 10;

        internal Map<T, Vertex<T>> my_vertices;

        private int my_vertices_size = 0;
        private int my_edge_size = 0;

        /// <summary>
        /// Sets up the directed graph with default settings.
        /// </summary>
        public DirectedGraph_AL()
        {
            setupVertices(DEFAULT_NUM_OF_VERTICES);
        }

        /// <summary>
        /// Sets up the graph with a hint concerning the number
        /// of vertices that will be added to the graph.
        /// </summary>
        /// <param name="the_number_of_vertices"></param>
        public DirectedGraph_AL(int the_number_of_vertices)
        {
            setupVertices(the_number_of_vertices);
        }

        /// <summary>
        /// Sets up the graph with an array of vertex values.
        /// </summary>
        /// <param name="the_vertices">the values to use as
        /// vertices.</param>
        public DirectedGraph_AL(T[] the_vertices)
        {
            setupVertices(the_vertices.Length);

            for (int i = 0; i < the_vertices.Length; i++)
            {
                addVertex(the_vertices[i]);
            }
        }

        /// <summary>
        /// Adds a vertex to graph.
        /// </summary>
        /// <param name="the_value">the vertex to add.</param>
        public void addVertex(T the_value)
        {
            my_vertices.put(the_value, new Vertex<T>(the_value));
            my_vertices_size++;
        }

        /// <summary>
        /// Adds an edge to the graph.
        /// </summary>
        /// <param name="the_first_vertex">the first vertex on the edge.</param>
        /// <param name="the_second_vertex">the second vertex on the edge.</param>
        /// <param name="the_edge_cost">the edge cost.</param>
        public virtual void addEdge(T the_first_vertex, T the_second_vertex, double the_edge_cost)
        {
            Vertex<T> first = getVertex(the_first_vertex);
            Vertex<T> second = getVertex(the_second_vertex);

            //check for loop
            if (first.Equals(second))
            {
                throw new ArgumentException("Cannot add a loop to this graph.");
            }

            if (first.addEdge(second, the_edge_cost))
            {
                my_edge_size++;
            }
        }

        /// <summary>
        /// Finds all edges incident to a vertex.
        /// </summary>
        /// <param name="the_vertex">the vertex in question.</param>
        /// <returns>a list of vertices that form edges between
        /// the vertex in question and themselves.</returns>
        public List<SimpleEdge<T>> getEdgesIncidentTo(T the_vertex)
        {
            //get edges
            List<Edge<T>> edges = getVertex(the_vertex).edge_list;

            //copy across (shallow copy)
            List<SimpleEdge<T>> values = new ArrayList<SimpleEdge<T>>(edges.size());
            for (int i = 0; i < edges.size(); i++)
            {
                values.add(edges.get(i));
            }

            return values;
        }

        /// <summary>
        /// Returns all edges in the graph.
        /// </summary>
        /// <returns>all edges in the graph.</returns>
        public List<SimpleEdge<T>> getEdges()
        {
            //loop through all vertices
            List<SimpleEdge<T>> return_value = new ArrayList<SimpleEdge<T>>(edgeSize());
            Iterator<Vertex<T>> it = my_vertices.values().iterator();
            while (it.hasNext())
            {
                //loop through all edges
                Vertex<T> v = it.next();
                Iterator<Edge<T>> it_edge = v.edge_list.iterator();
                while (it_edge.hasNext())
                {
                    return_value.add(it_edge.next());
                }
            }
            return return_value;
        }

        /// <summary>
        /// Returns a list of all vertex labels in the graph.
        /// </summary>
        /// <returns>a list of vertex labels.</returns>
        public List<T> getVertices()
        {
            //loop through all vertices
            List<T> return_value = new ArrayList<T>(vertexSize());
            Iterator<Vertex<T>> it = my_vertices.values().iterator();
            while (it.hasNext())
            {
                return_value.add(it.next().value);
            }
            return return_value;
        }

        /// <summary>
        /// Gets the edge cost in a graph given two vertices.
        /// </summary>
        /// <param name="the_first_vertex">the first vertex.</param>
        /// <param name="the_second_vertex">the second vertex.</param>
        /// <returns>an edge cost.</returns>
        public double getEdgeCost(T the_first_vertex, T the_second_vertex)
        {
            return findEdge(the_first_vertex, the_second_vertex).edge_cost;
        }

        /// <summary>
        /// Sets the cost of an edge in the graph.
        /// </summary>
        /// <param name="the_first_vertex">the first vertex.</param>
        /// <param name="the_second_vertex">the second vertex.</param>
        /// <param name="the_new_cost">the new cost of the edge.</param>
        public void setEdgeCost(T the_first_vertex, T the_second_vertex, double the_new_cost)
        {
            findEdge(the_first_vertex, the_second_vertex).edge_cost = the_new_cost;
        }

        /// <summary>
        /// Clears the vertex/edge sets of the graph.
        /// </summary>
        public void clear()
        {
            my_vertices.clear();
            my_vertices_size = 0;
            my_edge_size = 0;
        }

        /// <summary>
        /// Finds the number of vertices in the graph.
        /// </summary>
        /// <returns>the number of vertices in the graph.</returns>
        public int vertexSize()
        {
            return my_vertices_size;
        }

        /// <summary>
        /// Finds the number of edges in the graph.
        /// </summary>
        /// <returns>the number of edges in the graph.</returns>
        public virtual int edgeSize()
        {
            return my_edge_size;
        }

        /// <summary>
        /// Removes a vertex from the graph.
        /// </summary>
        /// <param name="the_vertex">the vertex to remove.</param>
        /// <returns>true if the vertex was found and removed,
        /// otherwise false.</returns>
        public bool removeVertex(T the_vertex)
        {
            Vertex<T> vertex = my_vertices.remove(the_vertex);
            if (vertex != null)
            {
                my_vertices_size--;

                //find all other vertices with edges between this vertex and themselves
                Iterator<Vertex<T>> it = my_vertices.values().iterator();
                while (it.hasNext())
                {
                    Vertex<T> v = it.next();
                    Iterator<Edge<T>> it_edge = v.edge_list.iterator();
                    while (it_edge.hasNext())
                    {
                        Edge<T> edge = it_edge.next();
                        if (edge.second_vertex.value.Equals(the_vertex))
                        {
                            it_edge.remove();
                        }
                    }
                }

                return true;
            }
            else //vertex not found
            {
                return false;
            }
        }

        /// <summary>
        /// Removes an edge from the graph.
        /// </summary>
        /// <param name="the_first_vertex">the first
        /// vertex on the edge.</param>
        /// <param name="the_second_vertex">the second
        /// vertex on the edge.</param>
        /// <returns>true if the edge was found and removed, 
        /// otherwise false</returns>
        public virtual bool removeEdge(T the_first_vertex, T the_second_vertex)
        {
            Vertex<T> first = getVertex(the_first_vertex);
            Vertex<T> second = getVertex(the_second_vertex);

            bool removed = first.removeEdge(second);
            if (removed)
            {
                my_edge_size--;
            }

            return removed;
        }

        /// <summary>
        /// Shows whether the graph contains a vertex given.
        /// </summary>
        /// <param name="the_vertex">the specified vertex.</param>
        /// <returns>true if the graph contains the vertex,
        /// otherwise false</returns>
        public bool containsVertex(T the_vertex)
        {
            return my_vertices.containsKey(the_vertex);
        }

        /// <summary>
        /// Shows whether the graph contains and edge given.
        /// </summary>
        /// <param name="the_first_vertex">the first vertex
        /// of a specified edge.</param>
        /// <param name="the_second_vertex">the second vertex
        /// of a specified edge.</param>
        /// <returns>true if the graph contains the edge,
        /// otherwise false.</returns>
        public bool containsEdge(T the_first_vertex, T the_second_vertex)
        {
            //check the edge list of the first vertex
            Vertex<T> v = getVertex(the_first_vertex);
            if (v == null)
            {
                return false;
            }
            else
            {
                return v.hasEdgeToVertex(the_second_vertex);
            }
        }

        /// <summary>
        /// Clears all edges from the graph.
        /// </summary>
        public void clearEdges()
        {
            Iterator<Vertex<T>> it = my_vertices.values().iterator();
            while (it.hasNext())
            {
                Vertex<T> v = it.next();
                v.edge_list.clear();
            }

            my_edge_size = 0;
        }

        /// <summary>
        /// Shows the in-degree of a vertex in the graph.
        /// </summary>
        /// <param name="the_vertex">the vertex to find
        /// the in-degree for.</param>
        /// <returns>the in-degree of the vertex given</returns>
        public int inDegree(T the_vertex)
        {
            //add up all edges incoming to the vertex
            int count = 0;
            Vertex<T> check = getVertex(the_vertex);
            Iterator<Vertex<T>> it = my_vertices.values().iterator();
            while (it.hasNext())
            {
                Vertex<T> v = it.next();
                if (v.hasEdgeToVertex(the_vertex))
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Shows the out-degree of a vertex.
        /// </summary>
        /// <param name="the_vertex">the specified
        /// vertex to find the out-degree for.</param>
        /// <returns>the out-degree of the vertex.</returns>
        public int outDegree(T the_vertex)
        {
            //the number of items in the adjacency list is the out degree
            return getVertex(the_vertex).edge_list.size();
        }

        /// <summary>
        /// Shows the degree of a vertex.
        /// </summary>
        /// <param name="the_vertex">the specified
        /// vertex.</param>
        /// <returns>the degree of the vertex.</returns>
        public virtual int degree(T the_vertex)
        {
            return inDegree(the_vertex) + outDegree(the_vertex);
        }

        /// <summary>
        /// Gives an iterator over the vertex values
        /// in the graph.
        /// </summary>
        /// <returns>iterator for the vertices in the
        /// labels in the graph.</returns>
        public Iterator<T> vertexIterator()
        {
            return my_vertices.keyset().iterator();
        }

        /// <summary>
        /// Shows whether the graph is a tree.
        /// </summary>
        /// <returns>true if the graph is a tree, 
        /// otherwise false.</returns>
        public bool isTree()
        {
            //standard check
            if (edgeSize() != vertexSize() - 1)
            {
                return false;
            }

            //check incoming edges
            bool root_found = false;
            Iterator<Vertex<T>> it = my_vertices.values().iterator();
            while (it.hasNext())
            {
                int in_degree = inDegree(it.next().value);
                if (in_degree == 0 && !root_found) //mark the root when found
                {
                    root_found = true;
                }
                else if (in_degree == 0 && root_found) //a second root with no incoming edge (this is a forest)
                {
                    return false;
                }
                else if (in_degree > 1) //each vertex in a tree has one incoming edge
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Shows whether the graph contains a cycle.
        /// </summary>
        /// <returns>true if a cycle exists, otherwise
        /// false.</returns>
        public bool containsCycle()
        {
            //clear previous algorithm variables
            clearAll();

            //perform a dfs search on every unchecked vertex
            Iterator<Vertex<T>> it = my_vertices.values().iterator();
            while (it.hasNext())
            {
                Vertex<T> v = it.next();
                if (!v.visited)
                {
                    //dfsCycleCheck does dfs and returns true if dfs returns to a previously visited vertex
                    if (dfsCycleCheck(new ArrayList<Vertex<T>>(), v))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Represents a string representation of the graph including vertex and edge size and a list
        /// of both vertices and edges.
        /// </summary>
        /// <returns>the string representation of the graph.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            //vertex and edge count
            builder.Append("Vertex Count: ");
            builder.Append(vertexSize());
            builder.Append(", Edge Count: ");
            builder.Append(edgeSize());

            //if there are any vertices
            if (vertexSize() > 0)
            {
                bool first = true;
                Iterator<T> it = my_vertices.keyset().iterator();
                while (it.hasNext())
                {
                    //mark the header of vertices returned
                    if (first)
                    {
                        first = false;
                        builder.Append(", Vertices: ");
                    }
                    else
                    {
                        builder.Append(", ");
                    }
                    builder.Append(it.next().ToString());
                }
            }

            //if there are any edges
            if (edgeSize() > 0)
            {
                bool first = true;
                Iterator<T> it = my_vertices.keyset().iterator();
                while (it.hasNext())
                {
                    T vertex = it.next();
                    List<SimpleEdge<T>> edges = getEdgesIncidentTo(vertex);
                    
                    //loop through all edges
                    for (int i=0; i < edges.size(); i++)
                    {
                        //mark the header of vertices returned
                        if (first)
                        {
                            first = false;
                            builder.Append(", Edges: ");
                        }
                        else
                        {
                            builder.Append(", ");
                        }
                        builder.Append(vertex.ToString());
                        builder.Append(" -> ");
                        builder.Append(edges.get(i).ToString());
                    }
                }
            }

            return builder.ToString();
        }

        //------------------- GRAPH ALGORITHMS  -----------------------

        /// <summary>
        /// Finds the shortest path between vertex the_base_vertex and all other vertices connected to
        /// the_base_vertex.
        /// </summary>
        /// <param name="the_base_vertex">the graph that is the start of each path.</param>
        /// <returns>a map holding vertex to shortest path values from the_base_vertex to all other vertices connected
        /// to the_base_vertex.</returns>
        public void unweighted(T the_base_vertex)
        {
            BasicQueue<Vertex<T>> queue = new Queue<Vertex<T>>();

            //clear all previous algorithm variables
            clearAll();

            //add the initial vertex to the list
            Vertex<T> v = getVertex(the_base_vertex);
            v.distance = 0;
            queue.add(v);
            
            //perform a breadth-first search
            while(!queue.isEmpty())
            {
                v = queue.dequeue();
                v.visited = true;
                for (int i=0; i < v.edge_list.size(); i++)
                {
                    //set the new shortest distance if applicable
                    Vertex<T> adjacent = v.edge_list.get(i).second_vertex;
                    if (v.distance + 1 < adjacent.distance)
                    {
                        adjacent.distance = v.distance + 1;
                        adjacent.last_vertex = v;
                    }

                    //setup the adjacent vertex to be visited also if not already visited
                    if (!adjacent.visited)
                    {
                        queue.enqueue(adjacent);
                    }
                }
            }
        }

        /// <summary>
        /// Performs Dijkstra's algorithm for the shortest
        /// path between some base vertex and the other
        /// vertices in a graph. These calculations are 
        /// done for non-negative edge weights.
        /// </summary>
        /// <param name="the_base_vertex">the vertex
        /// which lies at the beginning of all paths
        /// derived from Dijkstra's algorithm.</param>
        public void dijkstras(T the_base_vertex)
        {
            BasicQueue<Vertex<T>> queue = new PriorityQueue<Vertex<T>>(true, new DistanceComparator());

            //clear all previous algorithm variables
            clearAll();

            //add the initial vertex to the list
            Vertex<T> v = getVertex(the_base_vertex);
            v.distance = 0;
            queue.add(v);

            //perform a breadth-first search
            while (!queue.isEmpty())
            {
                v = queue.dequeue();
                v.visited = true;
                for (int i = 0; i < v.edge_list.size(); i++)
                {
                    //set the new shortest distance if applicable
                    Edge<T> edge = v.edge_list.get(i);
                    Vertex<T> adjacent = edge.second_vertex;

                    //check for no negative edges
                    if (edge.edge_cost < 0.0)
                    {
                        throw new IllegalStateException("You cannot perform dijkstras algorithm with an edge of negative weight.");
                    }

                    if (v.distance + edge.edge_cost < adjacent.distance)
                    {
                        adjacent.distance = v.distance + edge.edge_cost;
                        adjacent.last_vertex = v;
                    }

                    //setup the adjacent vertex to be visited also if not already visited
                    if (!adjacent.visited)
                    {
                        queue.enqueue(adjacent);
                    }
                }
            }
        }

        /// <summary>
        /// This method should only be called after the method unweighted() or dijkstras().
        /// </summary>
        /// <param name="the_end_point">the point which is the last vertex on the shortest path from the 
        /// base vertex given in the method unweighted() or dijkstras().</param>
        /// <returns>A list of vertices which form a path from the base vertex in unweighted() or dijkstras() to 
        /// the_end_point.</returns>
        public List<T> getShortestPath(T the_end_point)
        {
            Vertex<T> current = getVertex(the_end_point);
            List<T> path = new LinkedList<T>();
            while (current != null)
            {
                path.addFirst(current.value);
                current = current.last_vertex;
            }

            return path;
        }

        /// <summary>
        /// This method returns the value of the shortest path from the base point specified in
        /// unweighted() or dijkstras() to the_end_point.
        /// </summary>
        /// <param name="the_end_point">the point which is the last vertex on the shortest path from the 
        /// base vertex given in the method unweighted() or dijkstras().</param>
        /// <returns>A double value representing the cost of the shortest path across weighted
        /// edges.</returns>
        public double getShortestPathLength(T the_end_point)
        {
            return getVertex(the_end_point).distance;
        }

        //------------------- GRAPH SEARCHING ----------------------

        /// <summary>
        /// Performs a topological search of the vertices
        /// in the graph.
        /// </summary>
        /// <returns>a list of vertex labels that represent
        /// the order in which they were visited in the 
        /// topological search.</returns>
        public List<T> topologicalSearch()
        {
            if (containsCycle())
            {
                throw new IllegalStateException("This search can only be performed on a graph without cycles.");
            }
            throw new NotImplementedException("Not yet implemented.");
        }

        /// <summary>
        /// Performs a breadth-first search of the graph.
        /// </summary>
        /// <param name="the_source_vertex">the source
        /// vertex to begin the search from</param>
        /// <returns>a list of vertex labels that represent
        /// the order in which they were visited in the 
        /// breadth-first search.</returns>
        public List<T> breadthFirstSearch(T the_source_vertex)
        {
            return breadthFirstSearch(the_source_vertex, true);
        }

        /// <summary>
        /// Performs a depth-first search of the graph.
        /// </summary>
        /// <param name="the_source_vertex">the source
        /// vertex to begin the search from</param>
        /// <returns>a list of vertex labels that represent
        /// the order in which they were visited in the 
        /// depth-first search.</returns>
        public List<T> depthFirstSearch(T the_source_vertex)
        {
            //clear previous algorithm variables
            clearAll();

            Vertex<T> v = getVertex(the_source_vertex);
            List<T> traversal = new ArrayList<T>();
            depthFirstSearch(traversal, v);

            return traversal;
        }

        /// <summary>
        /// Returns a list of vertex labels when the graph is traversed
        /// with a pre-order search from a source vertex.
        /// </summary>
        /// <param name="the_source_vertex">the source vertex.</param>
        /// <returns>a list of vertex labels.</returns>
        public List<T> preOrderSearch(T the_source_vertex)
        {
            clearAll();
            List<T> traversal = new LinkedList<T>();
            preOrderSearch(traversal, getVertex(the_source_vertex));
            return traversal;
        }

        /// <summary>
        /// Returns a list of vertex labels when the graph is traversed
        /// with a in-order search from a source vertex. With the in-order
        /// traversal the first child node is traversed, then the node and 
        /// lastly all other child nodes.
        /// </summary>
        /// <param name="the_source_vertex">the source vertex.</param>
        /// <returns>a list of vertex labels.</returns>
        public List<T> inOrderSearch(T the_source_vertex)
        {
            clearAll();
            List<T> traversal = new LinkedList<T>();
            inOrderSearch(traversal, getVertex(the_source_vertex));
            return traversal;
        }

        /// <summary>
        /// Returns a list of vertex labels when the graph is traversed
        /// with a post-order search from a source vertex.
        /// </summary>
        /// <param name="the_source_vertex">the source vertex.</param>
        /// <returns>a list of vertex labels.</returns>
        public List<T> postOrderSearch(T the_source_vertex)
        {
            clearAll();
            List<T> traversal = new LinkedList<T>();
            postOrderSearch(traversal, getVertex(the_source_vertex));
            return traversal;
        }

        /// <summary>
        /// Gives an iterator that will traverse the graph according to a traversal
        /// method.
        /// </summary>
        /// <param name="the_traversal_method">the traversal method.</param>
        /// <returns>an iterator.</returns>
        public Iterator<T> iterator(GraphTraversals the_traversal_method, T the_source_vertex)
        {
            return new GraphIterator<T>(the_traversal_method, getVertex(the_source_vertex), this);
        }

        //------------------- HELPER METHODS ----------------------

        //clears all algorithm variables from the vertices in the graph.
        internal void clearAll()
        {
            Vertex<T>[] array = my_vertices.values().toArray();
            for (int i = 0; i < array.Length; i++)
            {
                array[i].clear();
            }
        }

        //gets a vertex from the vertex map.
        internal Vertex<T> getVertex(T the_value)
        {
            return my_vertices.get(the_value);
        }

        //performs a breadth-first search of the graph and returns a list of vertex labels.
        internal List<T> breadthFirstSearch(T the_source_vertex, bool the_clear_variables)
        {
            //clear previous algorithm variables
            if (the_clear_variables)
            {
                clearAll();
            }

            //standard technique for a breadth-first search
            List<T> return_value = new ArrayList<T>();
            BasicQueue<Vertex<T>> queue = new Queue<Vertex<T>>();
            queue.enqueue(getVertex(the_source_vertex));

            //pull each vertex off the queue and enqueue all adjacent vertices that have not yet
            //been visited
            while (!queue.isEmpty())
            {
                //take the next item off the queue and record if necessary and mark as visited
                Vertex<T> v = queue.dequeue();
                if (!v.visited)
                {
                    return_value.add(v.value);
                }
                v.visited = true;

                //enqueue all non-visited adjacent vertices
                for (int i = 0; i < v.edge_list.size(); i++)
                {
                    Vertex<T> adjacent = v.edge_list.get(i).second_vertex;
                    if (!adjacent.visited)
                    {
                        queue.enqueue(adjacent);
                    }
                }
            }

            return return_value;
        }

        //finds an edge in the graph and returns it.
        private Edge<T> findEdge(T the_first_vertex, T the_second_vertex)
        {
            Preconditions.checkNull(the_first_vertex);
            Preconditions.checkNull(the_second_vertex);

            //get both vertices
            Vertex<T> first = getVertex(the_first_vertex);
            Vertex<T> second = getVertex(the_second_vertex);

            if (first == null || second == null)
            {
                throw new ArgumentException("One or more vertices not found.");
            }

            //look for the edge and return the cost
            Iterator<Edge<T>> it = first.edge_list.iterator();
            while (it.hasNext())
            {
                Edge<T> edge = it.next();
                if (edge.second_vertex.Equals(second))
                {
                    return edge;
                }
            }

            throw new IllegalStateException("Edge not found in graph.");
        }

        //performs a recursive pre-order traversal of the graph.
        private void preOrderSearch(List<T> the_traversal, Vertex<T> the_current)
        {
            //mark the current vertex
            the_traversal.add(the_current.value);
            the_current.visited = true;

            //go through each edge adjacent to the current and recursively traverse if
            //it has not yet been visited.
            for (int i = 0; i < the_current.edge_list.size(); i++)
            {
                Vertex<T> v = the_current.edge_list.get(i).second_vertex;
                if (!v.visited)
                {
                    preOrderSearch(the_traversal, v);
                }
            }
        }

        //performs a recursive in-order traversal of the graph.
        private void inOrderSearch(List<T> the_traversal, Vertex<T> the_current)
        {
            //arbitrary choice of only the first child node traversed before the node itself
            if (!the_current.edge_list.isEmpty())
            {
                Vertex<T> v = the_current.edge_list.get(0).second_vertex;
                if (!v.visited)
                {
                    preOrderSearch(the_traversal, v);
                }
            }
            
            //mark the current vertex
            the_traversal.add(the_current.value);
            the_current.visited = true;

            //go through each other edge adjacent to the current and recursively traverse if
            //it has not yet been visited.
            for (int i = 1; i < the_current.edge_list.size(); i++)
            {
                Vertex<T> v = the_current.edge_list.get(i).second_vertex;
                if (!v.visited)
                {
                    preOrderSearch(the_traversal, v);
                }
            }
        }

        //performs a recursive post-order traversal of the graph.
        private void postOrderSearch(List<T> the_traversal, Vertex<T> the_current)
        {
            //go through each edge adjacent to the current and recursively traverse if
            //it has not yet been visited.
            for (int i = 0; i < the_current.edge_list.size(); i++)
            {
                Vertex<T> v = the_current.edge_list.get(i).second_vertex;
                if (!v.visited)
                {
                    preOrderSearch(the_traversal, v);
                }
            }

            //mark the current vertex
            the_traversal.add(the_current.value);
            the_current.visited = true;
        }

        //this method performs a recursive depth-first search to look for cycles in the graph.
        private bool dfsCycleCheck(List<Vertex<T>> the_vertices_seen, Vertex<T> the_source_vertex)
        {
            //mark the first vertex
            the_source_vertex.visited = true;
            the_vertices_seen.add(the_source_vertex);

            //check children and traverse recursively
            Iterator<Edge<T>> it = the_source_vertex.edge_list.iterator();
            while (it.hasNext())
            {
                Edge<T> edge = it.next();
                if (!the_vertices_seen.contains(edge.second_vertex))
                {
                    return dfsCycleCheck(the_vertices_seen, edge.second_vertex);
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        //this method performs a depth-first search recursively.
        private void depthFirstSearch(List<T> the_dfs_list, Vertex<T> the_source_vertex)
        {
            //mark the first vertex
            the_source_vertex.visited = true;
            the_dfs_list.add(the_source_vertex.value);

            //check children and traverse recursively
            Iterator<Edge<T>> it = the_source_vertex.edge_list.iterator();
            while (it.hasNext())
            {
                Edge<T> edge = it.next();
                if (!edge.second_vertex.visited)
                {
                    depthFirstSearch(the_dfs_list, edge.second_vertex);
                }
            }
        }

        //this sets up the vertex map.
        private void setupVertices(int the_number_of_vertices)
        {
            my_vertices = new HashMap<T, Vertex<T>>(the_number_of_vertices);
        }

        /// <summary>
        /// Comparator class for comparing vertices with distance values.
        /// </summary>
        private class DistanceComparator : Comparator<Vertex<T>>
        {
            /// <summary>
            /// Required compare method for the comparator interface.
            /// </summary>
            /// <param name="the_one">the first vertex.</param>
            /// <param name="the_two">the second vertex.</param>
            /// <returns>the difference of distances of the vertices. if a negative
            /// number is returned the first vertex has a smaller distance, if zero
            /// is returned the vertices have the same distance and if a positive 
            /// number is returned then the first vertex has a larger distance.</returns>
            public int compare(Vertex<T> the_one, Vertex<T> the_two)
            {
                return (int)(the_one.distance - the_two.distance);
            }
        }

        /// <summary>
        /// Comparator class for comparing the in-degree of vertices.
        /// </summary>
        private class InDegreeComparator : Comparator<Vertex<T>>
        {
            private DirectedGraph<T> my_parent;

            /// <summary>
            /// Sets up the comparator with a parent link to call the inDegree() method with.
            /// </summary>
            /// <param name="the_parent">link to parent graph.</param>
            public InDegreeComparator(DirectedGraph<T> the_parent)
            {
                my_parent = the_parent;
            }

            /// <summary>
            /// Compares the in-degree of two vertices.
            /// </summary>
            /// <param name="the_one">the first vertex.</param>
            /// <param name="the_two">the second vertex.</param>
            /// <returns>a negative number if the first vertex has a smaller in-degree,
            /// zero if both vertices have the same in-degree, otherwise a positive number
            /// and the first vertex has a larger in-degree.</returns>
            public int compare(Vertex<T> the_one, Vertex<T> the_two)
            {
                return (int)(my_parent.inDegree(the_one.value) - my_parent.inDegree(the_two.value));
            }
        }

        /// <summary>
        /// Provides internal access to the count of edges in the graph.
        /// </summary>
        internal int edge_size
        {
            get { return my_edge_size; }
            set { my_edge_size = value; }
        }
    }
}
