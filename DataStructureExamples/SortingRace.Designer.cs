namespace DataStructureExamples
{
    partial class SortingRace
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SortingRace));
            this.btnStartTheRace = new System.Windows.Forms.Button();
            this.rdbSortedDescending = new System.Windows.Forms.RadioButton();
            this.rdbSortedAscending = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.rdbPermutation = new System.Windows.Forms.RadioButton();
            this.lblHeapSort = new System.Windows.Forms.Label();
            this.rdbAllSameInput = new System.Windows.Forms.RadioButton();
            this.pbrHeapSort = new System.Windows.Forms.ProgressBar();
            this.rdbLargeInput = new System.Windows.Forms.RadioButton();
            this.lblQuickSort = new System.Windows.Forms.Label();
            this.rdbSmallInput = new System.Windows.Forms.RadioButton();
            this.pbrQuickSort = new System.Windows.Forms.ProgressBar();
            this.lblMergeSort = new System.Windows.Forms.Label();
            this.pbrMergeSort = new System.Windows.Forms.ProgressBar();
            this.lblShellSort = new System.Windows.Forms.Label();
            this.pbrShellSort = new System.Windows.Forms.ProgressBar();
            this.lblInsertionSort = new System.Windows.Forms.Label();
            this.pbrInsertionSort = new System.Windows.Forms.ProgressBar();
            this.lblSelectionSort = new System.Windows.Forms.Label();
            this.pbrSelectionSort = new System.Windows.Forms.ProgressBar();
            this.lblBubbleSort = new System.Windows.Forms.Label();
            this.pbrBubbleSort = new System.Windows.Forms.ProgressBar();
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblLogo = new System.Windows.Forms.Label();
            this.pnlUserControls = new System.Windows.Forms.Panel();
            this.pnlUserControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartTheRace
            // 
            this.btnStartTheRace.Location = new System.Drawing.Point(154, 274);
            this.btnStartTheRace.Name = "btnStartTheRace";
            this.btnStartTheRace.Size = new System.Drawing.Size(115, 22);
            this.btnStartTheRace.TabIndex = 35;
            this.btnStartTheRace.Text = "Start the race!";
            this.btnStartTheRace.UseVisualStyleBackColor = true;
            this.btnStartTheRace.Click += new System.EventHandler(this.btnStartTheRace_Click);
            // 
            // rdbSortedDescending
            // 
            this.rdbSortedDescending.AutoSize = true;
            this.rdbSortedDescending.BackColor = System.Drawing.Color.Transparent;
            this.rdbSortedDescending.Location = new System.Drawing.Point(4, 140);
            this.rdbSortedDescending.Name = "rdbSortedDescending";
            this.rdbSortedDescending.Size = new System.Drawing.Size(219, 17);
            this.rdbSortedDescending.TabIndex = 52;
            this.rdbSortedDescending.Text = "A list of sorted integers (decreasing order)";
            this.rdbSortedDescending.UseVisualStyleBackColor = false;
            // 
            // rdbSortedAscending
            // 
            this.rdbSortedAscending.AutoSize = true;
            this.rdbSortedAscending.BackColor = System.Drawing.Color.Transparent;
            this.rdbSortedAscending.Location = new System.Drawing.Point(4, 117);
            this.rdbSortedAscending.Name = "rdbSortedAscending";
            this.rdbSortedAscending.Size = new System.Drawing.Size(215, 17);
            this.rdbSortedAscending.TabIndex = 51;
            this.rdbSortedAscending.Text = "A list of sorted integers (increasing order)";
            this.rdbSortedAscending.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 22);
            this.label2.TabIndex = 50;
            this.label2.Text = "Inputs";
            // 
            // rdbPermutation
            // 
            this.rdbPermutation.AutoSize = true;
            this.rdbPermutation.BackColor = System.Drawing.Color.Transparent;
            this.rdbPermutation.Location = new System.Drawing.Point(4, 94);
            this.rdbPermutation.Name = "rdbPermutation";
            this.rdbPermutation.Size = new System.Drawing.Size(179, 17);
            this.rdbPermutation.TabIndex = 41;
            this.rdbPermutation.Text = "Permutation of the first n integers";
            this.rdbPermutation.UseVisualStyleBackColor = false;
            // 
            // lblHeapSort
            // 
            this.lblHeapSort.BackColor = System.Drawing.Color.Transparent;
            this.lblHeapSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeapSort.Location = new System.Drawing.Point(8, 240);
            this.lblHeapSort.Name = "lblHeapSort";
            this.lblHeapSort.Size = new System.Drawing.Size(140, 22);
            this.lblHeapSort.TabIndex = 49;
            this.lblHeapSort.Text = "Heap Sort";
            // 
            // rdbAllSameInput
            // 
            this.rdbAllSameInput.AutoSize = true;
            this.rdbAllSameInput.BackColor = System.Drawing.Color.Transparent;
            this.rdbAllSameInput.Location = new System.Drawing.Point(4, 71);
            this.rdbAllSameInput.Name = "rdbAllSameInput";
            this.rdbAllSameInput.Size = new System.Drawing.Size(144, 17);
            this.rdbAllSameInput.TabIndex = 39;
            this.rdbAllSameInput.Text = "All entries a single integer";
            this.rdbAllSameInput.UseVisualStyleBackColor = false;
            // 
            // pbrHeapSort
            // 
            this.pbrHeapSort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbrHeapSort.Location = new System.Drawing.Point(154, 240);
            this.pbrHeapSort.Name = "pbrHeapSort";
            this.pbrHeapSort.Size = new System.Drawing.Size(578, 18);
            this.pbrHeapSort.TabIndex = 48;
            // 
            // rdbLargeInput
            // 
            this.rdbLargeInput.AutoSize = true;
            this.rdbLargeInput.BackColor = System.Drawing.Color.Transparent;
            this.rdbLargeInput.Checked = true;
            this.rdbLargeInput.Location = new System.Drawing.Point(4, 25);
            this.rdbLargeInput.Name = "rdbLargeInput";
            this.rdbLargeInput.Size = new System.Drawing.Size(166, 17);
            this.rdbLargeInput.TabIndex = 36;
            this.rdbLargeInput.TabStop = true;
            this.rdbLargeInput.Text = "Random Integers (0 - 100000)";
            this.rdbLargeInput.UseVisualStyleBackColor = false;
            // 
            // lblQuickSort
            // 
            this.lblQuickSort.BackColor = System.Drawing.Color.Transparent;
            this.lblQuickSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuickSort.Location = new System.Drawing.Point(8, 202);
            this.lblQuickSort.Name = "lblQuickSort";
            this.lblQuickSort.Size = new System.Drawing.Size(140, 22);
            this.lblQuickSort.TabIndex = 47;
            this.lblQuickSort.Text = "Quick Sort";
            // 
            // rdbSmallInput
            // 
            this.rdbSmallInput.AutoSize = true;
            this.rdbSmallInput.BackColor = System.Drawing.Color.Transparent;
            this.rdbSmallInput.Location = new System.Drawing.Point(4, 48);
            this.rdbSmallInput.Name = "rdbSmallInput";
            this.rdbSmallInput.Size = new System.Drawing.Size(148, 17);
            this.rdbSmallInput.TabIndex = 33;
            this.rdbSmallInput.Text = "Random Integers (0 - 100)";
            this.rdbSmallInput.UseVisualStyleBackColor = false;
            // 
            // pbrQuickSort
            // 
            this.pbrQuickSort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbrQuickSort.Location = new System.Drawing.Point(154, 202);
            this.pbrQuickSort.Name = "pbrQuickSort";
            this.pbrQuickSort.Size = new System.Drawing.Size(578, 18);
            this.pbrQuickSort.TabIndex = 46;
            // 
            // lblMergeSort
            // 
            this.lblMergeSort.BackColor = System.Drawing.Color.Transparent;
            this.lblMergeSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMergeSort.Location = new System.Drawing.Point(8, 164);
            this.lblMergeSort.Name = "lblMergeSort";
            this.lblMergeSort.Size = new System.Drawing.Size(140, 22);
            this.lblMergeSort.TabIndex = 45;
            this.lblMergeSort.Text = "Merge Sort";
            // 
            // pbrMergeSort
            // 
            this.pbrMergeSort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbrMergeSort.Location = new System.Drawing.Point(154, 164);
            this.pbrMergeSort.Name = "pbrMergeSort";
            this.pbrMergeSort.Size = new System.Drawing.Size(578, 18);
            this.pbrMergeSort.TabIndex = 44;
            // 
            // lblShellSort
            // 
            this.lblShellSort.BackColor = System.Drawing.Color.Transparent;
            this.lblShellSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShellSort.Location = new System.Drawing.Point(8, 126);
            this.lblShellSort.Name = "lblShellSort";
            this.lblShellSort.Size = new System.Drawing.Size(140, 22);
            this.lblShellSort.TabIndex = 43;
            this.lblShellSort.Text = "Shell Sort";
            // 
            // pbrShellSort
            // 
            this.pbrShellSort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbrShellSort.Location = new System.Drawing.Point(154, 126);
            this.pbrShellSort.Name = "pbrShellSort";
            this.pbrShellSort.Size = new System.Drawing.Size(578, 18);
            this.pbrShellSort.TabIndex = 42;
            // 
            // lblInsertionSort
            // 
            this.lblInsertionSort.BackColor = System.Drawing.Color.Transparent;
            this.lblInsertionSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInsertionSort.Location = new System.Drawing.Point(8, 88);
            this.lblInsertionSort.Name = "lblInsertionSort";
            this.lblInsertionSort.Size = new System.Drawing.Size(140, 22);
            this.lblInsertionSort.TabIndex = 40;
            this.lblInsertionSort.Text = "Insertion Sort";
            // 
            // pbrInsertionSort
            // 
            this.pbrInsertionSort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbrInsertionSort.Location = new System.Drawing.Point(154, 88);
            this.pbrInsertionSort.Name = "pbrInsertionSort";
            this.pbrInsertionSort.Size = new System.Drawing.Size(578, 18);
            this.pbrInsertionSort.TabIndex = 38;
            // 
            // lblSelectionSort
            // 
            this.lblSelectionSort.BackColor = System.Drawing.Color.Transparent;
            this.lblSelectionSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectionSort.Location = new System.Drawing.Point(8, 50);
            this.lblSelectionSort.Name = "lblSelectionSort";
            this.lblSelectionSort.Size = new System.Drawing.Size(140, 22);
            this.lblSelectionSort.TabIndex = 37;
            this.lblSelectionSort.Text = "Selection Sort";
            // 
            // pbrSelectionSort
            // 
            this.pbrSelectionSort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbrSelectionSort.Location = new System.Drawing.Point(154, 50);
            this.pbrSelectionSort.Name = "pbrSelectionSort";
            this.pbrSelectionSort.Size = new System.Drawing.Size(578, 18);
            this.pbrSelectionSort.TabIndex = 34;
            // 
            // lblBubbleSort
            // 
            this.lblBubbleSort.BackColor = System.Drawing.Color.Transparent;
            this.lblBubbleSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBubbleSort.Location = new System.Drawing.Point(8, 12);
            this.lblBubbleSort.Name = "lblBubbleSort";
            this.lblBubbleSort.Size = new System.Drawing.Size(140, 22);
            this.lblBubbleSort.TabIndex = 32;
            this.lblBubbleSort.Text = "Bubble Sort";
            // 
            // pbrBubbleSort
            // 
            this.pbrBubbleSort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbrBubbleSort.Location = new System.Drawing.Point(154, 12);
            this.pbrBubbleSort.Name = "pbrBubbleSort";
            this.pbrBubbleSort.Size = new System.Drawing.Size(578, 18);
            this.pbrBubbleSort.TabIndex = 31;
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Interval = 50;
            this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
            // 
            // lblInfo
            // 
            this.lblInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(238, 22);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(487, 141);
            this.lblInfo.TabIndex = 53;
            this.lblInfo.Text = resources.GetString("lblInfo.Text");
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLogo
            // 
            this.lblLogo.BackColor = System.Drawing.Color.Transparent;
            this.lblLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogo.Location = new System.Drawing.Point(289, -3);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(397, 25);
            this.lblLogo.TabIndex = 54;
            this.lblLogo.Text = "Welcome to the sorting race!";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlUserControls
            // 
            this.pnlUserControls.BackColor = System.Drawing.Color.Transparent;
            this.pnlUserControls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUserControls.Controls.Add(this.lblLogo);
            this.pnlUserControls.Controls.Add(this.label2);
            this.pnlUserControls.Controls.Add(this.lblInfo);
            this.pnlUserControls.Controls.Add(this.rdbSmallInput);
            this.pnlUserControls.Controls.Add(this.rdbLargeInput);
            this.pnlUserControls.Controls.Add(this.rdbSortedDescending);
            this.pnlUserControls.Controls.Add(this.rdbAllSameInput);
            this.pnlUserControls.Controls.Add(this.rdbSortedAscending);
            this.pnlUserControls.Controls.Add(this.rdbPermutation);
            this.pnlUserControls.Location = new System.Drawing.Point(11, 302);
            this.pnlUserControls.Name = "pnlUserControls";
            this.pnlUserControls.Size = new System.Drawing.Size(721, 167);
            this.pnlUserControls.TabIndex = 55;
            // 
            // SortingRace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DataStructureExamples.Properties.Resources.gradient;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(741, 473);
            this.Controls.Add(this.btnStartTheRace);
            this.Controls.Add(this.lblHeapSort);
            this.Controls.Add(this.pbrHeapSort);
            this.Controls.Add(this.lblQuickSort);
            this.Controls.Add(this.pbrQuickSort);
            this.Controls.Add(this.lblMergeSort);
            this.Controls.Add(this.pbrMergeSort);
            this.Controls.Add(this.lblShellSort);
            this.Controls.Add(this.pbrShellSort);
            this.Controls.Add(this.lblInsertionSort);
            this.Controls.Add(this.pbrInsertionSort);
            this.Controls.Add(this.lblSelectionSort);
            this.Controls.Add(this.pbrSelectionSort);
            this.Controls.Add(this.lblBubbleSort);
            this.Controls.Add(this.pbrBubbleSort);
            this.Controls.Add(this.pnlUserControls);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SortingRace";
            this.ShowIcon = false;
            this.Text = "Sorting Race [Author: Josh Archer]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SortingRace_FormClosing);
            this.pnlUserControls.ResumeLayout(false);
            this.pnlUserControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStartTheRace;
        private System.Windows.Forms.RadioButton rdbSortedDescending;
        private System.Windows.Forms.RadioButton rdbSortedAscending;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdbPermutation;
        private System.Windows.Forms.Label lblHeapSort;
        private System.Windows.Forms.RadioButton rdbAllSameInput;
        private System.Windows.Forms.ProgressBar pbrHeapSort;
        private System.Windows.Forms.RadioButton rdbLargeInput;
        private System.Windows.Forms.Label lblQuickSort;
        private System.Windows.Forms.RadioButton rdbSmallInput;
        private System.Windows.Forms.ProgressBar pbrQuickSort;
        private System.Windows.Forms.Label lblMergeSort;
        private System.Windows.Forms.ProgressBar pbrMergeSort;
        private System.Windows.Forms.Label lblShellSort;
        private System.Windows.Forms.ProgressBar pbrShellSort;
        private System.Windows.Forms.Label lblInsertionSort;
        private System.Windows.Forms.ProgressBar pbrInsertionSort;
        private System.Windows.Forms.Label lblSelectionSort;
        private System.Windows.Forms.ProgressBar pbrSelectionSort;
        private System.Windows.Forms.Label lblBubbleSort;
        private System.Windows.Forms.ProgressBar pbrBubbleSort;
        private System.Windows.Forms.Timer tmrUpdate;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Panel pnlUserControls;
    }
}