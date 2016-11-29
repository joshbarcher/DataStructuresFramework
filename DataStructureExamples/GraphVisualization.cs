using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataStructures.Interfaces;
using DataStructures.PrimitiveWrappers;
using DataStructures.Basic;
using DataStructures.Exceptions;

namespace DataStructureExamples
{
    /// <summary>
    /// Displays an application that allows the user to build random graphs and test
    /// graph operations on them. This application uses both the directed and undirected
    /// classes in the DataStructures assembly.
    /// </summary>
    public partial class GraphVisualization : Form
    {
        private const int VERTEX_SIZE = 16;
        private const int OUTER_EDGE = 32;
        private const double ONE_HUNDRED_PERCENT = 100.0;
        private const int MAX_EDGE_VALUE = 10000;

        //visual update constants
        private const int EVENT_UPDATE_THRESHOLD = 100;
        private const int MAXIMUM_EDGE_THRESHOLD = 50;

        //used to random pick edges
        private Random my_rand = new Random();

        //main data structures
        private DirectedGraph<DSInteger> my_d_graph;
        private UndirectedGraph<DSInteger> my_u_graph;
        private UndirectedGraph<DSInteger> my_mst;
        private Map<DSInteger, DrawnVertex> my_drawables;

        //last vertex highlighted
        private DSInteger my_last_highlighted;

        //state variables
        private bool my_reset_edge_costs = false;
        private bool my_generated = false;

        //drawing variables
        private int my_last_width;
        private int my_last_height;
        private Bitmap my_buffer;

        /// <summary>
        /// Sets up the application to be viewed by the user with default settings.
        /// </summary>
        public GraphVisualization()
        {
            InitializeComponent();

            my_last_width = pnlDraw.Width;
            my_last_height = pnlDraw.Height;
        }

        //----------------------- HELPER METHODS -------------------------

        //generates a random graph to display.
        private void generateGraph()
        {
            //flag not generated until done
            my_generated = false;

            //get graph to build
            DirectedGraph<DSInteger> new_graph;
            if (chkDirected.Checked)
            {
                new_graph = my_d_graph = new DirectedGraph_AL<DSInteger>();
                my_u_graph = null;

                btnKruskalsMST.Enabled = false;
            }
            else
            {
                new_graph = my_u_graph = new UndirectedGraph_AL<DSInteger>();
                my_d_graph = null;

                btnKruskalsMST.Enabled = true;
            }

            initializeGeneration();

            //add vertices
            for (int i = 0; i < hscrVertices.Value; i++)
            {
                new_graph.addVertex(new DSInteger(i));
            }

            //add edges
            addEdges(new_graph);

            cleanupGeneration();
        }

        //adds random edges to the graph.
        private void addEdges(DirectedGraph<DSInteger> the_graph)
        {
            //add random edges
            //percentage multiplied by LOAD_FACTOR multiplied by the number of vertices
            double percent = (hscrEdgeDensity.Value / ONE_HUNDRED_PERCENT);
            int max_edges = (int)(percent * (the_graph.vertexSize() * (the_graph.vertexSize() - 1) / 2));
            int connected_edges = the_graph.vertexSize() / 2 + the_graph.vertexSize() % 2;

            //show user the progress
            pbrProgress.Maximum = max_edges;
            pbrProgress.Value = 0;

            //set
            Set<DSInteger> not_added = new HashSet<DSInteger>(the_graph.vertexSize());
            Set<DSInteger> added = new HashSet<DSInteger>(the_graph.vertexSize());
            Iterator<DSInteger> it = the_graph.getVertices().iterator();
            while (it.hasNext())
            {
                not_added.add(it.next());
            }

            //loop until you have added all edges
            while (the_graph.edgeSize() < max_edges)
            {
                DSInteger first_vertex = new DSInteger(my_rand.Next(0, hscrVertices.Value));
                DSInteger second_vertex = new DSInteger(my_rand.Next(0, hscrVertices.Value));

                //check if the edge added is not a loop
                if (!first_vertex.Equals(second_vertex))
                {
                    double edge_cost = 0.0;
                    if (chkEdgeWeights.Checked)
                    {
                        edge_cost = my_rand.Next(0, MAX_EDGE_VALUE) / ONE_HUNDRED_PERCENT;
                    }

                    //make sure you are adding edges to unconnected vertices first
                    int degree_one = the_graph.degree(first_vertex);
                    int degree_two = the_graph.degree(second_vertex);
                    if (newEdgeCheck(the_graph, degree_one, degree_two, added) && 
                        !the_graph.containsEdge(first_vertex, second_vertex))
                    {
                        the_graph.addEdge(first_vertex, second_vertex, edge_cost);

                        //track changes
                        not_added.remove(first_vertex);
                        not_added.remove(second_vertex);
                        added.add(first_vertex);
                        added.add(second_vertex);

                        //show user progress
                        pbrProgress.Value += 1;

                        //update periodically or rapidly if near the end of edge generation
                        //this rapid update is due to the high cost of random selection with
                        //graphs whose edge count is near the complete graph Kn
                        if (pbrProgress.Value % EVENT_UPDATE_THRESHOLD == 0 ||
                            max_edges - the_graph.edgeSize() < MAXIMUM_EDGE_THRESHOLD)
                        {
                            Application.DoEvents();
                        }
                    }
                }
            }
        }

        //cleanup after generating the graph.
        private void cleanupGeneration()
        {
            //update graph information for the user
            updateGraphInformation();

            //visual
            generateVisual();

            //select the first vertex in the graph
            my_last_highlighted = new DSInteger(0);
            hscrChosenVertex.Value = 1;
            hscrChosenVertex_ValueChanged(hscrChosenVertex, new EventArgs());

            //make sure the right range of vertice indexes is selectable
            hscrChosenVertex.Maximum = hscrVertices.Value;

            //mark as done
            my_generated = true;

            //show the new graph
            pnlDraw.Refresh();
        }

        //initializes all variables for the graph generation.
        private void initializeGeneration()
        {
            //remove old structures and declare new ones
            my_mst = null;
            my_buffer = null;
            my_drawables = new HashMap<DSInteger, DrawnVertex>();

            //remove welcome
            if (lblInfo.Visible)
            {
                lblLogo.Visible = false;
                lblInfo.Visible = false;
            }
        }

        //update graph information labels.
        private void updateGraphInformation()
        {
            DirectedGraph<DSInteger> graph = getCurrentGraph();
            lblTotalEdges.Text = "Edge count: " + graph.edgeSize();
            lblConnected.Text = "Connected: " + (graph == my_u_graph ? my_u_graph.isConnected() : false);
            lblContainsCycle.Text = "Contains cycle: " + graph.containsCycle();
            lblComponents.Text = "# of components: " + (graph == my_u_graph ? my_u_graph.getComponentCount().ToString() : "NA");
        }

        //updates the algorithm label with time spent calculating.
        private void updateAlgorithm(string the_algorithm_name, double the_algorithm_seconds, double the_algorithm_ms)
        {
            if (the_algorithm_seconds != 0.0)
            {
                lblAlgorithmTime.Text = the_algorithm_name + ": " + the_algorithm_seconds.ToString("F4") + " secs";
            }
            else
            {
                lblAlgorithmTime.Text = the_algorithm_name + ": " + the_algorithm_ms.ToString("F4") + " msecs";
            }
        }

        //checks for whether a new edge is added to the graph if the "check connecting" option is chosen.
        private bool newEdgeCheck(DirectedGraph<DSInteger> the_new_graph, int the_degree_one, int the_degree_two, 
            Set<DSInteger> the_added)
        {
            if (!chkConnectingEdges.Checked) //don't perform the check if not wanted
            {
                return true;
            }
            else
            {
                //add an edge if the graph is reasonably connected (for undirected), or
                //if there is one vertex unconnected and it is part of the new edge or
                //if both edges are unconnected.
                return the_added.size() == the_new_graph.vertexSize() ||
                       (the_degree_one == 0 || the_degree_two == 0 && the_added.size() == the_new_graph.vertexSize() - 1) ||
                        (the_degree_one == 0 && the_degree_two == 0);
            }
        }

        //returns the directed or undirected graph depending on what was last generated.
        private DirectedGraph<DSInteger> getCurrentGraph()
        {
            if (my_d_graph == null)
            {
                return my_u_graph;
            }
            else
            {
                return my_d_graph;
            }
        }

        //changes all edge weights to 1.0 (for unweighted algorithm) or a random cost (for dikjstras).
        private void changeEdgeWeights(bool the_randomize)
        {
            //go through each vertex
            Iterator<DSInteger> it = my_drawables.keyset().iterator();
            while (it.hasNext())
            {
                //go through each edge adjacent to that vertex
                DirectedGraph<DSInteger> graph = getCurrentGraph();
                Iterator<SimpleEdge<DSInteger>> it_edge = graph.getEdgesIncidentTo(it.next()).iterator();
                while (it_edge.hasNext())
                {
                    //clear the edge weight
                    SimpleEdge<DSInteger> edge = it_edge.next();

                    //randomize the edge values for dijkstras
                    if (the_randomize)
                    {
                        graph.setEdgeCost(edge.first_label, edge.second_label, my_rand.Next(0, MAX_EDGE_VALUE) / ONE_HUNDRED_PERCENT);
                    }
                    else //set all edges to cost 1.0 for unweighted
                    {
                        graph.setEdgeCost(edge.first_label, edge.second_label, 1.0);
                    }
                }
            }
        }

        //updates all vertex headings after the shortest path algorithms are run.
        private void updateAfterShortestPath()
        {
            //go through each vertex
            DirectedGraph<DSInteger> graph = getCurrentGraph();
            Iterator<DrawnVertex> it = my_drawables.values().iterator();
            while (it.hasNext())
            {
                DrawnVertex dv = it.next();
                dv.draw_heading = true; //make them show their headings

                bool found = false;
                double total_edge_cost = 0.0;

                //make sure the source vertex is found
                if (dv.label.Equals(my_last_highlighted))
                {
                    found = true;
                }

                //get the shortest path
                Iterator<DSInteger> it_vertices = graph.getShortestPath(dv.label).iterator();
                if (it_vertices.hasNext())
                {
                    //add up the shortest path
                    DSInteger last = it_vertices.next();
                    while (it_vertices.hasNext())
                    {
                        found = true;
                        DSInteger next = it_vertices.next();
                        total_edge_cost += graph.getEdgeCost(last, next);
                        last = next;
                    }
                }

                //check for no shortest path
                if (!found)
                {
                    dv.heading = "Inf";
                }
                else
                {
                    dv.heading = total_edge_cost.ToString();
                }
            }

            //redraw the visual
            pnlDraw.Refresh();
        }

        //builds the vertex drawn elements after generating the graph.
        private void generateVisual()
        {
            //add vertices
            for (int i = 0; i < hscrVertices.Value; i++)
            {
                DSInteger vertex = new DSInteger(i);
                float x = my_rand.Next(VERTEX_SIZE, pnlDraw.Width - OUTER_EDGE);
                float y = my_rand.Next(VERTEX_SIZE, pnlDraw.Height - OUTER_EDGE);
                my_drawables.put(vertex, new DrawnVertex(x, y, vertex));
            }
        }

        //replaces the current graph with a scaled version of the same graph.
        private void replaceGraph(double the_width_ratio, double the_height_ratio)
        {
            //if there is something to draw
            if (my_generated)
            {
                //scale each vertex
                Iterator<DrawnVertex> it = my_drawables.values().iterator();
                while (it.hasNext())
                {
                    DrawnVertex dv = it.next();
                    dv.x = (float)(dv.x * the_width_ratio);
                    dv.y = (float)(dv.y * the_height_ratio);
                }
            }
        }

        //draws all edges on the window.
        private void drawEdges(DirectedGraph<DSInteger> the_graph, Graphics the_g, bool the_highlight)
        {
            //get all edges
            List<SimpleEdge<DSInteger>> edges = the_graph.getEdges();
            Iterator<SimpleEdge<DSInteger>> it = edges.iterator();
            while (it.hasNext())
            {
                //draw each edge
                SimpleEdge<DSInteger> edge = it.next();
                DrawnVertex dv = my_drawables.get(edge.first_label);

                //draw arrows or no arrows depending on the graph
                if (the_graph == my_d_graph)
                {
                    if (the_highlight)
                    {
                        dv.highlightDirectedEdgeTo(my_drawables.get(edge.second_label), edge.edge_cost, the_g);
                    }
                    else
                    {
                        dv.drawDirectedEdgeTo(my_drawables.get(edge.second_label), edge.edge_cost, the_g);
                    }
                }
                else
                {
                    if (the_highlight)
                    {
                        dv.highlightUndirectedEdgeTo(my_drawables.get(edge.second_label), edge.edge_cost, the_g);
                    }
                    else
                    {
                        dv.drawUndirectedEdgeTo(my_drawables.get(edge.second_label), edge.edge_cost, the_g);
                    }
                }
            }
        }

        //performs the unweighted algorithm on the current graph.
        private void unweighted()
        {
            if (my_generated)
            {
                long current = DateTime.Now.Ticks;

                //clear all edge weights if they are not zero
                changeEdgeWeights(false);
                my_reset_edge_costs = true;

                //performt the calculation
                getCurrentGraph().unweighted(my_last_highlighted);
                TimeSpan span = new TimeSpan(DateTime.Now.Ticks - current);
                updateAlgorithm("Unweighted", span.TotalSeconds, span.TotalMilliseconds);
                updateAfterShortestPath();

                //force a redraw
                my_buffer = null;
                pnlDraw.Invalidate();
            }
        }

        //performs dijkstras algorithm on the current graph.
        private void dijkstras()
        {
            if (my_generated)
            {
                long current = DateTime.Now.Ticks;

                //randomize all edge weights if they are not already random
                if (my_reset_edge_costs)
                {
                    changeEdgeWeights(true);
                    my_reset_edge_costs = false;
                }

                
                //perform the calculation
                getCurrentGraph().dijkstras(my_last_highlighted);
                TimeSpan span = new TimeSpan(DateTime.Now.Ticks - current);
                updateAlgorithm("Dijkstras", span.TotalSeconds, span.TotalMilliseconds);
                updateAfterShortestPath();

                //force a redraw
                my_buffer = null;
                pnlDraw.Invalidate();
            }
        }

        //performs kruskals algorithm on the current graph.
        private void kruskals()
        {
            try
            {
                long current = DateTime.Now.Ticks;

                my_mst = my_u_graph.kruskals();
                TimeSpan span = new TimeSpan(DateTime.Now.Ticks - current);
                updateAlgorithm("Kruskals", span.TotalSeconds, span.TotalMilliseconds);

                //force a redraw
                my_buffer = null;
                pnlDraw.Invalidate();

                //show the total cost for the user
                if (my_mst != null)
                {
                    double cost = 0.0;
                    Iterator<SimpleEdge<DSInteger>> it = my_mst.getEdges().iterator();
                    while (it.hasNext())
                    {
                        cost += it.next().edge_cost;
                    }
                    lblMSTCost.Text = "Minimum spanning tree cost: " + cost.ToString("F2");
                }
            }
            catch (IllegalStateException the_ex)
            {
                MessageBox.Show(the_ex.Message);
            }
        }

        //draws the generated graph to the window.
        private void pnlDraw_Paint(object sender, PaintEventArgs e)
        {
            //if some drawing objects are ready
            if (my_generated)
            {
                //redo the buffer if necessary
                if (my_buffer == null)
                {
                    my_buffer = new Bitmap(pnlDraw.Width, pnlDraw.Height);

                    DirectedGraph<DSInteger> graph = getCurrentGraph();
                    Graphics g = Graphics.FromImage(my_buffer);

                    //draw edges
                    drawEdges(graph, g, false);

                    //draw mst if present
                    if (my_mst != null)
                    {
                        drawEdges(my_mst, g, true);
                    }

                    //draw vertices
                    Iterator<DrawnVertex> it_dv = my_drawables.values().iterator();
                    while (it_dv.hasNext())
                    {
                        DrawnVertex dv = it_dv.next();
                        dv.draw(g);
                    }

                    //draw highlight
                    if (my_last_highlighted != null)
                    {
                        my_drawables.get(my_last_highlighted).highlight(g);
                    }
                }

                //draw from the buffer
                e.Graphics.DrawImage(my_buffer, new Rectangle(0, 0, pnlDraw.Width, pnlDraw.Height),
                    new Rectangle(0, 0, my_buffer.Width, my_buffer.Height), GraphicsUnit.Pixel);
            }
        } 

        //handles the resizing of the user window. this method dynamically redraws the generated graph if present.
        private void GraphVisualization_Resize(object sender, EventArgs e)
        {
            //only resize for a normal window size
            if (pnlDraw.Width != 0 && pnlDraw.Height != 0)
            {
                //resize the graph visual
                replaceGraph((pnlDraw.Width * 1.0) / my_last_width, (pnlDraw.Height * 1.0) / my_last_height);

                my_last_width = pnlDraw.Width;
                my_last_height = pnlDraw.Height;

                //invalidate the visual and redraw
                my_buffer = null;
            }
        }

        //performs the unweighted calculation on the current graph.
        private void btnUnweighted_Click(object sender, EventArgs e)
        {
            unweighted();
        }

        //performs dijkstra's calculation on the current graph.
        private void btnDijkstras_Click(object sender, EventArgs e)
        {
            //prepare a message for large operations on dense graphs
            lblMessage.Text = "Warning! This operation may take a substantial time to complete with large graphs.";
            pnlMessage.Visible = true;
            pnlMessage.Refresh();

            //perform the operation
            dijkstras();

            //remove the message
            pnlMessage.Visible = false;
        }

        //performs kruskal's calculation on the current graph.
        private void btnKruskalsMST_Click(object sender, EventArgs e)
        {
            kruskals();
        }

        //handles the value change of how many vertices to place in the graph.
        private void hscrVertices_ValueChanged(object sender, EventArgs e)
        {
            lblVertices.Text = hscrVertices.Value.ToString();
        }

        //handles the value change for edge density in the graph.
        private void hscrEdgeDensity_ValueChanged(object sender, EventArgs e)
        {
            lblEdges.Text = hscrEdgeDensity.Value.ToString() + "%";
        }

        //handles the value change for which vertex the user wants to use as source vertex for shortest
        //path problems.
        private void hscrChosenVertex_ValueChanged(object sender, EventArgs e)
        {
            int index = hscrChosenVertex.Value - 1;
            lblVertex.Text = index.ToString();

            if (my_last_highlighted != null)
            {
                //if some drawing objects are ready
                if (my_drawables != null)
                {
                    my_drawables.get(my_last_highlighted).draw(pnlDraw.CreateGraphics());
                }
            }

            my_last_highlighted = new DSInteger(index);

            //if some drawing objects are ready
            if (my_drawables != null)
            {
                my_drawables.get(my_last_highlighted).highlight(pnlDraw.CreateGraphics());
            }
        }

        //generates the random graph.
        private void btnGenerateGraph_Click(object sender, EventArgs e)
        {
            generateGraph();
        }

        /// <summary>
        /// Helper class that performs the brunt of the drawing work to show the graph on 
        /// the visualization window.
        /// </summary>
        private class DrawnVertex
        {
            //drawing constants
            private const int VERTEX_PADDING = 2;
            private const int VERTEX_CENTER = 8;
            private const float BACKDROP_HEIGHT = 14;
            private const float BACKDROP_WIDTH = 30;
            private const float LABEL_OFFSET = 10.0f;
            private const double ARROW_ANGLE = 30.0; //30 degrees
            private const int ARROW_LENGTH = 16;
            private const int HALF_VERTEX_SIZE = 8;

            private const double RIGHT_ANGLE = 90.0;
            private const double UPPER_ANGLE_OFFSET = 90.0;
            private const double LOWER_ANGLE_OFFSET = 270.0;

            //brushes and pens for different states
            private static Pen my_pen = new Pen(new SolidBrush(Color.Black));
            private static Pen my_heavy_pen = new Pen(new SolidBrush(Color.Black), 2.0f);
            private static Pen my_extra_heavy_pen = new Pen(new SolidBrush(Color.Black), 4.0f);
            private static Pen my_highlight_pen = new Pen(new SolidBrush(Color.White));
            private static Pen my_heavy_highlight_pen = new Pen(new SolidBrush(Color.White), 2.0f);
            private static Font my_font = new Font(new FontFamily("Times New Roman"), 10, FontStyle.Regular, GraphicsUnit.Pixel);
            private static SolidBrush my_fill_brush = new SolidBrush(Color.Black);
            private static SolidBrush my_highlight_brush = new SolidBrush(Color.Blue);
            private static SolidBrush my_text_brush = new SolidBrush(Color.White);
            private static SolidBrush my_edge_brush = new SolidBrush(Color.Gray);

            //main attributes
            private float my_x;
            private float my_y;
            private DSInteger my_label;
            private string my_heading;

            //state variable for showing or not showing the header information
            private bool my_draw_heading;

            /// <summary>
            /// Sets up the drawn vertex with a location and label.
            /// </summary>
            /// <param name="the_x">x coordinate of the vertex location.</param>
            /// <param name="the_y">y coordinate of the vertex location.</param>
            /// <param name="the_label">the label of the vertex.</param>
            public DrawnVertex(float the_x, float the_y, DSInteger the_label)
            {
                Preconditions.checkNull(the_label);
                //heading can begin as null

                x = the_x;
                y = the_y;
                label = the_label;
                draw_heading = false;
            }

            /// <summary>
            /// Draws an undirected edge.
            /// </summary>
            /// <param name="the_other">the other vertex that belongs to this edge.</param>
            /// <param name="the_edge_cost">the edge cost.</param>
            /// <param name="the_g">the graphics context to draw to.</param>
            public void drawUndirectedEdgeTo(DrawnVertex the_other, double the_edge_cost, Graphics the_g)
            {
                drawEdgeTo(the_other, the_edge_cost, the_g, my_pen, my_heavy_pen, false);
            }

            /// <summary>
            /// Draws an highlighted undirected edge.
            /// </summary>
            /// <param name="the_other">the other vertex that belongs to this edge.</param>
            /// <param name="the_edge_cost">the edge cost.</param>
            /// <param name="the_g">the graphics context to draw to.</param>
            public void highlightUndirectedEdgeTo(DrawnVertex the_other, double the_edge_cost, Graphics the_g)
            {
                drawEdgeTo(the_other, the_edge_cost, the_g, my_heavy_highlight_pen, my_extra_heavy_pen, false);
            }

            /// <summary>
            /// Draws an directed edge.
            /// </summary>
            /// <param name="the_other">the other vertex that belongs to this edge.</param>
            /// <param name="the_edge_cost">the edge cost.</param>
            /// <param name="the_g">the graphics context to draw to.</param>
            public void drawDirectedEdgeTo(DrawnVertex the_other, double the_edge_cost, Graphics the_g)
            {
                drawEdgeTo(the_other, the_edge_cost, the_g, my_pen, my_heavy_pen, true);
            }

            /// <summary>
            /// Draws an highlighted directed edge.
            /// </summary>
            /// <param name="the_other">the other vertex that belongs to this edge.</param>
            /// <param name="the_edge_cost">the edge cost.</param>
            /// <param name="the_g">the graphics context to draw to.</param>
            public void highlightDirectedEdgeTo(DrawnVertex the_other, double the_edge_cost, Graphics the_g)
            {
                drawEdgeTo(the_other, the_edge_cost, the_g, my_heavy_pen, my_extra_heavy_pen, true);
            }

            //draws an edge to an adjacent vertex given some drawing parameters.
            private void drawEdgeTo(DrawnVertex the_other, double the_edge_cost, 
                Graphics the_g, Pen the_edge_pen, Pen the_arrow_pen, bool the_draw_arrow)
            {
                //draw edge
                Point xy1_offset = getEdgeTarget(x, y, the_other.x, the_other.y);
                Point xy2_offset = getEdgeTarget(the_other.x, the_other.y, x, y);
                float x1 = x + xy2_offset.X;
                float y1 = y + xy2_offset.Y;
                float x2 = the_other.x + xy1_offset.X;
                float y2 = the_other.y + xy1_offset.Y;
                the_g.DrawLine(the_edge_pen, x1, y1, x2, y2);

                //draw weight
                float mid_x = (float)((x + the_other.x) / 2.0);
                float mid_y = (float)((y + the_other.y) / 2.0);

                //draw arrow
                if (the_draw_arrow)
                {
                    drawArrows(x1, y1, x2, y2, the_g, the_arrow_pen);
                }

                //backdrop
                the_g.FillRectangle(my_edge_brush, new RectangleF(mid_x,
                                                              mid_y - LABEL_OFFSET,
                                                              BACKDROP_WIDTH,
                                                              BACKDROP_HEIGHT));
                //edge cost
                the_g.DrawString(the_edge_cost.ToString("F2"), my_font, 
                    my_text_brush, new PointF(mid_x, mid_y - LABEL_OFFSET));
            }

            //draws the arrow head for the directed graph using some simple trigonometry.
            private void drawArrows(float the_x1, float the_y1, float the_x2, float the_y2, 
                Graphics the_g, Pen the_pen)
            {
                double delta_x = the_x2 - the_x1;
                double delta_y = -(the_y2 - the_y1);
                double hyp = Math.Sqrt(Math.Pow(delta_x, 2) + Math.Pow(delta_y, 2)); //pythagorean's theorem

                //sine law
                double adj_angle = Math.Abs(radiansToDegrees(Math.Asin(delta_x * Math.Sin(degreesToRadians(RIGHT_ANGLE)) / hyp)));

                double right_arrow_angle, left_arrow_angle;

                //reverse the y value to get the angles of the arrow rays because the window coordinates have opposite y-values
                getAngleOffset(out right_arrow_angle, out left_arrow_angle, delta_x, delta_y, adj_angle, ARROW_ANGLE);

                //draw both rays of the arrow head
                drawArrowRay(the_g, the_pen, right_arrow_angle, the_x2, the_y2);
                drawArrowRay(the_g, the_pen, left_arrow_angle, the_x2, the_y2);
            }

            //Forces an end of an edge to target an outside edge of a vertex.
            private Point getEdgeTarget(float the_x1, float the_y1, float the_x2, float the_y2)
            {
                Point return_value = new Point();

                if (the_x1 > the_x2) //aim for the right corners
                {
                    return_value.X = GraphVisualization.VERTEX_SIZE;
                    return_value.Y = GraphVisualization.VERTEX_SIZE / 2;
                }
                else if (the_y1 > the_y2) //aim for the bottom corners
                {
                    return_value.Y = GraphVisualization.VERTEX_SIZE;
                    return_value.X = GraphVisualization.VERTEX_SIZE / 2;
                }
                else
                {
                    //pick the closest side
                    //if the distance of x's is greater than y then aim for the sides
                    if (the_x2 - the_x1 > the_y2 - the_y1)
                    {
                        return_value.X = GraphVisualization.VERTEX_SIZE / 2;
                    }
                    else //aim for the top/bottom
                    {
                        return_value.Y = GraphVisualization.VERTEX_SIZE / 2;
                    }
                }

                return return_value;
            }

            //draws a single arrow ray from the end of the edge to the calculated end point of the ray.
            private void drawArrowRay(Graphics the_g, Pen the_pen, double the_ray_angle, double the_x_offset,
                double the_y_offset)
            {
                double x_arrow_ray = ARROW_LENGTH * Math.Cos(degreesToRadians(the_ray_angle));
                double y_arrow_ray = ARROW_LENGTH * -Math.Sin(degreesToRadians(the_ray_angle)); //reverse y values due to window coordinates
                double arrow_edge_x = the_x_offset + x_arrow_ray;
                double arrow_edge_y = the_y_offset + y_arrow_ray;

                the_g.DrawLine(the_pen, (float)the_x_offset, (float)the_y_offset, (float)arrow_edge_x, (float)arrow_edge_y);
                the_g.DrawLine(my_highlight_pen, (float)the_x_offset, (float)the_y_offset, (float)arrow_edge_x, (float)arrow_edge_y);
            }

            //calculates the angle of both arrow head rays.
            private void getAngleOffset(out double the_right_angle, out double the_left_angle, 
                double the_x, double the_y, double the_gamma, double the_beta)
            {
                //these offsets are used to calculate the angle of both rays of the arrow head
                if (the_x > 0 && the_y > 0)
                {
                    the_right_angle = LOWER_ANGLE_OFFSET - the_gamma + the_beta;
                    the_left_angle = LOWER_ANGLE_OFFSET - the_gamma - the_beta;
                }
                else if (the_x > 0)
                {
                    the_right_angle = UPPER_ANGLE_OFFSET + the_gamma + the_beta;
                    the_left_angle = UPPER_ANGLE_OFFSET + the_gamma - the_beta;
                }
                else if (the_y > 0)
                {
                    the_right_angle = LOWER_ANGLE_OFFSET + the_gamma + the_beta;
                    the_left_angle = LOWER_ANGLE_OFFSET + the_gamma - the_beta;
                }
                else
                {
                    the_right_angle = UPPER_ANGLE_OFFSET - the_gamma + the_beta;
                    the_left_angle = UPPER_ANGLE_OFFSET - the_gamma - the_beta;
                }
            }

            //simple helper function to turn radian values to degrees.
            private double radiansToDegrees(double the_radians)
            {
                return the_radians * (180 / Math.PI);
            }

            //simple helper function to turn degree values to radians.
            private double degreesToRadians(double the_degrees)
            {
                return the_degrees * (Math.PI / 180);
            }

            /// <summary>
            /// Highlights this vertex.
            /// </summary>
            /// <param name="the_g">the graphics device to highlight with.</param>
            public void highlight(Graphics the_g)
            {
                draw(the_g, my_highlight_brush);
            }

            /// <summary>
            /// Draws the vertex to a graphics context.
            /// </summary>
            /// <param name="the_g">the graphics context.</param>
            public void draw(Graphics the_g)
            {
                draw(the_g, my_fill_brush);
            }

            //draws the vertex using a brush and a graphics context.
            private void draw(Graphics the_g, Brush the_brush)
            {
                //draw vertex circle
                the_g.FillEllipse(the_brush, x, y, GraphVisualization.VERTEX_SIZE, GraphVisualization.VERTEX_SIZE);

                //draw label
                the_g.DrawString(label.ToString(), my_font, my_text_brush, new PointF(x + VERTEX_PADDING, y + VERTEX_PADDING));

                //draw heading
                if (draw_heading)
                {
                    //backdrop
                    the_g.FillRectangle(the_brush, new RectangleF(x + VERTEX_PADDING, 
                                                                  y - GraphVisualization.VERTEX_SIZE + VERTEX_PADDING,
                                                                  BACKDROP_WIDTH, 
                                                                  BACKDROP_HEIGHT));
                    //heading
                    the_g.DrawString(heading, my_font, my_text_brush, new PointF(x + VERTEX_PADDING, 
                                                                                 y - GraphVisualization.VERTEX_SIZE + VERTEX_PADDING));
                }
            }

            /// <summary>
            /// Provides a string representation of the vertex.
            /// </summary>
            /// <returns>a string representation.</returns>
            public override string ToString()
            {
                StringBuilder builder = new StringBuilder();

                //show label, location and heading
                builder.Append("Label: ");
                builder.Append(label.ToString());
                builder.Append(", x: ");
                builder.Append(x.ToString());
                builder.Append(", y: ");
                builder.Append(y.ToString());
                builder.Append(", Heading: ");
                builder.Append(heading);

                return builder.ToString();
            }

            /// <summary>
            /// Access to whether heading should be drawn.
            /// </summary>
            public bool draw_heading
            {
                get { return my_draw_heading; }
                set { my_draw_heading = value; }
            }

            /// <summary>
            /// Access to x coordinate of location.
            /// </summary>
            public float x
            {
                get { return my_x; }
                set { my_x = value; }
            }

            /// <summary>
            /// Access to y coordinate of location.
            /// </summary>
            public float y
            {
                get { return my_y; }
                set { my_y = value; }
            }

            /// <summary>
            /// Access to label.
            /// </summary>
            public DSInteger label
            {
                get { return my_label; }
                set { my_label = value; }
            }

            /// <summary>
            /// Access to heading.
            /// </summary>
            public string heading
            {
                get { return my_heading; }
                set { my_heading = value; }
            }
        }
    }
}
