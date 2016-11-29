using System;
using System.Linq;
using System.Text;
using DataStructures.Interfaces;
using DataStructures.Exceptions;

namespace DataStructures.Basic
{
    /// <summary>
    /// Represents a priority queue that returns elements added to it in sorted order.
    /// </summary>
    /// <typeparam name="T">the reference type of elements added to the queue.</typeparam>
    public class PriorityQueue<T> : BasicQueue<T> where T : class
    {
        private const int DEFAULT_QUEUE_SIZE = 10;

        private BasicHeap<T> my_heap;

        /// <summary>
        /// Sets up the queue with a sorting order and comparator to sort with.
        /// </summary>
        /// <param name="the_min_queue">the sorting order.</param>
        /// <param name="the_comparator">the comparator.</param>
        public PriorityQueue(bool the_min_queue, Comparator<T> the_comparator)
        {
            setupQueueSize(the_min_queue, DEFAULT_QUEUE_SIZE, null, the_comparator);
        }

        /// <summary>
        /// Sets up the queue with a sorting order, initial size and comparator to sort with.
        /// </summary>
        /// <param name="the_min_queue">the sorting order.</param>
        /// <param name="the_initial_size">the initial size.</param>
        /// <param name="the_comparator">the comparator.</param>
        public PriorityQueue(bool the_min_queue, int the_initial_size, Comparator<T> the_comparator)
        {
            setupQueueSize(the_min_queue, DEFAULT_QUEUE_SIZE, null, the_comparator);
        }

        /// <summary>
        /// Sets up the queue with a sorting order, initial elements and comparator to sort with.
        /// </summary>
        /// <param name="the_min_queue">the sorting order.</param>
        /// <param name="the_initial_elements">the initial elements.</param>
        /// <param name="the_comparator">the comparator.</param>
        public PriorityQueue(bool the_min_queue, T[] the_initial_elements, Comparator<T> the_comparator)
        {
            setupQueueSize(the_min_queue, DEFAULT_QUEUE_SIZE, the_initial_elements, the_comparator);
        }

        /// <summary>
        /// Sets up the queue with a sorting order.
        /// </summary>
        /// <param name="the_min_queue">the sorting order.</param>
        public PriorityQueue(bool the_min_queue)
        {
            setupQueueSize(the_min_queue, DEFAULT_QUEUE_SIZE, null, null);
        }

        /// <summary>
        /// Sets up the queue with a sorting order and initial size.
        /// </summary>
        /// <param name="the_min_queue">the sorting order.</param>
        /// <param name="the_initial_size">the initial size.</param>
        public PriorityQueue(bool the_min_queue, int the_initial_size)
        {
            setupQueueSize(the_min_queue, DEFAULT_QUEUE_SIZE, null, null);
        }

        /// <summary>
        /// Sets up the queue with a sorting order and initial elements.
        /// </summary>
        /// <param name="the_min_queue">the sorting order.</param>
        /// <param name="the_initial_elements">the initial elements.</param>
        public PriorityQueue(bool the_min_queue, T[] the_initial_elements)
        {
            setupQueueSize(the_min_queue, DEFAULT_QUEUE_SIZE, the_initial_elements, null);
        }

        /// <summary>
        /// Enqueues an element into the priority queue.
        /// </summary>
        /// <param name="the_addition">the element to enqueue.</param>
        /// <returns>true if the element was added successfully, otherwise false.</returns>
        public bool enqueue(T the_addition)
        {
            try
            {
                return my_heap.add(the_addition);
            }
            catch (ClassCastException the_ex) //this will be called when percolateUp() is called
            {
                throw new ClassCastException("You did not provide a comparator to the priority queue and your " +
                    "elements are not comparable.");
            }
        }

        /// <summary>
        /// Dequeues an element from the queue. This will be the min/max element
        /// according to the ordering.
        /// </summary>
        /// <returns>the min/max element.</returns>
        public T dequeue()
        {
            try
            {
                return my_heap.deleteMin();
            }
            catch (ClassCastException the_ex) //this will be thrown when percolateDown() is called
            {
                throw new ClassCastException("You did not provide a comparator to the priority queue and your " +
                    "elements are not comparable.");
            }
        }

        /// <summary>
        /// Reveals the min/max element in the heap but does not remove it.
        /// </summary>
        /// <returns>the min/max element.</returns>
        public T poll()
        {
            return my_heap.peek();
        }

        /// <summary>
        /// Shows whether there are elements in the heap.
        /// </summary>
        /// <returns>true if no elements exist, otherwise false.</returns>
        public bool isEmpty()
        {
            return my_heap.isEmpty();
        }

        /// <summary>
        /// Shows the number of elements in the heap.
        /// </summary>
        /// <returns>the number of elements in the heap.</returns>
        public int size()
        {
            return my_heap.size();
        }

        /// <summary>
        /// Adds an element (enqueues) to the heap.
        /// </summary>
        /// <param name="the_new_element">the new element to add (enqueue)</param>
        /// <returns>true if the element was added successfully, otherwise false.</returns>
        public bool add(T the_new_element)
        {
            return enqueue(the_new_element);
        }

        /// <summary>
        /// Shows whether the priority queue contains an element.
        /// </summary>
        /// <param name="the_check">the element to search for.</param>
        /// <returns>true if the queue contains the element, otherwise false.</returns>
        public bool contains(T the_check)
        {
            return my_heap.contains(the_check);
        }

        /// <summary>
        /// Clears all elements from the queue.
        /// </summary>
        public void clear()
        {
            my_heap.clear();
        }

        /// <summary>
        /// Returns a string representation of the 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            //print size
            builder.Append("Size: ");
            builder.Append(size());

            //print the min element if present
            if (size() > 0)
            {
                builder.Append(", ");
                Helpers.printElementIfNull(builder, "Min Element", my_heap.peek());
            }

            return builder.ToString();
        }

        //---------------- HELPER METHODS -----------------

        //sets up the queue initially
        private void setupQueueSize(bool the_min_queue, int the_size, T[] the_initial_elements, Comparator<T> the_comparator)
        {
            //flexible setup that lets the user choose Comparable or Comparator as a strategy
            try 
            {
                if (the_comparator == null)
                {
                    if (the_initial_elements == null)
                    {
                        my_heap = new BinaryHeap<T>(the_min_queue, the_size);
                    }
                    else
                    {
                        my_heap = new BinaryHeap<T>(the_min_queue, the_initial_elements);
                    }
                }
                else
                {
                    if (the_initial_elements == null)
                    {
                        my_heap = new BinaryHeap<T>(the_min_queue, the_size, the_comparator);
                    }
                    else
                    {
                        my_heap = new BinaryHeap<T>(the_min_queue, the_initial_elements, the_comparator);
                    }
                }

            }
            catch (ClassCastException the_ex) //this can be thrown by buildheap()
            {
                throw new ClassCastException("You did not provide a comparator to the priority queue and your " +
                    "elements are not comparable.");
            }
        }
    }
}
