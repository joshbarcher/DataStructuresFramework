using System;
using System.Linq;
using System.Text;
using DataStructures.Interfaces;

namespace DataStructures.Basic
{
    /// <summary>
    /// This class is a sorted set that uses a binary search tree as an underlying
    /// representation.
    /// </summary>
    /// <typeparam name="T">the reference type of elements in the set.</typeparam>
    public class TreeSet<T> : Set<T>, SortedCollection<T> where T : class, Comparable<T>
    {
        private BinarySearchTree<T> my_bst;

        /// <summary>
        /// Sets up the tree set with default settings.
        /// </summary>
        public TreeSet()
        {
            my_bst = new BinarySearchTree<T>();
        }

        /// <summary>
        /// Sets up the tree set with an array of initial elements.
        /// </summary>
        /// <param name="the_initial_elements">the elements to add to the
        /// set initially.</param>
        public TreeSet(T[] the_initial_elements)
        {
            my_bst = new BinarySearchTree<T>(the_initial_elements);
        }

        /// <summary>
        /// Shows whether the set is empty.
        /// </summary>
        /// <returns>true if there are no elements in the set, otherwise false.</returns>
        public bool isEmpty()
        {
            return my_bst.isEmpty();
        }

        /// <summary>
        /// Shows how many elements are in the set.
        /// </summary>
        /// <returns>the number of elements in the set.</returns>
        public int size()
        {
            return my_bst.size();
        }

        /// <summary>
        /// Adds an element to the set.
        /// </summary>
        /// <param name="the_new_element">the element to add to the set.</param>
        /// <returns>true if the element was added, otherwise false</returns>
        public bool add(T the_new_element)
        {
            return my_bst.add(the_new_element);
        }

        /// <summary>
        /// Shows whether the set contains an element.
        /// </summary>
        /// <param name="the_check">the element to look for in the set.</param>
        /// <returns>true if the element is in the set, otherwise false.</returns>
        public bool contains(T the_check)
        {
            return my_bst.contains(the_check);
        }

        /// <summary>
        /// Removes an element from the set.
        /// </summary>
        /// <param name="the_removal">the element to remove from the set.</param>
        /// <returns>true if the element was found and removed from the set, otherwise false.</returns>
        public bool remove(T the_removal)
        {
            return my_bst.remove(the_removal);
        }

        /// <summary>
        /// Gets an element stored in the set.
        /// </summary>
        /// <param name="the_check">the element to search for.</param>
        /// <returns>the element in the set, otherwise null if not found.</returns>
        public T getElement(T the_check)
        {
            return my_bst.getElement(the_check);
        }

        /// <summary>
        /// Clears the set of elements.
        /// </summary>
        public void clear()
        {
            my_bst.clear();
        }

        /// <summary>
        /// Gives an array representation of the elements in the set. These elements are
        /// returned in sorted order.
        /// </summary>
        /// <returns>an array of sorted elements.</returns>
        public T[] toArray()
        {
            return my_bst.toArray();
        }

        /// <summary>
        /// Returns an iterator over the elements in the set. The elements are traversed
        /// in the order given for the elements (in sorted order).
        /// </summary>
        /// <returns>an iterator to iterate over the elements in the set.</returns>
        public Iterator<T> iterator()
        {
            return my_bst.iterator(GraphTraversals.InOrder); //produces the items in sorted order
        }

        /// <summary>
        /// Gives an element in the set.
        /// </summary>
        /// <param name="the_check">the element to look for in the set.</param>
        /// <returns>true if the element is found and returned, otherwise false.</returns>
        public T get(T the_check)
        {
            return my_bst.getElement(the_check);
        }

        /// <summary>
        /// Gives the first element in the set.
        /// </summary>
        /// <returns>the first element.</returns>
        public T first()
        {
            return my_bst.first();
        }

        /// <summary>
        /// Gives the last element in the set.
        /// </summary>
        /// <returns>the last element in the set.</returns>
        public T last()
        {
            return my_bst.last();
        }

        /// <summary>
        /// Returns a string representation of the set.
        /// </summary>
        /// <returns>a string representation.</returns>
        public override string ToString()
        {
            return my_bst.ToString();
        }
    }
}
