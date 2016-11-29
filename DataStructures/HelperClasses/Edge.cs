using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStructures.Interfaces;

namespace DataStructures.HelperClasses
{
    /// <summary>
    /// Represents an directed/undirected edge in a graph.
    /// </summary>
    /// <typeparam name="T">the reference type of the vertex labels in
    /// the graph.</typeparam>
    internal class Edge<T> : SimpleEdge<T> where T : class
    {
        private Vertex<T> my_first_vertex;
        private Vertex<T> my_second_vertex;
        private double my_edge_cost;

        /// <summary>
        /// This constructor sets up the edge with both vertices and a cost.
        /// </summary>
        /// <param name="the_first_vertex">the first vertex in the edge.</param>
        /// <param name="the_second_vertex">the second vertex in the edge.</param>
        /// <param name="the_edge_cost">the cost of the edge.</param>
        public Edge(Vertex<T> the_first_vertex, Vertex<T> the_second_vertex, double the_edge_cost)
        {
            my_first_vertex = the_first_vertex;
            my_second_vertex = the_second_vertex;
            my_edge_cost = the_edge_cost;
        }

        /// <summary>
        /// Checks for equality between edges. This method ignores cost when comparing edges.
        /// </summary>
        /// <param name="the_other">the other edge to check for equality.</param>
        /// <returns>true if the edges are equal, otherwise false.</returns>
        public override bool Equals(object the_other)
        {
            if (the_other == null || !(the_other is Edge<T>))
            {
                return false;
            }
            else
            {
                //only compare the matching vertices and don't use the weight for comparison
                Edge<T> other = (Edge<T>)the_other;
                return first_vertex.Equals(other.first_vertex) && second_vertex.Equals(other.second_vertex);
            }
        }

        /// <summary>
        /// Returns a hash code based on both vertex hash codes.
        /// </summary>
        /// <returns>an integer hash code for the edge.</returns>
        public override int GetHashCode()
        {
            return first_vertex.GetHashCode() + second_vertex.GetHashCode();
        }

        /// <summary>
        /// Returns a string representation of the edge.
        /// </summary>
        /// <returns>a string representation.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            //print vertices
            Helpers.printElementIfNull(builder, "V1", first_vertex);
            builder.Append(", ");
            Helpers.printElementIfNull(builder, "V2", second_vertex);

            //print the cost
            builder.Append(", Cost: ");
            builder.Append(edge_cost.ToString());

            return builder.ToString();
        }

        //----------------------- HELPER METHODS --------------------

        public T first_label 
        {
            get { return first_vertex.value;  }
        }

        public T second_label
        {
            get { return second_vertex.value; }
        }

        /// <summary>
        /// The first edge vertex.
        /// </summary>
        public Vertex<T> first_vertex
        {
            get { return my_first_vertex; }
            set { my_first_vertex = value; }
        }

        /// <summary>
        /// The second edge vertex.
        /// </summary>
        public Vertex<T> second_vertex
        {
            get { return my_second_vertex; }
            set { my_second_vertex = value; }
        }

        /// <summary>
        /// The edge cost.
        /// </summary>
        public double edge_cost
        {
            get { return my_edge_cost; }
            set { my_edge_cost = value; }
        }
    }
}
