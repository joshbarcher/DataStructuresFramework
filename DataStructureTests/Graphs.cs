using System;
using System.Text;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures.Basic;
using DataStructures;
using DataStructures.PrimitiveWrappers;
using DataStructures.Interfaces;

namespace DataStructureTests
{
    /// <summary>
    /// Tests the Directed/Un-DirectedGraph classes.
    /// </summary>
    [TestClass]
    public class Graphs
    {
        private Random my_rand = new Random();
        private DirectedGraph<DSString> my_graph_al_directed;
        private UndirectedGraph<DSString> my_graph_al_undirected;

        private TestContext testContextInstance;

        public Graphs()
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
            my_graph_al_directed = new DirectedGraph_AL<DSString>();
            my_graph_al_undirected = new UndirectedGraph_AL<DSString>();
            addElementsToGraph(my_graph_al_directed);
            addElementsToGraph(my_graph_al_undirected);
        }
        
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void testAddVertex()
        {
            testAddVertex(my_graph_al_directed);
        }

        [TestMethod]
        public void testAddEdge()
        {
            testAddEdge(my_graph_al_directed);
        }

        [TestMethod]
        public void testClear()
        {
            testClear(my_graph_al_directed);
        }

        [TestMethod]
        public void testVertexSize()
        {
            testVertexSize(my_graph_al_directed);
        }

        [TestMethod]
        public void testEdgeSize()
        {
            testEdgeSize(my_graph_al_directed);
        }

        [TestMethod]
        public void testRemoveVertex()
        {
            testRemoveVertex(my_graph_al_directed);
        }

        [TestMethod]
        public void testRemoveEdge()
        {
            testRemoveEdge(my_graph_al_directed);
        }

        [TestMethod]
        public void testContainsVertex()
        {
            testContainsVertex(my_graph_al_directed);
        }

        [TestMethod]
        public void testContainsEdge()
        {
            testContainsEdge(my_graph_al_directed);
        }

        [TestMethod]
        public void testUnweighted()
        {
            testUnweighted(my_graph_al_directed);
        }

        [TestMethod]
        public void testGetShortestPath()
        {
            testGetShortestPath(my_graph_al_directed);
        }

        [TestMethod]
        public void testGetShortestPathLength()
        {
            testGetShortestPathLength(my_graph_al_directed);
        }

        [TestMethod]
        public void testDijkstras()
        {
            testDijkstras(my_graph_al_directed);
        }

        [TestMethod]
        public void testDirectedUndirected()
        {
            testDirectedUndirected(my_graph_al_directed, my_graph_al_undirected);
        }

        [TestMethod]
        public void testBreadthFirstSearch()
        {
            testBreadthFirstSearch(my_graph_al_directed, my_graph_al_undirected);
        }

        [TestMethod]
        public void testDepthFirstSearch()
        {
            testDepthFirstSearch(my_graph_al_directed, my_graph_al_undirected);
        }

        [TestMethod]
        public void testIsConnected()
        {
            testIsConnected(my_graph_al_directed, my_graph_al_undirected);
        }

        [TestMethod]
        public void testGetComponents()
        {
            testGetComponents(my_graph_al_directed, my_graph_al_undirected);
        }

        [TestMethod]
        public void testGetComponentCount()
        {
            testGetComponentCount(my_graph_al_directed, my_graph_al_undirected);
        }

        [TestMethod]
        public void testInDegree()
        {
            testInDegree(my_graph_al_directed, my_graph_al_undirected);
        }

        [TestMethod]
        public void testOutDegree()
        {
            testOutDegree(my_graph_al_directed, my_graph_al_undirected);
        }

        [TestMethod]
        public void testDegree()
        {
            testDegree(my_graph_al_directed, my_graph_al_undirected);
        }

        [TestMethod]
        public void testTopologicalSearch()
        {
            testTopologicalSearch(my_graph_al_directed, my_graph_al_undirected);
        }

        [TestMethod]
        public void testIsTree()
        {
            testIsTree(my_graph_al_directed, my_graph_al_undirected);
        }

        [TestMethod]
        public void testKruskals()
        {
            testKruskals(my_graph_al_undirected);
        }

        [TestMethod]
        public void testToString()
        {
            testToString(my_graph_al_directed, my_graph_al_undirected);
        }

        private void testToString(DirectedGraph<DSString> the_directed_graph, DirectedGraph<DSString> the_undirected_graph)
        {
            //just test for no exceptions, leave the output to the programmer, user
            try
            {
                the_directed_graph.ToString();
                the_undirected_graph.ToString();
            }
            catch (Exception the_ex)
            {
                Assert.Fail();
            }
        }

        private void testKruskals(DirectedGraph<DSString> the_undirected_graph)
        {
            UndirectedGraph<DSString> mst = ((UndirectedGraph<DSString>)the_undirected_graph).kruskals();

            //check whether the correct tree 
            Assert.IsTrue(the_undirected_graph.containsEdge(new DSString("A"), new DSString("B")));
            Assert.IsTrue(the_undirected_graph.containsEdge(new DSString("A"), new DSString("F")));
            Assert.IsTrue(the_undirected_graph.containsEdge(new DSString("A"), new DSString("C")));
            Assert.IsTrue(the_undirected_graph.containsEdge(new DSString("C"), new DSString("D")));
            Assert.IsTrue(the_undirected_graph.containsEdge(new DSString("A"), new DSString("E")));

            //Assert.AreEqual(5, the_undirected_graph.edgeSize());
            //Assert.IsFalse(the_undirected_graph.containsCycle());
        }

        private void testTopologicalSearch(DirectedGraph<DSString> the_directed_graph, DirectedGraph<DSString> the_undirected_graph)
        {

        }

        private void testIsTree(DirectedGraph<DSString> the_directed_graph, DirectedGraph<DSString> the_undirected_graph)
        {

        }

        private void testInDegree(DirectedGraph<DSString> the_directed_graph, DirectedGraph<DSString> the_undirected_graph)
        {
            //load a special case graph
            addGraphSearchElements(the_directed_graph);
            addGraphSearchElements(the_undirected_graph);

            //directed
            Assert.AreEqual(1, the_directed_graph.inDegree(new DSString("A")));
            Assert.AreEqual(1, the_directed_graph.inDegree(new DSString("B")));
            Assert.AreEqual(2, the_directed_graph.inDegree(new DSString("C")));
            Assert.AreEqual(2, the_directed_graph.inDegree(new DSString("D")));
            Assert.AreEqual(1, the_directed_graph.inDegree(new DSString("E")));
            Assert.AreEqual(1, the_directed_graph.inDegree(new DSString("F")));

            //undirected
            Assert.AreEqual(2, the_undirected_graph.inDegree(new DSString("A")));
            Assert.AreEqual(3, the_undirected_graph.inDegree(new DSString("B")));
            Assert.AreEqual(4, the_undirected_graph.inDegree(new DSString("C")));
            Assert.AreEqual(2, the_undirected_graph.inDegree(new DSString("D")));
            Assert.AreEqual(2, the_undirected_graph.inDegree(new DSString("E")));
            Assert.AreEqual(3, the_undirected_graph.inDegree(new DSString("F")));

            //make sure there are no false positives
            the_directed_graph.clearEdges();
            the_undirected_graph.clearEdges();
            Assert.AreEqual(0, the_directed_graph.inDegree(new DSString("A")));
            Assert.AreEqual(0, the_undirected_graph.inDegree(new DSString("A")));
        }

        private void testOutDegree(DirectedGraph<DSString> the_directed_graph, DirectedGraph<DSString> the_undirected_graph)
        {
            //load a special case graph
            addGraphSearchElements(the_directed_graph);
            addGraphSearchElements(the_undirected_graph);

            //directed
            Assert.AreEqual(1, the_directed_graph.outDegree(new DSString("A")));
            Assert.AreEqual(2, the_directed_graph.outDegree(new DSString("B")));
            Assert.AreEqual(2, the_directed_graph.outDegree(new DSString("C")));
            Assert.AreEqual(0, the_directed_graph.outDegree(new DSString("D")));
            Assert.AreEqual(1, the_directed_graph.outDegree(new DSString("E")));
            Assert.AreEqual(2, the_directed_graph.outDegree(new DSString("F")));

            //undirected (same as in-degree)
            Assert.AreEqual(2, the_undirected_graph.outDegree(new DSString("A")));
            Assert.AreEqual(3, the_undirected_graph.outDegree(new DSString("B")));
            Assert.AreEqual(4, the_undirected_graph.outDegree(new DSString("C")));
            Assert.AreEqual(2, the_undirected_graph.outDegree(new DSString("D")));
            Assert.AreEqual(2, the_undirected_graph.outDegree(new DSString("E")));
            Assert.AreEqual(3, the_undirected_graph.outDegree(new DSString("F")));

            //make sure there are no false positives
            the_directed_graph.clearEdges();
            the_undirected_graph.clearEdges();
            Assert.AreEqual(0, the_directed_graph.outDegree(new DSString("A")));
            Assert.AreEqual(0, the_undirected_graph.outDegree(new DSString("A")));
        }

        private void testDegree(DirectedGraph<DSString> the_directed_graph, DirectedGraph<DSString> the_undirected_graph)
        {
            //load a special case graph
            addGraphSearchElements(the_directed_graph);
            addGraphSearchElements(the_undirected_graph);

            //directed
            Assert.AreEqual(2, the_directed_graph.degree(new DSString("A")));
            Assert.AreEqual(3, the_directed_graph.degree(new DSString("B")));
            Assert.AreEqual(4, the_directed_graph.degree(new DSString("C")));
            Assert.AreEqual(2, the_directed_graph.degree(new DSString("D")));
            Assert.AreEqual(2, the_directed_graph.degree(new DSString("E")));
            Assert.AreEqual(3, the_directed_graph.degree(new DSString("F")));

            //undirected (same as directed)
            Assert.AreEqual(2, the_undirected_graph.degree(new DSString("A")));
            Assert.AreEqual(3, the_undirected_graph.degree(new DSString("B")));
            Assert.AreEqual(4, the_undirected_graph.degree(new DSString("C")));
            Assert.AreEqual(2, the_undirected_graph.degree(new DSString("D")));
            Assert.AreEqual(2, the_undirected_graph.degree(new DSString("E")));
            Assert.AreEqual(3, the_undirected_graph.degree(new DSString("F")));

            //make sure there are no false positives
            the_directed_graph.clearEdges();
            the_undirected_graph.clearEdges();
            Assert.AreEqual(0, the_directed_graph.degree(new DSString("A")));
            Assert.AreEqual(0, the_undirected_graph.degree(new DSString("A")));
        }

        private void testBreadthFirstSearch(DirectedGraph<DSString> the_directed_graph, UndirectedGraph<DSString> the_undirected_graph)
        {
            //check the initial items
            bfsCheck(the_directed_graph, the_undirected_graph);

            //load a special case graph
            addGraphSearchElements(the_directed_graph);
            addGraphSearchElements(the_undirected_graph);

            //breadth-first search the special case
            List<DSString> bfs_d = the_directed_graph.breadthFirstSearch(new DSString("A"));
            List<DSString> bfs_ud = the_undirected_graph.breadthFirstSearch(new DSString("A"));

            //check that the search covers all elements, but not the same search
            sameSizeDifferentElements(bfs_d, bfs_ud);
        }

        private void testDepthFirstSearch(DirectedGraph<DSString> the_directed_graph, UndirectedGraph<DSString> the_undirected_graph)
        {
            //check the initial items
            dfsCheck(the_directed_graph, the_undirected_graph);

            //load a special case graph
            addGraphSearchElements(the_directed_graph);
            addGraphSearchElements(the_undirected_graph);

            //depth-first search the special case
            List<DSString> dfs_d = the_directed_graph.depthFirstSearch(new DSString("A"));
            List<DSString> dfs_ud = the_undirected_graph.depthFirstSearch(new DSString("A"));

            //check that the search covers all elements, but not the same search
            sameSizeDifferentElements(dfs_d, dfs_ud);
        }

        private void testIsConnected(DirectedGraph<DSString> the_directed_graph, UndirectedGraph<DSString> the_undirected_graph)
        {
            //make sure the default is connected
            Assert.IsTrue(the_undirected_graph.isConnected());

            //try a graph that is not connected
            disconnectSmallGraph(the_undirected_graph);
            Assert.IsFalse(the_undirected_graph.isConnected());

            //try a large specific graph that is connected
            addLargeConnected(the_undirected_graph);
            Assert.IsTrue(the_undirected_graph.isConnected());

            //try a large specific graph that is not connected (disconnect the previous graph)
            int unconnected = 0;
            for (int i = 1; i < 100; i++)
            {
                the_undirected_graph.removeEdge(new DSString(unconnected.ToString()), new DSString(i.ToString()));
            }
            Assert.IsFalse(the_undirected_graph.isConnected());
        }

        private void testGetComponents(DirectedGraph<DSString> the_directed_graph, UndirectedGraph<DSString> the_undirected_graph)
        {
            //make sure the default is a single component
            List<List<DSString>> components = the_undirected_graph.getComponents();
            Assert.AreEqual(1, components.size());
            Assert.AreEqual(1, the_undirected_graph.getComponentCount());

            //try a graph that is not connected
            disconnectSmallGraph(the_undirected_graph);
            components = the_undirected_graph.getComponents();
            Assert.AreEqual(2, components.size());
            Assert.AreEqual(2, the_undirected_graph.getComponentCount());
            Assert.AreEqual(true, components.get(0).size() == 1 || components.get(1).size() == 1);

            List<DSString> one, two;
            if (components.get(0).size() == 1)
            {
                one = components.get(0);
                two = components.get(1);
            }
            else
            {
                two = components.get(0);
                one = components.get(1);
            }

            //make sure the single vertex graph contains "A"
            Assert.AreEqual("A", one.get(0).value);

            Assert.AreEqual(true, two.contains(new DSString("B")));
            Assert.AreEqual(true, two.contains(new DSString("C")));
            Assert.AreEqual(true, two.contains(new DSString("D")));
            Assert.AreEqual(true, two.contains(new DSString("E")));
            Assert.AreEqual(true, two.contains(new DSString("F")));
        }

        private void testGetComponentCount(DirectedGraph<DSString> the_directed_graph, UndirectedGraph<DSString> the_undirected_graph)
        {
            //tested in testGetComponents()
        }

        private void testDirectedUndirected(DirectedGraph<DSString> the_directed_graph, UndirectedGraph<DSString> the_undirected_graph)
        {
            //make sure edge count matchs between the two graphs
            Assert.AreEqual(the_directed_graph.edgeSize(), the_undirected_graph.edgeSize());

            //check for bi-directional only in the undirected
            Assert.IsTrue(checkEdgeForVertex(the_undirected_graph.getEdgesIncidentTo(new DSString("A")), new DSString("B")));
            Assert.IsTrue(checkEdgeForVertex(the_undirected_graph.getEdgesIncidentTo(new DSString("B")), new DSString("A")));
            Assert.IsTrue(checkEdgeForVertex(the_directed_graph.getEdgesIncidentTo(new DSString("A")), new DSString("B")));
            Assert.IsFalse(checkEdgeForVertex(the_directed_graph.getEdgesIncidentTo(new DSString("B")), new DSString("A")));
        }

        private void testDijkstras(DirectedGraph<DSString> the_graph)
        {
            //clear test values
            the_graph.clear();

            //add algorithm values
            addAlgorithmElementsToGraph(the_graph);

            //perform the calculation
            the_graph.dijkstras(new DSString("V2"));
            Assert.AreEqual(true, checkListElements(the_graph.getShortestPath(new DSString("V5")),
                new DSString("V2"), new DSString("V0"), new DSString("V3"), new DSString("V5")));
        }

        private void testGetShortestPath(DirectedGraph<DSString> the_graph)
        {
            //clear test values
            the_graph.clear();

            //add algorithm values
            addAlgorithmElementsToGraph(the_graph);

            //perform the calculation
            the_graph.unweighted(new DSString("V2"));

            //make sure the seven paths are correct
            Assert.AreEqual(true, checkListElements(the_graph.getShortestPath(new DSString("V0")), 
                new DSString("V2"), new DSString("V0")));
            Assert.AreEqual(true, checkListElements(the_graph.getShortestPath(new DSString("V1")), 
                new DSString("V2"), new DSString("V0"), new DSString("V1")));
            Assert.AreEqual(true, checkListElements(the_graph.getShortestPath(new DSString("V2")), 
                new DSString("V2")));
            Assert.AreEqual(true, checkListElements(the_graph.getShortestPath(new DSString("V3")), 
                new DSString("V2"), new DSString("V0"), new DSString("V3")));
            Assert.AreEqual(true, checkListElements(the_graph.getShortestPath(new DSString("V4")), 
                new DSString("V2"), new DSString("V0"), new DSString("V3"), new DSString("V4")) ||
                                  checkListElements(the_graph.getShortestPath(new DSString("V4")), 
                                  new DSString("V2"), new DSString("V0"), new DSString("V1"), 
                                  new DSString("V4")));
            Assert.AreEqual(true, checkListElements(the_graph.getShortestPath(new DSString("V5")), 
                new DSString("V2"), new DSString("V5")));
            Assert.AreEqual(true, checkListElements(the_graph.getShortestPath(new DSString("V6")), 
                new DSString("V2"), new DSString("V0"), new DSString("V3"), new DSString("V6")));
        }

        private void testGetShortestPathLength(DirectedGraph<DSString> the_graph)
        {
            //covered in testUnweighted()
        }

        private void testUnweighted(DirectedGraph<DSString> the_graph)
        {
            //clear test values
            the_graph.clear();

            //add algorithm values
            addAlgorithmElementsToGraph(the_graph);

            //perform the calculation
            the_graph.unweighted(new DSString("V2"));

            //assert that the paths are the right values
            Assert.AreEqual(1.0, the_graph.getShortestPathLength(new DSString("V0")));
            Assert.AreEqual(2.0, the_graph.getShortestPathLength(new DSString("V1")));
            Assert.AreEqual(0.0, the_graph.getShortestPathLength(new DSString("V2")));
            Assert.AreEqual(2.0, the_graph.getShortestPathLength(new DSString("V3")));
            Assert.AreEqual(3.0, the_graph.getShortestPathLength(new DSString("V4")));
            Assert.AreEqual(1.0, the_graph.getShortestPathLength(new DSString("V5")));
            Assert.AreEqual(3.0, the_graph.getShortestPathLength(new DSString("V6")));
        }

        private void testAddVertex(DirectedGraph<DSString> the_graph)
        {
            Assert.AreEqual(true, the_graph.containsVertex(new DSString("A")));
            Assert.AreEqual(true, the_graph.containsVertex(new DSString("B")));
            Assert.AreEqual(true, the_graph.containsVertex(new DSString("C")));
            Assert.AreEqual(true, the_graph.containsVertex(new DSString("D")));
            Assert.AreEqual(true, the_graph.containsVertex(new DSString("E")));
            Assert.AreEqual(true, the_graph.containsVertex(new DSString("F")));

            Assert.AreEqual(6, the_graph.vertexSize());
        }

        private void testAddEdge(DirectedGraph<DSString> the_graph)
        {
            Assert.AreEqual(true, the_graph.containsEdge(new DSString("A"), new DSString("B")));
            Assert.AreEqual(true, the_graph.containsEdge(new DSString("A"), new DSString("C")));
            Assert.AreEqual(true, the_graph.containsEdge(new DSString("A"), new DSString("D")));
            Assert.AreEqual(true, the_graph.containsEdge(new DSString("A"), new DSString("E")));
            Assert.AreEqual(true, the_graph.containsEdge(new DSString("A"), new DSString("F")));
            Assert.AreEqual(true, the_graph.containsEdge(new DSString("B"), new DSString("C")));
            Assert.AreEqual(true, the_graph.containsEdge(new DSString("B"), new DSString("D")));
            Assert.AreEqual(true, the_graph.containsEdge(new DSString("C"), new DSString("D")));
            Assert.AreEqual(true, the_graph.containsEdge(new DSString("D"), new DSString("E")));
            Assert.AreEqual(true, the_graph.containsEdge(new DSString("E"), new DSString("F")));

            Assert.AreEqual(10, the_graph.edgeSize());
        }

        private void testClear(DirectedGraph<DSString> the_graph)
        {
            the_graph.clear();
            Assert.AreEqual(0, the_graph.vertexSize());
            Assert.AreEqual(0, the_graph.edgeSize());
        }

        private void testVertexSize(DirectedGraph<DSString> the_graph)
        {
            Assert.AreEqual(6, the_graph.vertexSize());
            the_graph.removeVertex(new DSString("A"));
            Assert.AreEqual(5, the_graph.vertexSize());
            the_graph.clear();
            Assert.AreEqual(0, the_graph.vertexSize());
        }

        private void testEdgeSize(DirectedGraph<DSString> the_graph)
        {
            Assert.AreEqual(10, the_graph.edgeSize());
            the_graph.removeEdge(new DSString("A"), new DSString("B"));
            Assert.AreEqual(9, the_graph.edgeSize());
            the_graph.clear();
            Assert.AreEqual(0, the_graph.edgeSize());
        }

        private void testRemoveVertex(DirectedGraph<DSString> the_graph)
        {
            the_graph.removeVertex(new DSString("A"));
            the_graph.removeVertex(new DSString("B"));

            Assert.AreEqual(4, the_graph.vertexSize());
            Assert.AreEqual(false, the_graph.containsVertex(new DSString("A")));
            Assert.AreEqual(false, the_graph.containsVertex(new DSString("B")));

            Assert.AreEqual(false, the_graph.containsEdge(new DSString("A"), new DSString("B")));
            Assert.AreEqual(false, the_graph.containsEdge(new DSString("A"), new DSString("C")));
            Assert.AreEqual(false, the_graph.containsEdge(new DSString("A"), new DSString("D")));
            Assert.AreEqual(false, the_graph.containsEdge(new DSString("A"), new DSString("E")));
            Assert.AreEqual(false, the_graph.containsEdge(new DSString("A"), new DSString("F")));
            Assert.AreEqual(false, the_graph.containsEdge(new DSString("B"), new DSString("C")));
            Assert.AreEqual(false, the_graph.containsEdge(new DSString("B"), new DSString("D")));
        }

        private void testRemoveEdge(DirectedGraph<DSString> the_graph)
        {
            //remove edges common to one vertex
            the_graph.removeEdge(new DSString("A"), new DSString("B"));
            the_graph.removeEdge(new DSString("A"), new DSString("C"));
            the_graph.removeEdge(new DSString("A"), new DSString("D"));

            //make sure vertex count is the same, but edges have lowered correctly
            Assert.AreEqual(6, the_graph.vertexSize());
            Assert.AreEqual(7, the_graph.edgeSize());

            //make sure the edge list with vertex "A" has lowered
            Assert.AreEqual(2, the_graph.getEdgesIncidentTo(new DSString("A")).size());

            //ensure the correct edges remain incident to "A"
            Assert.AreEqual(true, the_graph.containsEdge(new DSString("A"), new DSString("E")));
            Assert.AreEqual(true, the_graph.containsEdge(new DSString("A"), new DSString("F")));
        }

        private void testContainsVertex(DirectedGraph<DSString> the_graph)
        {
            //check that the graph contains the correct vertices 
            Assert.AreEqual(true, the_graph.containsVertex(new DSString("A")));
            Assert.AreEqual(true, the_graph.containsVertex(new DSString("B")));

            //check that the graph does not report a vertex as being there that is not
            Assert.AreEqual(false, the_graph.containsVertex(new DSString("G")));
        }

        private void testContainsEdge(DirectedGraph<DSString> the_graph)
        {
            //check that the graph contains the correct edges 
            Assert.AreEqual(true, the_graph.containsEdge(new DSString("A"), new DSString("B")));
            Assert.AreEqual(true, the_graph.containsEdge(new DSString("B"), new DSString("C")));

            //check that the graph does not report a edge as being there that is not
            Assert.AreEqual(false, the_graph.containsEdge(new DSString("A"), new DSString("G")));
        }

        //------------------- HELPER METHODS -------------------

        private bool checkEdgeForVertex(List<SimpleEdge<DSString>> the_edge, DSString the_check)
        {
            //loop through simple edges
            for (int i = 0; i < the_edge.size(); i++)
            {
                if (the_edge.get(i).second_label.Equals(the_check))
                {
                    return true;
                }
            }
            
            //must find the element
            return false;
        }

        private void addLargeConnected(UndirectedGraph<DSString> the_graph)
        {
            the_graph.clear();

            for (int i = 0; i < 100; i++)
            {
                the_graph.addVertex(new DSString(i.ToString()));
            }

            //loop until connected
            while (!the_graph.isConnected())
            {
                int v_one = my_rand.Next(0, 100);
                int v_two = my_rand.Next(0, 100);

                the_graph.addEdge(new DSString(v_one.ToString()), new DSString(v_two.ToString()), 0.0);
            }
        }

        private void disconnectSmallGraph(DirectedGraph<DSString> the_graph)
        {
            the_graph.removeEdge(new DSString("A"), new DSString("B"));
            the_graph.removeEdge(new DSString("A"), new DSString("C"));
            the_graph.removeEdge(new DSString("A"), new DSString("D"));
            the_graph.removeEdge(new DSString("A"), new DSString("E"));
            the_graph.removeEdge(new DSString("A"), new DSString("F"));
        }

        private void addGraphSearchElements(DirectedGraph<DSString> the_graph)
        {
            the_graph.clearEdges();

            the_graph.addEdge(new DSString("A"), new DSString("C"), 1.0);
            the_graph.addEdge(new DSString("C"), new DSString("D"), 1.0);
            the_graph.addEdge(new DSString("B"), new DSString("D"), 1.0);
            the_graph.addEdge(new DSString("C"), new DSString("F"), 1.0);
            the_graph.addEdge(new DSString("F"), new DSString("B"), 1.0);
            the_graph.addEdge(new DSString("F"), new DSString("E"), 1.0);
            the_graph.addEdge(new DSString("E"), new DSString("A"), 1.0);
            the_graph.addEdge(new DSString("B"), new DSString("C"), 1.0);
        }

        private void dfsCheck(DirectedGraph<DSString> the_directed_graph, DirectedGraph<DSString> the_undirected_graph)
        {
            List<DSString> dfs_d = the_directed_graph.depthFirstSearch(new DSString("A"));
            List<DSString> dfs_ud = the_undirected_graph.depthFirstSearch(new DSString("A"));

            //make sure both searches match
            Assert.IsTrue(Helpers.checkEqualCollections<DSString>(dfs_d, dfs_ud));
        }

        private void bfsCheck(DirectedGraph<DSString> the_directed_graph, DirectedGraph<DSString> the_undirected_graph)
        {
            List<DSString> bfs_d = the_directed_graph.breadthFirstSearch(new DSString("A"));
            List<DSString> bfs_ud = the_undirected_graph.breadthFirstSearch(new DSString("A"));

            //make sure both searches match
            Assert.IsTrue(Helpers.checkEqualCollections<DSString>(bfs_d, bfs_ud));
        }

        private void addElementsToGraph(DirectedGraph<DSString> the_graph)
        {
            the_graph.addVertex(new DSString("A"));
            the_graph.addVertex(new DSString("B"));
            the_graph.addVertex(new DSString("C"));
            the_graph.addVertex(new DSString("D"));
            the_graph.addVertex(new DSString("E"));
            the_graph.addVertex(new DSString("F"));

            the_graph.addEdge(new DSString("A"), new DSString("B"), 0.1);
            the_graph.addEdge(new DSString("A"), new DSString("C"), 0.6);
            the_graph.addEdge(new DSString("A"), new DSString("D"), 1.3);
            the_graph.addEdge(new DSString("A"), new DSString("E"), 2.1);
            the_graph.addEdge(new DSString("A"), new DSString("F"), 0.5);
            the_graph.addEdge(new DSString("B"), new DSString("C"), 1.9);
            the_graph.addEdge(new DSString("B"), new DSString("D"), 3.3);
            the_graph.addEdge(new DSString("C"), new DSString("D"), 0.7);
            the_graph.addEdge(new DSString("D"), new DSString("E"), 7.3);
            the_graph.addEdge(new DSString("E"), new DSString("F"), 5.0);
        }

        private void addAlgorithmElementsToGraph(DirectedGraph<DSString> the_graph)
        {
            //add vertices
            the_graph.addVertex(new DSString("V0"));
            the_graph.addVertex(new DSString("V1"));
            the_graph.addVertex(new DSString("V2"));
            the_graph.addVertex(new DSString("V3"));
            the_graph.addVertex(new DSString("V4"));
            the_graph.addVertex(new DSString("V5"));
            the_graph.addVertex(new DSString("V6"));

            //add edges
            the_graph.addEdge(new DSString("V2"), new DSString("V0"), 600);
            the_graph.addEdge(new DSString("V0"), new DSString("V1"), 200);
            the_graph.addEdge(new DSString("V0"), new DSString("V3"), 100);
            the_graph.addEdge(new DSString("V3"), new DSString("V2"), 400);
            the_graph.addEdge(new DSString("V3"), new DSString("V5"), 700);
            the_graph.addEdge(new DSString("V2"), new DSString("V5"), 1900);
            the_graph.addEdge(new DSString("V3"), new DSString("V6"), 400);
            the_graph.addEdge(new DSString("V6"), new DSString("V5"), 300);
            the_graph.addEdge(new DSString("V3"), new DSString("V4"), 500);
            the_graph.addEdge(new DSString("V1"), new DSString("V3"), 200);
            the_graph.addEdge(new DSString("V1"), new DSString("V4"), 100);
            the_graph.addEdge(new DSString("V4"), new DSString("V6"), 400);
        }

        private bool checkListElements(List<DSString> the_list, params DSString[] the_args)
        {
            if (the_list == null || the_args == null ||
                the_list.size() != the_args.Length)
            {
                return false;
            }

            for (int i = 0; i < the_list.size(); i++)
            {
                if (!the_list.get(i).Equals(the_args[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private void sameSizeDifferentElements(List<DSString> the_one, List<DSString> the_two)
        {
            //make sure the number of items returned is the same
            Assert.AreEqual(the_one.size(), the_two.size());

            //make sure the search is not
            bool found = false;
            for (int i = 0; i < the_one.size(); i++)
            {
                if (!the_one.get(i).Equals(the_two.get(i)))
                {
                    found = true;
                }
            }
            Assert.IsTrue(found);

            //make sure all elements found cover all vertices possible
            Set<DSString> one = new HashSet<DSString>();
            Set<DSString> two = new HashSet<DSString>();
            for (int i = 0; i < the_one.size(); i++)
            {
                one.add(the_one.get(i));
                two.add(the_two.get(i));
            }

            Assert.AreEqual(one.size(), two.size());
        }
    }
}
