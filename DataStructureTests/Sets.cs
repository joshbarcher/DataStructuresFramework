using System;
using System.Text;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;
using DataStructures.PrimitiveWrappers;
using DataStructures.Basic;
using Algorithms;
using DataStructures.Algorithms;
using DataStructures.Interfaces;

namespace DataStructureTests
{
    /// <summary>
    /// Test the various set structures in this assembly.
    /// </summary>
    [TestClass]
    public class Sets
    {
        private Set<DSInteger> my_hs;
        private TreeSet<DSInteger> my_ts;

        private TestContext testContextInstance;

        public Sets()
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
        
        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize() 
        {
            my_hs = new HashSet<DSInteger>();
            my_ts = new TreeSet<DSInteger>();
            addInitialItems(my_hs);
            addInitialItems(my_ts);
        }
        
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void testAdd()
        {
            testAdd(my_hs);
            testAdd(my_ts);
        }

        [TestMethod]
        public void testIsEmpty()
        {
            testIsEmpty(my_hs);
            testIsEmpty(my_ts);
        }

        [TestMethod]
        public void testSize()
        {
            testSize(my_hs);
            testSize(my_ts);
        }

        [TestMethod]
        public void testContains()
        {
            testContains(my_hs);
            testContains(my_ts);
        }

        [TestMethod]
        public void testRemove()
        {
            testRemove(my_hs);
            testRemove(my_ts);
        }

        [TestMethod]
        public void testClear()
        {
            testClear(my_hs);
            testClear(my_ts);
        }

        [TestMethod]
        public void testToArray()
        {
            testToArray(my_hs);
            testToArray(my_ts);
        }

        [TestMethod]
        public void testIterator()
        {
            testIterator(my_hs);
            testIterator(my_ts);
        }

        [TestMethod]
        public void testFirst()
        {
            testFirst(my_ts);
        }

        [TestMethod]
        public void testLast()
        {
            testLast(my_ts);
        }

        [TestMethod]
        public void testToString()
        {
            testToString(my_hs);
            testToString(my_ts);
        }

        private void testToString(Set<DSInteger> the_set)
        {
            //just test for no exceptions, leave the output to the programmer, user
            try
            {
                the_set.ToString();
            }
            catch (Exception the_ex)
            {
                Assert.Fail();
            }
        }

        private void testFirst(TreeSet<DSInteger> the_set)
        {
            //test the obvious first
            Assert.AreEqual(10, the_set.first().value);

            //remove the first and check for a correct first after the alteration
            the_set.remove(new DSInteger(10));
            Assert.AreEqual(20, the_set.first().value);
            
            //remove all items and make sure first() returns null
            the_set.clear();
            Assert.AreEqual(null, the_set.first());
        }

        private void testLast(TreeSet<DSInteger> the_set)
        {
            //test the obvious last
            Assert.AreEqual(130, the_set.last().value);

            //remove the last and check for a correct last after the alteration
            the_set.remove(new DSInteger(130));
            Assert.AreEqual(120, the_set.last().value);

            //remove all items and make sure last() returns null
            the_set.clear();
            Assert.AreEqual(null, the_set.last());
        }

        private void testAdd(Set<DSInteger> the_set)
        {
            //test whether the additions worked (1 should not be added as a duplicate)
            Assert.AreEqual(13, the_set.size());
            Assert.AreEqual(true, the_set.contains(new DSInteger(30)));
            Assert.AreEqual(true, the_set.contains(new DSInteger(130)));

            //make sure non-existent items are contained within
            Assert.AreEqual(false, the_set.contains(new DSInteger(55))); 
        }

        private void testIsEmpty(Set<DSInteger> the_set)
        {
            //basic test after additions
            Assert.AreEqual(false, the_set.isEmpty());
            //clear the added entries and see if isEmpty() works
            the_set.clear();
            Assert.AreEqual(true, the_set.isEmpty());
        }

        private void testSize(Set<DSInteger> the_set)
        {
            //test the initial additions
            Assert.AreEqual(13, the_set.size());

            //test the size after removing items
            the_set.remove(new DSInteger(10));
            Assert.AreEqual(12, the_set.size());
            the_set.clear();
            Assert.AreEqual(0, the_set.size());
        }

        private void testContains(Set<DSInteger> the_set)
        {
            //test whether contains recognizes what is inside the collection
            Assert.AreEqual(true, the_set.contains(new DSInteger(30)));
            Assert.AreEqual(true, the_set.contains(new DSInteger(40)));

            //test whether contains recognizes what is not inside the collection
            Assert.AreEqual(false, the_set.contains(new DSInteger(55)));
        }

        private void testRemove(Set<DSInteger> the_set)
        {
            //test the initial additions
            Assert.AreEqual(13, the_set.size());

            //test the size after removing
            checkRemoval(the_set, 10, 12);
            checkRemoval(the_set, 50, 11);
            checkRemoval(the_set, 130, 10);
        }

        private void testClear(Set<DSInteger> the_set)
        {
            //check whether clearing works after additions
            the_set.clear();
            Assert.AreEqual(true, the_set.isEmpty());

            //check whether clearing from an empty set stays consistent
            the_set.clear();
            Assert.AreEqual(true, the_set.isEmpty());
        }

        private void testToArray(Set<DSInteger> the_set)
        {
            DSInteger[] array = the_set.toArray();
            Sorting<DSInteger>.Sort(Sorts.QuickSort, ref array);

            for (int i = 10; i < 140; i += 10)
            {
                Assert.AreNotEqual(-1, Searching.binarySearch<DSInteger>(array, new DSInteger(i)));
            }
            Assert.AreEqual(13, the_set.size());
        }

        private void testIterator(Set<DSInteger> the_set)
        {
            List<DSInteger> list = new ArrayList<DSInteger>(the_set.toArray());

            //check that the iteration goes over all elements
            Iterator<DSInteger> it = the_set.iterator();
            while (it.hasNext())
            {
                Assert.AreEqual(true, list.remove(it.next()));
            }
            Assert.AreEqual(true, list.isEmpty());

            //check removal
            it = the_set.iterator();
            Assert.AreEqual(13, the_set.size());

            //removal before calling next()
            try
            {
                it.remove();
                Assert.Fail();
            }
            catch (Exception the_ex)
            {
                //it should throw an exception here
            }

            //removal of the first item
            it.next();
            it.remove();
            Assert.AreEqual(12, the_set.size());

            //make sure you cannot remove twice
            it.next();
            it.remove();

            try
            {
                it.remove();
                Assert.Fail();
            }
            catch (Exception the_ex)
            {
                //it should throw an exception here
            }
        }

        //---------------- HELPER METHODS -----------------
        private void addInitialItems(Set<DSInteger> the_set)
        {
            the_set.add(new DSInteger(10));
            the_set.add(new DSInteger(20));
            the_set.add(new DSInteger(30));
            the_set.add(new DSInteger(40));
            the_set.add(new DSInteger(50));
            the_set.add(new DSInteger(60));
            the_set.add(new DSInteger(70));
            the_set.add(new DSInteger(80));
            the_set.add(new DSInteger(90));
            the_set.add(new DSInteger(100));
            the_set.add(new DSInteger(110));
            the_set.add(new DSInteger(120));
            the_set.add(new DSInteger(130));
        }

        private void checkRemoval(Set<DSInteger> the_set, int the_element_value, int the_new_size)
        {
            //test the size after removing from the middle
            the_set.remove(new DSInteger(the_element_value));
            Assert.AreEqual(the_new_size, the_set.size());
            Assert.AreEqual(false, the_set.contains(new DSInteger(the_element_value)));
        }
    }
}
