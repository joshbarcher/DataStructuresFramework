using System;
using System.Linq;
using System.Text;
using DataStructures.Basic;
using DataStructures.Interfaces;

namespace DataStructures.HelperClasses
{
    /// <summary>
    /// Represents a node in an M-ary tree that can have a variable number
    /// of children. The number M is not strictly enforced.
    /// </summary>
    /// <typeparam name="T">the reference type of values stored in the node.</typeparam>
    internal class MAryNode<T> where T : class
    {
        private T my_value;
        private List<MAryNode<T>> my_children;

        /// <summary>
        /// This constructor sets up the node with a value.
        /// </summary>
        /// <param name="the_value">the value to store in the node.</param>
        public MAryNode(T the_value)
        {
            my_value = the_value;
        }

        /// <summary>
        /// Adds a child to the node.
        /// </summary>
        /// <param name="the_child"></param>
        public void addChild(T the_child)
        {
            if (my_children == null)
            {
                my_children = new LinkedList<MAryNode<T>>();
            }
            my_children.add(new MAryNode<T>(the_child));
        }

        /// <summary>
        /// Provide a string representation of the M-ary node.
        /// </summary>
        /// <returns>a string representation.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            Helpers.printElementIfNull(builder, value);

            return builder.ToString();
        }

        /// <summary>
        /// The value stored in the node.
        /// </summary>
        public T value
        {
            get { return my_value; }
            set { my_value = value; }
        }

        /// <summary>
        /// The list of children of the node.
        /// </summary>
        internal List<MAryNode<T>> children
        {
            get { return my_children; }
            set { my_children = value; }
        }
    }
}
