using System;
using System.Linq;
using System.Text;
using DataStructures.Exceptions;
using DataStructures.Interfaces;
using DataStructures.HelperClasses;
using DataStructures.Algorithms;

namespace DataStructures.Basic
{
    /// <summary>
    /// The ArrayList class is a basic list of elements with an array as an underlying data structure.
    /// </summary>
    /// <typeparam name="T">Reference type for elements</typeparam>
    public class ArrayList<T> : List<T> where T : class
    {
        private const int DEFAULT_SIZE = 10;

        private T[] my_array;
        private int my_capacity;
        private int my_size = 0;

        //for iterator concurrency checks
        private int my_mod_count = 0;

        /// <summary>
        /// Default constructor that sets up the list with a default size.
        /// </summary>
        public ArrayList()
        {
            setSize(DEFAULT_SIZE);
        }

        /// <summary>
        /// Sets up the list with an initial size. This can save the cost of constantly
        /// redoubling the list when adding initial items.
        /// </summary>
        /// <param name="the_initial_size">the starting capacity of the list.</param>
        public ArrayList(int the_initial_size)
        {
            setSize(the_initial_size);
        }

        /// <summary>
        /// Sets up the list with initial items and capacity. The capacity of the list is
        /// set the length of the initial elements.
        /// </summary>
        /// <param name="the_initial_elements">array of elements to fill the list with initially.</param>
        public ArrayList(T[] the_initial_elements)
        {
            setSize(the_initial_elements.Length);
            
            //copy over the elements
            foreach(T t in the_initial_elements)
            {
                add(t);
            }
        }

        /// <summary>
        /// Returns an element by index.
        /// </summary>
        /// <param name="the_index">the index of the element desired.</param>
        /// <returns>the element at the specified index.</returns>
        public T get(int the_index)
        {
            rangeCheck(the_index);

            return my_array[the_index];
        }

        /// <summary>
        /// Replaces a value in the list at a given index.
        /// </summary>
        /// <param name="the_index">the index where the replacement will occur.</param>
        /// <param name="the_new_value">the replacing value.</param>
        public void set(int the_index, T the_new_value)
        {
            rangeCheck(the_index);

            my_array[the_index] = the_new_value;
            //flag the change
            my_mod_count++;
        }

        /// <summary>
        /// Removes an elements at a specified index in the list.
        /// </summary>
        /// <param name="the_index">the index to remove the element at.</param>
        /// <returns>the element at the specified index.</returns>
        public T removeAt(int the_index)
        {
            //flag the change
            my_mod_count++;

            return removeFromIndex(the_index);
        }

        /// <summary>
        /// Shows whether the list has items in it.
        /// </summary>
        /// <returns>true if the list has no elements, otherwise false.</returns>
        public bool isEmpty()
        {
            return my_size == 0;
        }

        /// <summary>
        /// Shows the number of elements in the list.
        /// </summary>
        /// <returns>the number of elements in the list.</returns>
        public int size()
        {
            return my_size;
        }

        /// <summary>
        /// Adds an item to the end of the list.
        /// </summary>
        /// <param name="the_new_element">the element to add to the list.</param>
        /// <returns>true if the element was added, otherwise false.</returns>
        public bool add(T the_new_element)
        {
            my_size++;
            checkAfterResize();

            //flag the change
            my_mod_count++;
            my_array[my_size - 1] = the_new_element;

            return true;
        }

        /// <summary>
        /// Shows whether the specified element is in the list.
        /// </summary>
        /// <param name="the_check">the element to look for in the list.</param>
        /// <returns>true if the element is in the list, otherwise false.</returns>
        public bool contains(T the_check)
        {
            Iterator<T> it = listIterator();
            while (it.hasNext())
            {
                if (it.next().Equals(the_check))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Gets an element in the list.
        /// </summary>
        /// <param name="the_check">the element to look for in the list.</param>
        /// <returns>the element stored in the list, or null if not found.</returns>
        public T getElement(T the_check)
        {
            Iterator<T> it = listIterator();
            while (it.hasNext())
            {
                T next = it.next();
                if (next.Equals(the_check))
                {
                    return next;
                }
            }
            return null;
        }

        /// <summary>
        /// Removes an element from the list.
        /// </summary>
        /// <param name="the_removal">the element to remove.</param>
        /// <returns>true if the element was found in the list and removed, otherwise false.</returns>
        public bool remove(T the_removal)
        {
            Iterator<T> it = listIterator();
            while (it.hasNext())
            {
                if (it.next().Equals(the_removal))
                {
                    it.remove();
                    //flag the change
                    my_mod_count++;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Removes all elements from the list.
        /// </summary>
        public void clear()
        {
            setSize(DEFAULT_SIZE);
        }

        /// <summary>
        /// Returns an array representation of the elements in the list.
        /// </summary>
        /// <returns>the array.</returns>
        public T[] toArray()
        {
            return Arrays.copyArray<T>(my_array, my_size); ;
        }

        /// <summary>
        /// Returns an iterator that allows traversal over the list of elements.
        /// </summary>
        /// <returns>the iterator.</returns>
        public Iterator<T> iterator()
        {
            return new AL_Iterator<T>(ref my_array, this);
        }

        /// <summary>
        /// Returns a list iterator that allows traversal over the list of elements 
        /// in both directions.
        /// </summary>
        /// <returns>the list iterator.</returns>
        public ListIterator<T> listIterator()
        {
            return new AL_ListIterator<T>(ref my_array, this);
        }

        /// <summary>
        /// Inserts an element into the list at a specified index.
        /// </summary>
        /// <param name="the_index">the index to insert the element at.</param>
        /// <param name="the_new_value">the new element to insert.</param>
        /// <returns>true if the element was inserted, otherwise false.</returns>
        public bool insertAt(int the_index, T the_new_value)
        {
            rangeCheck(the_index);
            my_size++;
            checkAfterResize();
            //flag the change
            my_mod_count++;

            //copy over the element
            Arrays.shiftArrayElementsUp<T>(my_array, the_index, my_size);
            my_array[the_index] = the_new_value;

            return true;
        }

        /// <summary>
        /// Removes and returns the first element in the list.
        /// </summary>
        /// <returns>the first element.</returns>
        public T removeFirst()
        {
            if (size() == 0)
            {
                return null;
            }
            return removeAt(0);
        }

        /// <summary>
        /// Removes and returns the last element in the list.
        /// </summary>
        /// <returns>the last element.</returns>
        public T removeLast()
        {
            if (size() == 0)
            {
                return null;
            }
            return removeAt(size() - 1);
        }

        /// <summary>
        /// Adds an element to the end of the list (the same as add(), this is here
        /// to match the List interface requirements).
        /// </summary>
        /// <param name="the_new_value">the element to add to the list.</param>
        /// <returns>true if the new element was added, otherwise false.</returns>
        public bool addLast(T the_new_value)
        {
            return add(the_new_value);
        }

        /// <summary>
        /// Adds an element to the beginning of the list.
        /// </summary>
        /// <param name="the_new_value">the new element to add to the list.</param>
        /// <returns>true if the new element was added, otherwise false.</returns>
        public bool addFirst(T the_new_value)
        {
            return insertAt(0, the_new_value);
        }

        /// <summary>
        /// Shows the first element in the list.
        /// </summary>
        /// <returns>the first element in the list.</returns>
        public T first()
        {
            if (my_size == 0)
            {
                return null;
            }
            return my_array[0];
        }

        /// <summary>
        /// Shows the last element in the list.
        /// </summary>
        /// <returns>the last element in the list.</returns>
        public T last()
        {
            if (my_size == 0)
            {
                return null;
            }
            return my_array[my_size - 1];
        }

        /// <summary>
        /// Returns a string representation of the elements in the list.
        /// </summary>
        /// <returns>a string representation of the list.</returns>
        public override string ToString()
        {
            //quick out for empty lists
            if (isEmpty())
            {
                return "";
            }

            //concatenate the ToString() outputs of all elements in the list
            StringBuilder builder = new StringBuilder();
            builder.Append("[");
            for (int i = 0; i < my_array.Length; i++)
            {
                if (i == 0)
                {
                    Helpers.printElementIfNull(builder, my_array[i]);
                }
                else
                {
                    builder.Append(", ");
                    Helpers.printElementIfNull(builder, my_array[i]);
                }
            }
            builder.Append("]");

            return builder.ToString();
        }

        //-------------- HELPER METHODS -----------------

        //checks for valid index ranges since the capacity and size are not always equal.
        internal void rangeCheck(int the_index)
        {
            if (the_index < 0 || the_index > my_capacity)
            {
                throw new IndexOutOfRangeException("Bad index given.");
            }
        }

        //resizes the inner array if necessary.
        private void checkAfterResize()
        {
            if (my_size > my_capacity)
            {
                my_capacity = my_capacity + my_capacity;
                my_array = Arrays.copyArray<T>(my_array, my_capacity);
            }
        }

        //sets the initial size of the list.
        private void setSize(int the_size)
        {
            my_array = new T[the_size];
            my_capacity = the_size;
            my_size = 0;
        }

        //gets the modification number for managing concurrency with iterators.
        internal int getModCount()
        {
            return my_mod_count;
        }

        //removes an item from the list at a specified index.
        //NOTE: no mod_count variable is changed so this may be called by iterators.
        internal T removeFromIndex(int the_index)
        {
            rangeCheck(the_index);

            //save return value
            T removed = my_array[the_index];

            //shift elements
            Arrays.shiftArrayElementsDown<T>(my_array, the_index, my_capacity);

            //housekeeping
            my_size--;

            //return the removed item
            return removed;
        }
    }
}
