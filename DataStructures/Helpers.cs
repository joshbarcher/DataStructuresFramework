using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStructures.Interfaces;
using DataStructures.Exceptions;

namespace DataStructures
{
    /// <summary>
    /// Contains helper methods for this assembly.
    /// </summary>
    public class Helpers
    {
        /// <summary>
        /// Checks whether a clone is successful and returns the cloned object.
        /// </summary>
        /// <param name="the_cloneable">the object to clone.</param>
        /// <returns>the new cloned object.</returns>
        public static Cloneable cloneCheck(Cloneable the_cloneable)
        {
            Cloneable clone = (Cloneable)the_cloneable.clone();

            //this check removes the chance of a programmer building a cloneable that
            //returns a reference to itself
            //this check ensures that after object.clone() is called, only a disconnected
            //object is returned
            if (the_cloneable == clone)
            {
                throw new ArgumentException("Clone method returns reference to the same object.");
            }

            return clone;
        }

        /// <summary>
        /// Initializes an array to some set value.
        /// </summary>
        /// <typeparam name="T">the reference type of elements in both arrays.</typeparam>
        /// <param name="the_array">the source array.</param>
        /// <param name="the_initial_value">the initial value of all items.</param>
        public static void initializeArray<T>(T[] the_array, T the_initial_value)
        {
            for (int i = 0; i < the_array.Length; i++)
            {
                the_array[i] = the_initial_value;
            }
        }

        /// <summary>
        /// Checks whether two collections contain the same elements at the same traversal locations.
        /// How the elements are found are up to the structures.
        /// </summary>
        /// <typeparam name="T">the reference type of elements in both arrays.</typeparam>
        /// <param name="the_one">the first collection.</param>
        /// <param name="the_two">the second collection.</param>
        /// <returns>true if they contain the same elements at the same locations, otherwise false.</returns>
        public static bool checkEqualCollections<T>(Collection<T> the_one, Collection<T> the_two) where T : class
        {
            //if sizes differ then they can't be equal
            if (the_one.size() != the_two.size())
            {
                return false;
            }

            //traverse and check like elements
            Iterator<T> it_one = the_one.iterator();
            Iterator<T> it_two = the_two.iterator();
            while (it_one.hasNext())
            {
                if (!it_one.next().Equals(it_two.next()))
                {
                    return false;
                }
            }
            return true;
        }

        //prints an element with a preceeding label taking into account whether the element is null.
        internal static void printElementIfNull(StringBuilder the_builder, string the_element_label, object the_element)
        {
            if (the_element == null)
            {
                the_builder.Append(the_element_label);
                the_builder.Append(": null");
            }
            else
            {
                the_builder.Append(the_element_label);
                the_builder.Append(": ");
                the_builder.Append(the_element.ToString());
            }
        }

        //prints an element with a preceeding label taking into account whether the element is null.
        internal static void printElementIfNull(StringBuilder the_builder, object the_element)
        {
            if (the_element == null)
            {
                the_builder.Append("null");
            }
            else
            {
                the_builder.Append(the_element.ToString());
            }
        }
    }
}
