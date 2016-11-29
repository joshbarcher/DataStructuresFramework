using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStructures.Interfaces;
using DataStructures.Exceptions;
using DataStructures.Algorithms;

namespace DataStructures.Basic
{
    /// <summary>
    /// Binary heap class that will return items from itself in ascending
    /// or descending order. The type of heap min/max to determine the
    /// order of returned items is given as a flag in the constructor.
    /// </summary>
    /// <typeparam name="T">the reference type of items added to the heap.</typeparam>
    public class BinaryHeap<T> : BasicHeap<T> where T : class
    {
        private const int DEFAULT_SIZE = 10;

        private T[] my_array;
        private int my_size = 0;

        //comparator variable (if null the heap attempts to cast T to Comparable<T>)
        private Comparator<T> my_comparator;

        //the type of heap (min/max)
        private bool my_min_heap;

        /// <summary>
        /// Sets up the heap with an ordering and optional comparator.
        /// </summary>
        /// <param name="the_min_heap">ordering flag for the heap.</param>
        /// <param name="the_comparator">the comparator to use with the heap.</param>
        public BinaryHeap(bool the_min_heap, Comparator<T> the_comparator)
            : this(the_min_heap)
        {
            my_comparator = the_comparator;
        }

        /// <summary>
        /// Sets up the heap with an ordering, initial size and comparator. 
        /// </summary>
        /// <param name="the_min_heap">ordering flag for the heap.</param>
        /// <param name="the_initial_size">the initial size of the heap (to lower the cost of resizing the heap).</param>
        /// <param name="the_comparator">the comparator to use with the heap.</param>
        public BinaryHeap(bool the_min_heap, int the_initial_size, Comparator<T> the_comparator)
            : this(the_min_heap, the_initial_size)
        {
            my_comparator = the_comparator;
        }

        /// <summary>
        /// Sets up the heap with an ordering, initial items and comparator.
        /// </summary>
        /// <param name="the_min_heap">ordering flag for the heap.</param>
        /// <param name="the_initial_items">the initial items to add to the heap.</param>
        /// <param name="the_comparator">the comparator to use with the heap.</param>
        public BinaryHeap(bool the_min_heap, T[] the_initial_items, Comparator<T> the_comparator)
        {
            my_comparator = the_comparator;
            setupHeap(the_initial_items.Length);
            setupHeapItems(the_initial_items);
        }

        /// <summary>
        /// Sets up the heap with an ordering.
        /// </summary>
        /// <param name="the_min_heap">ordering flag for the heap.</param>
        public BinaryHeap(bool the_min_heap)
        {
            my_min_heap = the_min_heap;
            setupHeap(DEFAULT_SIZE);
        }

        /// <summary>
        /// Sets up the heap with an ordering and initial size.
        /// </summary>
        /// <param name="the_min_heap">ordering flag for the heap.</param>
        /// <param name="the_initial_size">the initial size of the heap (to lower the cost of resizing the heap).</param>
        public BinaryHeap(bool the_min_heap, int the_initial_size)
            : this(the_min_heap)
        {
            setupHeap(the_initial_size);
        }

        /// <summary>
        /// Sets up the heap with an ordering and initial items to add to the heap.
        /// </summary>
        /// <param name="the_min_heap">ordering flag for the heap.</param>
        /// <param name="the_initial_items">the initial items to add to the heap.</param>
        public BinaryHeap(bool the_min_heap, T[] the_initial_items)
            : this(the_min_heap)
        {
            setupHeap(the_initial_items.Length);
            setupHeapItems(the_initial_items);
        }

        /// <summary>
        /// Shows whether the heap is a min or max heap. True means min heap, otherwise max heap.
        /// </summary>
        public bool min_heap
        {
            get { return my_min_heap; }
        }

        /// <summary>
        /// Removes the min/max item from the heap and returns it.
        /// </summary>
        /// <returns>the min/max item from the heap.</returns>
        public T deleteMin()
        {
            //no deletion here
            if (size() == 0)
            {
                return null;
            }

            //replace the top item in the heap with the last index
            T return_value = my_array[1];
            my_array[1] = my_array[my_size];
            my_array[my_size] = null;
            my_size--;

            percolateDown(1, my_array[1]);

            return return_value;
        }

        /// <summary>
        /// Adds an element to the heap.
        /// </summary>
        /// <param name="the_addition">the element to add to the heap.</param>
        /// <returns>true if the element was added successfully, otherwise false.</returns>
        public bool add(T the_addition)
        {
            my_size++;

            //reheap if the array is full
            if (size() > my_array.Length - 1)
            {
                rebuildArray();
            }

            percolateUp(my_size, the_addition);
            return true;
        }

        /// <summary>
        /// Clears all elements from the heap.
        /// </summary>
        public void clear()
        {
            Arrays.clearArray<T>(my_array);
            my_size = 0;
        }

        /// <summary>
        /// Returns the min/max element in the heap.
        /// </summary>
        /// <returns>the min/max element in the heap.</returns>
        public T peek()
        {
            return my_array[1];
        }

        /// <summary>
        /// Shows the number of elements in the heap.
        /// </summary>
        /// <returns>the number of elements.</returns>
        public int size()
        {
            return my_size;
        }

        /// <summary>
        /// Shows whether the heap is empty of elements.
        /// </summary>
        /// <returns>true if there are no elements in the heap,
        /// otherwise returns false.</returns>
        public bool isEmpty()
        {
            return my_size == 0;
        }

        /// <summary>
        /// Shows whether the heap contains an element.
        /// </summary>
        /// <param name="the_item">the element to look for.</param>
        /// <returns>the element found in the heap, otherwise null.</returns>
        public bool contains(T the_item)
        {
            for (int i = 1; i <= size(); i++)
            {
                if (my_array[i].Equals(the_item))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Returns a simple string representation of the heap.
        /// </summary>
        /// <returns>a string representation.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("Heap Size: ");
            builder.Append(size());

            //append the smallest element (if there is one)
            if (size() > 0)
            {
                builder.Append(", ");
                Helpers.printElementIfNull(builder, "Min Element", peek());
            }

            return builder.ToString();
        }

        //----------------- HELPER METHODS --------------------

        //setups up the heaps internal structure with initial elements.
        private void setupHeapItems(T[] the_initial_items)
        {
            //copies across the new items and sets the size of the heap
            copyArrayToHeapArray(the_initial_items);
            my_size = the_initial_items.Length;

            //re-establishes the heap ordering
            buildHeap();
        }

        //This runs in O(n) time to build a heap out of elements that can be in any order.
        private void buildHeap()
        {
            //only consider elements with children
            for (int i = size() / 2; i > 0; i--)
            {
                percolateDown(i, my_array[i]);
            }
        }

        //copies elements to the heap inner array.
        private void copyArrayToHeapArray(T[] the_elements)
        {
            for (int i = 0; i < the_elements.Length; i++)
            {
                my_array[i + 1] = the_elements[i];
            }
        }

        //percolates an element down in the heap (used for removals).
        private void percolateDown(int the_index, T the_new_element)
        {
            int last = the_index;

            //percolate up
            while (last + last <= size()) //2i (the left child)
            {
                //get children
                T left_child = getElement(the_index + the_index);
                T right_child = getElement(the_index + the_index + 1);

                if (right_child == null)
                {
                    the_index = the_index + the_index;
                    if (!checkAndSwap(left_child, the_new_element, last, the_index))
                    {
                        break;
                    }
                }
                else
                {
                    //left child is smaller
                    if (compare(left_child, right_child) < 0)
                    {
                        the_index = the_index + the_index;
                        if (!checkAndSwap(left_child, the_new_element, last, the_index))
                        {
                            break;
                        }
                    }
                    else //right child is smaller
                    {
                        the_index = the_index + the_index + 1;
                        if (!checkAndSwap(right_child, the_new_element, last, the_index))
                        {
                            break;
                        }
                    }
                }

                last = the_index;
            }
        }

        //checks for moving an element down in percolateDown() and swaps if necesary.
        //returns true if the swap was made of false if not.
        private bool checkAndSwap(T the_left_element, T the_right_element, int the_last_index, int the_new_index)
        {
            if (compare(the_left_element, the_right_element) < 0) //2i (the left child)
            {
                //swap elements that are higher in the heap (less than for minheap, greater than for a maxheap)
                Arrays.swap<T>(my_array, the_last_index, the_new_index);
                return true;
            }
            else //new element is larger than both
            {
                return false; ;
            }
        }

        //percolates an element up in the heap (used for additions).
        private void percolateUp(int the_index, T the_new_element)
        {
            int last = the_index;

            //percolate up
            while ((the_index /= 2) > 0)
            {
                if (compare(my_array[the_index], the_new_element) > 0)
                {
                    //swap elements that are lower in the heap (greater than for minheap, less than for a maxheap)
                    Arrays.swap<T>(my_array, last, the_index);
                }
                else
                {
                    break;
                }
                last = the_index;
            }
        
            //put the last element on the heap
            my_array[last] = the_new_element;
        }

        //gets an element at an index in the inner array.
        private T getElement(int the_index)
        {
            if (the_index > size())
            {
                return null;
            }
            else
            {
                return my_array[the_index];
            }
        }

        // Simple comparator that swaps the heap from min/max depending on the constructor flag.
        private int compare(T the_first, T the_second)
        {
            int comparison;
            
            if (my_comparator == null)
            {
                if (!(the_first is Comparable<T>))
                {
                    throw new ClassCastException("You did not provide a comparator to the binary heap and your " +
                    "elements are not comparable.");
                }
                else 
                {
                    comparison = ((Comparable<T>)the_first).compareTo(the_second);
                }
            }
            else 
            {
                comparison = my_comparator.compare(the_first, the_second);
            }

            //if a max heap then reverse the comparison
            if (!my_min_heap)
            {
                comparison *= -1;
            }

            return comparison;
        }

        //rebuilds the inner array to a larger capacity.
        private void rebuildArray()
        {
            my_array = Arrays.copyArray<T>(my_array, my_array.Length + my_array.Length);
        }

        //sets up the array with a hint about its capacity.
        private void setupHeap(int the_initial_size)
        {
            my_array = new T[the_initial_size + 1]; //+1 for the header element
        }

        //access internally to the array elements.
        internal T[] internal_array
        {
            get { return my_array; }
        }
    }
}
