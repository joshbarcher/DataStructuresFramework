using System;
using System.Linq;
using System.Text;
using DataStructures.Interfaces;
using DataStructures.Basic;

namespace DataStructures.HelperClasses
{
    /// <summary>
    /// Iterator used to iterate through the elements in the ArrayList.
    /// </summary>
    /// <typeparam name="T">Elements in the array.</typeparam>
    internal class AL_Iterator<T> : Iterator<T> where T : class
    {
        //Inner representation. This is used according to the adapter pattern to prevent redundant code.
        private AL_ListIterator<T> my_iterator;

        /// <summary>
        /// This constructor sets up the iterator so that it has proper links to both the
        /// data being iterated over and the parent list.
        /// </summary>
        /// <param name="the_array">the data array.</param>
        /// <param name="the_parent">the parent list.</param>
        public AL_Iterator(ref T[] the_array, ArrayList<T> the_parent)
        {
            my_iterator = new AL_ListIterator<T>(ref the_array, the_parent);
        }

        /// <summary>
        /// Shows the next item in the iteration of elements.
        /// </summary>
        /// <returns>the next item in the iteration of elements.</returns>
        public T next()
        {
            return my_iterator.next();
        }

        /// <summary>
        /// Shows whether there is a next item in the iteration of elements.
        /// </summary>
        /// <returns>true if a next item exists, otherwise false</returns>
        public bool hasNext()
        {
            return my_iterator.hasNext();
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
            return my_iterator.remove();
        }

        /// <summary>
        /// Provide a string representation of the iterator.
        /// </summary>
        /// <returns>a string representation.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            //show the current element if any
            builder.Append(my_iterator.printCurrentElement());

            //show whether there is another element
            builder.Append(", HasNext: ");
            builder.Append(hasNext());

            return builder.ToString();
        }
    }
}
