using System;
using System.Linq;
using System.Text;
using DataStructures.PrimitiveWrappers;
using DataStructures.Interfaces;
using DataStructures.Algorithms;

namespace DataStructures.Basic
{
    /// <summary>
    /// This class represents a collection of disjoint sets. The class
    /// allows for almost linear time for union and find operations on 
    /// the sets.
    /// </summary>
    /// <typeparam name="T">the reference type of set labels.</typeparam>
    public class DisjointSets<T> where T : class 
    {
        private const int DEFAULT_SETS = 10;

        private Map<T, DSInteger> my_index_map;
        private Map<DSInteger, T> my_value_map;
        private int[] my_sets;
        private int my_set_size = 0;

        /// <summary>
        /// Sets up the disjoint sets with default settings.
        /// </summary>
        public DisjointSets()
        {
            setupDS(DEFAULT_SETS);
            my_sets = new int[DEFAULT_SETS];
        }

        /// <summary>
        /// Sets up the disjoint sets with an initial array of set
        /// elements.
        /// </summary>
        /// <param name="the_values">array of set elements.</param>
        public DisjointSets(T[] the_values)
        {
            setupDS(the_values.Length);
            my_set_size = the_values.Length;

            //add all elements to the structure
            for (int i = 0; i < the_values.Length; i++)
            {
                DSInteger index = new DSInteger(i);
                T value = the_values[i];
                my_index_map.put(value, index); //map to index
                my_value_map.put(index, value); //map to value
            }

            my_sets = new int[the_values.Length];
            Helpers.initializeArray<int>(my_sets, -1);
        }

        /// <summary>
        /// Performs a union between two sets.
        /// </summary>
        /// <param name="the_one">the first set.</param>
        /// <param name="the_two">the second set.</param>
        public void union(T the_one, T the_two)
        {
            //make sure is valid input
            checkIsASet(the_one);
            checkIsASet(the_two);

            int set_one_index = find(the_one);
            int set_two_index = find(the_two);
            int set_one = my_sets[set_one_index];
            int set_two = my_sets[set_two_index];

            //quick out if necessary
            if (set_one_index == set_two_index)
            {
                return;
            }

            //------- UNION BY RANK --------
            //if the second set is deeper than the first
            if (set_two < set_one)
            {
                my_sets[set_one_index] = set_two_index;
            }
            else//if the first set is deeper/equal height with the first
            {
                //if they are the same, increase the height of the resulting set
                if (set_one == set_two)
                {
                    my_sets[set_one_index]--;
                }
                my_sets[set_two_index] = set_one_index;
            }
        }

        /// <summary>
        /// Finds the set an element belongs to.
        /// </summary>
        /// <param name="the_check">the set to check.</param>
        /// <returns>the index of the other set this one belongs to.</returns>
        public int find(T the_check)
        {
            checkIsASet(the_check);
            return find(my_index_map.get(the_check).value);
        }

        /// <summary>
        /// Adds a set to the collection of sets.
        /// </summary>
        /// <param name="the_new_value">the new set to add.</param>
        public void addSet(T the_new_value)
        {
            my_set_size++;
            checkForResize();
            my_index_map.put(the_new_value, new DSInteger(my_set_size - 1));
            my_value_map.put(new DSInteger(my_set_size - 1), the_new_value); //map to value
            my_sets[my_set_size - 1] = -1;
        }

        /// <summary>
        /// Gets the sets elements that belong to a certain set (by index). Use
        /// the find() operation to get the index of a set.
        /// </summary>
        /// <param name="the_set_index">the ind</param>
        /// <returns></returns>
        public List<T> getSetElements(int the_set_index)
        {
            List<T> return_value = new ArrayList<T>();

            //loop through all set elements
            for (int i = 0; i < my_set_size; i++)
            {
                //if they belong to the set in question, add them to the return list
                int set_index = find(i);
                if (set_index == the_set_index)
                {
                    return_value.add(my_value_map.get(new DSInteger(i)));
                }
            }

            return return_value;
        }

        /// <summary>
        /// Gets the sets elements that belong to a certain set (by index). Use
        /// the find() operation to get the index of a set.
        /// </summary>
        /// <param name="the_set_index">the ind</param>
        /// <returns></returns>
        public int getSetCount(int the_set_index)
        {
            int count = 0;

            //loop through all set elements
            for (int i = 0; i < my_set_size; i++)
            {
                //if they belong to the set in question, add them to the return list
                int set_index = find(i);
                if (set_index == the_set_index)
                {
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        /// Gives a string representation of the sets in the disjoint set class.
        /// </summary>
        /// <returns>a string representation.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            //loop through all labels and output the set they belong to
            bool first = true;
            Iterator<T> it = my_value_map.values().iterator();
            while (it.hasNext())
            {
                T next = it.next();

                if (first)
                {
                    first = false;
                }
                else
                {
                    builder.Append(", ");
                }

                builder.Append("Label: ");
                builder.Append(next.ToString());
                builder.Append(" Set: ");
                builder.Append(find(next).ToString());
            }

            return builder.ToString();
        }

        //-------------------- HELPER METHODS --------------------

        //finds the set an element belongs to.
        private int find(int the_index)
        {
            if (my_sets[the_index] < 0)
            {
                return the_index;
            }
            else
            {
                //path compression, each item from the first index to the root of the
                //uptree is pointed at the root
                return (my_sets[the_index] = find(my_sets[the_index]));
            }
        }

        //checks whether the set given is valid (has been added as a set).
        private void checkIsASet(T the_other)
        {
            if (!my_index_map.containsKey(the_other))
            {
                throw new ArgumentException("Element not added as a set.");
            }
        }

        //checks whether to resize the inner array since this disjoint set class is dynamic.
        private void checkForResize()
        {
            if (my_set_size > my_sets.Length)
            {
                my_sets = Arrays.copyArray<int>(my_sets, my_sets.Length + my_sets.Length); //double size
            }
        }
        
        //sets up the disjoint set class inner data structures.
        private void setupDS(int the_number_of_elements)
        {
            if (my_set_size > 0)
            {
                my_index_map = new HashMap<T, DSInteger>(the_number_of_elements);
                my_value_map = new HashMap<DSInteger, T>(the_number_of_elements);
            }
            else
            {
                my_index_map = new HashMap<T, DSInteger>();
                my_value_map = new HashMap<DSInteger, T>();
            }
        }
    }
}
