using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStructures.Interfaces;

namespace DataStructures.HelperClasses
{
    internal class GraphIterator<T> : Iterator<T> where T : class
    {
        private BasicStack<Vertex<T>> my_elements;
        private DirectedGraph<T> my_parent;

        private GraphTraversals my_traversal_method;

        public GraphIterator(GraphTraversals the_traversal_method, Vertex<T> the_parent_root, DirectedGraph<T> the_parent)
        {
            /*my_traversal_method = the_traversal_method;
            my_parent = the_parent;

            //prepare stack for traversal
            my_elements = new Stack<BinaryNode<T>>(my_parent.size());

            //add the first element if it is there
            if (my_parent.my_root != null)
            {
                my_elements.push(my_parent.my_root);
            }*/
        }

        public T next()
        {
            if (my_traversal_method == GraphTraversals.InOrder)
            {
                return InOrderNext();
            }
            else if (my_traversal_method == GraphTraversals.PostOrder)
            {
                return PostOrderNext();
            }
            else if (my_traversal_method == GraphTraversals.PreOrder)
            {
                return PreOrderNext();
            }
            return null;
        }

        public bool hasNext()
        {
            return !my_elements.isEmpty();
        }

        public T remove()
        {
            return null;
        }

        //------------------- HELPER METHODS ---------------------

        private T InOrderNext()
        {
            /*BinaryNode<T> last = my_elements.pop();
            if (last.stack_turn == 0) //first time off the stack
            {
                //put last back on the stack and mark as visited
                my_elements.push(last);
                last.stack_turn++;

                if (last.left != null)
                {
                    my_elements.push(last.left);
                }
                return InOrderNext();
            }
            else //stack_turn == 1
            {
                if (last.right != null)
                {
                    my_elements.push(last.right);
                }

                last.stack_turn = 0;
                return last.value;
            }*/
            return null;
        }

        private T PreOrderNext()
        {
            /*BinaryNode<T> last = my_elements.pop();

            if (last.right != null)
            {
                my_elements.push(last.right);
            }
            if (last.left != null)
            {
                my_elements.push(last.left);
            }

            return last.value;*/
            return null;
        }

        private T PostOrderNext()
        {
            /*BinaryNode<T> last = my_elements.pop();

            if (last.stack_turn == 0)
            {
                //put last back on the stack and mark as visited
                my_elements.push(last);
                last.stack_turn++;

                if (last.right != null)
                {
                    my_elements.push(last.right);
                }
                if (last.left != null)
                {
                    my_elements.push(last.left);
                }

                return PostOrderNext();
            }
            else //stack_turn == 1
            {
                return last.value;
            }*/
            return null;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}