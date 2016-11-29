using System;
using System.Linq;
using System.Text;
using DataStructures.Interfaces;
using DataStructures.Basic;
using DataStructures.Exceptions;

namespace DataStructures.HelperClasses
{ 
    /// <summary>
    /// This is an internal iterator for the hash set class.
    /// </summary>
    /// <typeparam name="T">the reference type of elements stored in the set.</typeparam>
    internal class HashIterator<T> : Iterator<T> where T : class
    {
        private HashEntry<T>[] my_array;

        private int my_mod_count = 0;
        private int my_index = -1;
        private int my_items = 0;
        private int my_total_items;
        private HashSet<T> my_parent;

        private HashEntry<T> my_last_entry;

        /// <summary>
        /// Sets up the iterator with the inner array of the hash set and a link to the
        /// parent set.
        /// </summary>
        /// <param name="the_array">the array of entries.</param>
        /// <param name="the_parent">the parent set.</param>
        public HashIterator(ref HashEntry<T>[] the_array, HashSet<T> the_parent)
        {
            my_array = the_array;
            my_parent = the_parent;
            my_mod_count = my_parent.getModCount();
            my_total_items = my_parent.size();
        }

        /// <summary>
        /// Shows whether the iterator has more elements to iterate over.
        /// </summary>
        /// <returns>true if more elements exist, otherwise false.</returns>
        public bool hasNext()
        {
            modCheck();
            return my_items < my_total_items;
        }

        /// <summary>
        /// Gets the next element from the iterator.
        /// </summary>
        /// <returns>the next element in the iteration.</returns>
        public T next()
        {
            modCheck();

            //get the next non-null and active element
            HashEntry<T> next = my_last_entry = iterateToNextActiveElement();
            my_items++;
            return next.entry;
        }

        /// <summary>
        /// Removes an element from the set through the iterator.
        /// </summary>
        /// <returns>the removed element in the set.</returns>
        public T remove()
        {
            modCheck();

            if (my_items == 0)
            {
                throw new InvalidOperationException("You cannot remove an item before iterating to an element.");
            }
            else if (my_last_entry == null)
            {
                throw new InvalidOperationException("You have to iterate to a new element before calling remove().");
            }

            //flag the element as dead in the set and remove the link to the item.
            //this forces another call to next() before being able to remove() again.
            my_last_entry.active = false;
            T return_value = my_last_entry.entry;
            my_last_entry = null;
            my_parent.decrementSize();

            return return_value;
        }

        /// <summary>
        /// Returns a string representation of the iterator.
        /// </summary>
        /// <returns>a string representation.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            //print the entry
            Helpers.printElementIfNull(builder, "Current", my_last_entry);

            //print hasNext()
            builder.Append(", hasNext: ");
            builder.Append(hasNext());

            return builder.ToString();
        }

        //------------------ HELPER METHODS -------------------

        //iterates to the next non-null and active element in the set.
        private HashEntry<T> iterateToNextActiveElement()
        {
            //find the next active element
            HashEntry<T> next;
            do
            {
                my_index++;
                next = my_array[my_index];
            } while (next == null || !next.active);

            return next;
        }

        //checks for concurrent action on the set during the iteration.
        private void modCheck()
        {
            if (my_parent.getModCount() != my_mod_count)
            {
                throw new ModificationException("Underlying structure changed while iterating.");
            }
        }
    }
}
