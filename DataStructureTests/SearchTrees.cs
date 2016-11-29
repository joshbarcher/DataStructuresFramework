using System;
using System.Text;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures.Interfaces;
using DataStructures.PrimitiveWrappers;
using DataStructures.Basic;
using DataStructures.Algorithms;
using DataStructures.Exceptions;

namespace DataStructureTests
{
    /// <summary>
    /// Tests all search trees in this assembly.
    /// </summary>
    [TestClass]
    public class SearchTrees
    {
        private Random my_rand = new Random();
        private Tree<DSShort> my_bst;

        private TestContext testContextInstance;

        public SearchTrees()
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
            my_bst = new BinarySearchTree<DSShort>();
            addElements(my_bst);
        }
        
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void testBreadthFirstSearch()
        {
            testBreadthFirstSearch(my_bst);
        }

        [TestMethod]
        public void testDepthFirstSearch()
        {
            testDepthFirstSearch(my_bst);
        }

        [TestMethod]
        public void testPreOrderSearch()
        {
            testPreOrderSearch(my_bst);
        }

        [TestMethod]
        public void testInOrderSearch()
        {
            testInOrderSearch(my_bst);
        }

        [TestMethod]
        public void testPostOrderSearch()
        {
            testPostOrderSearch(my_bst);
        }

        [TestMethod]
        public void testIsEmpty()
        {
            testIsEmpty(my_bst);
        }

        [TestMethod]
        public void testSize()
        {
            testSize(my_bst);
        }

        [TestMethod]
        public void testAdd()
        {
            testAdd(my_bst);
        }

        [TestMethod]
        public void testContains()
        {
            testContains(my_bst);
        }

        [TestMethod]
        public void testRemove()
        {
            testRemove(my_bst);
        }

        [TestMethod]
        public void testClear()
        {
            testClear(my_bst);
        }

        [TestMethod]
        public void testToArray()
        {
            testToArray(my_bst);
        }

        [TestMethod]
        public void testIterator()
        {
            testIterator(my_bst);
        }

        [TestMethod]
        public void testGetElement()
        {
            testGetElement(my_bst);
        }

        [TestMethod]
        public void testFirst()
        {
            testFirst((BinarySearchTree<DSShort>)my_bst);
        }

        [TestMethod]
        public void testLast()
        {
            testLast((BinarySearchTree<DSShort>)my_bst);
        }

        [TestMethod]
        public void testToString()
        {
            testToString(my_bst);
        }

        private void testToString(Tree<DSShort> the_bst)
        {
            //just test for no exceptions, leave the output to the programmer, user
            try
            {
                the_bst.ToString();
            }
            catch (Exception the_ex)
            {
                Assert.Fail();
            }
        }

        private void testGetElement(Tree<DSShort> the_bst)
        {
            Iterator<DSShort> it = the_bst.iterator();
            while (it.hasNext())
            {
                DSShort next = it.next();
                //Assert.AreEqual(next.Equals(the_bst.g
            }
        }

        private void testFirst(BinarySearchTree<DSShort> the_bst)
        {
            //test the obvious first
            Assert.AreEqual(1, the_bst.first().value);

            //remove the first and check for a correct first after the alteration
            the_bst.remove(new DSShort(1));
            Assert.AreEqual(2, the_bst.first().value);

            //remove all items and make sure first() returns null
            the_bst.clear();
            Assert.AreEqual(null, the_bst.first());
        }

        private void testLast(BinarySearchTree<DSShort> the_bst)
        {
            //test the obvious last
            Assert.AreEqual(20, the_bst.last().value);

            //remove the first and check for a correct first after the alteration
            the_bst.remove(new DSShort(20));
            Assert.AreEqual(18, the_bst.last().value);

            //remove all items and make sure first() returns null
            the_bst.clear();
            Assert.AreEqual(null, the_bst.last());
        }

        private void testBreadthFirstSearch(Tree<DSShort> the_bst)
        {
            //test the list traversal
            List<DSShort> bfs = the_bst.breadthFirstSearch();
            Assert.AreEqual(10, bfs.get(0).value);
            Assert.AreEqual(5, bfs.get(1).value);
            Assert.AreEqual(15, bfs.get(2).value);
            Assert.AreEqual(2, bfs.get(3).value);
            Assert.AreEqual(8, bfs.get(4).value);
            Assert.AreEqual(12, bfs.get(5).value);
            Assert.AreEqual(18, bfs.get(6).value);
            Assert.AreEqual(1, bfs.get(7).value);
            Assert.AreEqual(3, bfs.get(8).value);
            Assert.AreEqual(7, bfs.get(9).value);
            Assert.AreEqual(9, bfs.get(10).value);
            Assert.AreEqual(11, bfs.get(11).value);
            Assert.AreEqual(13, bfs.get(12).value);
            Assert.AreEqual(16, bfs.get(13).value);
            Assert.AreEqual(20, bfs.get(14).value);

            //test the iterator at the root 
            Iterator<DSShort> it = the_bst.iterator(GraphTraversals.BreadthFirst);
            Assert.AreEqual(10, it.next().value);
            Assert.AreEqual(5, it.next().value);
            Assert.AreEqual(15, it.next().value);
            Assert.AreEqual(2, it.next().value);
            Assert.AreEqual(8, it.next().value);
            Assert.AreEqual(12, it.next().value);
            Assert.AreEqual(18, it.next().value);
            Assert.AreEqual(1, it.next().value);
            Assert.AreEqual(3, it.next().value);
            Assert.AreEqual(7, it.next().value);
            Assert.AreEqual(9, it.next().value);
            Assert.AreEqual(11, it.next().value);
            Assert.AreEqual(13, it.next().value);
            Assert.AreEqual(16, it.next().value);
            Assert.AreEqual(20, it.next().value);

            //make sure no more are available
            Assert.IsFalse(it.hasNext());

            //test the iterator at an arbitrary node
            it = the_bst.iterator(GraphTraversals.BreadthFirst, new DSShort(5));
            Assert.AreEqual(5, it.next().value);
            Assert.AreEqual(2, it.next().value);
            Assert.AreEqual(8, it.next().value);
            Assert.AreEqual(1, it.next().value);
            Assert.AreEqual(3, it.next().value);
            Assert.AreEqual(7, it.next().value);
            Assert.AreEqual(9, it.next().value);

            //make sure no more are available
            Assert.IsFalse(it.hasNext());
        }

        private void testDepthFirstSearch(Tree<DSShort> the_bst)
        {
            //test the list traversal
            List<DSShort> dfs = the_bst.depthFirstSearch();
            Assert.AreEqual(10, dfs.get(0).value);
            Assert.AreEqual(5, dfs.get(1).value);
            Assert.AreEqual(2, dfs.get(2).value);
            Assert.AreEqual(1, dfs.get(3).value);
            Assert.AreEqual(3, dfs.get(4).value);
            Assert.AreEqual(8, dfs.get(5).value);
            Assert.AreEqual(7, dfs.get(6).value);
            Assert.AreEqual(9, dfs.get(7).value);
            Assert.AreEqual(15, dfs.get(8).value);
            Assert.AreEqual(12, dfs.get(9).value);
            Assert.AreEqual(11, dfs.get(10).value);
            Assert.AreEqual(13, dfs.get(11).value);
            Assert.AreEqual(18, dfs.get(12).value);
            Assert.AreEqual(16, dfs.get(13).value);
            Assert.AreEqual(20, dfs.get(14).value);

            //test the iterator
            Iterator<DSShort> it = the_bst.iterator(GraphTraversals.DepthFirst);
            Assert.AreEqual(10, it.next().value);
            Assert.AreEqual(5, it.next().value);
            Assert.AreEqual(2, it.next().value);
            Assert.AreEqual(1, it.next().value);
            Assert.AreEqual(3, it.next().value);
            Assert.AreEqual(8, it.next().value);
            Assert.AreEqual(7, it.next().value);
            Assert.AreEqual(9, it.next().value);
            Assert.AreEqual(15, it.next().value);
            Assert.AreEqual(12, it.next().value);
            Assert.AreEqual(11, it.next().value);
            Assert.AreEqual(13, it.next().value);
            Assert.AreEqual(18, it.next().value);
            Assert.AreEqual(16, it.next().value);
            Assert.AreEqual(20, it.next().value);

            //make sure no more are available
            Assert.IsFalse(it.hasNext());

            //test the iterator at an arbitrary node
            it = the_bst.iterator(GraphTraversals.DepthFirst, new DSShort(5));
            Assert.AreEqual(5, it.next().value);
            Assert.AreEqual(2, it.next().value);
            Assert.AreEqual(1, it.next().value);
            Assert.AreEqual(3, it.next().value);
            Assert.AreEqual(8, it.next().value);
            Assert.AreEqual(7, it.next().value);
            Assert.AreEqual(9, it.next().value);

            //make sure no more are available
            Assert.IsFalse(it.hasNext());
        }

        private void testPreOrderSearch(Tree<DSShort> the_bst)
        {
            //make sure all elements are in the tree
            Assert.AreEqual(15, the_bst.size());

            Iterator<DSShort> it = the_bst.iterator(GraphTraversals.PreOrder);
            DSShort current = it.next();
            Assert.AreEqual(current, new DSShort(10));
            current = it.next();
            Assert.AreEqual(current, new DSShort(5));
            current = it.next();
            Assert.AreEqual(current, new DSShort(2));
            current = it.next();
            Assert.AreEqual(current, new DSShort(1));
            current = it.next();
            Assert.AreEqual(current, new DSShort(3));
            current = it.next();
            Assert.AreEqual(current, new DSShort(8));
            current = it.next();
            Assert.AreEqual(current, new DSShort(7));
            current = it.next();
            Assert.AreEqual(current, new DSShort(9));
            current = it.next();
            Assert.AreEqual(current, new DSShort(15));
            current = it.next();
            Assert.AreEqual(current, new DSShort(12));
            current = it.next();
            Assert.AreEqual(current, new DSShort(11));
            current = it.next();
            Assert.AreEqual(current, new DSShort(13));
            current = it.next();
            Assert.AreEqual(current, new DSShort(18));
            current = it.next();
            Assert.AreEqual(current, new DSShort(16));
            current = it.next();
            Assert.AreEqual(current, new DSShort(20));

            //check method version
            List<DSShort> list = the_bst.preOrderSearch();

            Assert.AreEqual(list.get(0), new DSShort(10));
            Assert.AreEqual(list.get(1), new DSShort(5));
            Assert.AreEqual(list.get(2), new DSShort(2));
            Assert.AreEqual(list.get(3), new DSShort(1));
            Assert.AreEqual(list.get(4), new DSShort(3));
            Assert.AreEqual(list.get(5), new DSShort(8));
            Assert.AreEqual(list.get(6), new DSShort(7));
            Assert.AreEqual(list.get(7), new DSShort(9));
            Assert.AreEqual(list.get(8), new DSShort(15));
            Assert.AreEqual(list.get(9), new DSShort(12));
            Assert.AreEqual(list.get(10), new DSShort(11));
            Assert.AreEqual(list.get(11), new DSShort(13));
            Assert.AreEqual(list.get(12), new DSShort(18));
            Assert.AreEqual(list.get(13), new DSShort(16));
            Assert.AreEqual(list.get(14), new DSShort(20));
        }

        private void testInOrderSearch(Tree<DSShort> the_bst)
        {
            //iterator tested in testAdd()

            //check method version
            List<DSShort> list = the_bst.inOrderSearch();

            Assert.AreEqual(list.get(0), new DSShort(1));
            Assert.AreEqual(list.get(1), new DSShort(2));
            Assert.AreEqual(list.get(2), new DSShort(3));
            Assert.AreEqual(list.get(3), new DSShort(5));
            Assert.AreEqual(list.get(4), new DSShort(7));
            Assert.AreEqual(list.get(5), new DSShort(8));
            Assert.AreEqual(list.get(6), new DSShort(9));
            Assert.AreEqual(list.get(7), new DSShort(10));
            Assert.AreEqual(list.get(8), new DSShort(11));
            Assert.AreEqual(list.get(9), new DSShort(12));
            Assert.AreEqual(list.get(10), new DSShort(13));
            Assert.AreEqual(list.get(11), new DSShort(15));
            Assert.AreEqual(list.get(12), new DSShort(16));
            Assert.AreEqual(list.get(13), new DSShort(18));
            Assert.AreEqual(list.get(14), new DSShort(20));
        }

        private void testPostOrderSearch(Tree<DSShort> the_bst)
        {
            //make sure all elements are in the tree
            Assert.AreEqual(15, the_bst.size());

            //check iterator
            Iterator<DSShort> it = the_bst.iterator(GraphTraversals.PostOrder);
            DSShort current = it.next();
            Assert.AreEqual(current, new DSShort(1));
            current = it.next();
            Assert.AreEqual(current, new DSShort(3));
            current = it.next();
            Assert.AreEqual(current, new DSShort(2));
            current = it.next();
            Assert.AreEqual(current, new DSShort(7));
            current = it.next();
            Assert.AreEqual(current, new DSShort(9));
            current = it.next();
            Assert.AreEqual(current, new DSShort(8));
            current = it.next();
            Assert.AreEqual(current, new DSShort(5));
            current = it.next();
            Assert.AreEqual(current, new DSShort(11));
            current = it.next();
            Assert.AreEqual(current, new DSShort(13));
            current = it.next();
            Assert.AreEqual(current, new DSShort(12));
            current = it.next();
            Assert.AreEqual(current, new DSShort(16));
            current = it.next();
            Assert.AreEqual(current, new DSShort(20));
            current = it.next();
            Assert.AreEqual(current, new DSShort(18));
            current = it.next();
            Assert.AreEqual(current, new DSShort(15));
            current = it.next();
            Assert.AreEqual(current, new DSShort(10));

            //check method version
            List<DSShort> list = the_bst.postOrderSearch();

            Assert.AreEqual(list.get(0), new DSShort(1));
            Assert.AreEqual(list.get(1), new DSShort(3));
            Assert.AreEqual(list.get(2), new DSShort(2));
            Assert.AreEqual(list.get(3), new DSShort(7));
            Assert.AreEqual(list.get(4), new DSShort(9));
            Assert.AreEqual(list.get(5), new DSShort(8));
            Assert.AreEqual(list.get(6), new DSShort(5));
            Assert.AreEqual(list.get(7), new DSShort(11));
            Assert.AreEqual(list.get(8), new DSShort(13));
            Assert.AreEqual(list.get(9), new DSShort(12));
            Assert.AreEqual(list.get(10), new DSShort(16));
            Assert.AreEqual(list.get(11), new DSShort(20));
            Assert.AreEqual(list.get(12), new DSShort(18));
            Assert.AreEqual(list.get(13), new DSShort(15));
            Assert.AreEqual(list.get(14), new DSShort(10));
        }

        private void testIsEmpty(Tree<DSShort> the_bst)
        {
            //make sure no false positives
            Assert.AreEqual(false, the_bst.isEmpty());

            //clear items
            the_bst.clear();

            //make sure size() and isEmpty() are correct
            Assert.AreEqual(0, the_bst.size());
            Assert.AreEqual(true, the_bst.isEmpty());

            //make sure no items can be traversed
            Iterator<DSShort> it = the_bst.iterator(GraphTraversals.InOrder);
            Assert.AreEqual(false, it.hasNext());
        }

        private void testSize(Tree<DSShort> the_bst)
        {
            //check initial items
            Assert.AreEqual(15, the_bst.size());

            //remove a single item
            Assert.IsTrue(the_bst.remove(new DSShort(10)));

            Assert.AreEqual(14, the_bst.size());

            //clear items
            the_bst.clear();

            //empty tree
            Assert.AreEqual(0, the_bst.size());
        }

        private void testAdd(Tree<DSShort> the_bst)
        {
            //make sure all elements are in the tree
            Assert.AreEqual(15, the_bst.size());

            //make sure the correct ones are in there
            Assert.AreEqual(true, the_bst.contains(new DSShort(1)));
            Assert.AreEqual(true, the_bst.contains(new DSShort(2)));
            Assert.AreEqual(true, the_bst.contains(new DSShort(3)));
            Assert.AreEqual(true, the_bst.contains(new DSShort(5)));
            Assert.AreEqual(true, the_bst.contains(new DSShort(7)));
            Assert.AreEqual(true, the_bst.contains(new DSShort(8)));
            Assert.AreEqual(true, the_bst.contains(new DSShort(9)));
            Assert.AreEqual(true, the_bst.contains(new DSShort(10)));
            Assert.AreEqual(true, the_bst.contains(new DSShort(11)));
            Assert.AreEqual(true, the_bst.contains(new DSShort(12)));
            Assert.AreEqual(true, the_bst.contains(new DSShort(13)));
            Assert.AreEqual(true, the_bst.contains(new DSShort(15)));
            Assert.AreEqual(true, the_bst.contains(new DSShort(16)));
            Assert.AreEqual(true, the_bst.contains(new DSShort(18)));
            Assert.AreEqual(true, the_bst.contains(new DSShort(20)));

            //perform an in-order traversal to make sure the bst ordering property works
            Iterator<DSShort> it = the_bst.iterator(GraphTraversals.InOrder);
            DSShort last, current; ;
            last = current = it.next(); //more than one item in the tree
            while (it.hasNext())
            {
                current = it.next();
                
                //if the next item in the in-order traversal is bigger (this should not happen)
                if (last.compareTo(current) > 0)
                {
                    Assert.Fail();
                }
            }
        }

        private void testContains(Tree<DSShort> the_bst)
        {
            //tested in testAdd()
        }

        private void testRemove(Tree<DSShort> the_bst)
        {
            Set<DSShort> set = new HashSet<DSShort>(15);

            set.add(new DSShort(1));
            set.add(new DSShort(2));
            set.add(new DSShort(3));
            set.add(new DSShort(5));
            set.add(new DSShort(7));
            set.add(new DSShort(8));
            set.add(new DSShort(9));
            set.add(new DSShort(10));
            set.add(new DSShort(11));
            set.add(new DSShort(12));
            set.add(new DSShort(13));
            set.add(new DSShort(15));
            set.add(new DSShort(16));
            set.add(new DSShort(18));
            set.add(new DSShort(20));

            removeAndCheckConstistency(new DSShort(10), set, the_bst);
            removeAndCheckConstistency(new DSShort(9), set, the_bst);
            removeAndCheckConstistency(new DSShort(5), set, the_bst);
            removeAndCheckConstistency(new DSShort(15), set, the_bst);
            removeAndCheckConstistency(new DSShort(16), set, the_bst);
            removeAndCheckConstistency(new DSShort(7), set, the_bst);
            removeAndCheckConstistency(new DSShort(1), set, the_bst);
            removeAndCheckConstistency(new DSShort(2), set, the_bst);
            removeAndCheckConstistency(new DSShort(20), set, the_bst);
            removeAndCheckConstistency(new DSShort(3), set, the_bst);
            removeAndCheckConstistency(new DSShort(8), set, the_bst);
            removeAndCheckConstistency(new DSShort(11), set, the_bst);
            removeAndCheckConstistency(new DSShort(12), set, the_bst);
            removeAndCheckConstistency(new DSShort(13), set, the_bst);
            removeAndCheckConstistency(new DSShort(18), set, the_bst);

            //test the removal mechanism with a large input tree
            List<DSShort> permutation = new ArrayList<DSShort>(1000);
            for (int i = 0; i < 1000; i++)
            {
                permutation.add(new DSShort((short)i));
            }

            //randomize the insertion order and add them to the bst
            DSShort[] additions = permutation.toArray();
            Randomization.shuffleArray<DSShort>(ref additions);

            for (int i = 0; i < additions.Length; i++)
            {
                the_bst.add(additions[i]);
            }

            //get another permutation of the shorts so that we can remove them in random order
            Randomization.shuffleArray<DSShort>(ref additions);

            //remove each item one by one
            for (int i = 0; i < additions.Length; i++)
            {
                the_bst.remove(additions[i]);

                //make sure all other items are still find-able in the tree
                for (int j = i + 1; j < additions.Length; j++)
                {
                    Assert.IsTrue(the_bst.contains(additions[j]));
                }
            }
        }

        private void testClear(Tree<DSShort> the_bst)
        {
            //make sure the tree is not empty at first
            Assert.IsFalse(the_bst.isEmpty());

            //remove all items
            the_bst.clear();

            //note the change
            Assert.IsTrue(the_bst.isEmpty());

            //add items and confirm no false positives
            the_bst.add(new DSShort(1));
            Assert.IsFalse(the_bst.isEmpty());

            //remove again and check for consistency
            the_bst.clear();
            Assert.IsTrue(the_bst.isEmpty());
        }

        private void testToArray(Tree<DSShort> the_bst)
        {
            //in-order traversal of elements in array form
            DSShort[] elements = the_bst.toArray();

            //make sure the ordering is correct
            Assert.AreEqual(elements[0], new DSShort(1));
            Assert.AreEqual(elements[1], new DSShort(2));
            Assert.AreEqual(elements[2], new DSShort(3));
            Assert.AreEqual(elements[3], new DSShort(5));
            Assert.AreEqual(elements[4], new DSShort(7));
            Assert.AreEqual(elements[5], new DSShort(8));
            Assert.AreEqual(elements[6], new DSShort(9));
            Assert.AreEqual(elements[7], new DSShort(10));
            Assert.AreEqual(elements[8], new DSShort(11));
            Assert.AreEqual(elements[9], new DSShort(12));
            Assert.AreEqual(elements[10], new DSShort(13));
            Assert.AreEqual(elements[11], new DSShort(15));
            Assert.AreEqual(elements[12], new DSShort(16));
            Assert.AreEqual(elements[13], new DSShort(18));
            Assert.AreEqual(elements[14], new DSShort(20));
        }

        private void testIterator(Tree<DSShort> the_bst)
        {
            //traversal tested in testInOrderSearch()

            Iterator<DSShort> it = the_bst.iterator();
            //test removing before moving the iterator
            try
            {
                it.remove();
                Assert.Fail(); //should error out before here
            }
            catch (IllegalStateException the_ex)
            {
                //good
            }

            //test removing the first item
            it.next();
            DSShort removed = it.remove();
            Assert.AreEqual(1, removed.value);

            //test removing in the middle of the set
            it.next();
            it.next();
            removed = it.remove();
            Assert.AreEqual(3, removed.value);

            //test double removal
            try
            {
                it.remove();
                Assert.Fail(); //should error out before here
            }
            catch (IllegalStateException the_ex)
            {
                //good
            }

            //test removing the last item
            while (it.hasNext())
            {
                removed = it.next();
            }
            Assert.AreEqual(20, removed.value);
        }

        //----------------------- HELPER METHODS ----------------------

        private void removeAndCheckConstistency(DSShort the_element, Set<DSShort> the_set, Tree<DSShort> the_bst)
        {
            //remove the item from the tree and set
            the_bst.remove(the_element);
            the_set.remove(the_element);

            Iterator<DSShort> it = the_set.iterator();
            while (it.hasNext())
            {
                Assert.IsTrue(the_bst.contains(it.next()));
            }
        }

        private void addElements(Tree<DSShort> the_bst)
        {
            the_bst.add(new DSShort(10));
            the_bst.add(new DSShort(5));
            the_bst.add(new DSShort(15));
            the_bst.add(new DSShort(2));
            the_bst.add(new DSShort(8));
            the_bst.add(new DSShort(12));
            the_bst.add(new DSShort(18));
            the_bst.add(new DSShort(1));
            the_bst.add(new DSShort(3));
            the_bst.add(new DSShort(7));
            the_bst.add(new DSShort(9));
            the_bst.add(new DSShort(11));
            the_bst.add(new DSShort(13));
            the_bst.add(new DSShort(16));
            the_bst.add(new DSShort(20));
        }
    }
}
