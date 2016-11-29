using System;
using System.Linq;
using System.Text;
using DataStructures.Interfaces;
using DataStructures.Exceptions;

namespace DataStructures.Basic
{
    /// <summary>
    /// Represents a stack which adds/removes items in a FIFO manner
    /// (First In First Out).
    /// </summary>
    /// <typeparam name="T">the reference type of elements in the stack.</typeparam>
    public class Stack<T> : BasicStack<T> where T : class 
    {
        internal List<T> my_list;

        /// <summary>
        /// Sets up the stack with default settings.
        /// </summary>
        public Stack()
        {
            my_list = new ArrayList<T>();
        }

        /// <summary>
        /// Sets up the stack with a hint for initial capacity.
        /// </summary>
        /// <param name="the_initial_size">the initial capacity
        /// of the stack.</param>
        public Stack(int the_initial_size)
        {
            my_list = new ArrayList<T>(the_initial_size);
        }

        /// <summary>
        /// Sets up the stack with an initial array of elements.
        /// </summary>
        /// <param name="the_initial_elements">the new elements
        /// to add.</param>
        public Stack(T[] the_initial_elements)
        {
            my_list = new ArrayList<T>(the_initial_elements);
        }

        /// <summary>
        /// Adds an element to the top of the stack.
        /// </summary>
        /// <param name="the_addition">the new element to add to the stack.</param>
        /// <returns>true if the element was added successfully, otherwise false.</returns>
        public virtual bool push(T the_addition)
        {
            return my_list.add(the_addition);
        }

        /// <summary>
        /// Removes and returns the top element of the stack.
        /// </summary>
        /// <returns>the top element.</returns>
        public T pop()
        {
            if (isEmpty())
            {
                throw new StackUnderflowException("You popped an element off an empty stack.");
            }

            return my_list.removeLast();
        }

        /// <summary>
        /// Returns the top element of the stack, but does not remove the element.
        /// </summary>
        /// <returns>the top element of the stack.</returns>
        public T peek()
        {
            return my_list.last();
        }

        /// <summary>
        /// Shows whether the stack has no elements in itself.
        /// </summary>
        /// <returns>true if no elements are in the stack, otherwise false.</returns>
        public bool isEmpty()
        {
            return my_list.isEmpty();
        }

        /// <summary>
        /// Shows the number of elements in the stack.
        /// </summary>
        /// <returns>the number of elements in the stack.</returns>
        public int size()
        {
            return my_list.size();
        }

        /// <summary>
        /// Adds (pushs) an element onto the stack.
        /// </summary>
        /// <param name="the_new_element">the new element to add to the stack.</param>
        /// <returns>true if the element was added successfully, otherwise false.</returns>
        public bool add(T the_new_element)
        {
            return push(the_new_element);
        }

        /// <summary>
        /// Shows whether the stack contains an element.
        /// </summary>
        /// <param name="the_check">the element to look for on the stack.</param>
        /// <returns>true if the stack contains an element, otherwise false.</returns>
        public bool contains(T the_check)
        {
            return my_list.contains(the_check);
        }

        /// <summary>
        /// Clears all elements from the stack.
        /// </summary>
        public void clear()
        {
            my_list.clear();
        }

        /// <summary>
        /// Returns a string representation of the list of elements in the stack.
        /// </summary>
        /// <returns>a string representation of the stack.</returns>
        public override string ToString()
        {
            return my_list.ToString();
        }
    }
}
