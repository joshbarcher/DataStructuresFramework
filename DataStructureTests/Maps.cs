using System;
using System.Text;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures.PrimitiveWrappers;
using DataStructures.Basic;
using DataStructures;
using DataStructures.Interfaces;

namespace DataStructureTests
{
    /// <summary>
    /// Tests the maps present in this assembly.
    /// </summary>
    [TestClass]
    public class Maps
    {
        private Map<DSString, DSInteger> my_h_map;
        private Map<DSString, DSInteger> my_t_map;

        private TestContext testContextInstance;

        public Maps()
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
            my_h_map = new HashMap<DSString, DSInteger>();
            my_t_map = new TreeMap<DSString, DSInteger>();
            addInitialItems(my_h_map);
            addInitialItems(my_t_map);
        }
        
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void testIsEmpty()
        {
            testIsEmpty(my_h_map);
            testIsEmpty(my_t_map);
        }

        [TestMethod]
        public void testContainsKey()
        {
            testContainsKey(my_h_map);
            testContainsKey(my_t_map);
        }

        [TestMethod]
        public void testGet()
        {
            testGet(my_h_map);
            testGet(my_t_map);
        }

        [TestMethod]
        public void testPut()
        {
            testPut(my_h_map);
            testPut(my_t_map);
        }

        [TestMethod]
        public void testRemove()
        {
            testRemove(my_h_map);
            testRemove(my_t_map);
        }

        [TestMethod]
        public void testClear()
        {
            testClear(my_h_map);
            testClear(my_t_map);
        }

        [TestMethod]
        public void testKeyset()
        {
            testKeyset(my_h_map);
            testKeyset(my_t_map);
        }

        [TestMethod]
        public void testValues()
        {
            testValues(my_h_map);
            testValues(my_t_map);
        }

        [TestMethod]
        public void testToString()
        {
            testToString(my_h_map);
            testToString(my_t_map);
        }

        [TestMethod]
        public void testTreeMap()
        {
            testTreeMap((TreeMap<DSString, DSInteger>)my_t_map);
        }

        private void testTreeMap(TreeMap<DSString, DSInteger> the_map)
        {
            Set<DSString> keys = the_map.keyset();
            Iterator<DSString> it = keys.iterator();

            //test the correct order coming out of the set (from the map)
            Assert.AreEqual("Addrienne", it.next().value);
            Assert.AreEqual("Ariel", it.next().value);
            Assert.AreEqual("Billy", it.next().value);
            Assert.AreEqual("Bobby", it.next().value);
            Assert.AreEqual("Eric", it.next().value);
            Assert.AreEqual("Ferrill", it.next().value);
            Assert.AreEqual("Foran", it.next().value);
            Assert.AreEqual("Foster", it.next().value);
            Assert.AreEqual("Larry", it.next().value);
            Assert.AreEqual("Margy", it.next().value);
            Assert.AreEqual("Merin", it.next().value);
            Assert.AreEqual("Rogan", it.next().value);
            Assert.AreEqual("Womack", it.next().value);

            Assert.IsFalse(it.hasNext());
        }

        private void testToString(Map<DSString, DSInteger> the_map)
        {
            //just test for no exceptions, leave the output to the programmer, user
            try
            {
                string to_string = the_map.ToString();
            }
            catch (Exception the_ex)
            {
                Assert.Fail();
            }
        }

        private void testIsEmpty(Map<DSString, DSInteger> the_map)
        {
            //remove all items after adding them and check for the empty inner structures
            the_map.clear();
            Assert.AreEqual(true, the_map.keyset().size() == 0);
            Assert.AreEqual(true, the_map.values().size() == 0);
        }

        private void testContainsKey(Map<DSString, DSInteger> the_map)
        {
            //check for keys that exist
            Assert.AreEqual(true, the_map.containsKey(new DSString("Bobby")));
            Assert.AreEqual(true, the_map.containsKey(new DSString("Ariel")));
            Assert.AreEqual(true, the_map.containsKey(new DSString("Rogan")));

            //check for keys that do not exist
            Assert.AreEqual(false, the_map.containsKey(new DSString("Martene")));
        }

        private void testGet(Map<DSString, DSInteger> the_map)
        {
            //check some entries for valid return values
            DSInteger check = the_map.get(new DSString("Bobby"));
            Assert.AreEqual(20, check.value);
            check = the_map.get(new DSString("Foran"));
            Assert.AreEqual(52, check.value);

            //check for something that is not in the map
            check = the_map.get(new DSString("Susan"));
            Assert.AreEqual(null, check);
        }

        private void testPut(Map<DSString, DSInteger> the_map)
        {
            Assert.AreEqual(true, the_map.containsKey(new DSString("Bobby")));
            Assert.AreEqual(true, the_map.containsKey(new DSString("Ariel")));
            Assert.AreEqual(true, the_map.containsKey(new DSString("Foran")));
        }

        private void testRemove(Map<DSString, DSInteger> the_map)
        {
            //remove items and verify that they are gone
            the_map.remove(new DSString("Bobby"));
            Assert.AreEqual(false, the_map.containsKey(new DSString("Bobby")));
            the_map.remove(new DSString("Ariel"));
            Assert.AreEqual(false, the_map.containsKey(new DSString("Ariel")));
            the_map.remove(new DSString("Foran"));
            Assert.AreEqual(false, the_map.containsKey(new DSString("Foran")));
        }

        private void testClear(Map<DSString, DSInteger> the_map)
        {
            //clear the map and verify that it is empty
            the_map.clear();
            Assert.AreEqual(true, the_map.isEmpty());
            Assert.AreEqual(0, the_map.keyset().size());
        }

        private void testKeyset(Map<DSString, DSInteger> the_map)
        {
            Set<DSString> keys = the_map.keyset();

            //check that all keys are present
            Assert.AreEqual(true, keys.contains(new DSString("Bobby")));
            Assert.AreEqual(true, keys.contains(new DSString("Addrienne")));
            Assert.AreEqual(true, keys.contains(new DSString("Larry")));
            Assert.AreEqual(true, keys.contains(new DSString("Womack")));
            Assert.AreEqual(true, keys.contains(new DSString("Billy")));
            Assert.AreEqual(true, keys.contains(new DSString("Ariel")));
            Assert.AreEqual(true, keys.contains(new DSString("Foster")));
            Assert.AreEqual(true, keys.contains(new DSString("Eric")));
            Assert.AreEqual(true, keys.contains(new DSString("Rogan")));
            Assert.AreEqual(true, keys.contains(new DSString("Margy")));
            Assert.AreEqual(true, keys.contains(new DSString("Ferrill")));
            Assert.AreEqual(true, keys.contains(new DSString("Merin")));
            Assert.AreEqual(true, keys.contains(new DSString("Foran")));

            //check to make sure there are only these keys
            Assert.AreEqual(13, keys.size());
        }

        private void testValues(Map<DSString, DSInteger> the_map)
        {
            Collection<DSInteger> values = the_map.values();

            //check that all values are present
            Assert.AreEqual(true, values.contains(new DSInteger(20)));
            Assert.AreEqual(true, values.contains(new DSInteger(31)));
            Assert.AreEqual(true, values.contains(new DSInteger(11)));
            Assert.AreEqual(true, values.contains(new DSInteger(44)));
            Assert.AreEqual(true, values.contains(new DSInteger(32)));
            Assert.AreEqual(true, values.contains(new DSInteger(67)));
            Assert.AreEqual(true, values.contains(new DSInteger(10)));
            Assert.AreEqual(true, values.contains(new DSInteger(3)));
            Assert.AreEqual(true, values.contains(new DSInteger(17)));
            Assert.AreEqual(true, values.contains(new DSInteger(19)));
            Assert.AreEqual(true, values.contains(new DSInteger(35)));
            Assert.AreEqual(true, values.contains(new DSInteger(71)));
            Assert.AreEqual(true, values.contains(new DSInteger(52)));

            //check to make sure there are only these values
            Assert.AreEqual(13, values.size());
        }

        //---------------- HELPER METHODS -----------------
        private void addInitialItems(Map<DSString, DSInteger> the_map)
        {
            the_map.put(new DSString("Bobby"), new DSInteger(20));
            the_map.put(new DSString("Addrienne"), new DSInteger(31));
            the_map.put(new DSString("Larry"), new DSInteger(11));
            the_map.put(new DSString("Womack"), new DSInteger(44));
            the_map.put(new DSString("Billy"), new DSInteger(32));
            the_map.put(new DSString("Ariel"), new DSInteger(67));
            the_map.put(new DSString("Foster"), new DSInteger(10));
            the_map.put(new DSString("Eric"), new DSInteger(3));
            the_map.put(new DSString("Rogan"), new DSInteger(17));
            the_map.put(new DSString("Margy"), new DSInteger(19));
            the_map.put(new DSString("Ferrill"), new DSInteger(35));
            the_map.put(new DSString("Merin"), new DSInteger(71));
            the_map.put(new DSString("Foran"), new DSInteger(52));
        }
    }
}
