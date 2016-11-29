using System;
using System.Linq;
using System.Text;
using DataStructures.Exceptions;
using DataStructures.Interfaces;
using DataStructures.HelperClasses;

namespace DataStructures.Basic
{
    /// <summary>
    /// Linked list class that stores elements in nodes as an underlying
    /// representation.
    /// </summary>
    /// <typeparam name="T">the reference type of elements.</typeparam>
    public class LinkedList<T> : List<T> where T : class 
    {
        private LL_Node<T> my_head;
        private LL_Node<T> my_tail;

        private int my_size = 0;
        private int my_mod_count = 0;

        /// <summary>
        /// Sets up the list with default settings.
        /// </summary>
        public LinkedList()
        {
            //do nothing
        }

        /// <summary>
        /// Shows whether the list is empty.
        /// </summary>
        /// <returns>true if the list is empty, otherwise false.</returns>
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
        /// Adds an element to the list.
        /// </summary>
        /// <param name="the_new_element">the element to add.</param>
        /// <returns>true if the element was added, otherwise false.</returns>
        public bool add(T the_new_element)
        {
            //quick out for a bad element given
            if (the_new_element == null)
            {
                throw new ArgumentException("Null element given to add to the list.");
            }

            LL_Node<T> new_node = new LL_Node<T>(the_new_element, null, null);

            //if the first addition to the list
            if (my_head == null)
            {
                my_head = my_tail = new_node;
            }
            else //link to the tail and replace the tail
            {
                my_tail.next = new_node;
                new_node.prev = my_tail;
                my_tail = new_node;
            }
            my_size++;
            my_mod_count++;
            return true;
        }

        /// <summary>
        /// Shows whether the list contains an element.
        /// </summary>
        /// <param name="the_check">the element to look for in the list.</param>
        /// <returns>true if the element is in the list, otherwise false.</returns>
        public bool contains(T the_check)
        {
            LL_Node<T> found = traverseToNode(the_check);
            return found != null;
        }

        /// <summary>
        /// Returns an element stored in the list.
        /// </summary>
        /// <param name="the_check">the element to look for in the list.</param>
        /// <returns>the element in the list, otherwise returns null if not found.</returns>
        public T getElement(T the_check)
        {
            LL_Node<T> found = traverseToNode(the_check);
            if (found == null)
            {
                return null;
            }
            else
            {
                return found.value;
            }
        }

        /// <summary>
        /// Removes an element from the list.
        /// </summary>
        /// <param name="the_removal">the element to find
        /// and remove from the list.</param>
        /// <returns>true if the element was found and removed,
        /// otherwise false.</returns>
        public bool remove(T the_removal)
        {
            //look for the node
            LL_Node<T> found = traverseToNode(the_removal);
            if (found == null)
            {
                return false;
            }
            else //remove the node if found
            {
                removeNode(found);
                my_mod_count++;
                return true;
            }
        }

        /// <summary>
        /// Clears the list of elements.
        /// </summary>
        public void clear()
        {
            my_head = my_tail = null;
            my_size = 0;
            my_mod_count++;
        }

        /// <summary>
        /// Returns an array representation of the elements in the list.
        /// </summary>
        /// <returns>an array of elements.</returns>
        public T[] toArray()
        {
            T[] return_value = new T[size()];
            int count = 0;

            //iterate across elements and add them to the array
            Iterator<T> it = iterator();
            while (it.hasNext())
            {
                return_value[count] = it.next();
                count++;
            }

            return return_value;
        }

        /// <summary>
        /// Returns an iterator that can traverse the list.
        /// </summary>
        /// <returns>iterator for the list.</returns>
        public Iterator<T> iterator()
        {
            return new LL_Iterator<T>(this);
        }

        /// <summary>
        /// Gets an item at the index given.
        /// </summary>
        /// <param name="the_index">the index of the iterm being searched for.</param>
        /// <returns>the item at the index given.</returns>
        public T get(int the_index)
        {
            LL_Node<T> node = traverseToNode(the_index);
            if (node != null)
            {
                return node.value;
            }
            else 
            {
                return null;
            }
        }

        /// <summary>
        /// Sets the item at the given index.
        /// </summary>
        /// <param name="the_index">the index of the element
        /// to replace.</param>
        /// <param name="the_new_value">the new value to replace
        /// the element at the given index with.</param>
        public void set(int the_index, T the_new_value)
        {
            LL_Node<T> found = traverseToNode(the_index);
            found.value = the_new_value;
            //flag the change
            my_mod_count++;
        }

        /// <summary>
        /// Removes an element at the given index.
        /// </summary>
        /// <param name="the_index">the index to remove an element
        /// at.</param>
        /// <returns>the element that was removed.</returns>
        public T removeAt(int the_index)
        {
            T value = removeElementAt(the_index);
            my_mod_count++;
            return value;
        }

        /// <summary>
        /// Returns a list iterator which can traverse the list in
        /// both the forward and backward directions.
        /// </summary>
        /// <returns>a list iterator.</returns>
        public ListIterator<T> listIterator()
        {
            return new LL_ListIterator<T>(this);
        }

        /// <summary>
        /// Inserts an element at the given index. All elements from
        /// this index to the end of the list will be shifted forward
        /// in the list.
        /// </summary>
        /// <param name="the_index">the index to insert an element at.</param>
        /// <param name="the_new_value">the new element to insert.</param>
        /// <returns>true if the element was insert correctly, otherwise false.</returns>
        public bool insertAt(int the_index, T the_new_value)
        {
            rangeCheck(the_index);
            my_size++;

            LL_Node<T> node = traverseToNode(the_index);
            LL_Node<T> new_node = new LL_Node<T>(the_new_value, null, null);

            //case of insertAt(0)
            if (node.prev == null)
            {
                my_head = new_node;
            }
            else
            {
                node.prev.next = new_node;
            }
            new_node.prev = node.prev;
            node.prev = new_node;
            new_node.next = node;

            return true;
        }

        /// <summary>
        /// Removes the last element from the list.
        /// </summary>
        /// <returns>the removed element.</returns>
        public T removeLast()
        {
            T return_value = null;
            if (my_size == 1) //handle the case of the head being removed
            {
                return_value = my_head.value;
                clear();
            }
            else if (my_size > 1) //fix links with the tail
            {
                LL_Node<T> tail = my_tail;
                tail.prev.next = null;
                my_tail = tail.prev;
                return_value = tail.value;
                my_size--;
            }
            return return_value;
        }

        /// <summary>
        /// Removes the first element from the list. This is a constant time operation.
        /// </summary>
        /// <returns>the element removed.</returns>
        public T removeFirst()
        {
            T return_value = null;
            if (my_size == 1) //handle the case of removing the head
            {
                clear();
                my_size--;
            }
            else if (my_size > 1) //restore links with the head after removal
            {
                LL_Node<T> head = my_head;
                head.next.prev = null;
                my_head = head.next;

                return_value = head.value;
                my_size--;
            }
            return return_value;
        }

        /// <summary>
        /// Adds an element at the end of the list.
        /// </summary>
        /// <param name="the_new_value">the new element to add.</param>
        /// <returns>true if the element is added to the list, otherwise false.</returns>
        public bool addLast(T the_new_value)
        {
            if (my_size == 0) //handle the case of adding the first element
            {
                add(the_new_value);
            }
            else //fix the links near the tail when adding to the end of the list
            {
                LL_Node<T> new_node = new LL_Node<T>(the_new_value, null, null);
                my_tail.next = new_node;
                new_node.prev = my_tail;
                my_tail = new_node;
                my_size++;
            }

            return true;
        }

        /// <summary>
        /// Adds an element to the start of the list.
        /// </summary>
        /// <returns>true if the element is added to the list, otherwise false.</returns>
        /// <returns></returns>
        public bool addFirst(T the_new_value)
        {
            if (my_size == 0) //handle the case of adding the first element
            {
                add(the_new_value);
            }
            else //fix the links near the head when adding to the end of the list
            {
                LL_Node<T> new_node = new LL_Node<T>(the_new_value, null, null);
                my_head.prev = new_node;
                new_node.next = my_head;
                my_head = new_node;
                my_size++;
            }

            return true;
        }

        /// <summary>
        /// Returns the first element in the list.
        /// </summary>
        /// <returns>the first element.</returns>
        public T first()
        {
            if (my_head == null)
            {
                return null;
            }
            return my_head.value;
        }

        /// <summary>
        /// Returns the last element in the list.
        /// </summary>
        /// <returns>the last element.</returns>
        public T last()
        {
            if (my_tail == null)
            {
                return null;
            }
            return my_tail.value;
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

            bool first = true;
            Iterator<T> it = iterator();
            while (it.hasNext())
            {
                if (first)
                {
                    first = false;
                    Helpers.printElementIfNull(builder, it.next());
                }
                else
                {
                    builder.Append(", ");
                    Helpers.printElementIfNull(builder, it.next());
                }
            }
            builder.Append("]");

            return builder.ToString();
        }

        //----------------- HELPER METHODS ------------------

        //checks for range violations with user input
        internal void rangeCheck(int the_index)
        {
            if (the_index < 0 || the_index > size())
            {
                throw new IndexOutOfRangeException("Bad index given.");
            }
        }

        //removes an element at a specified index
        internal T removeElementAt(int the_index)
        {
            LL_Node<T> node = traverseToNode(the_index);
            removeNode(node);
            return node.value;
        }

        //gets the modification count for iterators to check for consistency
        internal int getModCount()
        {
            return my_mod_count;
        }

        //gives access to the head node for iterators to use
        internal LL_Node<T> headNode()
        {
            return my_head;
        }

        //removes a node from the list
        internal LL_Node<T> removeNode(LL_Node<T> the_node)
        {
            LL_Node<T> next_node = null;

            //not removing the head
            if (the_node.prev != null)
            {
                the_node.prev.next = the_node.next;
            }
            else //removing the head
            {
                my_head = the_node.next;
                next_node = my_head;
            }

            //not removing the tail
            if (the_node.next != null)
            {
                the_node.next.prev = the_node.prev;
            }
            else //removing the tail
            {
                my_tail = the_node.prev;
            }

            //if the next is not the last element
            if (next_node == null)
            {
                next_node = the_node.prev;
            }

            my_size--;
            return next_node;
        }

        //returns a node at the given index
        private LL_Node<T> traverseToNode(int the_index)
        {
            rangeCheck(the_index);

            //traverse to the index
            int count = 0;
            LL_Node<T> current = my_head;
            while (true)
            {
                if (count == the_index)
                {
                    return current;
                }

                if (current == null)
                {
                    return null;
                }

                current = current.next;
                count++;
            }
        }

        //traverse to a given node
        private LL_Node<T> traverseToNode(T the_element)
        {
            LL_Node<T> current = my_head;

            //traverse until you find the right node
            while (true)
            {
                if (current == null)
                {
                    return null;
                }
                else if (current.value.Equals(the_element))
                {
                    return current;
                }
                else
                {
                    current = current.next;
                }
            }
        }
    }
}
