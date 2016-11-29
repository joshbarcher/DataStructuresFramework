using System;
using System.Linq;
using System.Text;
using DataStructures.Basic;
using DataStructures.Interfaces;
using DataStructures.Exceptions;

namespace DataStructures.HelperClasses
{
    /// <summary>
    /// Basic list iterator that allows for iteration over the ArrayList in either the
    /// forward or reverse direction.
    /// </summary>
    /// <typeparam name="T">Elements in the array.</typeparam>
    internal class AL_ListIterator<T> : ListIterator<T> where T : class
    {
        private T[] my_array;
        private ArrayList<T> my_parent;
        private int my_index = -1;
        private bool my_removed = false; //flag to avoid double removals

        //modification variable to track whether we are operating on an 
        //unchanged list
        private int my_mod_count;

        /// <summary>
        /// This constructor just sets up links between the iterator and the
        /// list it is iterating over. A link to the inner array is provided
        /// for ease of programming.
        /// </summary>
        /// <param name="the_array">the inner array of the parent.</param>
        /// <param name="the_parent">link to the parent list.</param>
        public AL_ListIterator(ref T[] the_array, ArrayList<T> the_parent)
        {
            my_array = the_array;
            my_parent = the_parent;
            my_mod_count = my_parent.getModCount();
        }

        /// <summary>
        /// Moves the iterator to a previous element.
        /// </summary>
        /// <returns>the previous element in the iteration of elements.</returns>
        public T previous()
        {
            modCheck();
            my_index--;

            //check the current index so the iterator does not go past
            //the beginning of the list.
            my_parent.rangeCheck(my_index);

            //check for double removal
            if (my_removed)
            {
                my_removed = false;
            }

            return my_array[my_index];
        }

        /// <summary>
        /// Shows whether there is a previous item in the iteration of elements.
        /// </summary>
        /// <returns>true if a previous item exists, otherwise false</returns>
        public bool hasPrevious()
        {
            return my_index > 0;
        }

        /// <summary>
        /// Shows the next item in the iteration of elements.
        /// </summary>
        /// <returns>the next item in the iteration of elements.</returns>
        public T next()
        {
            modCheck();
            my_index++;

            //check the current index so the iterator does not go past
            //the end of the list.
            my_parent.rangeCheck(my_index);

            //check for double removal
            if (my_removed)
            {
                my_removed = false;
            }

            return my_array[my_index];
        }

        /// <summary>
        /// Shows whether there is a next item in the iteration of elements.
        /// </summary>
        /// <returns>true if a next item exists, otherwise false</returns>
        public bool hasNext()
        {
            return my_index < my_parent.size() - 1;
        }

        /// <summary>
        /// Removes an item from the list. This will remove the last item that was removed
        /// by a call to next() or previous(), the item before the last removal if multiple
        /// removals were made, the starting item if the previous starting item was already
        /// removed or the last item if the last item was previously removed.
        /// </summary>
        /// <returns></returns>
        public T remove()
        {
            modCheck();

            if (my_removed)
            {
                throw new IllegalStateException("You cannot remove an item twice before advancing the iterator.");
            }

            my_removed = true;
            T ret_value = my_parent.removeFromIndex(my_index);
            my_index--;

            return ret_value;
        }

        /// <summary>
        /// Provide a string representation of the iterator.
        /// </summary>
        /// <returns>a string representation.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            //show the current element if any
            builder.Append(printCurrentElement());

            //show whether there is another element
            builder.Append(", HasNext: ");
            builder.Append(hasNext());
            builder.Append(", HasPrevious: ");
            builder.Append(hasPrevious());

            return builder.ToString();
        }

        //-------------- HELPER METHODS -----------------

        internal string printCurrentElement()
        {
            //show the current element if any
            if (my_index < 0 || my_index > my_array.Length || my_array[my_index] == null)
            {
                return "Current Element: null";
            }
            else
            {
                return "Current Element: " + my_array[my_index].ToString();
            }
        }

        //checks for concurrency issues (changing the list while still iterating).
        private void modCheck()
        {
            if (my_mod_count != my_parent.getModCount())
            {
                throw new ModificationException("Underlying structure changed while iterating.");
            }
        }
    }
}
