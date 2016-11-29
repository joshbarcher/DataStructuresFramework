using System;
using System.Linq;
using System.Text;
using Algorithms;
using DataStructures.Basic;
using DataStructures.Interfaces;

namespace DataStructures.Algorithms
{
    public class SetOperations
    {
        /// <summary>
        /// Adds the elements from this set and the_other set and joins them into a common set.
        /// </summary>
        /// <param name="the_other">the other set to union with.</param>
        /// <returns>A new set which is the union of this set and the_other set.</returns>
        public static Set<T> union<T>(Set<T> the_first, Set<T> the_other) where T : class, Comparable<T>
        {
            //flag the new set size for minimal collisions in the final inner array size
            Set<T> return_value = new HashSet<T>(the_other.size() + the_first.size());

            //iterate over both sets and add them to the new set
            Iterator<T> it = the_first.iterator();
            while (it.hasNext())
            {
                return_value.add(it.next());
            }

            it = the_other.iterator();
            while (it.hasNext())
            {
                return_value.add(it.next());
            }

            return return_value;
        }

        /// <summary>
        /// Adds common elements between this set and the_other set into a third set, which is returned.
        /// </summary>
        /// <param name="the_other">the other set to intersect with.</param>
        /// <returns>A new set with all elements which are common to both this set and the_other set.</returns>
        public static Set<T> intersection<T>(Set<T> the_first, Set<T> the_other) where T : class, Comparable<T>
        {
            Set<T> return_value = new HashSet<T>();

            addCommonEntries(ref return_value, the_first, the_other.toArray());
            addCommonEntries(ref return_value, the_other, the_first.toArray());

            return return_value;
        }

        /// <summary>
        /// Adds all elements which are in this set but not in the_other set.
        /// </summary>
        /// <param name="the_other">the other set to consider in the difference operation.</param>
        /// <returns>A new set with all elements unique to this set.</returns>
        public static Set<T> difference<T>(Set<T> the_first, Set<T> the_other) where T : class, Comparable<T>
        {
            Set<T> return_value = new HashSet<T>();

            addDifferentEntries(ref return_value, the_first, the_other.toArray());

            return return_value;
        }

        /// <summary>
        /// Adds all elements that are unique between this set and the_other set and visa-versa. So, the 
        /// returned set will have all elements that are in this set and not the_other AND all elements that
        /// are in the other_set and not this set.
        /// </summary>
        /// <param name="the_other">the other set to consider in the symmetric difference operation.</param>
        /// <returns>A new set with all elements that are unique between this set and the_other set and visa-versa.</returns>
        public static Set<T> symmetricDifference<T>(Set<T> the_first, Set<T> the_other) where T : class, Comparable<T>
        {
            Set<T> return_value = new HashSet<T>();

            addDifferentEntries(ref return_value, the_first, the_other.toArray());
            addDifferentEntries(ref return_value, the_other, the_first.toArray());

            return return_value;
        }

        /// <summary>
        /// Determines whether this set is a subset of the_other set.
        /// </summary>
        /// <param name="the_other">The other set to consider in the subset operation.</param>
        /// <returns>True if this is a subset of the other set, otherwise false.</returns>
        public static bool subset<T>(Set<T> the_first, Set<T> the_other) where T : class, Comparable<T>
        {
            //if the difference between this set and the_other is the empty set, then
            //this is a subset of the_other set.
            Set<T> check = new HashSet<T>();
            addDifferentEntries(ref check, the_first, the_other.toArray());

            return check.size() == 0;
        }

        //adds common entries between a set and an array into a new set
        private static void addCommonEntries<T>(ref Set<T> the_new_set, Set<T> the_old_set, T[] the_old_array) where T : class, Comparable<T>
        {
            //iterate over this set and see which items are in the other set
            Iterator<T> it = the_old_set.iterator();
            while (it.hasNext())
            {
                T next = it.next();
                int index = Searching.binarySearch<T>(the_old_array, next);

                //if the item is found
                if (index != -1)
                {
                    the_new_set.add(next);
                }
            }
        }

        //adds elements that are in a set, but are also not in an array, to another set
        private static void addDifferentEntries<T>(ref Set<T> the_new_set, Set<T> the_old_set, T[] the_old_array) where T : class, Comparable<T>
        {
            //iterate over this set and see which items are in the other set
            Iterator<T> it = the_old_set.iterator();
            while (it.hasNext())
            {
                T next = it.next();
                int index = Searching.binarySearch<T>(the_old_array, next);

                //if the item is found
                if (index == -1)
                {
                    the_new_set.add(next);
                }
            }
        }
    }
}
