using System;
using System.Linq;
using System.Text;
using DataStructures.HelperClasses;
using DataStructures.Basic;
using DataStructures.Interfaces;
using DataStructures.PrimitiveWrappers;

namespace DataStructures.Algorithms
{
    /// <summary>
    /// Algorithms class that provides functionality for finding subsets of elements.
    /// </summary>
    public class Subsets : Observable
    {
        /// <summary>
        /// Given a number of elements, this method will return all subsets and the
        /// permutations for each subset. The list returned contains lists of indices
        /// which can be used on an original list/array of data elements.
        /// </summary>
        /// <typeparam name="T">the reference type of elements.</typeparam>
        /// <param name="the_number_of_elements">the number of elements to find subsets of.</param>
        /// <returns>a list containing lists of unique subsets and their permutations.</returns>
        public List<List<DSInteger>> getUniquePermutationIndices<T>(int the_number_of_elements) where T : class
        {
            //this method builds an M-ary tree of unique subsets and their permutations
            //where M is the number of elements given to the method
            //   -------------------- STEPS -----------------------
            //1. The algorithm first adds a dummy root node and each of the element's
            //   indices as a child to the root.
            //2. The algorithm then begins a depth first search adding child elements
            //   to existing elements where there are no duplications. The indices of
            //   the elements at any node in the tree are stored in a list as the value
            //   for the tree node.
            //3. Lastly a second breadth-first search is performed on the tree to extract
            //   all unique permutations from the nodes.

            if (the_number_of_elements == 0)
            {
                return new ArrayList<List<DSInteger>>();
            }

            //updates
            int tree_elements = getTotalTreeElements(the_number_of_elements);
            tree_elements = tree_elements + tree_elements;
            int update_count = 0;

            int depth = 0;
            List<List<DSInteger>> return_value = new ArrayList<List<DSInteger>>(the_number_of_elements);
            MAryNode<List<DSInteger>> root = new MAryNode<List<DSInteger>>(null);

            //build the first level of the tree
            for (int i = 0; i < the_number_of_elements; i++)
            {
                List<DSInteger> list = new LinkedList<DSInteger>();
                list.add(new DSInteger(i));
                root.addChild(list);
            }
            depth = 1;

            int row_count, new_row_count;
            BasicQueue<MAryNode<List<DSInteger>>> queue = new Queue<MAryNode<List<DSInteger>>>();
            for (int i = 0; i < root.children.size(); i++)
            {
                queue.add(root.children.get(i));
                showChanges(tree_elements, ++update_count);
            }

            //for each level
            while (depth < the_number_of_elements)
            {
                row_count = queue.size();
                new_row_count = 0;

                //for each element in the row
                while (row_count > 0)
                {
                    MAryNode<List<DSInteger>> node = queue.dequeue();
                    row_count--;

                    for (int i = 0; i < the_number_of_elements; i++)
                    {
                        DSInteger check = new DSInteger(i);
                        if (!node.value.contains(check))
                        {
                            //copy across old values 
                            List<DSInteger> new_list = new LinkedList<DSInteger>();
                            for (int j = 0; j < node.value.size(); j++)
                            {
                                new_list.add(node.value.get(j));
                            }
                            
                            //add new value
                            new_list.add(check);

                            //add the new node
                            node.addChild(new_list);

                            //ready the next row
                            new_row_count++;

                            //enqueue the new child
                            queue.enqueue(node.children.get(node.children.size() - 1));

                            //show the change
                            showChanges(tree_elements, ++update_count);
                        }
                    }
                }

                depth++;
            }
            queue.clear();

            //perform a breadth-first search and record the lists
            for (int i = 0; i < root.children.size(); i++)
            {
                queue.enqueue(root.children.get(i));
            }

            //loop while searching
            while (!queue.isEmpty())
            {
                //record the current nodes list
                MAryNode<List<DSInteger>> node = queue.dequeue();
                return_value.add(node.value);

                //add all children to the queue
                if (node.children != null)
                {
                    for (int i = 0; i < node.children.size(); i++)
                    {
                        queue.enqueue(node.children.get(i));
                    }
                }

                //show the change
                showChanges(tree_elements, ++update_count);
            }
            return return_value;
        }

        //Returns the total number of elements in the M-ary tree (for visual updates when calculating)
        private int getTotalTreeElements(int the_number_of_elements)
        {
            int count = the_number_of_elements;
            int last_level = count;

            //this calculates the number of nodes on the current tree level multiplied
            //by the number of elements left
            for (int i = the_number_of_elements - 1; i >= 1; i--)
            {
                int temp = last_level * i;
                count = count + temp;
                last_level = temp;
            }
            return count;
        }

        //Sends updates to any observers watching the process
        private void showChanges(int the_total, int the_current)
        {
            changed = true;
            notifyUpdate(new object[] { the_total, the_current });
        }
    }
}
