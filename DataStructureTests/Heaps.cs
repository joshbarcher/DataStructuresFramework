using System;
using System.Text;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures.Interfaces;
using DataStructures.PrimitiveWrappers;
using DataStructures.Basic;

namespace DataStructureTests
{
    /// <summary>
    /// Tests the heap class.
    /// </summary>
    [TestClass]
    public class Heaps
    {
        private BasicHeap<DSInteger> my_b_minheap;
        private BasicHeap<DSInteger> my_b_maxheap;

        private TestContext testContextInstance;

        public Heaps()
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
            my_b_minheap = new BinaryHeap<DSInteger>(true);
            my_b_maxheap = new BinaryHeap<DSInteger>(false);
            addHeapItems(my_b_minheap);
            addHeapItems(my_b_maxheap);
        }
        
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void testConstructors()
        {
            testConstructors(my_b_minheap);
            testConstructors(my_b_maxheap);
        }

        [TestMethod]
        public void testAdd()
        {
            testAdd(my_b_minheap);
            testAdd(my_b_maxheap);
        }

        [TestMethod]
        public void testDeleteMin()
        {
            testDeleteMin(my_b_minheap);
            testDeleteMin(my_b_maxheap);
        }

        [TestMethod]
        public void testPeek()
        {
            testPeek(my_b_minheap);
            testPeek(my_b_maxheap);
        }

        [TestMethod]
        public void testSize()
        {
            testSize(my_b_minheap);
            testSize(my_b_maxheap);
        }

        [TestMethod]
        public void testIsEmpty()
        {
            testIsEmpty(my_b_minheap);
            testIsEmpty(my_b_maxheap);
        }

        [TestMethod]
        public void testContains()
        {
            testContains(my_b_minheap);
            testContains(my_b_maxheap);
        }

        [TestMethod]
        public void testClear()
        {
            testClear(my_b_minheap);
            testClear(my_b_maxheap);
        }

        [TestMethod]
        public void testToString()
        {
            testToString(my_b_minheap);
            testToString(my_b_maxheap);
        }

        private void testToString(BasicHeap<DSInteger> the_heap)
        {
            //just test for no exceptions, leave the output to the programmer, user
            try
            {
                the_heap.ToString();
            }
            catch (Exception the_ex)
            {
                Assert.Fail();
            }
        }

        private void testClear(BasicHeap<DSInteger> the_heap)
        {
            Assert.AreEqual(false, the_heap.isEmpty());
            Assert.AreEqual(true, the_heap.size() > 0);
            the_heap.clear();
            Assert.AreEqual(true, the_heap.isEmpty());
            Assert.AreEqual(0, the_heap.size());
        }

        private void testPeek(BasicHeap<DSInteger> the_heap)
        {
            if (the_heap.min_heap) //min heap
            {
                Assert.AreEqual(5, the_heap.peek().value);
                Assert.AreEqual(5, the_heap.peek().value);
                the_heap.deleteMin();
                Assert.AreEqual(10, the_heap.peek().value);
                Assert.AreEqual(10, the_heap.peek().value);
            }
            else //max heap
            {
                Assert.AreEqual(110, the_heap.peek().value);
                Assert.AreEqual(110, the_heap.peek().value);
                the_heap.deleteMin();
                Assert.AreEqual(100, the_heap.peek().value);
                Assert.AreEqual(100, the_heap.peek().value);
            }
        }

        private void testSize(BasicHeap<DSInteger> the_heap)
        {
            //check initial size
            Assert.AreEqual(12, the_heap.size());

            //make sure the size alters when removing
            the_heap.deleteMin();
            Assert.AreEqual(11, the_heap.size());

            //make sure the size reduces itself to zero
            while (!the_heap.isEmpty())
            {
                the_heap.deleteMin();
            }
            Assert.AreEqual(0, the_heap.size());

            //make sure the size does not go below 0
            the_heap.deleteMin();
            Assert.AreEqual(0, the_heap.size());
        }

        private void testIsEmpty(BasicHeap<DSInteger> the_heap)
        {
            Assert.AreEqual(false, the_heap.isEmpty());
            the_heap.clear();
            Assert.AreEqual(true, the_heap.isEmpty());
        }

        private void testContains(BasicHeap<DSInteger> the_heap)
        {
            //make sure the correct items are in the queue
            Assert.AreEqual(true, the_heap.contains(new DSInteger(5)));
            Assert.AreEqual(true, the_heap.contains(new DSInteger(10)));
            Assert.AreEqual(true, the_heap.contains(new DSInteger(20)));
            Assert.AreEqual(true, the_heap.contains(new DSInteger(30)));
            Assert.AreEqual(true, the_heap.contains(new DSInteger(40)));
            Assert.AreEqual(true, the_heap.contains(new DSInteger(50)));
            Assert.AreEqual(true, the_heap.contains(new DSInteger(60)));
            Assert.AreEqual(true, the_heap.contains(new DSInteger(70)));
            Assert.AreEqual(true, the_heap.contains(new DSInteger(80)));
            Assert.AreEqual(true, the_heap.contains(new DSInteger(90)));
            Assert.AreEqual(true, the_heap.contains(new DSInteger(100)));
            Assert.AreEqual(true, the_heap.contains(new DSInteger(110)));

            //make sure no false positives are given
            Assert.AreEqual(false, the_heap.contains(new DSInteger(120)));
        }

        private void testDeleteMin(BasicHeap<DSInteger> the_heap)
        {
            //removing of the default items handled in testAdd()
            while (!the_heap.isEmpty())
            {
                the_heap.deleteMin();
            }
            Assert.AreEqual(null, the_heap.deleteMin());
            Assert.AreEqual(true, the_heap.isEmpty());

            //adding items after all are removed, then check for correct state
            the_heap.add(new DSInteger(5));
            Assert.AreEqual(5, the_heap.deleteMin().value);
            Assert.AreEqual(null, the_heap.deleteMin());
            Assert.AreEqual(true, the_heap.isEmpty());Assert.AreEqual(true, the_heap.isEmpty());
        }

        private void testAdd(BasicHeap<DSInteger> the_heap)
        {
            //min heap
            if (the_heap.min_heap)
            {
                Assert.AreEqual(5, the_heap.deleteMin().value);
                Assert.AreEqual(10, the_heap.deleteMin().value);
                Assert.AreEqual(20, the_heap.deleteMin().value);
                Assert.AreEqual(30, the_heap.deleteMin().value);
                Assert.AreEqual(40, the_heap.deleteMin().value);
                Assert.AreEqual(50, the_heap.deleteMin().value);
                Assert.AreEqual(60, the_heap.deleteMin().value);
                Assert.AreEqual(70, the_heap.deleteMin().value);
                Assert.AreEqual(80, the_heap.deleteMin().value);
                Assert.AreEqual(90, the_heap.deleteMin().value);
                Assert.AreEqual(100, the_heap.deleteMin().value);
                Assert.AreEqual(110, the_heap.deleteMin().value);
            }
            else //max heap
            {
                Assert.AreEqual(110, the_heap.deleteMin().value);
                Assert.AreEqual(100, the_heap.deleteMin().value);
                Assert.AreEqual(90, the_heap.deleteMin().value);
                Assert.AreEqual(80, the_heap.deleteMin().value);
                Assert.AreEqual(70, the_heap.deleteMin().value);
                Assert.AreEqual(60, the_heap.deleteMin().value);
                Assert.AreEqual(50, the_heap.deleteMin().value);
                Assert.AreEqual(40, the_heap.deleteMin().value);
                Assert.AreEqual(30, the_heap.deleteMin().value);
                Assert.AreEqual(20, the_heap.deleteMin().value);
                Assert.AreEqual(10, the_heap.deleteMin().value);
                Assert.AreEqual(5, the_heap.deleteMin().value);
            }
        }

        private void testConstructors(BasicHeap<DSInteger> the_heap)
        {
            the_heap = new BinaryHeap<DSInteger>(true, new DSInteger[] {new DSInteger(30), new DSInteger(40), new DSInteger(60),
                                                                    new DSInteger(20), new DSInteger(10), new DSInteger(50)});
            //make sure the count is correct
            Assert.AreEqual(6, the_heap.size());

            //min heap
            if (the_heap.min_heap)
            {
                //make sure the items can be removed correctly after adding
                Assert.AreEqual(10, the_heap.deleteMin().value);
                Assert.AreEqual(20, the_heap.deleteMin().value);
                Assert.AreEqual(30, the_heap.deleteMin().value);
                Assert.AreEqual(40, the_heap.deleteMin().value);
                Assert.AreEqual(50, the_heap.deleteMin().value);
                Assert.AreEqual(60, the_heap.deleteMin().value);
            }
            else //max heap
            {
                //make sure the items can be removed correctly after adding
                Assert.AreEqual(60, the_heap.deleteMin().value);
                Assert.AreEqual(50, the_heap.deleteMin().value);
                Assert.AreEqual(40, the_heap.deleteMin().value);
                Assert.AreEqual(30, the_heap.deleteMin().value);
                Assert.AreEqual(20, the_heap.deleteMin().value);
                Assert.AreEqual(10, the_heap.deleteMin().value);
            }
        }

        //---------------- HELPER METHODS -----------------

        private void addHeapItems(BasicHeap<DSInteger> the_heap)
        {
            the_heap.add(new DSInteger(30));
            the_heap.add(new DSInteger(100));
            the_heap.add(new DSInteger(40));
            the_heap.add(new DSInteger(10));
            the_heap.add(new DSInteger(60));
            the_heap.add(new DSInteger(70));
            the_heap.add(new DSInteger(20));
            the_heap.add(new DSInteger(110));
            the_heap.add(new DSInteger(50));
            the_heap.add(new DSInteger(5));
            the_heap.add(new DSInteger(90));
            the_heap.add(new DSInteger(80));
        }
    }
}
