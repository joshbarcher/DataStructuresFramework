using System;
using System.Linq;
using System.Text;
using Algorithms;
using DataStructures.Exceptions;
using DataStructures.Interfaces;
using DataStructures.HelperClasses;

namespace DataStructures.Basic
{
    /// <summary>
    /// This structure holds elements without duplicates. The HashSet stores elements
    /// using a hash table and can quickly, roughly O(1), access an item in the collection.
    /// </summary>
    /// <typeparam name="T">the reference type of elements stored in the collection.</typeparam>
    public class HashSet<T> : Set<T> where T: class
    {
        private const int GROWTH_RATIO = 3;
        private const double MAX_FILL_RATIO = 0.7;
        private const int DEFAULT_SIZE = 10;

        private HashEntry<T>[] my_array;
        private int my_size = 0;
        private int my_filled = 0; //my_size plus removed items that must remain for hash purposes
        private int my_mod_count = 0;

        /// <summary>
        /// Sets up the hash set with default values.
        /// </summary>
        public HashSet()
        {
            setSize(DEFAULT_SIZE);
        }

        /// <summary>
        /// Sets up the hash set with an initial estimated capacity.
        /// </summary>
        /// <param name="the_initial_size"></param>
        public HashSet(int the_initial_size)
        {
            setSize(the_initial_size * GROWTH_RATIO);
        }

        /// <summary>
        /// Shows whether the set is empty.
        /// </summary>
        /// <returns>returns true if empty, otherwise false.</returns>
        public bool isEmpty()
        {
            return my_size == 0;
        }

        /// <summary>
        /// Shows the number of elements in the collection.
        /// </summary>
        /// <returns>the number of elements in the collection.</returns>
        public int size()
        {
            return my_size;
        }

        /// <summary>
        /// Adds an element to the collection.
        /// </summary>
        /// <param name="the_new_element">the new element to add to the set.</param>
        /// <returns>true if the element was successfully added, otherwise false.</returns>
        public bool add(T the_new_element)
        {
            //rehash the set if it grows beyond twice the full size of the inner array
            if (my_filled > my_array.Length * MAX_FILL_RATIO)
            {
                rehash();
            }

            int hash_index = hash(the_new_element, my_array.Length);

            //check for a previous addition
            if (contains(the_new_element, hash_index))
            {
                return false;
            }

            my_mod_count++;
            my_size++;
            my_filled++;

            //add the new item
            linearProbe(the_new_element, hash_index);

            return true;
        }

        /// <summary>
        /// Gets an element that is stored in the set.
        /// </summary>
        /// <param name="the_check">the element to search for in the collection.</param>
        /// <returns>the element found in the collection or null if it is not found.</returns>
        public T getElement(T the_check)
        {
            int hash_value = getElementIndex(the_check, hash(the_check, my_array.Length));
            HashEntry<T> h_entry = null;
            if (hash_value != -1)
            {
                h_entry = my_array[hash_value];
            }

            if (h_entry == null)
            {
                return null;
            }
            else
            {
                return h_entry.entry;
            }
        }

        /// <summary>
        /// Shows whether an element is in the set.
        /// </summary>
        /// <param name="the_check">the element to search for in the collection.</param>
        /// <returns>true if the element exists, otherwise false.</returns>
        public bool contains(T the_check)
        {
            return contains(the_check, hash(the_check, my_array.Length));
        }

        /// <summary>
        /// Removes an element from the set.
        /// </summary>
        /// <param name="the_removal">the element to remove.</param>
        /// <returns>true if the element was found and removed, otherwise false.</returns>
        public bool remove(T the_removal)
        {
            //remove the element and get its index
            int removed_index = getElementIndex(the_removal, hash(the_removal, my_array.Length));
            
            if (removed_index == -1) //not found
            {
                return false;
            }
            else //found
            {
                my_mod_count++;
                my_size--;
                my_array[removed_index].active = false;
                return true;
            }
        }

        /// <summary>
        /// Clears the set of all elements.
        /// </summary>
        public void clear()
        {
            my_mod_count++;
            setSize(DEFAULT_SIZE);
        }

        /// <summary>
        /// Gives an array representation of the set. This array elements
        /// are not guaranteed to be in any natural order.
        /// </summary>
        /// <returns>the array of elements.</returns>
        public T[] toArray()
        {
            T[] return_value = new T[my_size];
            int current_index = 0;

            //loop through the inner table and add the non-null entries to the return array
            foreach (HashEntry<T> h in my_array)
            {
                if (h != null && h.active)
                {
                    return_value[current_index] = h.entry;
                    current_index++;
                }
            }

            return return_value;
        }

        /// <summary>
        /// Gives an iterator to iterate over elements in the set.
        /// </summary>
        /// <returns>an iterate to iterate over the set.</returns>
        public Iterator<T> iterator()
        {
            return new HashIterator<T>(ref my_array, this);
        }

        /// <summary>
        /// Gives a string representation of the set elements.
        /// </summary>
        /// <returns>a string representation.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            //print out each element in the set
            bool first = true;
            Iterator<T> it = iterator();
            while (it.hasNext())
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    builder.Append(", ");
                }

                //print elements
                T next = it.next();
                if (next != null)
                {
                    builder.Append(next.ToString());
                }
                else
                {
                    builder.Append("null");
                }
            }
            return builder.ToString();
        }

        //----------------- HELPER METHODS -------------------

        //hash function to insert items into the set.
        internal virtual int hash(T the_add, int the_table_size)
        {
            int hash = the_add.GetHashCode();
            return Math.Abs(37 * hash + hash % 37) % the_table_size;
        }

        //determines whether an element is in the set, using the object's Equals() method and 
        //the object's hash code.
        private bool contains(T the_check, int the_hash)
        {
            return getElementIndex(the_check, the_hash) != -1;
        }

        //performs a linear probe to place items in the hash table.
        private void linearProbe(T the_add, int the_new_index)
        {
            int new_index = the_new_index;
            while (true)
            {
                if (my_array[new_index] == null)
                {
                    my_array[new_index] = new HashEntry<T>(the_add);
                    break;
                }

                //clock arithmetic
                new_index = (new_index + 1) % my_array.Length;
            }
        }

        //resizes the inner table and replaces all elements into the table using
        //the standard hash function.
        private void rehash()
        {
            HashEntry<T>[] old_entries = my_array;

            //prepare the new hash table
            my_array = new HashEntry<T>[old_entries.Length * GROWTH_RATIO];
            my_filled = 0;
            my_size = 0;

            //replace all elements into the table
            foreach (HashEntry<T> h in old_entries)
            {
                if (h != null && h.active)
                {
                    add(h.entry);
                }
            }
        }

        //gets an element by its hash index position
        private int getElementIndex(T the_element, int the_hash_index)
        {
            while (true)
            {
                HashEntry<T> element = my_array[the_hash_index];
                if (element == null)
                {
                    return -1;
                }
                else if (the_element.Equals(element.entry) && element.active)
                {
                    return the_hash_index;
                }

                //clock arithmetic
                the_hash_index = (the_hash_index + 1) % my_array.Length;
            }
        }

        //sets the initial size of the hash sets inner hash table.
        private void setSize(int the_size)
        {
            my_array = new HashEntry<T>[the_size];
            my_size = 0;
            my_filled = 0;
        }

        //returns a modification count for iterators over the hash set.
        internal int getModCount()
        {
            return my_mod_count;
        }

        //lowers the size value of the set (used by the iterators of this class).
        internal void decrementSize()
        {
            my_size--;
        }

        //provides access to the inner array of this class for testing and academic purposes.
        internal HashEntry<T>[] inner_array
        {
            get { return my_array; }
        }
    }
}
