using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Basic
{
    /// <summary>
    /// A stack that has a limited number of elements allowed within itself.
    /// </summary>
    /// <typeparam name="T">the reference type of elements on the stack.</typeparam>
    public class BoundedStack<T> : Stack<T> where T : class
    {
        private int my_max_elements;

        /// <summary>
        /// Sets up the stack with a stack limit.
        /// </summary>
        /// <param name="the_max_elements">the maximum number of elements
        /// on the stack.</param>
        public BoundedStack(int the_max_elements)
        {
            my_max_elements = the_max_elements;
        }

        /// <summary>
        /// Sets up the stack with a stack limit and initial elements.
        /// </summary>
        /// <param name="the_max_elements"></param>
        /// <param name="the_initial_elements"></param>
        public BoundedStack(int the_max_elements, T[] the_initial_elements)
            : this(the_max_elements)
        {
            for (int i = 0; i < the_initial_elements.Length; i++)
            {
                push(the_initial_elements[i]);
            }
        }

        /// <summary>
        /// Pushs elements onto the stack. A check is made to make sure you do not
        /// add more elements than the maximum allowed.
        /// </summary>
        /// <param name="the_addition">the new element.</param>
        /// <returns>true if the element was added successfully, otherwise false.</returns>
        public override bool push(T the_addition)
        {
            if (my_list.size() == my_max_elements)
            {
                throw new StackOverflowException("You have added an item beyond the bound of this stack.");
            }

            return base.push(the_addition);
        }
    }
}
