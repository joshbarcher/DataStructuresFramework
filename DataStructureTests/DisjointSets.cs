using System;
using System.Text;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures.Basic;
using DataStructures.PrimitiveWrappers;
using DataStructures.Interfaces;

namespace DataStructureTests
{
    /// <summary>
    /// Tests the DisjointSets class.
    /// </summary>
    [TestClass]
    public class DisjointSets
    {
        private Random my_rand = new Random();
        private DisjointSets<DSString> my_d_sets;

        private TestContext testContextInstance;

        public DisjointSets()
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
            my_d_sets = new DisjointSets<DSString>(new DSString[] {new DSString("A"), new DSString("B"), 
                new DSString("C"), new DSString("D"), new DSString("E")});
        }
        
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void testFind()
        {
            testFind(my_d_sets);
        }

        [TestMethod]
        public void testUnion()
        {
            testUnion(my_d_sets);
        }

        [TestMethod]
        public void testAdd()
        {
            testAdd(my_d_sets);
        }

        [TestMethod]
        public void testGetSetElements()
        {
            testGetSetElements(my_d_sets);
        }

        [TestMethod]
        public void testToString()
        {
            testToString(my_d_sets);
        }

        private void testToString(DisjointSets<DSString> the_d_sets)
        {
            //just test for no exceptions, leave the output to the programmer, user
            try
            {
                the_d_sets.ToString();
            }
            catch (Exception the_ex)
            {
                Assert.Fail();
            }
        }

        private void testGetSetElements(DisjointSets<DSString> the_d_sets)
        {
            //union two sets
            the_d_sets.union(new DSString("A"), new DSString("B"));

            //get elements and make sure only the correct ones are in the set
            List<DSString> elements = the_d_sets.getSetElements(the_d_sets.find(new DSString("A")));
            Assert.AreEqual(2, elements.size());
            Assert.AreEqual(true, elements.contains(new DSString("A")));
            Assert.AreEqual(true, elements.contains(new DSString("B")));

            //union two sets
            the_d_sets.union(new DSString("C"), new DSString("D"));

            //get elements and make sure only the correct ones are in the set
            elements = the_d_sets.getSetElements(the_d_sets.find(new DSString("C")));
            Assert.AreEqual(2, elements.size());
            Assert.AreEqual(true, elements.contains(new DSString("C")));
            Assert.AreEqual(true, elements.contains(new DSString("D")));

            //union both pair sets
            the_d_sets.union(new DSString("B"), new DSString("D"));

            //get elements and make sure only the correct ones are in the set
            elements = the_d_sets.getSetElements(the_d_sets.find(new DSString("A")));
            Assert.AreEqual(4, elements.size());
            Assert.AreEqual(true, elements.contains(new DSString("A")));
            Assert.AreEqual(true, elements.contains(new DSString("B")));
            Assert.AreEqual(true, elements.contains(new DSString("C")));
            Assert.AreEqual(true, elements.contains(new DSString("D")));

            //union both pair sets
            the_d_sets.union(new DSString("A"), new DSString("E"));

            //get elements and make sure only the correct ones are in the set
            elements = the_d_sets.getSetElements(the_d_sets.find(new DSString("A")));
            Assert.AreEqual(5, elements.size());
            Assert.AreEqual(true, elements.contains(new DSString("A")));
            Assert.AreEqual(true, elements.contains(new DSString("B")));
            Assert.AreEqual(true, elements.contains(new DSString("C")));
            Assert.AreEqual(true, elements.contains(new DSString("D")));
            Assert.AreEqual(true, elements.contains(new DSString("E")));
        }

        private void testAdd(DisjointSets<DSString> the_d_sets)
        {
            my_d_sets = new DisjointSets<DSString>();
            
            //add 100 items
            for (int i = 0; i < 100; i++)
            {
                my_d_sets.addSet(new DSString(i.ToString()));
            }

            //union them all
            for (int i = 0; i < 99; i++)
            {
                my_d_sets.union(new DSString(i.ToString()), new DSString((i + 1).ToString()));
            }
            
            //ensure they are all in the same set
            for (int i = 0; i < 99; i++)
            {
                Assert.AreEqual(true, my_d_sets.find(new DSString(i.ToString())) == my_d_sets.find(new DSString((i + 1).ToString())));
            }
        }

        private void testUnion(DisjointSets<DSString> the_d_sets)
        {
            //union two sets
            the_d_sets.union(new DSString("A"), new DSString("B"));
            Assert.AreEqual(true, the_d_sets.find(new DSString("A"))  == the_d_sets.find(new DSString("B")));

            //union a different pair
            the_d_sets.union(new DSString("C"), new DSString("D"));
            Assert.AreEqual(true, the_d_sets.find(new DSString("C")) == the_d_sets.find(new DSString("D")));

            //join the two pairs
            the_d_sets.union(new DSString("A"), new DSString("C"));
            Assert.AreEqual(true, the_d_sets.find(new DSString("A")) == the_d_sets.find(new DSString("C")));
            Assert.AreEqual(true, the_d_sets.find(new DSString("A")) == the_d_sets.find(new DSString("D")));
            Assert.AreEqual(true, the_d_sets.find(new DSString("B")) == the_d_sets.find(new DSString("C")));
            Assert.AreEqual(true, the_d_sets.find(new DSString("B")) == the_d_sets.find(new DSString("D")));

            //join the last set
            the_d_sets.union(new DSString("D"), new DSString("E"));
            Assert.AreEqual(true, the_d_sets.find(new DSString("A")) == the_d_sets.find(new DSString("B")));
            Assert.AreEqual(true, the_d_sets.find(new DSString("A")) == the_d_sets.find(new DSString("C")));
            Assert.AreEqual(true, the_d_sets.find(new DSString("A")) == the_d_sets.find(new DSString("D")));
            Assert.AreEqual(true, the_d_sets.find(new DSString("A")) == the_d_sets.find(new DSString("E")));
            Assert.AreEqual(true, the_d_sets.find(new DSString("B")) == the_d_sets.find(new DSString("C")));
            Assert.AreEqual(true, the_d_sets.find(new DSString("B")) == the_d_sets.find(new DSString("D")));
            Assert.AreEqual(true, the_d_sets.find(new DSString("B")) == the_d_sets.find(new DSString("E")));
            Assert.AreEqual(true, the_d_sets.find(new DSString("C")) == the_d_sets.find(new DSString("D")));
            Assert.AreEqual(true, the_d_sets.find(new DSString("C")) == the_d_sets.find(new DSString("E")));
            Assert.AreEqual(true, the_d_sets.find(new DSString("D")) == the_d_sets.find(new DSString("E")));
        }

        private void testFind(DisjointSets<DSString> the_d_sets)
        {
            Assert.AreEqual(0, the_d_sets.find(new DSString("A")));
            Assert.AreEqual(1, the_d_sets.find(new DSString("B")));
            Assert.AreEqual(2, the_d_sets.find(new DSString("C")));
            Assert.AreEqual(3, the_d_sets.find(new DSString("D")));
            Assert.AreEqual(4, the_d_sets.find(new DSString("E")));

            the_d_sets.union(new DSString("A"), new DSString("B"));
            Assert.AreEqual(0, the_d_sets.find(new DSString("A")));
            Assert.AreEqual(0, the_d_sets.find(new DSString("B")));
        }
    }
}
