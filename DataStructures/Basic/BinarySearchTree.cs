using System;
using System.Linq;
using System.Text;
using DataStructures.Interfaces;
using DataStructures.HelperClasses;
using DataStructures.Exceptions;

namespace DataStructures.Basic
{
    /// <summary>
    /// Binary search tree that can provide logarithmic search time
    /// for comparable elements added to the tree.
    /// </summary>
    /// <typeparam name="T">the reference element type.</typeparam>
    public class BinarySearchTree<T> : SortedCollection<T>, Tree<T> where T : class, Comparable<T>
    {
        //random generator so that two-child removals are random and don't skew the tree
        private static Random my_rand = new Random();

        private BinaryNode<T> my_root;

        private int my_size = 0;
        private int my_mod_count = 0;

        /// <summary>
        /// Default constructor sets up the search tree with default settings.
        /// </summary>
        public BinarySearchTree()
        {
            //do nothing
        }

        /// <summary>
        /// Constructor that sets up the search tree with initial elements added to the tree.
        /// </summary>
        /// <param name="the_initial_elements"></param>
        public BinarySearchTree(T[] the_initial_elements)
        {
            Preconditions.checkNull(the_initial_elements);

            //add the initial elements to the tree
            for (int i = 0; i < the_initial_elements.Length; i++)
            {
                add(the_initial_elements[i]);
            }
        }

        /// <summary>
        /// Shows whether the search tree is empty of elements.
        /// </summary>
        /// <returns>true if no elements are in the tree, otherwise false.</returns>
        public bool isEmpty()
        {
            return my_size == 0;
        }

        /// <summary>
        /// Shows the number of elements added to the search tree.
        /// </summary>
        /// <returns>the number of elements in the search tree.</returns>
        public int size()
        {
            return my_size;
        }

        /// <summary>
        /// Adds a comparable element to the search tree.
        /// </summary>
        /// <param name="the_new_element">the comparable element to 
        /// add to the search tree.</param>
        /// <returns>true if the element was added, otherwise false.</returns>
        public bool add(T the_new_element)
        {
            Preconditions.checkNull(the_new_element);

            bool found = false;
            bool added = false;

            //add the first element if necessary
            if (my_root == null)
            {
                my_root = new BinaryNode<T>(the_new_element);
                added = true;
            }
            else
            {
                BinaryNode<T> current = my_root;
                while (true)
                {
                    //if the current is more than the new element
                    if (current.value.compareTo(the_new_element) > 0)
                    {
                        if (current.left == null)
                        {
                            current.left = new BinaryNode<T>(the_new_element);
                            current.left.parent = current; //set parent link
                            added = true;
                            break;
                        }
                        else
                        {
                            current = current.left;
                        }
                    }
                    //if the current is less than the new element
                    else if (current.value.compareTo(the_new_element) < 0)
                    {
                        if (current.right == null)
                        {
                            current.right = new BinaryNode<T>(the_new_element);
                            current.right.parent = current; //set parent link
                            added = true;
                            break;
                        }
                        else
                        {
                            current = current.right;
                        }
                    }
                    else //equal (just return, the element is already in the tree)
                    {
                        found = true;
                        break;
                    }
                }
            }

            //change the size only if it was successfully added
            if (added)
            {
                my_size++;
            }
            
            return !found;
        }

        /// <summary>
        /// Shows whether the search tree contains an element.
        /// </summary>
        /// <param name="the_check">the element to look for in the search tree.</param>
        /// <returns>true if the tree contains the element, otherwise false.</returns>
        public bool contains(T the_check)
        {
            Preconditions.checkNull(the_check);

            return getNode(the_check) != null;
        }

        /// <summary>
        /// Removes an element from the search tree.
        /// </summary>
        /// <param name="the_removal">the element to remove from the search tree.</param>
        /// <returns>true if the element was successfully found and removed, 
        /// otherwise false.</returns>
        public bool remove(T the_removal)
        {
            Preconditions.checkNull(the_removal);

            //handle the empty tree case
            if (my_root == null)
            {
                return false;
            }

            BinaryNode<T> current;
            bool left_child = false; //to determine which child link of the parent the current is
            current = my_root;

            while (true)
            {
                //if the current is more than the new element
                if (current.value.compareTo(the_removal) > 0)
                {
                    if (current.left == null)
                    {
                        return false;
                    }
                    else
                    {
                        current = current.left;
                        left_child = true;
                    }
                }
                //if the current is less than the new element
                else if (current.value.compareTo(the_removal) < 0)
                {
                    if (current.right == null)
                    {
                        return false;
                    }
                    else
                    {
                        current = current.right;
                        left_child = false;
                    }
                }
                else //equal (the element is in the tree)
                {
                    remove(current.parent, current, left_child);
                    my_size--;
                    return true;
                }
            }
        }

        /// <summary>
        /// Clears the search tree of all values.
        /// </summary>
        public void clear()
        {
            my_size = 0;
            my_root = null;
        }

        /// <summary>
        /// Returns an array representation of the search tree elements,
        /// using an in-order traversal to find all elements in the tree.
        /// </summary>
        /// <returns>an array representation of the search tree elements.</returns>
        public T[] toArray()
        {
            if (my_root == null)
            {
                return new T[0];
            }

            return inOrderSearch(my_root.value).toArray();
        }

        /// <summary>
        /// Returns an iterator over the search tree elements using
        /// the default in-order traversal to find elements.
        /// </summary>
        /// <returns>an array representation of the search tree elements.</returns>
        public Iterator<T> iterator()
        {
            return iterator(GraphTraversals.InOrder);
        }

        /// <summary>
        /// Returns an iterator over the search tree elements using
        /// the specified traversal to find elements.
        /// </summary>
        /// <param name="the_traversal_method">a traversal method to 
        /// retrieve elements from the search tree.</param>
        /// <returns>an array representation of the search tree elements.</returns>
        public Iterator<T> iterator(GraphTraversals the_traversal_method)
        {
            return new BSTIterator<T>(the_traversal_method, my_root, this);
        }

        /// <summary>
        /// Returns an iterator over the search tree elements using
        /// the specified traversal to find elements.
        /// </summary>
        /// <param name="the_traversal_method">a traversal method to 
        /// retrieve elements from the search tree.</param>
        /// <returns>an array representation of the search tree elements.</returns>
        public Iterator<T> iterator(GraphTraversals the_traversal_method, T the_source_node)
        {
            BinaryNode<T> node = getNode(the_source_node);
            Preconditions.checkNull(node);
            return new BSTIterator<T>(the_traversal_method, node, this);
        }

        /// <summary>
        /// Gets an element that exists in the tree.
        /// </summary>
        /// <param name="the_check">the element to look for in the tree.</param>
        /// <returns>the element or null if the element is not found.</returns>
        public T getElement(T the_check)
        {
            BinaryNode<T> node = getNode(the_check);
            if (node == null)
            {
                return null;
            }
            else
            {
                return node.value;
            }
        }

        /// <summary>
        /// Gives the first element in the tree using the given ordering of elements.
        /// </summary>
        /// <returns>the first element.</returns>
        public T first()
        {
            //quick out for no elements in the tree
            if (my_root == null)
            {
                return null;
            }

            //traverse down the left child nodes until you reach a null link
            BinaryNode<T> current = my_root;
            while (current.left != null)
            {
                current = current.left;
            }

            return current.value;
        }

        /// <summary>
        /// Gives the last element in the tree using the given ordering of elements.
        /// </summary>
        /// <returns>the last element.</returns>
        public T last()
        {
            //quick out for no elements in the tree
            if (my_root == null)
            {
                return null;
            }

            //traverse down the right child nodes until you reach a null link
            BinaryNode<T> current = my_root;
            while (current.right != null)
            {
                current = current.right;
            }

            return current.value;
        }

        /// <summary>
        /// Returns a string representation of the search tree. It simply returns a list
        /// format of the elements found through an in-order search.
        /// </summary>
        /// <returns>a string representation of the tree.</returns>
        public override string ToString()
        {
            return inOrderSearch().ToString();
        }

        //----------------- SEARCHING -------------------

        /// <summary>
        /// Performs a pre-order search of the tree and returns
        /// the elements visited in a list.
        /// </summary>
        /// <returns>a list of traversed elements.</returns>
        public List<T> preOrderSearch()
        {
            List<T> return_value = new ArrayList<T>(size());
            preOrder(return_value, my_root);
            return return_value;
        }

        /// <summary>
        /// Performs a in-order search of the tree and returns
        /// the elements visited in a list.
        /// </summary>
        /// <returns>a list of traversed elements.</returns>
        public List<T> inOrderSearch()
        {
            List<T> return_value = new ArrayList<T>(size());
            inOrder(return_value, my_root);
            return return_value;
        }

        /// <summary>
        /// Performs a post-order search of the tree and returns
        /// the elements visited in a list.
        /// </summary>
        /// <returns>a list of traversed elements.</returns>
        public List<T> postOrderSearch()
        {
            List<T> return_value = new ArrayList<T>(size());
            postOrder(return_value, my_root);
            return return_value;
        }

        /// <summary>
        /// Performs a pre-order search of the tree starting at
        /// the specified node and returns the elements visited 
        /// in a list.
        /// </summary>
        /// <param name="the_source_node">the node to begin the
        /// traversal at.</param>
        /// <returns>a list of traversed elements.</returns>
        public List<T> preOrderSearch(T the_source_node)
        {
            Preconditions.checkNull(the_source_node);

            List<T> return_value = new ArrayList<T>(size());
            preOrder(return_value, getNode(the_source_node));
            return return_value;
        }

        /// <summary>
        /// Performs a in-order search of the tree starting at
        /// the specified node and returns the elements visited 
        /// in a list.
        /// </summary>
        /// <param name="the_source_node">the node to begin the
        /// traversal at.</param>
        /// <returns>a list of traversed elements.</returns>
        public List<T> inOrderSearch(T the_source_node)
        {
            Preconditions.checkNull(the_source_node);

            List<T> return_value = new ArrayList<T>(size());
            inOrder(return_value, getNode(the_source_node));
            return return_value;
        }

        /// <summary>
        /// Performs a post-order search of the tree starting at
        /// the specified node and returns the elements visited 
        /// in a list.
        /// </summary>
        /// <param name="the_source_node">the node to begin the
        /// traversal at.</param>
        /// <returns>a list of traversed elements.</returns>
        public List<T> postOrderSearch(T the_source_node)
        {
            Preconditions.checkNull(the_source_node);

            List<T> return_value = new ArrayList<T>(size());
            postOrder(return_value, getNode(the_source_node));
            return return_value;
        }

        /// <summary>
        /// Performs a breadth-first search of tree starting at the
        /// specified node.
        /// </summary>
        /// <param name="the_source_node">the node to begin the
        /// search at.</param>
        /// <returns>a list of elements visited in the breadth-first
        /// traversal.</returns>
        public List<T> breadthFirstSearch(T the_source_node)
        {
            Preconditions.checkNull(the_source_node);

            //check for empty tree
            if (size() == 0)
            {
                return new ArrayList<T>();
            }

            //perform the breadth-first search using the standard method
            //of retrieving elements through a queue.
            List<T> return_value = new ArrayList<T>();
            BasicQueue<BinaryNode<T>> queue = new Queue<BinaryNode<T>>();
            queue.enqueue(getNode(the_source_node));

            //pull each item off the queue, record the element and toss
            //the children of the element on the queue
            while (!queue.isEmpty())
            {
                BinaryNode<T> node = queue.dequeue();
                return_value.add(node.value);

                if (node.left != null)
                {
                    queue.enqueue(node.left);
                }
                if (node.right != null)
                {
                    queue.enqueue(node.right);
                }
            }

            return return_value;
        }

        /// <summary>
        /// Performs a depth-first search of tree starting at the
        /// specified node.
        /// </summary>
        /// <param name="the_source_node">the node to begin the
        /// search at.</param>
        /// <returns>a list of elements visited in the depth-first
        /// traversal.</returns>
        public List<T> depthFirstSearch(T the_source_node)
        {
            return preOrderSearch(the_source_node);
        }

        /// <summary>
        /// Performs a breadth-first search of tree.
        /// </summary>
        /// <returns>a list of elements visited in the breadth-first
        /// traversal.</returns>
        public List<T> breadthFirstSearch()
        {
            return breadthFirstSearch(my_root.value);
        }

        /// <summary>
        /// Performs a depth-first search of tree.
        /// </summary>
        /// <returns>a list of elements visited in the depth-first
        /// traversal.</returns>
        public List<T> depthFirstSearch()
        {
            return depthFirstSearch(my_root.value);
        }

        //---------------- HELPER METHODS -----------------

        //gets a node that holds an element value.
        private BinaryNode<T> getNode(T the_value)
        {
            if (my_root == null)
            {
                return null;
            }

            BinaryNode<T> current = my_root;
            while (true)
            {
                //if the current is more than the new element
                if (current.value.compareTo(the_value) > 0)
                {
                    if (current.left == null)
                    {
                        return null;
                    }
                    else
                    {
                        current = current.left;
                    }
                }
                //if the current is less than the new element
                else if (current.value.compareTo(the_value) < 0)
                {
                    if (current.right == null)
                    {
                        return null;
                    }
                    else
                    {
                        current = current.right;
                    }
                }
                else //equal (the element is in the tree)
                {
                    return current;
                }
            }
        }

        //removes an element from the tree.
        internal void remove(BinaryNode<T> the_parent, BinaryNode<T> the_removal, bool the_left_child)
        {
            //no children
            if (the_removal.left == null && the_removal.right == null)
            {
                //the replace node is the root
                if (the_parent == null)
                {
                    my_root = null;
                }
                else
                {
                    if (the_left_child)
                    {
                        the_parent.left = null;
                    }
                    else
                    {
                        the_parent.right = null;
                    }
                }
            }
            //two children
            else if (the_removal.left != null && the_removal.right != null)
            {
                //two-child case, remove from either side randomly to avoid a skewed tree
                int rand = my_rand.Next(0, 2);
                BinaryNode<T> moved;
                if (rand == 0)
                {
                    if (the_removal.left.right == null)
                    {
                        moved = the_removal.left;
                        placeNode(moved, the_parent, the_left_child);
                        moved.right = the_removal.right;
                        moved.right.parent = moved;
                    }
                    else
                    {
                        moved = removeMax(the_removal.left);

                        placeNode(moved, the_parent, the_left_child);
                        moved.left = the_removal.left;
                        moved.left.parent = moved;
                        moved.right = the_removal.right;
                        moved.right.parent = moved;
                    }
                    moved.parent = the_removal.parent; //set parent link of new to the removal
                }
                else
                {
                    if (the_removal.right.left == null)
                    {
                        moved = the_removal.right;
                        placeNode(moved, the_parent, the_left_child);
                        moved.left = the_removal.left;
                        moved.left.parent = moved;
                    }
                    else
                    {
                        moved = removeMin(the_removal.right);

                        placeNode(moved, the_parent, the_left_child);
                        moved.left = the_removal.left;
                        moved.left.parent = moved;
                        moved.right = the_removal.right;
                        moved.right.parent = moved;
                    }
                    moved.parent = the_removal.parent; //set parent link of new to the removal
                }
            }
            //left child
            else if (the_removal.right == null)
            {
                placeNode(the_removal.left, the_parent, the_left_child);
                the_removal.left.parent = the_removal.parent; //set parent link of new to the removal
            }
            //right child
            else if (the_removal.left == null)
            {
                placeNode(the_removal.right, the_parent, the_left_child);
                the_removal.right.parent = the_removal.parent; //set parent link of new to the removal
            }
        }

        //helper method that moves a new node into its new position after a removal.
        private void placeNode(BinaryNode<T> the_moved_node, BinaryNode<T> the_parent, bool the_left_child)
        {
            //the replace node is the root
            if (the_parent == null)
            {
                my_root = the_moved_node;
            }
            else
            {
                if (the_left_child)
                {
                    the_parent.left = the_moved_node;
                }
                else
                {
                    the_parent.right = the_moved_node;
                }
            }
        }

        //Removes the largest node in a sub-tree beginning at the node specified.
        private BinaryNode<T> removeMax(BinaryNode<T> the_removal)
        {
            BinaryNode<T> current;
            current = the_removal;

            //traverse each right child to find the maximum element
            while (current.right != null)
            {
                current = current.right;
            }

            remove(current.parent, current, false); //always the right

            return current;
        }

        //Removes the smallest node in a sub-tree beginning at the node specified.
        private BinaryNode<T> removeMin(BinaryNode<T> the_removal)
        {
            BinaryNode<T> current;
            current = the_removal;

            //traverse each left child to find the minimum element
            while (current.left != null)
            {
                current = current.left;
            }

            remove(current.parent, current, true); //always the left

            return current;
        }

        //performs a pre-order traversal of the tree
        private void preOrder(List<T> the_traversal, BinaryNode<T> the_source_vertex)
        {
            if (the_source_vertex == null)
            {
                return;
            }

            //node first
            the_traversal.add(the_source_vertex.value);

            //left
            if (the_source_vertex.left != null)
            {
                preOrder(the_traversal, the_source_vertex.left);
            }

            //right
            if (the_source_vertex.right != null)
            {
                preOrder(the_traversal, the_source_vertex.right);
            }
        }

        //performs a post-order traversal of the tree
        private void postOrder(List<T> the_traversal, BinaryNode<T> the_source_vertex)
        {
            if (the_source_vertex == null)
            {
                return;
            }

            //left
            if (the_source_vertex.left != null)
            {
                postOrder(the_traversal, the_source_vertex.left);
            }

            //right
            if (the_source_vertex.right != null)
            {
                postOrder(the_traversal, the_source_vertex.right);
            }

            //node first
            the_traversal.add(the_source_vertex.value);
        }

        //performs an in-order traversal of the tree
        private void inOrder(List<T> the_traversal, BinaryNode<T> the_source_vertex)
        {
            if (the_source_vertex == null)
            {
                return;
            }

            //left
            if (the_source_vertex.left != null)
            {
                inOrder(the_traversal, the_source_vertex.left);
            }

            //node first
            the_traversal.add(the_source_vertex.value);

            //right
            if (the_source_vertex.right != null)
            {
                inOrder(the_traversal, the_source_vertex.right);
            }
        }

        //returns the modification count of the tree for iterators to ensure consistency
        internal int getModCount()
        {
            return my_mod_count;
        }

        //returns a link to the root for iterators and internal classes
        internal BinaryNode<T> root
        {
            get { return my_root; }
        }

        //lowers the size of the tree for iterators and internal classes
        internal void decrementSize()
        {
            my_size--;
        }
    }
}
