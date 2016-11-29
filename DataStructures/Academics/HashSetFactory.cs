using System;
using System.Linq;
using System.Text;
using DataStructures.Interfaces;
using DataStructures.Basic;

namespace DataStructures.Academics
{
    /// <summary>
    /// Simple hashing method that can be used to insert different strategies
    /// for hashing into a hash structure. In this case it overrides the default
    /// hash method in the hash set class.
    /// </summary>
    /// <typeparam name="T">the reference type of elements stored in the hashset.</typeparam>
    /// <param name="the_object">the object to get a hash code from.</param>
    /// <param name="the_table_length">the length of the inner table of the hash set.</param>
    /// <returns></returns>
    public delegate int hash<T>(T the_object, int the_table_length) where T : class;

    /// <summary>
    /// This class simply provides some child classes of the hash set class. The class follows
    /// the factory pattern and provides hash sets that follow a hashing strategy. These classes
    /// are meant purely for observation so that an optimal hashing algorithm can be tested and
    /// found. In this regard, this class also follows the strategy pattern.
    /// </summary>
    /// <typeparam name="T">the reference type of elements stored in the hashsets formed by this
    /// class.</typeparam>
    public class HashSetFactory<T> where T : class
    {
        /// <summary>
        /// Builds a hash set around a strategy for hashing and returns it to the user.
        /// </summary>
        /// <param name="the_strategy"></param>
        /// <returns></returns>
        public static HashSet<T> getHashSet(HashingStrategy the_strategy)
        {
            //go through the strategies and build a hash set accordingly
            switch (the_strategy)
            {
                case HashingStrategy.ModTableSize:
                    return new StrategyHashSet<T>(modTableSize, "Math.abs( item.GetHashCode() ) % my_table.length;");
                case HashingStrategy.MultiplyPrimeModPrimeModTable:
                    return new StrategyHashSet<T>(multiplyPrimeModPrime, "int hash = item.GetHashCode();" + 
                        "  Math.abs( 37 * hash + hash % 37 ) % my_table.length;");
                default:
                    throw new ArgumentException("No such enum value found.");
            }
        }

        /// <summary>
        /// This method is meant to be used as a strategy for hashing in a hash table.
        /// The method uses a prime number to multiply and then mod with the input item.
        /// </summary>
        /// <param name="the_object">input item to get a hash code from.</param>
        /// <param name="the_table_length">length of the inner table inside the hash set.</param>
        /// <returns>an integer hash value for the object to be inserted into a hash
        /// table.</returns>
        public static int multiplyPrimeModPrime(T the_object, int the_table_length)
        {
            int hash = the_object.GetHashCode();
            return Math.Abs(37 * hash + hash % 37) % the_table_length;
        }

        /// <summary>
        /// This method is meant to be used as a strategy for hashing in a hash table.
        /// The method uses the most simple method of hashing, returning the mod of
        /// the items hash code to the length of the table inside the hash set.
        /// </summary>
        /// <param name="the_object">input item to get a hash code from.</param>
        /// <param name="the_table_length">length of the inner table inside the hash set.</param>
        /// <returns>an integer hash value for the object to be inserted into a hash
        /// table.</returns>
        public static int modTableSize(T the_object, int the_table_length)
        {
            return Math.Abs(the_object.GetHashCode()) % the_table_length;
        }
    }

    /// <summary>
    /// Helper class that stores a hash method to hash within the hash set and an
    /// output string that displays a string representation of the hashing algorithm.
    /// This class is only meant to be used for testing and academic purposes.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class StrategyHashSet<T> : HashSet<T> where T : class 
    {
        private hash<T> my_hashing_method;
        private string my_method;

        /// <summary>
        /// Sets up the hash set with an alternate hashing function and
        /// a string representation of that function.
        /// </summary>
        /// <param name="the_hashing_method">the hashing function pointer.</param>
        /// <param name="the_method">the string representation of the hashing
        /// function.</param>
        public StrategyHashSet(hash<T> the_hashing_method, string the_method)
        {
            my_hashing_method = the_hashing_method;
            my_method = the_method;
        }

        //this method overrides the standard hash function
        internal override int hash(T the_object, int the_table_length)
        {
            return my_hashing_method(the_object, the_table_length);
        }

        /// <summary>
        /// Returns a string representation of the hash function provided in this class.
        /// </summary>
        /// <returns>the string representation.</returns>
        public string getStrategyFunction()
        {
            return my_method;
        }
    }

    /// <summary>
    /// An enum that represents different hashing strategies in a hash table.
    /// </summary>
    public enum HashingStrategy
    {
        ModTableSize,
        MultiplyPrimeModPrimeModTable
    }
}
