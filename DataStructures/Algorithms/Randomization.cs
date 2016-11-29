using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStructures.PrimitiveWrappers;

namespace DataStructures.Algorithms
{
    /// <summary>
    /// Algorithm class that holds useful methods related to (quasi) randomness.
    /// </summary>
    public class Randomization
    {
        private static Random my_rand = new Random();

        /// <summary>
        /// Shuffles an array of elements.
        /// </summary>
        /// <typeparam name="T">the reference type of elements in the array.</typeparam>
        /// <param name="the_array">the array of elements.</param>
        public static void shuffleArray<T>(ref T[] the_array)
        {
            for (int i = 0; i < the_array.Length; i++)
            {
                Arrays.swap<T>(the_array, i, my_rand.Next(0, the_array.Length));
            }
        }

        /// <summary>
        /// Puts the first n integers into an array and then returns a random permutation of them.
        /// </summary>
        /// <typeparam name="T">the reference type of elements in the returned array.</typeparam>
        /// <param name="the_max_number">the number of integer n.</param>
        /// <returns>a random permutation of the first n integers.</returns>
        public static DSInteger[] randomPermutation<T>(int the_max_number)
        {
            //add the first n integers to and array.
            DSInteger[] return_value = new DSInteger[the_max_number];
            for (int i = 0; i < return_value.Length; i++)
            {
                return_value[i] = new DSInteger(i);
            }

            //get a random permutation and return
            shuffleArray<DSInteger>(ref return_value);
            return return_value;
        }
    }
}
