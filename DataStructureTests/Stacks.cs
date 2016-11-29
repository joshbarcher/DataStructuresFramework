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
    /// Summary description for Stacks
    /// </summary>
    [TestClass]
    public class Stacks
    {
        private const int MAX_STACK_ELEMENTS = 100;
        
        private TestContext testContextInstance;

        private BasicStack<DSString> my_stack;
        private BoundedStack<DSString> my_b_stack;

        public Stacks()
        {
            //
            // TODO: Add constructor logic here
            //
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
            my_stack = new Stack<DSString>();
            my_b_stack = new BoundedStack<DSString>(MAX_STACK_ELEMENTS);
            addStackItems(my_stack);
            addStackItems(my_b_stack);
        }

        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void testPush()
        {
            testPush(my_stack);
            testPush(my_b_stack);
        }

        [TestMethod]
        public void testPop()
        {
            testPop(my_stack);
            testPop(my_b_stack);
        }

        [TestMethod]
        public void testPeek()
        {
            testPeek(my_stack);
            testPeek(my_b_stack);
        }

        [TestMethod]
        public void testIsEmpty()
        {
            testIsEmpty(my_stack);
            testIsEmpty(my_b_stack);
        }

        [TestMethod]
        public void testSize()
        {
            testSize(my_stack);
            testSize(my_b_stack);
        }

        [TestMethod]
        public void testAdd()
        {
            testAdd(my_stack);
            testAdd(my_b_stack);
        }

        [TestMethod]
        public void testContains()
        {
            testContains(my_stack);
            testContains(my_b_stack);
        }

        [TestMethod]
        public void testClear()
        {
            testClear(my_stack);
            testClear(my_b_stack);
        }

        [TestMethod]
        public void testBoundedStack()
        {
            testBoundedStack(my_b_stack);
        }

        [TestMethod]
        public void testToString()
        {
            testToString(my_b_stack);
        }

        private void testToString(BoundedStack<DSString> the_stack)
        {
            //just test for no exceptions, leave the output to the programmer, user
            try
            {
                the_stack.ToString();
            }
            catch (Exception the_ex)
            {
                Assert.Fail();
            }
        }

        private void testBoundedStack(BoundedStack<DSString> the_b_stack)
        {
            //add the rest of 100 elements
            for (int i = 0; i < 90; i++)
            {
                the_b_stack.push(new DSString((i + 10).ToString()));
            }

            try
            {
                the_b_stack.push(new DSString((101).ToString()));
                Assert.Fail(); //fail if no exception is thrown
            }
            catch (StackOverflowException the_exception)
            {
                //good
            }
        }

        private void testPush(BasicStack<DSString> the_stack)
        {
            //items already added in initialization

            //make sure first size is right
            Assert.AreEqual(10, the_stack.size());

            //make sure first removal matches FIFO ordering
            Assert.AreEqual("9", the_stack.pop().value);

            //remove all elements and check last item to make sure removals match FIFO ordering
            string element  = "";
            while (!the_stack.isEmpty())
            {
                element = the_stack.pop().value;
            }
            Assert.AreEqual("0", element);
        }

        private void testPop(BasicStack<DSString> the_stack)
        {
            //make sure the ordering is secure
            Assert.AreEqual("9", the_stack.pop().value);
            Assert.AreEqual("8", the_stack.pop().value);
            Assert.AreEqual("7", the_stack.pop().value);

            //add an item after removing
            the_stack.push(new DSString("13"));

            //check ordering
            Assert.AreEqual("13", the_stack.pop().value);
            Assert.AreEqual("6", the_stack.pop().value);
            Assert.AreEqual("5", the_stack.pop().value);
            Assert.AreEqual("4", the_stack.pop().value);
            Assert.AreEqual("3", the_stack.pop().value);
            Assert.AreEqual("2", the_stack.pop().value);
            Assert.AreEqual("1", the_stack.pop().value);
            Assert.AreEqual("0", the_stack.pop().value);
        }

        private void testPeek(BasicStack<DSString> the_stack)
        {
            //check multiple peeks
            Assert.AreEqual("9", the_stack.peek().value);
            Assert.AreEqual("9", the_stack.peek().value);

            //peek after removal
            the_stack.pop();
            Assert.AreEqual("8", the_stack.peek().value);

            //peek with nothing on the stack
            while (!the_stack.isEmpty())
            {
                the_stack.pop();
            }
            Assert.AreEqual(null, the_stack.peek());
        }

        private void testIsEmpty(BasicStack<DSString> the_stack)
        {
            //check while not empty
            Assert.IsFalse(the_stack.isEmpty());

            //after empty
            the_stack.clear();
            Assert.IsTrue(the_stack.isEmpty());

            //after re-addition
            the_stack.push(new DSString("1"));
            Assert.IsFalse(the_stack.isEmpty());

            //after empty again
            the_stack.clear();
            Assert.IsTrue(the_stack.isEmpty());
        }

        private void testSize(BasicStack<DSString> the_stack)
        {
            //check after initial insertion
            Assert.AreEqual(10, the_stack.size());

            //check after removal
            the_stack.pop();
            Assert.AreEqual(9, the_stack.size());

            //check after addition
            the_stack.push(new DSString("13"));
            Assert.AreEqual(10, the_stack.size());

            //check after removing all
            the_stack.clear();
            Assert.AreEqual(0, the_stack.size());
        }

        private void testAdd(BasicStack<DSString> the_stack)
        {
            //tested in testPush()
        }

        private void testContains(BasicStack<DSString> the_stack)
        {
            //make sure all items are matched inside
            Assert.AreEqual(true, the_stack.contains(new DSString("0")));
            Assert.AreEqual(true, the_stack.contains(new DSString("1")));
            Assert.AreEqual(true, the_stack.contains(new DSString("2")));
            Assert.AreEqual(true, the_stack.contains(new DSString("3")));
            Assert.AreEqual(true, the_stack.contains(new DSString("4")));
            Assert.AreEqual(true, the_stack.contains(new DSString("5")));
            Assert.AreEqual(true, the_stack.contains(new DSString("6")));
            Assert.AreEqual(true, the_stack.contains(new DSString("7")));
            Assert.AreEqual(true, the_stack.contains(new DSString("8")));
            Assert.AreEqual(true, the_stack.contains(new DSString("9")));

            //check after removal
            the_stack.pop();
            Assert.AreEqual(false, the_stack.contains(new DSString("9")));

            //check after adding
            the_stack.push(new DSString("13"));
            Assert.AreEqual(true, the_stack.contains(new DSString("13")));

            //check after removing all
            the_stack.clear();
            Assert.AreEqual(false, the_stack.contains(new DSString("13")));
            Assert.AreEqual(false, the_stack.contains(new DSString("0")));
            Assert.AreEqual(false, the_stack.contains(new DSString("1")));
            Assert.AreEqual(false, the_stack.contains(new DSString("2")));
            Assert.AreEqual(false, the_stack.contains(new DSString("3")));
            Assert.AreEqual(false, the_stack.contains(new DSString("4")));
            Assert.AreEqual(false, the_stack.contains(new DSString("5")));
            Assert.AreEqual(false, the_stack.contains(new DSString("6")));
            Assert.AreEqual(false, the_stack.contains(new DSString("7")));
            Assert.AreEqual(false, the_stack.contains(new DSString("8")));
            Assert.AreEqual(false, the_stack.contains(new DSString("9")));
        }

        private void testClear(BasicStack<DSString> the_stack)
        {
            //make sure size() and isEmpty() are correct before clear
            Assert.AreEqual(false, the_stack.isEmpty());
            Assert.AreEqual(10, the_stack.size());

            //after clearing
            the_stack.clear();
            Assert.AreEqual(true, the_stack.isEmpty());
            Assert.AreEqual(0, the_stack.size());

            //after readding and clearing
            the_stack.push(new DSString("13"));
            Assert.AreEqual(false, the_stack.isEmpty());
            Assert.AreEqual(1, the_stack.size());
        }

        //------------------- HELPER METHODS ----------------------

        private void addStackItems(BasicStack<DSString> the_stack)
        {
            for (int i = 0; i < 10; i++)
            {
                the_stack.push(new DSString(i.ToString()));
            }
        }
    }
}
