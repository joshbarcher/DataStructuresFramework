using System;
using System.Text;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures.Interfaces;
using DataStructures.PrimitiveWrappers;
using DataStructures.Algorithms;
using System.Collections;
using DataStructures.Basic;

namespace DataStructureTests
{
    /// <summary>
    /// Tests the various sorts in this assembly.
    /// </summary>
    [TestClass]
    public class Sortings
    {
        private Random my_rand = new Random();
        private List<DSInteger> my_sortable_list;
        private List<DSInteger> my_large_sortable_list;

        private TestContext testContextInstance;

        public Sortings()
        {
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        
        //Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize() 
        {
            my_sortable_list = new ArrayList<DSInteger>();
            my_large_sortable_list = new ArrayList<DSInteger>();
        }
        
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void testSorts()
        {
            Array sorts = Enum.GetValues(Sorts.BubbleSort.GetType());
            IEnumerator enumerator = sorts.GetEnumerator();
            while (enumerator.MoveNext())
            {
                for (int i = 0; i < 5; i++)
                {
                    testSort((Sorts)enumerator.Current);
                }
            }
        }

        //----------------------- HELPER METHODS -------------------------

        //tests a certain sort with both a small list and large list.
        private void testSort(Sorts the_sort_type)
        {
            fillLists();

            //small list
            DSInteger[] elements = my_sortable_list.toArray();
            testSingleSort(the_sort_type, ref elements);

            //large list
            elements = my_large_sortable_list.toArray();
            testSingleSort(the_sort_type, ref elements);
        }

        //tests a single sort with an array of elements.
        private void testSingleSort(Sorts the_sort_type, ref DSInteger[] the_elements)
        {
            Sorting<DSInteger>.Sort(the_sort_type, ref the_elements);
            Assert.AreEqual(true, Sorting<DSInteger>.isSorted(the_elements, true));
        }

        //fills a large and small list with elements
        private void fillLists()
        {
            my_sortable_list.clear();
            my_large_sortable_list.clear();

            for (int i = 0; i < 50; i++)
            {
                my_sortable_list.add(new DSInteger(my_rand.Next(1, 21)));
            }

            for (int i = 0; i < 1000; i++)
            {
                my_large_sortable_list.add(new DSInteger(my_rand.Next(1, 1001)));
            }
        }
    }
}
