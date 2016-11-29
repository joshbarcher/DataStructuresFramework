using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStructures.Exceptions;
using DataStructures.Interfaces;

namespace DataStructures.Algorithms
{
    public class Arrays
    {
        /// <summary>
        /// Reverses the elements in an array.
        /// </summary>
        /// <typeparam name="T">the reference type of elements in the array.</typeparam>
        /// <param name="the_source">the source array.</param>
        public static void reverse<T>(T[] the_source) where T : class 
        {
            //quick out for null array or already sorted array of length 0 or 1
            if (the_source == null || the_source.Length < 2)
            {
                return;
            }

            //swap elements symmetrically
            for (int i = 0; i < the_source.Length / 2; i++)
            {
                Arrays.swap<T>(the_source, i, the_source.Length - i - 1);
            }
        }

        /// <summary>
        /// Clones all elements of an array with values from the_source to the_dest.
        /// </summary>
        /// <typeparam name="T">the reference type of values in the array (must be cloneable).</typeparam>
        /// <param name="the_source">the source array.</param>
        /// <param name="the_dest">the destination array.</param>
        /// <returns>a cloned array.</returns>
        public static void cloneArray<T>(ref T[] the_source, ref T[] the_dest) where T : class, Cloneable
        {
            //check for cloning to the same array
            if (the_source == the_dest)
            {
                throw new IllegalStateException("Source and destination array cannot be the same.");
            }

            //resize the array only on the first call
            if (the_dest == null || the_dest.Length != the_source.Length)
            {
                the_dest = new T[the_source.Length];
            }

            //deep copy of the array
            for (int i = 0; i < the_source.Length; i++)
            {
                if (the_source[i] != null)
                {
                    the_dest[i] = (T)the_source[i].clone(); //clones the object if valid
                }
                else
                {
                    the_dest[i] = null;
                }
            }
        }

        /// <summary>
        /// Copies an array to a new array of a certain size.
        /// </summary>
        /// <typeparam name="T">the reference type of elements in both arrays.</typeparam>
        /// <param name="the_source">the source array.</param>
        /// <param name="the_new_size">the size of the new array.</param>
        /// <returns>the new array with elements from the source array.</returns>
        public static T[] copyArray<T>(T[] the_source, int the_new_size)
        {
            //check for bad arguments
            Preconditions.checkNull(the_source);
            Preconditions.checkNonNegative(the_new_size);

            //instantiate the new array and get the maximum index
            T[] ret_value = new T[the_new_size];
            int min_copy_index = Math.Min(the_source.Length, the_new_size);

            //copy
            for (int i = 0; i < min_copy_index; i++)
            {
                ret_value[i] = the_source[i];
            }

            return ret_value;
        }

        /// <summary>
        /// Shifts array elements down in the array.
        /// </summary>
        /// <typeparam name="T">the reference type of elements in both arrays.</typeparam>
        /// <param name="the_source">the source array.</param>
        /// <param name="the_start">the starting index to shift elements.</param>
        /// <param name="the_end">the last index to shift from, the element at this index
        /// is set to null.</param>
        public static void shiftArrayElementsDown<T>(T[] the_source, int the_start, int the_end) where T : class
        {
            //shift elements
            for (int i = the_start; i < the_end - 1; i++)
            {
                the_source[i] = the_source[i + 1];
            }

            the_source[the_end - 1] = null;
        }

        /// <summary>
        /// Shifts array elements up in the array.
        /// </summary>
        /// <typeparam name="T">the reference type of elements in both arrays.</typeparam>
        /// <param name="the_source">the source array.</param>
        /// <param name="the_start">the starting index to shift elements, the element at this index
        /// is set to null.</param>
        /// <param name="the_end">the last index to shift to.</param>
        public static void shiftArrayElementsUp<T>(T[] the_source, int the_start, int the_end) where T : class
        {
            Preconditions.checkNull(the_source);
            Preconditions.checkNonNegative(the_start);
            Preconditions.checkNonNegative(the_end);
            Preconditions.checkNonNegative(the_end - the_start);

            //shift elements
            for (int i = the_end - 1; i > the_start; i--)
            {
                the_source[i] = the_source[i - 1];
            }

            the_source[the_start] = null;
        }

        /// <summary>
        /// Swaps two elements in an array using their indexes to find them.
        /// </summary>
        /// <typeparam name="T">the reference type of elements in both arrays.</typeparam>
        /// <param name="the_array">the source array.</param>
        /// <param name="the_first_index">the index of the first element.</param>
        /// <param name="the_second_index">the index of the second element.</param>
        public static void swap<T>(T[] the_array, int the_first_index, int the_second_index)
        {
            //no precondition checks here, this method needs to be fast

            T temp = the_array[the_first_index];
            the_array[the_first_index] = the_array[the_second_index];
            the_array[the_second_index] = temp;
        }

        /// <summary>
        /// Sets the elements of an array to null.
        /// </summary>
        /// <typeparam name="T">the reference type of elements in both arrays.</typeparam>
        /// <param name="the_array">the source array.</param>
        public static void clearArray<T>(T[] the_array) where T : class
        {
            Preconditions.checkNull(the_array);

            for (int i = 0; i < the_array.Length; i++)
            {
                the_array[i] = null;
            }
        }
    }
}
