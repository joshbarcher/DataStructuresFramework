using System;
using System.Text;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;
using DataStructures.Basic;
using DataStructures.PrimitiveWrappers;
using DataStructures.Interfaces;

namespace DataStructureTests
{
    /// <summary>
    /// Tests all queues in this assembly.
    /// </summary>
    [TestClass]
    public class Queues
    {
        private BasicQueue<DSInteger> my_queue;
        private PriorityQueue<DSInteger> my_p_queue;

        private TestContext testContextInstance;

        public Queues()
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
            my_queue = new Queue<DSInteger>();
            my_p_queue = new PriorityQueue<DSInteger>(true);
            addInitialQueueItems(my_queue);
            addInitialQueueItems(my_p_queue);
        }
        
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void testEnqueue()
        {
            testEnqueue(my_queue);
            testEnqueue(my_p_queue);
        }

        [TestMethod]
        public void testDequeue()
        {
            testDequeue(my_queue);
            testPriorityQueueOrdering(my_p_queue);
        }

        [TestMethod]
        public void testPoll()
        {
            testPoll(my_queue);
            testPriorityQueuePoll(my_p_queue);
        }

        [TestMethod]
        public void testIsEmpty()
        {
            testIsEmpty(my_queue);
            testIsEmpty(my_p_queue);
        }

        [TestMethod]
        public void testSize()
        {
            testSize(my_queue);
            testSize(my_p_queue);
        }

        [TestMethod]
        public void testAdd()
        {
            testAdd(my_queue);
            testAdd(my_p_queue);
        }

        [TestMethod]
        public void testContains()
        {
            testContains(my_queue);
            testContains(my_p_queue);
        }

        [TestMethod]
        public void testClear()
        {
            testClear(my_queue);
            testClear(my_p_queue);
        }

        [TestMethod]
        public void testToString()
        {
            testToString(my_queue);
            testToString(my_p_queue);
        }

        private void testToString(BasicQueue<DSInteger> the_queue)
        {
            //just test for no exceptions, leave the output to the programmer, user
            try
            {
                the_queue.ToString();
            }
            catch (Exception the_ex)
            {
                Assert.Fail();
            }
        }

        private void testPriorityQueuePoll(PriorityQueue<DSInteger> the_p_queue)
        {
            //assert that calling poll does not remove the first item
            Assert.AreEqual(25, the_p_queue.poll().value);
            Assert.AreEqual(25, the_p_queue.poll().value);

            //make sure that poll works even after a dequeue() operation
            the_p_queue.dequeue();
            Assert.AreEqual(50, the_p_queue.poll().value);
        }

        private void testPriorityQueueOrdering(PriorityQueue<DSInteger> the_p_queue)
        {
            //check for correct removal order
            Assert.AreEqual(25, the_p_queue.dequeue().value);
            Assert.AreEqual(50, the_p_queue.dequeue().value);
            Assert.AreEqual(100, the_p_queue.dequeue().value);
            Assert.AreEqual(200, the_p_queue.dequeue().value);
            Assert.AreEqual(400, the_p_queue.dequeue().value);

            //make sure no false positives
            Assert.IsTrue(the_p_queue.isEmpty());
        }

        private void testEnqueue(BasicQueue<DSInteger> the_queue)
        {
            //make sure the last element removed is the last one added
            DSInteger next = null, last = null;
            while ((next = the_queue.dequeue()) != null)
            {
                last = next;
            }
            Assert.AreEqual(400, last.value);
        }

        private void testDequeue(BasicQueue<DSInteger> the_queue)
        {
            //make sure the elements are removed with a LIFO methodology
            Assert.AreEqual(100, the_queue.dequeue().value);
            Assert.AreEqual(50, the_queue.dequeue().value);
            Assert.AreEqual(200, the_queue.dequeue().value);
            Assert.AreEqual(25, the_queue.dequeue().value);
            Assert.AreEqual(400, the_queue.dequeue().value);

            //make sure no remain after all dequeues
            Assert.AreEqual(true, the_queue.isEmpty());
        }

        private void testPoll(BasicQueue<DSInteger> the_queue)
        {
            //assert that calling poll does not remove the first item
            Assert.AreEqual(100, the_queue.poll().value);
            Assert.AreEqual(100, the_queue.poll().value);

            //make sure that poll works even after a dequeue() operation
            the_queue.dequeue();
            Assert.AreEqual(50, the_queue.poll().value);
        }

        private void testIsEmpty(BasicQueue<DSInteger> the_queue)
        {
            //simple isEmpty() check with items and without
            Assert.AreEqual(false, the_queue.isEmpty());
            the_queue.clear();
            Assert.AreEqual(true, the_queue.isEmpty());
        }

        private void testSize(BasicQueue<DSInteger> the_queue)
        {
            Assert.AreEqual(5, the_queue.size());
            the_queue.dequeue();
            Assert.AreEqual(4, the_queue.size());
            the_queue.clear();
            Assert.AreEqual(0, the_queue.size());
        }

        private void testAdd(BasicQueue<DSInteger> the_queue)
        {
            //same as enqueue() test
        }

        private void testContains(BasicQueue<DSInteger> the_queue)
        {
            //make sure the items that should be there are there
            Assert.AreEqual(true, the_queue.contains(new DSInteger(100)));
            Assert.AreEqual(true, the_queue.contains(new DSInteger(50)));
            Assert.AreEqual(true, the_queue.contains(new DSInteger(200)));
            Assert.AreEqual(true, the_queue.contains(new DSInteger(25)));
            Assert.AreEqual(true, the_queue.contains(new DSInteger(400)));

            //make sure there are no false positives
            Assert.AreEqual(false, the_queue.contains(new DSInteger(90)));
        }

        private void testClear(BasicQueue<DSInteger> the_queue)
        {
            //make sure there are items
            Assert.AreEqual(false, the_queue.isEmpty());

            //make sure they are cleared
            the_queue.clear();
            Assert.AreEqual(true, the_queue.isEmpty());
            Assert.AreEqual(null, the_queue.dequeue());
        }

        private void addInitialQueueItems(BasicQueue<DSInteger> the_queue)
        {
            the_queue.enqueue(new DSInteger(100));
            the_queue.enqueue(new DSInteger(50));
            the_queue.enqueue(new DSInteger(200));
            the_queue.enqueue(new DSInteger(25));
            the_queue.enqueue(new DSInteger(400));
        }
    }
}
