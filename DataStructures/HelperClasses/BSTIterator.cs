using System;
using System.Linq;
using System.Text;
using DataStructures.Interfaces;
using DataStructures.Basic;
using DataStructures.Exceptions;

namespace DataStructures.HelperClasses
{
    /// <summary>
    /// Internal helper class that iterates over the elements in a binary search tree.
    /// </summary>
    /// <typeparam name="T">the reference type of elements in the tree.</typeparam>
    internal class BSTIterator<T> : Iterator<T> where T : class, Comparable<T>
    {
        private BasicStack<BinaryNode<T>> my_element_stack; //for traversal in a recursive manner
        private Queue<BinaryNode<T>> my_element_queue; //for breadth-first search
        private BinarySearchTree<T> my_parent;
        private BinaryNode<T> my_current;
        private BinaryNode<T> my_previous;
        private bool my_removed = false; //flag to avoid double removals

        private GraphTraversals my_traversal_method;

        /// <summary>
        /// Sets up the iterate with a traversal method, an initial node to traverse from and a link
        /// to the parent binary search tree.
        /// </summary>
        /// <param name="the_traversal_method">the method of traversing the tree.</param>
        /// <param name="the_parent_root">the root of the tree.</param>
        /// <param name="the_parent">link to the parent tree itself.</param>
        public BSTIterator(GraphTraversals the_traversal_method, BinaryNode<T> the_source_node, BinarySearchTree<T> the_parent)
        {
            my_traversal_method = the_traversal_method;
            my_parent = the_parent;

            //prepare stack for traversal
            my_element_stack = new Stack<BinaryNode<T>>(my_parent.size());
            my_element_queue = new Queue<BinaryNode<T>>();

            //add the first element if it is there
            if (my_parent.root != null)
            {
                my_element_stack.push(the_source_node);
                my_element_queue.enqueue(the_source_node);
            }
        }

        /// <summary>
        /// Advances to the next element in the tree.
        /// </summary>
        /// <returns>the next element.</returns>
        public T next()
        {
            //check for double removal
            if (my_removed)
            {
                my_removed = false;
            }

            //get the next element according to the traversal method
            if (my_traversal_method == GraphTraversals.InOrder)
            {
                return inOrderNext();
            }
            else if (my_traversal_method == GraphTraversals.PostOrder)
            {
                return postOrderNext();
            }
            else if (my_traversal_method == GraphTraversals.PreOrder)
            {
                return preOrderNext();
            }
            else if (my_traversal_method == GraphTraversals.BreadthFirst)
            {
                return breadthFirstNext();
            }
            else
            {
                return depthFirstNext();
            }
        }

        /// <summary>
        /// Shows whether there is another element to traverse in the tree.
        /// </summary>
        /// <returns>true if there are more elements, otherwise false.</returns>
        public bool hasNext()
        {
            if (my_traversal_method == GraphTraversals.BreadthFirst)
            {
                return !my_element_queue.isEmpty();
            }
            else
            {
                return !my_element_stack.isEmpty();
            }
        }

        /// <summary>
        /// Removes the next item from the traversal. This method relies on the parent
        /// internal remove() method. You cannot call remove before moving the iterator.
        /// You also cannot call remove twice in a row. You must first move the iterator
        /// after the first removal.
        /// </summary>
        /// <returns>the element that was removed.</returns>
        public T remove()
        {
            //check for removal before moving the iterator
            if (my_current == null)
            {
                throw new IllegalStateException("You must advance the iterator before removing an element.");
            }

            //check for double removal
            if (my_removed)
            {
                throw new IllegalStateException("You cannot remove an item twice before advancing the iterator.");
            }
            my_removed = true;

            //if the parent is null don't worry about the flag for left/right child of parent
            if (my_current.parent == null || my_current.parent.left == my_current)
            {
                my_parent.remove(my_current.parent, my_current, true);
            }
            else
            {
                my_parent.remove(my_current.parent, my_current, false);
            }

            //lower parent size
            my_parent.decrementSize();

            //save the return value, move the iterator back one and return
            T return_value = my_current.value;
            my_current = my_previous;
            return return_value;
        }

        /// <summary>
        /// Provides a string representation of the iterator.
        /// </summary>
        /// <returns>a string representation of the iterator.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            //print the current
            Helpers.printElementIfNull(builder, "Current", my_current.value);

            //print hasNext()
            builder.Append(", HasNext: ");
            builder.Append(hasNext());

            return builder.ToString();
        }

        //------------------- HELPER METHODS ---------------------

        //gets the next item in an in-order search.
        private T inOrderNext()
        {
            BinaryNode<T> last = my_element_stack.pop();
            if (last.stack_turn == 0) //first time off the stack
            {
                //put last back on the stack and mark as visited
                my_element_stack.push(last);
                last.stack_turn++;

                if (last.left != null)
                {
                    my_element_stack.push(last.left);
                }
                return inOrderNext();
            }
            else //stack_turn == 1
            {
                if (last.right != null)
                {
                    my_element_stack.push(last.right);
                }

                last.stack_turn = 0;
                my_previous = my_current;
                my_current = last;
                return last.value;
            }
        }

        //gets the next item in a pre-order search.
        private T preOrderNext()
        {
            BinaryNode<T> last = my_element_stack.pop();

            if (last.right != null)
            {
                my_element_stack.push(last.right);
            }
            if (last.left != null)
            {
                my_element_stack.push(last.left);
            }

            my_previous = my_current;
            my_current = last;
            return last.value;
        }

        //gets the next item in a post-order search.
        private T postOrderNext()
        {
            BinaryNode<T> last = my_element_stack.pop();

            if (last.stack_turn == 0)
            {
                //put last back on the stack and mark as visited
                my_element_stack.push(last);
                last.stack_turn++;

                if (last.right != null)
                {
                    my_element_stack.push(last.right);
                }
                if (last.left != null)
                {
                    my_element_stack.push(last.left);
                }

                return postOrderNext();
            }
            else //stack_turn == 1
            {
                my_previous = my_current;
                my_current = last;
                return last.value;
            }
        }

        //gets the next item in an breadth-first search.
        private T breadthFirstNext()
        {
            BinaryNode<T> last = my_element_queue.dequeue();
            T return_value = last.value;
            
            //add children if not null
            if (last.left != null)
            {
                my_element_queue.enqueue(last.left);
            }
            if (last.right != null)
            {
                my_element_queue.enqueue(last.right);
            }

            return return_value;
        }

        //gets the next item in an depth-first search.
        private T depthFirstNext()
        {
            //the same as pre-order search
            return preOrderNext();
        }
    }
}
