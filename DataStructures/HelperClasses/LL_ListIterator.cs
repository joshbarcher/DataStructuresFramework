using System;
using System.Linq;
using System.Text;
using DataStructures.Interfaces;
using DataStructures.Basic;
using DataStructures.Exceptions;

namespace DataStructures.HelperClasses
{
    /// <summary>
    /// A list iterator over a linked list which allows for traversal in
    /// both the forward and backward direction.
    /// </summary>
    /// <typeparam name="T">the reference type of elements stored in the 
    /// list.</typeparam>
    internal class LL_ListIterator<T> : ListIterator<T> where T : class
    {
        private LL_Node<T> my_current;
        private LinkedList<T> my_parent;
        private int my_mod_count;
        private int my_index = -1;
        private bool my_removed = false; //flag to avoid double removals

        /// <summary>
        /// Sets up the iterator with a link to the parent list.
        /// </summary>
        /// <param name="the_parent"></param>
        public LL_ListIterator(LinkedList<T> the_parent)
        {
            my_current = the_parent.headNode();
            my_parent = the_parent;
            my_mod_count = my_parent.getModCount();
        }

        /// <summary>
        /// Moves the iterator to the previous element in the list.
        /// </summary>
        /// <returns>the previous element in the list.</returns>
        public T previous()
        {
            modCheck();
            my_index--;
            my_parent.rangeCheck(my_index);

            //check for double removal
            if (my_removed)
            {
                my_removed = false;
            }

            //get the next value normally and return it
            my_current = my_current.prev;
            return my_current.value;
        }

        /// <summary>
        /// Shows whether the list has a previous element before the
        /// location of the iterator.
        /// </summary>
        /// <returns>true if there is a previous element, otherwise
        /// false.</returns>
        public bool hasPrevious()
        {
            return my_index > 0;
        }

        /// <summary>
        /// Moves the iterator to the next element after the current
        /// iterator position.
        /// </summary>
        /// <returns>the next element in the list.</returns>
        public T next()
        {
            modCheck();
            my_index++;
            my_parent.rangeCheck(my_index);

            //check for double removal
            if (my_removed)
            {
                my_removed = false;
            }

            //check whether we are on the first element, in this case just return the value
            if (my_index == 0)
            {
                return my_current.value;
            }
            else //advance normally here
            {
                my_current = my_current.next;
                return my_current.value;
            }
        }

        /// <summary>
        /// Shows whether there is a next element in the iteration after
        /// the current iterator element.
        /// </summary>
        /// <returns>true if there is a next element, otherwise false.</returns>
        public bool hasNext()
        {
            return my_index < my_parent.size() - 1;
        }

        /// <summary>
        /// Removes an element from the list that was last returned by
        /// a call to previous() or next().
        /// </summary>
        /// <returns>the removed element.</returns>
        public T remove()
        {
            modCheck();

            //check for double removal
            if (my_removed)
            {
                throw new IllegalStateException("You cannot remove an item twice before advancing the iterator.");
            }
            my_removed = true;

            T ret_value = my_current.value;
            my_current = my_parent.removeNode(my_current);
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
            builder.Append(printElement());

            //show whether there is another element
            builder.Append(", HasNext: ");
            builder.Append(hasNext());
            builder.Append(", HasPrevious: ");
            builder.Append(hasPrevious());

            return builder.ToString();
        }

        //-------------- HELPER METHODS -----------------

        //prints the current element look at in the iteration.
        internal string printElement()
        {
            //show the current element if any
            if (my_index < 0 || my_index >= my_parent.size() || my_current == null)
            {
                return "Current Element: null";
            }
            else
            {
                return "Current Element: " + my_current.ToString();
            }
        }

        //checks for concurrent modification during the iterators traversal.
        private void modCheck()
        {
            if (my_mod_count != my_parent.getModCount())
            {
                throw new ModificationException("Underlying structure changed while iterating.");
            }
        }
    }
}
