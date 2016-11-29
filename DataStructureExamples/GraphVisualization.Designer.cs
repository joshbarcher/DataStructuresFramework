namespace DataStructureExamples
{
    partial class GraphVisualization
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphVisualization));
            this.pnlDraw = new System.Windows.Forms.Panel();
            this.pnlMessage = new System.Windows.Forms.Panel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.hscrVertices = new System.Windows.Forms.HScrollBar();
            this.hscrEdgeDensity = new System.Windows.Forms.HScrollBar();
            this.lblVertInfo = new System.Windows.Forms.Label();
            this.lblEdgeDensity = new System.Windows.Forms.Label();
            this.lblVertices = new System.Windows.Forms.Label();
            this.lblEdges = new System.Windows.Forms.Label();
            this.btnGenerateGraph = new System.Windows.Forms.Button();
            this.lblVertex = new System.Windows.Forms.Label();
            this.lblChooseVertex = new System.Windows.Forms.Label();
            this.hscrChosenVertex = new System.Windows.Forms.HScrollBar();
            this.pnlDivider = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUnweighted = new System.Windows.Forms.Button();
            this.btnDijkstras = new System.Windows.Forms.Button();
            this.btnKruskalsMST = new System.Windows.Forms.Button();
            this.chkEdgeWeights = new System.Windows.Forms.CheckBox();
            this.chkDirected = new System.Windows.Forms.CheckBox();
            this.chkConnectingEdges = new System.Windows.Forms.CheckBox();
            this.lblTotalEdges = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblConnected = new System.Windows.Forms.Label();
            this.lblContainsCycle = new System.Windows.Forms.Label();
            this.lblMSTCost = new System.Windows.Forms.Label();
            this.lblComponents = new System.Windows.Forms.Label();
            this.lblAlgorithmTime = new System.Windows.Forms.Label();
            this.pbrProgress = new System.Windows.Forms.ProgressBar();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.pnlDraw.SuspendLayout();
            this.pnlMessage.SuspendLayout();
            this.pnlControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDraw
            // 
            this.pnlDraw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDraw.BackColor = System.Drawing.Color.Transparent;
            this.pnlDraw.Controls.Add(this.pnlMessage);
            this.pnlDraw.Controls.Add(this.lblLogo);
            this.pnlDraw.Controls.Add(this.lblInfo);
            this.pnlDraw.Location = new System.Drawing.Point(233, 1);
            this.pnlDraw.Name = "pnlDraw";
            this.pnlDraw.Size = new System.Drawing.Size(663, 659);
            this.pnlDraw.TabIndex = 0;
            this.pnlDraw.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDraw_Paint);
            // 
            // pnlMessage
            // 
            this.pnlMessage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlMessage.BackgroundImage = global::DataStructureExamples.Properties.Resources.gradient;
            this.pnlMessage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlMessage.Controls.Add(this.lblMessage);
            this.pnlMessage.Controls.Add(this.panel4);
            this.pnlMessage.Controls.Add(this.panel3);
            this.pnlMessage.Controls.Add(this.panel5);
            this.pnlMessage.Controls.Add(this.panel6);
            this.pnlMessage.Location = new System.Drawing.Point(176, 267);
            this.pnlMessage.Name = "pnlMessage";
            this.pnlMessage.Size = new System.Drawing.Size(269, 108);
            this.pnlMessage.TabIndex = 19;
            this.pnlMessage.Visible = false;
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(19, 16);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(232, 73);
            this.lblMessage.TabIndex = 8;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Location = new System.Drawing.Point(13, 92);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(249, 10);
            this.panel4.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(13, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(249, 10);
            this.panel3.TabIndex = 6;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.Location = new System.Drawing.Point(5, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(8, 99);
            this.panel5.TabIndex = 5;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Black;
            this.panel6.Location = new System.Drawing.Point(257, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(8, 99);
            this.panel6.TabIndex = 4;
            // 
            // lblLogo
            // 
            this.lblLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLogo.BackColor = System.Drawing.Color.Transparent;
            this.lblLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogo.Location = new System.Drawing.Point(59, 52);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(560, 25);
            this.lblLogo.TabIndex = 17;
            this.lblLogo.Text = "Welcome to the graph visualization tool!";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(59, 77);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(560, 163);
            this.lblInfo.TabIndex = 18;
            this.lblInfo.Text = resources.GetString("lblInfo.Text");
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hscrVertices
            // 
            this.hscrVertices.LargeChange = 1;
            this.hscrVertices.Location = new System.Drawing.Point(7, 6);
            this.hscrVertices.Maximum = 50;
            this.hscrVertices.Minimum = 2;
            this.hscrVertices.Name = "hscrVertices";
            this.hscrVertices.Size = new System.Drawing.Size(221, 25);
            this.hscrVertices.TabIndex = 0;
            this.hscrVertices.Value = 2;
            this.hscrVertices.ValueChanged += new System.EventHandler(this.hscrVertices_ValueChanged);
            // 
            // hscrEdgeDensity
            // 
            this.hscrEdgeDensity.LargeChange = 1;
            this.hscrEdgeDensity.Location = new System.Drawing.Point(7, 64);
            this.hscrEdgeDensity.Minimum = 1;
            this.hscrEdgeDensity.Name = "hscrEdgeDensity";
            this.hscrEdgeDensity.Size = new System.Drawing.Size(221, 25);
            this.hscrEdgeDensity.TabIndex = 1;
            this.hscrEdgeDensity.Value = 1;
            this.hscrEdgeDensity.ValueChanged += new System.EventHandler(this.hscrEdgeDensity_ValueChanged);
            // 
            // lblVertInfo
            // 
            this.lblVertInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblVertInfo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVertInfo.Location = new System.Drawing.Point(3, 37);
            this.lblVertInfo.Name = "lblVertInfo";
            this.lblVertInfo.Size = new System.Drawing.Size(90, 23);
            this.lblVertInfo.TabIndex = 0;
            this.lblVertInfo.Text = "# of Vertices";
            // 
            // lblEdgeDensity
            // 
            this.lblEdgeDensity.BackColor = System.Drawing.Color.Transparent;
            this.lblEdgeDensity.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEdgeDensity.Location = new System.Drawing.Point(3, 98);
            this.lblEdgeDensity.Name = "lblEdgeDensity";
            this.lblEdgeDensity.Size = new System.Drawing.Size(90, 23);
            this.lblEdgeDensity.TabIndex = 2;
            this.lblEdgeDensity.Text = "Edge Density";
            // 
            // lblVertices
            // 
            this.lblVertices.BackColor = System.Drawing.Color.Transparent;
            this.lblVertices.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVertices.Location = new System.Drawing.Point(99, 37);
            this.lblVertices.Name = "lblVertices";
            this.lblVertices.Size = new System.Drawing.Size(86, 23);
            this.lblVertices.TabIndex = 3;
            this.lblVertices.Text = "2";
            // 
            // lblEdges
            // 
            this.lblEdges.BackColor = System.Drawing.Color.Transparent;
            this.lblEdges.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEdges.Location = new System.Drawing.Point(99, 98);
            this.lblEdges.Name = "lblEdges";
            this.lblEdges.Size = new System.Drawing.Size(86, 23);
            this.lblEdges.TabIndex = 4;
            this.lblEdges.Text = "1%";
            // 
            // btnGenerateGraph
            // 
            this.btnGenerateGraph.Location = new System.Drawing.Point(43, 196);
            this.btnGenerateGraph.Name = "btnGenerateGraph";
            this.btnGenerateGraph.Size = new System.Drawing.Size(139, 31);
            this.btnGenerateGraph.TabIndex = 0;
            this.btnGenerateGraph.Text = "Generate Graph";
            this.btnGenerateGraph.UseVisualStyleBackColor = true;
            this.btnGenerateGraph.Click += new System.EventHandler(this.btnGenerateGraph_Click);
            // 
            // lblVertex
            // 
            this.lblVertex.BackColor = System.Drawing.Color.Transparent;
            this.lblVertex.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVertex.Location = new System.Drawing.Point(108, 329);
            this.lblVertex.Name = "lblVertex";
            this.lblVertex.Size = new System.Drawing.Size(86, 23);
            this.lblVertex.TabIndex = 7;
            this.lblVertex.Text = "0";
            // 
            // lblChooseVertex
            // 
            this.lblChooseVertex.BackColor = System.Drawing.Color.Transparent;
            this.lblChooseVertex.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChooseVertex.Location = new System.Drawing.Point(0, 329);
            this.lblChooseVertex.Name = "lblChooseVertex";
            this.lblChooseVertex.Size = new System.Drawing.Size(102, 23);
            this.lblChooseVertex.TabIndex = 6;
            this.lblChooseVertex.Text = "Source vertex";
            // 
            // hscrChosenVertex
            // 
            this.hscrChosenVertex.LargeChange = 1;
            this.hscrChosenVertex.Location = new System.Drawing.Point(4, 298);
            this.hscrChosenVertex.Maximum = 2;
            this.hscrChosenVertex.Minimum = 1;
            this.hscrChosenVertex.Name = "hscrChosenVertex";
            this.hscrChosenVertex.Size = new System.Drawing.Size(224, 25);
            this.hscrChosenVertex.TabIndex = 5;
            this.hscrChosenVertex.Value = 1;
            this.hscrChosenVertex.ValueChanged += new System.EventHandler(this.hscrChosenVertex_ValueChanged);
            // 
            // pnlDivider
            // 
            this.pnlDivider.BackColor = System.Drawing.Color.Black;
            this.pnlDivider.Location = new System.Drawing.Point(4, 258);
            this.pnlDivider.Name = "pnlDivider";
            this.pnlDivider.Size = new System.Drawing.Size(224, 4);
            this.pnlDivider.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 265);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 23);
            this.label1.TabIndex = 8;
            this.label1.Text = "Algorithms";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnUnweighted
            // 
            this.btnUnweighted.Location = new System.Drawing.Point(43, 355);
            this.btnUnweighted.Name = "btnUnweighted";
            this.btnUnweighted.Size = new System.Drawing.Size(139, 31);
            this.btnUnweighted.TabIndex = 9;
            this.btnUnweighted.Text = "Unweighted Shortest Path";
            this.btnUnweighted.UseVisualStyleBackColor = true;
            this.btnUnweighted.Click += new System.EventHandler(this.btnUnweighted_Click);
            // 
            // btnDijkstras
            // 
            this.btnDijkstras.Location = new System.Drawing.Point(43, 392);
            this.btnDijkstras.Name = "btnDijkstras";
            this.btnDijkstras.Size = new System.Drawing.Size(139, 31);
            this.btnDijkstras.TabIndex = 10;
            this.btnDijkstras.Text = "Dijkstra\'s Shortest Path";
            this.btnDijkstras.UseVisualStyleBackColor = true;
            this.btnDijkstras.Click += new System.EventHandler(this.btnDijkstras_Click);
            // 
            // btnKruskalsMST
            // 
            this.btnKruskalsMST.Location = new System.Drawing.Point(43, 429);
            this.btnKruskalsMST.Name = "btnKruskalsMST";
            this.btnKruskalsMST.Size = new System.Drawing.Size(139, 36);
            this.btnKruskalsMST.TabIndex = 11;
            this.btnKruskalsMST.Text = "Kruskal\'s Minimum Spanning Tree";
            this.btnKruskalsMST.UseVisualStyleBackColor = true;
            this.btnKruskalsMST.Click += new System.EventHandler(this.btnKruskalsMST_Click);
            // 
            // chkEdgeWeights
            // 
            this.chkEdgeWeights.BackColor = System.Drawing.Color.Transparent;
            this.chkEdgeWeights.Checked = true;
            this.chkEdgeWeights.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEdgeWeights.Location = new System.Drawing.Point(7, 124);
            this.chkEdgeWeights.Name = "chkEdgeWeights";
            this.chkEdgeWeights.Size = new System.Drawing.Size(127, 18);
            this.chkEdgeWeights.TabIndex = 0;
            this.chkEdgeWeights.Text = "Assign Edge Weights";
            this.chkEdgeWeights.UseVisualStyleBackColor = false;
            // 
            // chkDirected
            // 
            this.chkDirected.BackColor = System.Drawing.Color.Transparent;
            this.chkDirected.Checked = true;
            this.chkDirected.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDirected.Location = new System.Drawing.Point(7, 148);
            this.chkDirected.Name = "chkDirected";
            this.chkDirected.Size = new System.Drawing.Size(127, 18);
            this.chkDirected.TabIndex = 12;
            this.chkDirected.Text = "Directed Edges";
            this.chkDirected.UseVisualStyleBackColor = false;
            // 
            // chkConnectingEdges
            // 
            this.chkConnectingEdges.BackColor = System.Drawing.Color.Transparent;
            this.chkConnectingEdges.Checked = true;
            this.chkConnectingEdges.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkConnectingEdges.Location = new System.Drawing.Point(6, 172);
            this.chkConnectingEdges.Name = "chkConnectingEdges";
            this.chkConnectingEdges.Size = new System.Drawing.Size(161, 18);
            this.chkConnectingEdges.TabIndex = 13;
            this.chkConnectingEdges.Text = "Add Connecting Edges First";
            this.chkConnectingEdges.UseVisualStyleBackColor = false;
            // 
            // lblTotalEdges
            // 
            this.lblTotalEdges.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalEdges.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalEdges.Location = new System.Drawing.Point(1, 478);
            this.lblTotalEdges.Name = "lblTotalEdges";
            this.lblTotalEdges.Size = new System.Drawing.Size(224, 22);
            this.lblTotalEdges.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(4, 471);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(224, 4);
            this.panel1.TabIndex = 1;
            // 
            // lblConnected
            // 
            this.lblConnected.BackColor = System.Drawing.Color.Transparent;
            this.lblConnected.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnected.Location = new System.Drawing.Point(1, 505);
            this.lblConnected.Name = "lblConnected";
            this.lblConnected.Size = new System.Drawing.Size(224, 22);
            this.lblConnected.TabIndex = 14;
            // 
            // lblContainsCycle
            // 
            this.lblContainsCycle.BackColor = System.Drawing.Color.Transparent;
            this.lblContainsCycle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContainsCycle.Location = new System.Drawing.Point(1, 559);
            this.lblContainsCycle.Name = "lblContainsCycle";
            this.lblContainsCycle.Size = new System.Drawing.Size(224, 22);
            this.lblContainsCycle.TabIndex = 1;
            // 
            // lblMSTCost
            // 
            this.lblMSTCost.BackColor = System.Drawing.Color.Transparent;
            this.lblMSTCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMSTCost.Location = new System.Drawing.Point(1, 613);
            this.lblMSTCost.Name = "lblMSTCost";
            this.lblMSTCost.Size = new System.Drawing.Size(224, 22);
            this.lblMSTCost.TabIndex = 15;
            // 
            // lblComponents
            // 
            this.lblComponents.BackColor = System.Drawing.Color.Transparent;
            this.lblComponents.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComponents.Location = new System.Drawing.Point(1, 532);
            this.lblComponents.Name = "lblComponents";
            this.lblComponents.Size = new System.Drawing.Size(224, 22);
            this.lblComponents.TabIndex = 1;
            // 
            // lblAlgorithmTime
            // 
            this.lblAlgorithmTime.BackColor = System.Drawing.Color.Transparent;
            this.lblAlgorithmTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlgorithmTime.Location = new System.Drawing.Point(1, 586);
            this.lblAlgorithmTime.Name = "lblAlgorithmTime";
            this.lblAlgorithmTime.Size = new System.Drawing.Size(224, 22);
            this.lblAlgorithmTime.TabIndex = 16;
            // 
            // pbrProgress
            // 
            this.pbrProgress.Location = new System.Drawing.Point(4, 230);
            this.pbrProgress.Name = "pbrProgress";
            this.pbrProgress.Size = new System.Drawing.Size(221, 22);
            this.pbrProgress.TabIndex = 19;
            // 
            // pnlControls
            // 
            this.pnlControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlControls.BackColor = System.Drawing.Color.Transparent;
            this.pnlControls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlControls.Controls.Add(this.pbrProgress);
            this.pnlControls.Controls.Add(this.pnlDivider);
            this.pnlControls.Controls.Add(this.hscrVertices);
            this.pnlControls.Controls.Add(this.lblAlgorithmTime);
            this.pnlControls.Controls.Add(this.hscrEdgeDensity);
            this.pnlControls.Controls.Add(this.lblComponents);
            this.pnlControls.Controls.Add(this.lblVertInfo);
            this.pnlControls.Controls.Add(this.lblMSTCost);
            this.pnlControls.Controls.Add(this.lblEdgeDensity);
            this.pnlControls.Controls.Add(this.lblContainsCycle);
            this.pnlControls.Controls.Add(this.lblVertices);
            this.pnlControls.Controls.Add(this.lblConnected);
            this.pnlControls.Controls.Add(this.lblEdges);
            this.pnlControls.Controls.Add(this.panel1);
            this.pnlControls.Controls.Add(this.btnGenerateGraph);
            this.pnlControls.Controls.Add(this.lblTotalEdges);
            this.pnlControls.Controls.Add(this.hscrChosenVertex);
            this.pnlControls.Controls.Add(this.chkConnectingEdges);
            this.pnlControls.Controls.Add(this.lblChooseVertex);
            this.pnlControls.Controls.Add(this.chkDirected);
            this.pnlControls.Controls.Add(this.lblVertex);
            this.pnlControls.Controls.Add(this.chkEdgeWeights);
            this.pnlControls.Controls.Add(this.label1);
            this.pnlControls.Controls.Add(this.btnKruskalsMST);
            this.pnlControls.Controls.Add(this.btnUnweighted);
            this.pnlControls.Controls.Add(this.btnDijkstras);
            this.pnlControls.Location = new System.Drawing.Point(2, 3);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(234, 654);
            this.pnlControls.TabIndex = 20;
            // 
            // GraphVisualization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DataStructureExamples.Properties.Resources.gradient;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(898, 661);
            this.Controls.Add(this.pnlControls);
            this.Controls.Add(this.pnlDraw);
            this.Name = "GraphVisualization";
            this.ShowIcon = false;
            this.Text = "Graph Visualization [Author: Josh Archer]";
            this.Resize += new System.EventHandler(this.GraphVisualization_Resize);
            this.pnlDraw.ResumeLayout(false);
            this.pnlMessage.ResumeLayout(false);
            this.pnlControls.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDraw;
        private System.Windows.Forms.HScrollBar hscrVertices;
        private System.Windows.Forms.HScrollBar hscrEdgeDensity;
        private System.Windows.Forms.Label lblVertInfo;
        private System.Windows.Forms.Label lblEdgeDensity;
        private System.Windows.Forms.Label lblVertices;
        private System.Windows.Forms.Label lblEdges;
        private System.Windows.Forms.Button btnGenerateGraph;
        private System.Windows.Forms.Label lblVertex;
        private System.Windows.Forms.Label lblChooseVertex;
        private System.Windows.Forms.HScrollBar hscrChosenVertex;
        private System.Windows.Forms.Panel pnlDivider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUnweighted;
        private System.Windows.Forms.Button btnDijkstras;
        private System.Windows.Forms.Button btnKruskalsMST;
        private System.Windows.Forms.CheckBox chkEdgeWeights;
        private System.Windows.Forms.CheckBox chkDirected;
        private System.Windows.Forms.CheckBox chkConnectingEdges;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTotalEdges;
        private System.Windows.Forms.Label lblConnected;
        private System.Windows.Forms.Label lblContainsCycle;
        private System.Windows.Forms.Label lblMSTCost;
        private System.Windows.Forms.Label lblComponents;
        private System.Windows.Forms.Label lblAlgorithmTime;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.ProgressBar pbrProgress;
        private System.Windows.Forms.Panel pnlMessage;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel pnlControls;
    }
}