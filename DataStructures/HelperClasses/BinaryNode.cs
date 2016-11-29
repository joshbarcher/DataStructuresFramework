using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.HelperClasses
{
    /// <summary>
    /// Binary node with two links to child nodes. This class is useful in tree-like structures.
    /// </summary>
    /// <typeparam name="T">the reference element type to store in the node.</typeparam>
    public class BinaryNode<T> 
    {
        private T my_value;
        private BinaryNode<T> my_parent;
        private BinaryNode<T> my_left;
        private BinaryNode<T> my_right;
        
        //more information about the node as the root of a sub-tree
        private int my_size;
        private int my_height;

        //scratch variables
        private int my_stack_turn; //used for in/post/pre-order traversals with a stack

        /// <summary>
        /// Sets up the node with an element value.
        /// </summary>
        /// <param name="the_value">the value to set in the element.</param>
        public BinaryNode(T the_value)
        {
            value = the_value;
        }

        /// <summary>
        /// Sets up the node with an element value and links to its child nodes.
        /// </summary>
        /// <param name="the_value">the value to set in the element.</param>
        /// <param name="the_left">the left child node.</param>
        /// <param name="the_right">the right child node.</param>
        public BinaryNode(T the_value, BinaryNode<T> the_left, BinaryNode<T> the_right)
            : this(the_value)
        {
            left = the_left;
            right = the_right;
        }

        /// <summary>
        /// Sets up the node with an element value and links to its parent and child nodes.
        /// </summary>
        /// <param name="the_value">the value to set in the element.</param>
        /// <param name="the_parent">the parent node.</param>
        /// <param name="the_left">the left child node.</param>
        /// <param name="the_right">the right child node.</param>
        public BinaryNode(T the_value, BinaryNode<T> the_parent, BinaryNode<T> the_left, BinaryNode<T> the_right)
            : this(the_value, the_left, the_right)
        {
            parent = the_parent;
        }

        /// <summary>
        /// Provides a string representation of the binary node.
        /// </summary>
        /// <returns>a string representation of the node.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            Helpers.printElementIfNull(builder, value);

            return builder.ToString();
        }
        
        /// <summary>
        /// The node value.
        /// </summary>
        public T value
        {
            get { return my_value; }
            set { my_value = value; }
        }

        /// <summary>
        /// The parent node.
        /// </summary>
        public BinaryNode<T> parent
        {
            get { return my_parent; }
            set { my_parent = value; }
        }

        /// <summary>
        /// The left child node.
        /// </summary>
        public BinaryNode<T> left
        {
            get { return my_left; }
            set { my_left = value; }
        }

        /// <summary>
        /// The right child node.
        /// </summary>
        public BinaryNode<T> right
        {
            get { return my_right; }
            set { my_right = value; }
        }

        /// <summary>
        /// Scratch variable that allows traversal of nodes with a stack
        /// rather than with recursion.
        /// </summary>
        internal int stack_turn
        {
            get { return my_stack_turn; }
            set { my_stack_turn = value; }
        }
    }
}
