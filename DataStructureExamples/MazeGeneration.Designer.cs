namespace DataStructureExamples
{
    partial class MazeGeneration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MazeGeneration));
            this.pnlDraw = new System.Windows.Forms.Panel();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblFinish = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.cmbSize = new System.Windows.Forms.ComboBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.btnShowSolution = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnFindSolution = new System.Windows.Forms.Button();
            this.pbrProgress = new System.Windows.Forms.ProgressBar();
            this.lblCells = new System.Windows.Forms.Label();
            this.lblWalls = new System.Windows.Forms.Label();
            this.lblSolutionPathLength = new System.Windows.Forms.Label();
            this.lblTimeToGenerateMaze = new System.Windows.Forms.Label();
            this.lblTimeToSolveMaze = new System.Windows.Forms.Label();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.pnlDraw.SuspendLayout();
            this.pnlControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDraw
            // 
            this.pnlDraw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDraw.BackColor = System.Drawing.Color.Transparent;
            this.pnlDraw.Controls.Add(this.lblStart);
            this.pnlDraw.Controls.Add(this.lblFinish);
            this.pnlDraw.Location = new System.Drawing.Point(2, 1);
            this.pnlDraw.Name = "pnlDraw";
            this.pnlDraw.Size = new System.Drawing.Size(865, 621);
            this.pnlDraw.TabIndex = 0;
            this.pnlDraw.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDraw_Paint);
            // 
            // lblStart
            // 
            this.lblStart.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStart.ForeColor = System.Drawing.Color.Blue;
            this.lblStart.Location = new System.Drawing.Point(3, 17);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(20, 27);
            this.lblStart.TabIndex = 1;
            this.lblStart.Text = "S";
            this.lblStart.Visible = false;
            // 
            // lblFinish
            // 
            this.lblFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFinish.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinish.ForeColor = System.Drawing.Color.Blue;
            this.lblFinish.Location = new System.Drawing.Point(845, 584);
            this.lblFinish.Name = "lblFinish";
            this.lblFinish.Size = new System.Drawing.Size(20, 27);
            this.lblFinish.TabIndex = 0;
            this.lblFinish.Text = "F";
            this.lblFinish.Visible = false;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGenerate.Location = new System.Drawing.Point(4, 34);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(127, 25);
            this.btnGenerate.TabIndex = 1;
            this.btnGenerate.Text = "Generate maze";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // cmbSize
            // 
            this.cmbSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSize.FormattingEnabled = true;
            this.cmbSize.Items.AddRange(new object[] {
            "8 x 8",
            "16 x 16",
            "32 x 32",
            "48 x 48",
            "64 x 64",
            "96 x 96",
            "128 x 128",
            "160 x 160",
            "192 x 192",
            "224 x 224",
            "256 x 256"});
            this.cmbSize.Location = new System.Drawing.Point(41, 7);
            this.cmbSize.Name = "cmbSize";
            this.cmbSize.Size = new System.Drawing.Size(90, 21);
            this.cmbSize.TabIndex = 2;
            // 
            // lblSize
            // 
            this.lblSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSize.AutoSize = true;
            this.lblSize.BackColor = System.Drawing.Color.Transparent;
            this.lblSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize.Location = new System.Drawing.Point(4, 8);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(34, 16);
            this.lblSize.TabIndex = 4;
            this.lblSize.Text = "Size";
            // 
            // btnShowSolution
            // 
            this.btnShowSolution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnShowSolution.Location = new System.Drawing.Point(4, 96);
            this.btnShowSolution.Name = "btnShowSolution";
            this.btnShowSolution.Size = new System.Drawing.Size(127, 25);
            this.btnShowSolution.TabIndex = 6;
            this.btnShowSolution.Text = "Show solution";
            this.btnShowSolution.UseVisualStyleBackColor = true;
            this.btnShowSolution.Click += new System.EventHandler(this.btnShowSolution_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(300, 27);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(556, 120);
            this.lblInfo.TabIndex = 7;
            this.lblInfo.Text = resources.GetString("lblInfo.Text");
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(467, 4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(246, 23);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Welcome to maze generation";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFindSolution
            // 
            this.btnFindSolution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFindSolution.Location = new System.Drawing.Point(4, 65);
            this.btnFindSolution.Name = "btnFindSolution";
            this.btnFindSolution.Size = new System.Drawing.Size(127, 25);
            this.btnFindSolution.TabIndex = 9;
            this.btnFindSolution.Text = "Try to solve the Maze!";
            this.btnFindSolution.UseVisualStyleBackColor = true;
            this.btnFindSolution.Click += new System.EventHandler(this.btnTryIt_Click);
            // 
            // pbrProgress
            // 
            this.pbrProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbrProgress.Location = new System.Drawing.Point(4, 127);
            this.pbrProgress.Name = "pbrProgress";
            this.pbrProgress.Size = new System.Drawing.Size(127, 20);
            this.pbrProgress.TabIndex = 10;
            // 
            // lblCells
            // 
            this.lblCells.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCells.BackColor = System.Drawing.Color.Transparent;
            this.lblCells.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCells.Location = new System.Drawing.Point(137, 18);
            this.lblCells.Name = "lblCells";
            this.lblCells.Size = new System.Drawing.Size(157, 22);
            this.lblCells.TabIndex = 11;
            this.lblCells.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWalls
            // 
            this.lblWalls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblWalls.BackColor = System.Drawing.Color.Transparent;
            this.lblWalls.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWalls.Location = new System.Drawing.Point(137, 44);
            this.lblWalls.Name = "lblWalls";
            this.lblWalls.Size = new System.Drawing.Size(157, 22);
            this.lblWalls.TabIndex = 12;
            this.lblWalls.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSolutionPathLength
            // 
            this.lblSolutionPathLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSolutionPathLength.BackColor = System.Drawing.Color.Transparent;
            this.lblSolutionPathLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSolutionPathLength.Location = new System.Drawing.Point(137, 122);
            this.lblSolutionPathLength.Name = "lblSolutionPathLength";
            this.lblSolutionPathLength.Size = new System.Drawing.Size(157, 22);
            this.lblSolutionPathLength.TabIndex = 13;
            this.lblSolutionPathLength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTimeToGenerateMaze
            // 
            this.lblTimeToGenerateMaze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTimeToGenerateMaze.BackColor = System.Drawing.Color.Transparent;
            this.lblTimeToGenerateMaze.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeToGenerateMaze.Location = new System.Drawing.Point(137, 70);
            this.lblTimeToGenerateMaze.Name = "lblTimeToGenerateMaze";
            this.lblTimeToGenerateMaze.Size = new System.Drawing.Size(157, 22);
            this.lblTimeToGenerateMaze.TabIndex = 14;
            this.lblTimeToGenerateMaze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTimeToSolveMaze
            // 
            this.lblTimeToSolveMaze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTimeToSolveMaze.BackColor = System.Drawing.Color.Transparent;
            this.lblTimeToSolveMaze.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeToSolveMaze.Location = new System.Drawing.Point(137, 96);
            this.lblTimeToSolveMaze.Name = "lblTimeToSolveMaze";
            this.lblTimeToSolveMaze.Size = new System.Drawing.Size(157, 22);
            this.lblTimeToSolveMaze.TabIndex = 15;
            this.lblTimeToSolveMaze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlControls
            // 
            this.pnlControls.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pnlControls.BackColor = System.Drawing.Color.Transparent;
            this.pnlControls.Controls.Add(this.lblTimeToSolveMaze);
            this.pnlControls.Controls.Add(this.lblTimeToGenerateMaze);
            this.pnlControls.Controls.Add(this.lblInfo);
            this.pnlControls.Controls.Add(this.lblSolutionPathLength);
            this.pnlControls.Controls.Add(this.lblTitle);
            this.pnlControls.Controls.Add(this.lblWalls);
            this.pnlControls.Controls.Add(this.cmbSize);
            this.pnlControls.Controls.Add(this.lblCells);
            this.pnlControls.Controls.Add(this.btnGenerate);
            this.pnlControls.Controls.Add(this.btnShowSolution);
            this.pnlControls.Controls.Add(this.lblSize);
            this.pnlControls.Controls.Add(this.pbrProgress);
            this.pnlControls.Controls.Add(this.btnFindSolution);
            this.pnlControls.Location = new System.Drawing.Point(2, 617);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(865, 163);
            this.pnlControls.TabIndex = 2;
            // 
            // MazeGeneration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DataStructureExamples.Properties.Resources.gradient;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(870, 776);
            this.Controls.Add(this.pnlControls);
            this.Controls.Add(this.pnlDraw);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "MazeGeneration";
            this.ShowIcon = false;
            this.Text = "Maze Generation  [Author: Josh Archer]";
            this.SizeChanged += new System.EventHandler(this.MazeGeneration_SizeChanged);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MazeGeneration_KeyPress);
            this.pnlDraw.ResumeLayout(false);
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDraw;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.ComboBox cmbSize;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Button btnShowSolution;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblFinish;
        private System.Windows.Forms.Button btnFindSolution;
        private System.Windows.Forms.ProgressBar pbrProgress;
        private System.Windows.Forms.Label lblCells;
        private System.Windows.Forms.Label lblWalls;
        private System.Windows.Forms.Label lblSolutionPathLength;
        private System.Windows.Forms.Label lblTimeToGenerateMaze;
        private System.Windows.Forms.Label lblTimeToSolveMaze;
        private System.Windows.Forms.Panel pnlControls;
    }
}