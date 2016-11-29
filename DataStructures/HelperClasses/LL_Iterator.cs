using System;
using System.Linq;
using System.Text;
using DataStructures.Interfaces;
using DataStructures.Basic;

namespace DataStructures.HelperClasses
{
    /// <summary>
    /// A linked list iterator that iterates over a linked list in one direction.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class LL_Iterator<T> : Iterator<T> where T : class
    {
        //Inner representation. This is used according to the adapter pattern to prevent redundant code.
        private LL_ListIterator<T> my_iterator;

        /// <summary>
        /// Sets up the iterator with a link to the parent list.
        /// </summary>
        /// <param name="the_parent"></param>
        public LL_Iterator(LinkedList<T> the_parent)
        {
            my_iterator = new LL_ListIterator<T>(the_parent);
        }

        /// <summary>
        /// Returns the next element in the iteration.
        /// </summary>
        /// <returns>the next element in the iteration.</returns>
        public T next()
        {
            return my_iterator.next();
        }

        /// <summary>
        /// Shows whether there is another element in the iteration.
        /// </summary>
        /// <returns>true if the element exists, otherwise false.</returns>
        public bool hasNext()
        {
            return my_iterator.hasNext();
        }

        /// <summary>
        /// Removes the last item returned by a call to next() from the list.
        /// </summary>
        /// <returns>the last element returned by a call to next().</returns>
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
            builder.Append(my_iterator.printElement());

            //show whether there is another element
            builder.Append(", HasNext: ");
            builder.Append(hasNext());

            return builder.ToString();
        }
    }
}
