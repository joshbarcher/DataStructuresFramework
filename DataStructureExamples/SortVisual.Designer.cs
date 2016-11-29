namespace DataStructureExamples
{
    partial class SortVisual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SortVisual));
            this.pnlUserControls = new System.Windows.Forms.Panel();
            this.lblInputInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLogo = new System.Windows.Forms.Label();
            this.lblSortingAlgorithm = new System.Windows.Forms.Label();
            this.rdbQuickSort = new System.Windows.Forms.RadioButton();
            this.rdbHeapSort = new System.Windows.Forms.RadioButton();
            this.rdbMergeSort = new System.Windows.Forms.RadioButton();
            this.rdbShellSort = new System.Windows.Forms.RadioButton();
            this.rdbInsertionSort = new System.Windows.Forms.RadioButton();
            this.rdbSelectionSort = new System.Windows.Forms.RadioButton();
            this.rdbBubbleSort = new System.Windows.Forms.RadioButton();
            this.btnStartVisual = new System.Windows.Forms.Button();
            this.txtInputSize = new System.Windows.Forms.TextBox();
            this.lblInputSize = new System.Windows.Forms.Label();
            this.pnlDraw = new System.Windows.Forms.Panel();
            this.pnlUserControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlUserControls
            // 
            this.pnlUserControls.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pnlUserControls.BackColor = System.Drawing.Color.Transparent;
            this.pnlUserControls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUserControls.Controls.Add(this.lblInputInfo);
            this.pnlUserControls.Controls.Add(this.label1);
            this.pnlUserControls.Controls.Add(this.lblLogo);
            this.pnlUserControls.Controls.Add(this.lblSortingAlgorithm);
            this.pnlUserControls.Controls.Add(this.rdbQuickSort);
            this.pnlUserControls.Controls.Add(this.rdbHeapSort);
            this.pnlUserControls.Controls.Add(this.rdbMergeSort);
            this.pnlUserControls.Controls.Add(this.rdbShellSort);
            this.pnlUserControls.Controls.Add(this.rdbInsertionSort);
            this.pnlUserControls.Controls.Add(this.rdbSelectionSort);
            this.pnlUserControls.Controls.Add(this.rdbBubbleSort);
            this.pnlUserControls.Controls.Add(this.btnStartVisual);
            this.pnlUserControls.Controls.Add(this.txtInputSize);
            this.pnlUserControls.Controls.Add(this.lblInputSize);
            this.pnlUserControls.Location = new System.Drawing.Point(4, 456);
            this.pnlUserControls.Name = "pnlUserControls";
            this.pnlUserControls.Size = new System.Drawing.Size(738, 133);
            this.pnlUserControls.TabIndex = 0;
            // 
            // lblInputInfo
            // 
            this.lblInputInfo.Location = new System.Drawing.Point(80, 30);
            this.lblInputInfo.Name = "lblInputInfo";
            this.lblInputInfo.Size = new System.Drawing.Size(65, 16);
            this.lblInputInfo.TabIndex = 14;
            this.lblInputInfo.Text = "(50 - 5000)";
            this.lblInputInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(323, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(414, 88);
            this.label1.TabIndex = 13;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLogo
            // 
            this.lblLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogo.Location = new System.Drawing.Point(384, 4);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(285, 22);
            this.lblLogo.TabIndex = 12;
            this.lblLogo.Text = "Welcome to the sorting visualization!";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSortingAlgorithm
            // 
            this.lblSortingAlgorithm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSortingAlgorithm.Location = new System.Drawing.Point(151, 4);
            this.lblSortingAlgorithm.Name = "lblSortingAlgorithm";
            this.lblSortingAlgorithm.Size = new System.Drawing.Size(139, 22);
            this.lblSortingAlgorithm.TabIndex = 11;
            this.lblSortingAlgorithm.Text = "Sorting algorithm";
            // 
            // rdbQuickSort
            // 
            this.rdbQuickSort.AutoSize = true;
            this.rdbQuickSort.Location = new System.Drawing.Point(248, 52);
            this.rdbQuickSort.Name = "rdbQuickSort";
            this.rdbQuickSort.Size = new System.Drawing.Size(75, 17);
            this.rdbQuickSort.TabIndex = 10;
            this.rdbQuickSort.TabStop = true;
            this.rdbQuickSort.Text = "Quick Sort";
            this.rdbQuickSort.UseVisualStyleBackColor = true;
            // 
            // rdbHeapSort
            // 
            this.rdbHeapSort.AutoSize = true;
            this.rdbHeapSort.Location = new System.Drawing.Point(248, 76);
            this.rdbHeapSort.Name = "rdbHeapSort";
            this.rdbHeapSort.Size = new System.Drawing.Size(73, 17);
            this.rdbHeapSort.TabIndex = 9;
            this.rdbHeapSort.TabStop = true;
            this.rdbHeapSort.Text = "Heap Sort";
            this.rdbHeapSort.UseVisualStyleBackColor = true;
            // 
            // rdbMergeSort
            // 
            this.rdbMergeSort.AutoSize = true;
            this.rdbMergeSort.Location = new System.Drawing.Point(248, 29);
            this.rdbMergeSort.Name = "rdbMergeSort";
            this.rdbMergeSort.Size = new System.Drawing.Size(77, 17);
            this.rdbMergeSort.TabIndex = 7;
            this.rdbMergeSort.TabStop = true;
            this.rdbMergeSort.Text = "Merge Sort";
            this.rdbMergeSort.UseVisualStyleBackColor = true;
            // 
            // rdbShellSort
            // 
            this.rdbShellSort.AutoSize = true;
            this.rdbShellSort.Location = new System.Drawing.Point(151, 98);
            this.rdbShellSort.Name = "rdbShellSort";
            this.rdbShellSort.Size = new System.Drawing.Size(70, 17);
            this.rdbShellSort.TabIndex = 6;
            this.rdbShellSort.TabStop = true;
            this.rdbShellSort.Text = "Shell Sort";
            this.rdbShellSort.UseVisualStyleBackColor = true;
            // 
            // rdbInsertionSort
            // 
            this.rdbInsertionSort.AutoSize = true;
            this.rdbInsertionSort.Location = new System.Drawing.Point(151, 75);
            this.rdbInsertionSort.Name = "rdbInsertionSort";
            this.rdbInsertionSort.Size = new System.Drawing.Size(87, 17);
            this.rdbInsertionSort.TabIndex = 5;
            this.rdbInsertionSort.TabStop = true;
            this.rdbInsertionSort.Text = "Insertion Sort";
            this.rdbInsertionSort.UseVisualStyleBackColor = true;
            // 
            // rdbSelectionSort
            // 
            this.rdbSelectionSort.AutoSize = true;
            this.rdbSelectionSort.Location = new System.Drawing.Point(151, 52);
            this.rdbSelectionSort.Name = "rdbSelectionSort";
            this.rdbSelectionSort.Size = new System.Drawing.Size(91, 17);
            this.rdbSelectionSort.TabIndex = 4;
            this.rdbSelectionSort.TabStop = true;
            this.rdbSelectionSort.Text = "Selection Sort";
            this.rdbSelectionSort.UseVisualStyleBackColor = true;
            // 
            // rdbBubbleSort
            // 
            this.rdbBubbleSort.AutoSize = true;
            this.rdbBubbleSort.Checked = true;
            this.rdbBubbleSort.Location = new System.Drawing.Point(151, 29);
            this.rdbBubbleSort.Name = "rdbBubbleSort";
            this.rdbBubbleSort.Size = new System.Drawing.Size(80, 17);
            this.rdbBubbleSort.TabIndex = 3;
            this.rdbBubbleSort.TabStop = true;
            this.rdbBubbleSort.Text = "Bubble Sort";
            this.rdbBubbleSort.UseVisualStyleBackColor = true;
            // 
            // btnStartVisual
            // 
            this.btnStartVisual.Location = new System.Drawing.Point(7, 55);
            this.btnStartVisual.Name = "btnStartVisual";
            this.btnStartVisual.Size = new System.Drawing.Size(138, 22);
            this.btnStartVisual.TabIndex = 2;
            this.btnStartVisual.Text = "Start the sort";
            this.btnStartVisual.UseVisualStyleBackColor = true;
            this.btnStartVisual.Click += new System.EventHandler(this.btnStartVisual_Click);
            // 
            // txtInputSize
            // 
            this.txtInputSize.Location = new System.Drawing.Point(7, 29);
            this.txtInputSize.Name = "txtInputSize";
            this.txtInputSize.Size = new System.Drawing.Size(71, 20);
            this.txtInputSize.TabIndex = 1;
            this.txtInputSize.Text = "100";
            // 
            // lblInputSize
            // 
            this.lblInputSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInputSize.Location = new System.Drawing.Point(7, 4);
            this.lblInputSize.Name = "lblInputSize";
            this.lblInputSize.Size = new System.Drawing.Size(111, 22);
            this.lblInputSize.TabIndex = 0;
            this.lblInputSize.Text = "Input size";
            // 
            // pnlDraw
            // 
            this.pnlDraw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDraw.BackColor = System.Drawing.Color.Transparent;
            this.pnlDraw.Location = new System.Drawing.Point(4, 3);
            this.pnlDraw.Name = "pnlDraw";
            this.pnlDraw.Size = new System.Drawing.Size(738, 447);
            this.pnlDraw.TabIndex = 1;
            // 
            // SortVisual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DataStructureExamples.Properties.Resources.gradient;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(745, 590);
            this.Controls.Add(this.pnlDraw);
            this.Controls.Add(this.pnlUserControls);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SortVisual";
            this.ShowIcon = false;
            this.Text = "Sorting Visualization [Author: Josh Archer]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SortVisual_FormClosing);
            this.Resize += new System.EventHandler(this.SortingRace_Resize);
            this.pnlUserControls.ResumeLayout(false);
            this.pnlUserControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlUserControls;
        private System.Windows.Forms.TextBox txtInputSize;
        private System.Windows.Forms.Label lblInputSize;
        private System.Windows.Forms.RadioButton rdbMergeSort;
        private System.Windows.Forms.RadioButton rdbShellSort;
        private System.Windows.Forms.RadioButton rdbInsertionSort;
        private System.Windows.Forms.RadioButton rdbSelectionSort;
        private System.Windows.Forms.RadioButton rdbBubbleSort;
        private System.Windows.Forms.Button btnStartVisual;
        private System.Windows.Forms.RadioButton rdbQuickSort;
        private System.Windows.Forms.RadioButton rdbHeapSort;
        private System.Windows.Forms.Label lblSortingAlgorithm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Panel pnlDraw;
        private System.Windows.Forms.Label lblInputInfo;
    }
}