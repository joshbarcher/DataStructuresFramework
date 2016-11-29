using System;
using System.Linq;
using System.Text;
using DataStructures.Interfaces;

namespace DataStructures.Basic
{
    /// <summary>
    /// Queue class that adds/removes elements in a LIFO fashion
    /// (Last In First Out).
    /// </summary>
    /// <typeparam name="T">the reference type of elements in the queue.</typeparam>
    public class Queue<T> : BasicQueue<T> where T : class 
    {
        private List<T> my_list = new LinkedList<T>();

        /// <summary>
        /// Sets up the queue with default settings.
        /// </summary>
        public Queue()
        {
            //do nothing
        }

        /// <summary>
        /// Sets up the queue with initial elements.
        /// </summary>
        /// <param name="the_initial_elements">the initial elements.</param>
        public Queue(T[] the_initial_elements)
        {
            //enqueue each
            foreach (T t in the_initial_elements)
            {
                enqueue(t);
            }
        }

        /// <summary>
        /// Adds an element to the queue.
        /// </summary>
        /// <param name="the_addition">the new element to add.</param>
        /// <returns>true if the element was added correctly, otherwise false.</returns>
        public bool enqueue(T the_addition)
        {
            return my_list.addFirst(the_addition);
        }

        /// <summary>
        /// Removes and returns the first element from the queue.
        /// </summary>
        /// <returns>the first element in the queue.</returns>
        public T dequeue()
        {
            return my_list.removeLast();
        }

        /// <summary>
        /// Returns the first element in the queue, but does not remove it.
        /// </summary>
        /// <returns>the first element in the queue.</returns>
        public T poll()
        {
            return my_list.last();
        }

        /// <summary>
        /// Shows whether the queue has no elements.
        /// </summary>
        /// <returns>true if the queue has no elements, otherwise false.</returns>
        public bool isEmpty()
        {
            return my_list.size() == 0;
        }

        /// <summary>
        /// Shows the number of elements in the queue.
        /// </summary>
        /// <returns>the number of elements in the list.</returns>
        public int size()
        {
            return my_list.size();
        }

        /// <summary>
        /// Adds an element to the front of the queue (enqueues it).
        /// </summary>
        /// <param name="the_new_element">the new element to add</param>
        /// <returns>true if the new element was added correctly, otherwise false.</returns>
        public bool add(T the_new_element)
        {
            return enqueue(the_new_element);
        }

        /// <summary>
        /// Shows whether the queue contains an element.
        /// </summary>
        /// <param name="the_check">the element to look for.</param>
        /// <returns>true if the element is in the queue, otherwise false.</returns>
        public bool contains(T the_check)
        {
            return my_list.contains(the_check);
        }

        /// <summary>
        /// Clears all elements from the queue.
        /// </summary>
        public void clear()
        {
            my_list.clear();
        }

        /// <summary>
        /// Returns a string representation of the queue.
        /// </summary>
        /// <returns>a string representation.</returns>
        public override string ToString()
        {
            return my_list.ToString();
        }
    }
}
