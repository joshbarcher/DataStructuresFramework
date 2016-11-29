using System;
using System.Linq;
using System.Text;
using DataStructures.Interfaces;
using DataStructures.Basic;

namespace DataStructures.HelperClasses
{
    /// <summary>
    /// Represents a vertex in a graph.
    /// </summary>
    /// <typeparam name="T">the reference type of the vertex label.</typeparam>
    public class Vertex<T> where T : class
    {
        private T my_value;
        private List<Edge<T>> my_edge_list;

        //algorithm variables
        private bool my_visited = false;
        private double my_distance = 0.0;
        private Vertex<T> my_last_vertex;
        private int my_stack_turn;

        /// <summary>
        /// Sets up the vertex with a label.
        /// </summary>
        /// <param name="the_value">the label for the vertex.</param>
        public Vertex(T the_value)
        {
            my_value = the_value;
            my_edge_list = new LinkedList<Edge<T>>();
        }

        /// <summary>
        /// Shows whether the vertex has an edge to another vertex.
        /// </summary>
        /// <param name="the_check">the other vertex to look for in the edge list.</param>
        /// <returns>true if an edge exists between the this vertex and the other
        /// specified.</returns>
        public bool hasEdgeToVertex(T the_check)
        {
            for (int i = 0; i < my_edge_list.size(); i++)
            {
                if (my_edge_list.get(i).second_vertex.value.Equals(the_check))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Adds an edge from this vertex to another vertex.
        /// </summary>
        /// <param name="the_other_vertex">the other vertex of the edge.</param>
        /// <param name="the_cost">the cost of the edge.</param>
        /// <returns>true if the edge was not already added, otherwise false</returns>
        public bool addEdge(Vertex<T> the_other_vertex, double the_cost)
        {
            Edge<T> edge = new Edge<T>(this, the_other_vertex, the_cost);
            if (!my_edge_list.contains(edge))
            {
                my_edge_list.add(edge);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Removes an edge from the vertex to another vertex.
        /// </summary>
        /// <param name="the_other_vertex">the other vertex of the edge.</param>
        /// <returns>true if the edge is found, otherwise false.</returns>
        public bool removeEdge(Vertex<T> the_other_vertex)
        {
            for (int i = 0; i < my_edge_list.size(); i++)
            {
                if (my_edge_list.get(i).second_vertex.Equals(the_other_vertex))
                {
                    my_edge_list.removeAt(i);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Clears all algorithm variables from the vertex.
        /// </summary>
        public void clear()
        {
            visited = false;
            distance = Double.MaxValue;
            last_vertex = null;
            my_stack_turn = 0;
        }

        /// <summary>
        /// Provide a string representation of the vertex.
        /// </summary>
        /// <returns>a string representation.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("[");

            //print elements in the vertex
            Helpers.printElementIfNull(builder, "Label", value);
            builder.Append(", ");

            //edges adjacent
            if (edge_list == null)
            {
                builder.Append("Edges Adjacent: 0");
            }
            else
            {
                Helpers.printElementIfNull(builder, "Edges Adjacent", edge_list.size());
            }

            builder.Append(", ");
            Helpers.printElementIfNull(builder, "Visited", visited);
            builder.Append(", ");
            Helpers.printElementIfNull(builder, "Distance", distance);
            builder.Append(", ");
            Helpers.printElementIfNull(builder, "Stack Turn", stack_turn);
            builder.Append("]");

            return builder.ToString();
        }

        /// <summary>
        /// The value of the vertex.
        /// </summary>
        public T value
        {
            get { return my_value; }
            set { my_value = value; }
        }

        /// <summary>
        /// The edge list of the vertex.
        /// </summary>
        internal List<Edge<T>> edge_list
        {
            get { return my_edge_list; }
            set { my_edge_list = value; }
        }

        /// <summary>
        /// The visited algorithm variable. Used for searching algorithms.
        /// </summary>
        public bool visited
        {
            get { return my_visited; }
            set { my_visited = value; }
        }

        /// <summary>
        /// The distance algorithm variable. Used for shortest path algorithms.
        /// </summary>
        public double distance
        {
            get { return my_distance; }
            set { my_distance = value; }
        }

        /// <summary>
        /// The last vertex algorithm variable. Used for traversal algorithms.
        /// </summary>
        public Vertex<T> last_vertex
        {
            get { return my_last_vertex; }
            set { my_last_vertex = value; }
        }

        /// <summary>
        /// Scratch variable that allows traversal of nodes with a stack
        /// rather than with recursion.
        /// </summary>
        public int stack_turn
        {
            get { return my_stack_turn; }
            set { my_stack_turn = value; }
        }
    }
}
