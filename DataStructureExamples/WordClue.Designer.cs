namespace DataStructureExamples
{
    partial class WordClue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WordClue));
            this.btnSearch = new System.Windows.Forms.Button();
            this.lstWords = new System.Windows.Forms.ListBox();
            this.txtLetters = new System.Windows.Forms.TextBox();
            this.lblExplanation = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbrProgress = new System.Windows.Forms.ProgressBar();
            this.lblInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(443, 151);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 20);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lstWords
            // 
            this.lstWords.FormattingEnabled = true;
            this.lstWords.Location = new System.Drawing.Point(12, 177);
            this.lstWords.Name = "lstWords";
            this.lstWords.Size = new System.Drawing.Size(505, 264);
            this.lstWords.TabIndex = 1;
            // 
            // txtLetters
            // 
            this.txtLetters.BackColor = System.Drawing.Color.Gold;
            this.txtLetters.Location = new System.Drawing.Point(12, 151);
            this.txtLetters.Name = "txtLetters";
            this.txtLetters.Size = new System.Drawing.Size(425, 20);
            this.txtLetters.TabIndex = 2;
            // 
            // lblExplanation
            // 
            this.lblExplanation.BackColor = System.Drawing.Color.Transparent;
            this.lblExplanation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExplanation.Location = new System.Drawing.Point(12, 9);
            this.lblExplanation.Name = "lblExplanation";
            this.lblExplanation.Size = new System.Drawing.Size(505, 24);
            this.lblExplanation.TabIndex = 3;
            this.lblExplanation.Text = "Welcome to Word Clue!";
            this.lblExplanation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(505, 115);
            this.label1.TabIndex = 4;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbrProgress
            // 
            this.pbrProgress.ForeColor = System.Drawing.Color.Gold;
            this.pbrProgress.Location = new System.Drawing.Point(12, 453);
            this.pbrProgress.Name = "pbrProgress";
            this.pbrProgress.Size = new System.Drawing.Size(263, 20);
            this.pbrProgress.TabIndex = 5;
            // 
            // lblInfo
            // 
            this.lblInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(281, 453);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(237, 20);
            this.lblInfo.TabIndex = 6;
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WordClue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DataStructureExamples.Properties.Resources.gradient;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(529, 482);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.pbrProgress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblExplanation);
            this.Controls.Add(this.txtLetters);
            this.Controls.Add(this.lstWords);
            this.Controls.Add(this.btnSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "WordClue";
            this.ShowIcon = false;
            this.Text = "WordClue  [Author: Josh Archer]";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListBox lstWords;
        private System.Windows.Forms.TextBox txtLetters;
        private System.Windows.Forms.Label lblExplanation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar pbrProgress;
        private System.Windows.Forms.Label lblInfo;
    }
}