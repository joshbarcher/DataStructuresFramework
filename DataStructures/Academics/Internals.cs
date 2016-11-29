using System;
using System.Linq;
using System.Text;
using DataStructures.Basic;
using DataStructures.HelperClasses;
using DataStructures.Exceptions;
using DataStructures.Interfaces;
using DataStructures.Algorithms;

namespace DataStructures.Academics
{
    /// <summary>
    /// This class provides access to the internal structures of some of the data structures
    /// provided in this assembly. Access is limited and provided purely for testing or 
    /// academic purposes.
    /// </summary>
    public class Internals
    {
        /// <summary>
        /// Provides access to the inner hash table of the hash set. The copy of the internal
        /// array is a deep copy to prevent tampering. This method only exists to provide for
        /// testing and academics.
        /// </summary>
        /// <typeparam name="T">the reference type of the elements stored in the set.</typeparam>
        /// <param name="the_set">the set to search.</param>
        /// <returns>the array of elements.</returns>
        public static void getHashSetInternals<T>(HashSet<T> the_set, ref T[] the_dest) where T : class, Cloneable
        {
            Preconditions.checkNull(the_set);

            HashEntry<T>[] inner = the_set.inner_array;

            //resize the array only on the first call
            if (the_dest == null || the_dest.Length != inner.Length)
            {
                the_dest = new T[inner.Length];
            }

            //deep copy of the array
            for (int i = 0; i < inner.Length; i++)
            {
                if (inner[i] != null)
                {
                    the_dest[i] = (T)inner[i].entry.clone(); //clones the object if valid
                }
                else
                {
                    the_dest[i] = null;
                }
            }
        }

        /// <summary>
        /// Gives access to a cloned copy of the internals of the binary heap class.
        /// </summary>
        /// <typeparam name="T">the reference type of elements in the heap (must be cloneable).</typeparam>
        /// <param name="the_heap">the heap to find elements in.</param>
        /// <param name="the_array">the array to store the internals in.</param>
        public static void getHeapInternals<T>(BinaryHeap<T> the_heap, ref T[] the_array) where T : class, Cloneable
        {
            Preconditions.checkNull(the_heap);

            //get cloned copies of the elements
            T[] internal_array = the_heap.internal_array;
            Arrays.cloneArray<T>(ref internal_array, ref the_array);
        }
    }
}
