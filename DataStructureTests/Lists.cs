using System;
using System.Text;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures.Basic;
using DataStructures.PrimitiveWrappers;
using DataStructures;
using DataStructures.Interfaces;
using DataStructures.Exceptions;

namespace DataStructureTests
{
    /// <summary>
    /// Tests all list classes.
    /// </summary>
    [TestClass]
    public class Lists
    {
        private TestContext testContextInstance;

        private static ArrayList<DSInteger> my_a_list;
        private static LinkedList<DSInteger> my_ll_list;

        public Lists()
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
        //[ClassCleanup()]
        //public static void MyClassCleanup() 
        //{
        //}

        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            my_a_list = new ArrayList<DSInteger>();
            my_ll_list = new LinkedList<DSInteger>();

            //add some items
            addInitialItems(my_a_list);
            addInitialItems(my_ll_list);
        }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void testAdd()
        {
            testAdd(my_a_list);
            testAdd(my_ll_list);
        }

        [TestMethod]
        public void testRemove()
        {
            testRemove(my_a_list);
            testRemove(my_ll_list);
        }

        [TestMethod]
        public void testClear()
        {
            testClear(my_a_list);
            testClear(my_ll_list);
        }

        [TestMethod]
        public void testIsEmpty()
        {
            testIsEmpty(my_a_list);
            testIsEmpty(my_ll_list);
        }

        [TestMethod]
        public void testContains()
        {
            testContains(my_a_list);
            testContains(my_ll_list);
        }

        [TestMethod]
        public void testSet()
        {
            testSet(my_a_list);
            testSet(my_ll_list);
        }

        [TestMethod]
        public void testListIterator()
        {
            testListIterator(my_a_list);
            testListIterator(my_ll_list);
        }

        [TestMethod]
        public void testIterator()
        {
            testIterator(my_a_list);
            testIterator(my_ll_list);
        }

        [TestMethod]
        public void testGet()
        {
            testGet(my_a_list);
            testGet(my_ll_list);
        }

        [TestMethod]
        public void testSize()
        {
            testSize(my_a_list);
            testSize(my_ll_list);
        }

        [TestMethod]
        public void testToArray()
        {
            testToArray(my_a_list);
            testToArray(my_ll_list);
        }

        [TestMethod]
        public void testInsertAt()
        {
            testInsertAt(my_a_list);
            testInsertAt(my_ll_list);
        }

        [TestMethod]
        public void testFirst()
        {
            testFirst(my_a_list);
            testFirst(my_ll_list);
        }

        [TestMethod]
        public void testLast()
        {
            testLast(my_a_list);
            testLast(my_ll_list);
        }

        [TestMethod]
        public void testRemoveFirst()
        {
            testRemoveFirst(my_a_list);
            testRemoveFirst(my_ll_list);
        }

        [TestMethod]
        public void testRemoveLast()
        {
            testRemoveLast(my_a_list);
            testRemoveLast(my_ll_list);
        }

        [TestMethod]
        public void testToString()
        {
            testToString(my_a_list);
            testToString(my_ll_list);
        }

        private void testToString(List<DSInteger> the_list)
        {
            //just test for no exceptions, leave the output to the programmer, user
            try
            {
                the_list.ToString();
            }
            catch (Exception the_ex)
            {
                Assert.Fail();
            }
        }

        private void testRemoveFirst(List<DSInteger> the_list)
        {
            Assert.AreEqual(30, the_list.removeFirst().value);
            Assert.AreEqual(60, the_list.first().value);
            Assert.AreEqual(4, the_list.size());
        }

        private void testRemoveLast(List<DSInteger> the_list)
        {
            Assert.AreEqual(150, the_list.removeLast().value);
            Assert.AreEqual(120, the_list.last().value);
            Assert.AreEqual(4, the_list.size());
        }

        private void testInsertAt(List<DSInteger> the_list)
        {
            //add an item in the middle
            the_list.insertAt(1, new DSInteger(50));
            Assert.AreEqual(50, the_list.get(1).value);
            Assert.AreEqual(30, the_list.get(0).value);
            Assert.AreEqual(60, the_list.get(2).value);
            
            //add an item at the beginning
            the_list.insertAt(0, new DSInteger(20));
            Assert.AreEqual(20, the_list.get(0).value);
            Assert.AreEqual(30, the_list.get(1).value);

            //add an item at the end index
            the_list.insertAt(4, new DSInteger(160));
            Assert.AreEqual(160, the_list.get(4).value);
            Assert.AreEqual(150, the_list.last().value);
        }

        private void testFirst(List<DSInteger> the_list)
        {
            Assert.AreEqual(30, the_list.first().value);
            the_list.removeAt(0);
            Assert.AreEqual(60, the_list.first().value);
        }

        private void testLast(List<DSInteger> the_list)
        {
            Assert.AreEqual(150, the_list.last().value);
            the_list.removeAt(the_list.size() - 1);
            Assert.AreEqual(120, the_list.last().value);
        }

        private void testToArray(List<DSInteger> the_list)
        {
            DSInteger[] array = the_list.toArray();

            //check whether the array was passed across correctly
            Assert.AreEqual(30, array[0].value);
            Assert.AreEqual(150, array[4].value); ;
            Assert.AreEqual(5, array.Length);
        }

        private void testSize(List<DSInteger> the_list)
        {
            //simple check to make sure the size() functionality is working
            Assert.AreEqual(5, the_list.size());
            the_list.clear();
            Assert.AreEqual(0, the_list.size());
        }

        private void testGet(List<DSInteger> the_list)
        {
            //test simple retrieval
            Assert.AreEqual(30, the_list.get(0).value);
            Assert.AreEqual(60, the_list.get(1).value);
            Assert.AreEqual(150, the_list.get(4).value);

            try
            {
                the_list.get(5);
                Assert.Fail();
            }
            catch (Exception the_ex)
            {
                //the test will pass if the exception is thrown
            }
        }

        private void testIterator(List<DSInteger> the_list)
        {
            Iterator<DSInteger> it = the_list.iterator();

            int count = 0;
            while (it.hasNext())
            {
                count++;
                it.next();
            }
            Assert.AreEqual(5, count);

            //test removal at the end of the list
            DSInteger removed = it.remove();
            Assert.AreEqual(150, removed.value);
            Assert.AreEqual(false, it.hasNext());

            //test removal of two items at once
            try
            {
                it.remove();
                Assert.Fail(); //should throw an error before here
            }
            catch (IllegalStateException the_ex)
            {
                //good
            }

            //test values returned
            it = the_list.iterator();
            Assert.AreEqual(30, it.next().value);
            Assert.AreEqual(60, it.next().value);

            //test removal at a middle index
            removed = it.remove();
            Assert.AreEqual(60, removed.value);
            Assert.AreEqual(90, it.next().value);

            it = the_list.iterator();
            it.next();
            Assert.AreEqual(30, it.remove().value);
            Assert.AreEqual(true, it.hasNext());
            Assert.AreEqual(90, it.next().value);
        }

        private void testListIterator(List<DSInteger> the_list)
        {
            ListIterator<DSInteger> it = the_list.listIterator();

            int count = 0;
            while (it.hasNext())
            {
                count++;
                it.next();
            }

            //you are at the last item, not one before the first item when the
            //initial loop begins
            count--;

            while (it.hasPrevious())
            {
                count--;
                it.previous();
            }
            Assert.AreEqual(0, count);

            //test values returned
            it = the_list.listIterator();
            Assert.AreEqual(30, it.next().value);
            Assert.AreEqual(60, it.next().value);

            //test removal
            DSInteger removed = it.remove();
            Assert.AreEqual(60, removed.value);
            Assert.AreEqual(90, it.next().value);

            it.next(); //120
            it.next(); //150

            //test removing the last item
            Assert.AreEqual(false, it.hasNext());
            Assert.AreEqual(150, it.remove().value);
            Assert.AreEqual(false, it.hasNext());
            Assert.AreEqual(90, it.previous().value);
            Assert.AreEqual(true, it.hasNext());
            Assert.AreEqual(120, it.next().value);

            //test removing the first item
            the_list.clear();
            addInitialItems(the_list);
            it = the_list.listIterator();
            Assert.AreEqual(false, it.hasPrevious());
            Assert.AreEqual(30, it.next().value);
            it.remove();
            Assert.AreEqual(false, it.hasPrevious());
            Assert.AreEqual(60, it.next().value);
            Assert.AreEqual(90, it.next().value);
            Assert.AreEqual(60, it.previous().value);
            Assert.AreEqual(false, it.hasPrevious());
        }

        private void testSet(List<DSInteger> the_list)
        {
            //check an initial item
            Assert.AreEqual(60, the_list.get(1).value);

            //overwrite the item with set and check for change
            the_list.set(1, new DSInteger(50));
            Assert.AreEqual(50, the_list.get(1).value);

            //make sure the index check is working
            try
            {
                the_list.set(10, new DSInteger(50));
                Assert.Fail();
            }
            catch (Exception the_ex)
            {
                //the test passes if the exception was thrown
            }
        }

        private void testContains(List<DSInteger> the_list)
        {
            //check for an item in the list
            Assert.AreEqual(true, the_list.contains(new DSInteger(60)));

            //check for an item not in the list
            Assert.AreEqual(false, the_list.contains(new DSInteger(50)));
        }

        private void testIsEmpty(List<DSInteger> the_list)
        {
            //assert that all items are in the list
            Assert.AreEqual(5, the_list.size());
            Assert.AreEqual(false, the_list.isEmpty());

            //remove items and check for isEmpty()
            the_list.clear();
            Assert.AreEqual(true, the_list.isEmpty());
        }

        private void testClear(List<DSInteger> the_list)
        {
            //assert that all items are in the list
            Assert.AreEqual(5, the_list.size());

            //clear the items
            the_list.clear();
            Assert.AreEqual(0, the_list.size());
        }

        private void testRemove(List<DSInteger> the_list)
        {
            //---------------- TEST remove(T the_removal) -------------------

            //assert that all items are in the list
            Assert.AreEqual(5, the_list.size());

            //remove an index in the middle
            bool found = the_list.remove(new DSInteger(60));
            Assert.AreEqual(4, the_list.size());
            Assert.AreEqual(true, found);
            Assert.AreEqual(30, the_list.get(0).value);
            Assert.AreEqual(90, the_list.get(1).value);

            //remove the first element
            the_list.remove(new DSInteger(30));
            Assert.AreEqual(3, the_list.size());
            Assert.AreEqual(90, the_list.get(0).value);

            //remove the last element
            the_list.remove(new DSInteger(150));
            Assert.AreEqual(2, the_list.size());
            Assert.AreEqual(120, the_list.get(1).value);

            //remove an element that is not in the list
            found = the_list.remove(new DSInteger(50));
            Assert.AreEqual(2, the_list.size());
            Assert.AreEqual(false, found);

            //---------------- TEST removeAt(int the_index) -------------------
            the_list.clear();
            addInitialItems(the_list);
            Assert.AreEqual(5, the_list.size());

            //remove an index in the middle
            the_list.removeAt(1);
            Assert.AreEqual(4, the_list.size());
            Assert.AreEqual(30, the_list.get(0).value);
            Assert.AreEqual(90, the_list.get(1).value);

            //remove the first element
            the_list.removeAt(0);
            Assert.AreEqual(3, the_list.size());
            Assert.AreEqual(90, the_list.get(0).value);

            //remove the last element
            the_list.removeAt(2);
            Assert.AreEqual(2, the_list.size());
            Assert.AreEqual(120, the_list.get(1).value);

            //remove an element that is not in the list
            try
            {
                the_list.removeAt(10);
                Assert.Fail();
            }
            catch (Exception the_ex)
            {
                //we're good if we get here
            }

            //remove a negative index
            try
            {
                the_list.removeAt(-1);
                Assert.Fail();
            }
            catch (Exception the_ex)
            {
                //we're good if we get here
            }
        }

        private void testAdd(List<DSInteger> the_list)
        {
            //assert they are in the correct order
            DSInteger added = the_list.get(0);
            Assert.AreEqual(30, added.value);
            added = the_list.get(1);
            Assert.AreEqual(60, added.value);
            added = the_list.get(2);
            Assert.AreEqual(90, added.value);

            //assert they are all in the list
            Assert.AreEqual(5, the_list.size());
        }

        private void addInitialItems(List<DSInteger> the_list)
        {
            the_list.add(new DSInteger(30));
            the_list.add(new DSInteger(60));
            the_list.add(new DSInteger(90));
            the_list.add(new DSInteger(120));
            the_list.add(new DSInteger(150));
        }
    }
}
