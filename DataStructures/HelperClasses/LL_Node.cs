using System;
using System.Linq;
using System.Text;

namespace DataStructures.HelperClasses
{
    /// <summary>
    /// Node class with a single link to another next and previous node. Useful in linked list classes.
    /// </summary>
    /// <typeparam name="T">the reference type of the element stored in the node.</typeparam>
    internal class LL_Node<T> where T : class
    {
        private T my_value;
        private LL_Node<T> my_next;
        private LL_Node<T> my_prev;

        /// <summary>
        /// Sets up the node with an element, a link to the next and previous nodes.
        /// </summary>
        /// <param name="the_value">the element value.</param>
        /// <param name="the_next">the next node link.</param>
        /// <param name="the_prev">the previous node link.</param>
        public LL_Node(T the_value, LL_Node<T> the_next, LL_Node<T> the_prev)
        {
            my_value = the_value;
            my_next = the_next;
            my_prev = the_prev;
        }

        /// <summary>
        /// Provide a string representation of the linked list node.
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
        /// The next node link.
        /// </summary>
        public LL_Node<T> next
        {
            get { return my_next; }
            set { my_next = value; }
        }

        /// <summary>
        /// The previous node link.
        /// </summary>
        public LL_Node<T> prev
        {
            get { return my_prev; }
            set { my_prev = value; }
        }
    }
}
