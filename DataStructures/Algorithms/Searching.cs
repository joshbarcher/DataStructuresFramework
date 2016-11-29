using System;
using System.Linq;
using System.Text;
using DataStructures;
using DataStructures.Interfaces;
using DataStructures.Basic;

namespace Algorithms
{
    /// <summary>
    /// Algorithm class that has static methods for searching through data structures.
    /// </summary>
    public class Searching
    {
        /// <summary>
        /// This method returns a split-traversal through an array of elements. The first
        /// element in the traversal is the middle element in the array. Then each sub-array
        /// to the left and right of the middle element are called recursively and their
        /// middle elements are added to the traversal. This search method is useful when used
        /// on a sorted array because the ordering of elements returned can be added to a 
        /// binary search tree to ensure logarithmic search time.
        /// </summary>
        /// <typeparam name="T">the reference type of the elements in the array.</typeparam>
        /// <param name="the_array">the array of elements.</param>
        /// <returns>a list with elements in the order they were traversed during the search.</returns>
        public static List<T> binarySplit<T>(T[] the_array) where T : class 
        {
            List<T> return_value = new ArrayList<T>(the_array.Length);

            binarySplit<T>(the_array, 0, the_array.Length - 1, return_value);

            return return_value;
        }

        /// <summary>
        /// Standard binary search which, when performed on a sorted array, returns an element
        /// searched for in logarithmic time.
        /// </summary>
        /// <typeparam name="T">the reference type of the elements in the array.</typeparam>
        /// <param name="the_array">the array of elements.</param>
        /// <param name="the_search">the element being searched for in the array.</param>
        /// <returns>the index of the element found in the array, or -1 if not found</returns>
        public static int binarySearch<T>(T[] the_array, T the_search) where T: class, Comparable<T>
        {
            //quick out for empty arrays
            if (the_array == null || the_array.Length == 0)
            {
                return -1;
            }

            int low = 0;
            int high = the_array.Length - 1;
            int mid;

            //binary search routine
            while (low <= high)
            {
                mid = (low + high) / 2;

                if (the_array[mid].compareTo(the_search) < 0)
                {
                    low = mid + 1;
                }
                else if (the_array[mid].compareTo(the_search) > 0)
                {
                    high = mid - 1;
                }
                else 
                {
                    return mid;
                }
            }

            return -1;
        }

        //------------------------ HELPER METHODS ---------------------------

        //this method is called recursively to perform the binarySplit on an array
        //(see the comments for the method above)
        private static void binarySplit<T>(T[] the_array, int the_low, int the_high, List<T> the_traversal) where T : class
        {
            //base case (no elements)
            if (the_low > the_high)
            {
                return;
            }

            //add the middle element to the list
            int mid = (the_high + the_low) / 2;
            the_traversal.add(the_array[mid]);

            //recursively check the left and right sub-array
            binarySplit<T>(the_array, the_low, mid - 1, the_traversal);
            binarySplit<T>(the_array, mid + 1, the_high, the_traversal);
        }
    }
}
