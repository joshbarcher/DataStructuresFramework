namespace DataStructureExamples
{
    partial class HashVisualization
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HashVisualization));
            this.pnlDraw = new System.Windows.Forms.Panel();
            this.rdbRandomString = new System.Windows.Forms.RadioButton();
            this.rdbSequentialString = new System.Windows.Forms.RadioButton();
            this.rdbRandomInteger = new System.Windows.Forms.RadioButton();
            this.rdbSequentialInteger = new System.Windows.Forms.RadioButton();
            this.btnBuild = new System.Windows.Forms.Button();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblHashingFunction = new System.Windows.Forms.Label();
            this.lblActualHashFunction = new System.Windows.Forms.Label();
            this.pnlHashingStrategy = new System.Windows.Forms.Panel();
            this.rdbModTableSize = new System.Windows.Forms.RadioButton();
            this.rdbMultiplyPrimeModPrime = new System.Windows.Forms.RadioButton();
            this.pnlInputType = new System.Windows.Forms.Panel();
            this.lblHashingStrategy = new System.Windows.Forms.Label();
            this.lblInputType = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblItems = new System.Windows.Forms.Label();
            this.txtItems = new System.Windows.Forms.TextBox();
            this.lblItemsOne = new System.Windows.Forms.Label();
            this.lblItemsTwo = new System.Windows.Forms.Label();
            this.lblItemsFive = new System.Windows.Forms.Label();
            this.lblItemsThree = new System.Windows.Forms.Label();
            this.lblItemsFour = new System.Windows.Forms.Label();
            this.pnlInfo.SuspendLayout();
            this.pnlHashingStrategy.SuspendLayout();
            this.pnlInputType.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDraw
            // 
            this.pnlDraw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDraw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDraw.Location = new System.Drawing.Point(3, 32);
            this.pnlDraw.Name = "pnlDraw";
            this.pnlDraw.Size = new System.Drawing.Size(985, 448);
            this.pnlDraw.TabIndex = 0;
            this.pnlDraw.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDraw_Paint);
            // 
            // rdbRandomString
            // 
            this.rdbRandomString.AutoSize = true;
            this.rdbRandomString.Checked = true;
            this.rdbRandomString.Location = new System.Drawing.Point(3, 0);
            this.rdbRandomString.Name = "rdbRandomString";
            this.rdbRandomString.Size = new System.Drawing.Size(127, 17);
            this.rdbRandomString.TabIndex = 1;
            this.rdbRandomString.TabStop = true;
            this.rdbRandomString.Text = "Random string values";
            this.rdbRandomString.UseVisualStyleBackColor = true;
            // 
            // rdbSequentialString
            // 
            this.rdbSequentialString.AutoSize = true;
            this.rdbSequentialString.Location = new System.Drawing.Point(3, 23);
            this.rdbSequentialString.Name = "rdbSequentialString";
            this.rdbSequentialString.Size = new System.Drawing.Size(137, 17);
            this.rdbSequentialString.TabIndex = 2;
            this.rdbSequentialString.Text = "Sequential string values";
            this.rdbSequentialString.UseVisualStyleBackColor = true;
            // 
            // rdbRandomInteger
            // 
            this.rdbRandomInteger.AutoSize = true;
            this.rdbRandomInteger.Location = new System.Drawing.Point(3, 68);
            this.rdbRandomInteger.Name = "rdbRandomInteger";
            this.rdbRandomInteger.Size = new System.Drawing.Size(137, 17);
            this.rdbRandomInteger.TabIndex = 3;
            this.rdbRandomInteger.Text = "Random integer values ";
            this.rdbRandomInteger.UseVisualStyleBackColor = true;
            // 
            // rdbSequentialInteger
            // 
            this.rdbSequentialInteger.AutoSize = true;
            this.rdbSequentialInteger.Location = new System.Drawing.Point(3, 46);
            this.rdbSequentialInteger.Name = "rdbSequentialInteger";
            this.rdbSequentialInteger.Size = new System.Drawing.Size(144, 17);
            this.rdbSequentialInteger.TabIndex = 4;
            this.rdbSequentialInteger.Text = "Sequential integer values";
            this.rdbSequentialInteger.UseVisualStyleBackColor = true;
            // 
            // btnBuild
            // 
            this.btnBuild.Location = new System.Drawing.Point(8, 22);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(97, 24);
            this.btnBuild.TabIndex = 7;
            this.btnBuild.Text = "Build hash table";
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            // 
            // pnlInfo
            // 
            this.pnlInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlInfo.BackColor = System.Drawing.Color.Transparent;
            this.pnlInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInfo.Controls.Add(this.lblInfo);
            this.pnlInfo.Controls.Add(this.label2);
            this.pnlInfo.Controls.Add(this.lblHashingFunction);
            this.pnlInfo.Controls.Add(this.lblActualHashFunction);
            this.pnlInfo.Controls.Add(this.pnlHashingStrategy);
            this.pnlInfo.Controls.Add(this.pnlInputType);
            this.pnlInfo.Controls.Add(this.lblHashingStrategy);
            this.pnlInfo.Controls.Add(this.lblInputType);
            this.pnlInfo.Controls.Add(this.label1);
            this.pnlInfo.Controls.Add(this.btnBuild);
            this.pnlInfo.Controls.Add(this.lblItems);
            this.pnlInfo.Controls.Add(this.txtItems);
            this.pnlInfo.Location = new System.Drawing.Point(3, 486);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(985, 112);
            this.pnlInfo.TabIndex = 8;
            // 
            // lblInfo
            // 
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(613, 22);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(367, 84);
            this.lblInfo.TabIndex = 16;
            this.lblInfo.Text = resources.GetString("lblInfo.Text");
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(661, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(278, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Welcome to the Hashing Visualization!";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHashingFunction
            // 
            this.lblHashingFunction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHashingFunction.Location = new System.Drawing.Point(462, 3);
            this.lblHashingFunction.Name = "lblHashingFunction";
            this.lblHashingFunction.Size = new System.Drawing.Size(140, 16);
            this.lblHashingFunction.TabIndex = 14;
            this.lblHashingFunction.Text = "Hashing Function";
            this.lblHashingFunction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblActualHashFunction
            // 
            this.lblActualHashFunction.Location = new System.Drawing.Point(435, 32);
            this.lblActualHashFunction.Name = "lblActualHashFunction";
            this.lblActualHashFunction.Size = new System.Drawing.Size(178, 43);
            this.lblActualHashFunction.TabIndex = 13;
            this.lblActualHashFunction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlHashingStrategy
            // 
            this.pnlHashingStrategy.Controls.Add(this.rdbModTableSize);
            this.pnlHashingStrategy.Controls.Add(this.rdbMultiplyPrimeModPrime);
            this.pnlHashingStrategy.Location = new System.Drawing.Point(272, 22);
            this.pnlHashingStrategy.Name = "pnlHashingStrategy";
            this.pnlHashingStrategy.Size = new System.Drawing.Size(157, 84);
            this.pnlHashingStrategy.TabIndex = 12;
            // 
            // rdbModTableSize
            // 
            this.rdbModTableSize.AutoSize = true;
            this.rdbModTableSize.Checked = true;
            this.rdbModTableSize.Location = new System.Drawing.Point(3, 0);
            this.rdbModTableSize.Name = "rdbModTableSize";
            this.rdbModTableSize.Size = new System.Drawing.Size(99, 17);
            this.rdbModTableSize.TabIndex = 1;
            this.rdbModTableSize.TabStop = true;
            this.rdbModTableSize.Text = "Mod Table Size";
            this.rdbModTableSize.UseVisualStyleBackColor = true;
            // 
            // rdbMultiplyPrimeModPrime
            // 
            this.rdbMultiplyPrimeModPrime.AutoSize = true;
            this.rdbMultiplyPrimeModPrime.Location = new System.Drawing.Point(3, 23);
            this.rdbMultiplyPrimeModPrime.Name = "rdbMultiplyPrimeModPrime";
            this.rdbMultiplyPrimeModPrime.Size = new System.Drawing.Size(142, 17);
            this.rdbMultiplyPrimeModPrime.TabIndex = 2;
            this.rdbMultiplyPrimeModPrime.Text = "Multiply Prime Mod Prime";
            this.rdbMultiplyPrimeModPrime.UseVisualStyleBackColor = true;
            // 
            // pnlInputType
            // 
            this.pnlInputType.Controls.Add(this.rdbRandomString);
            this.pnlInputType.Controls.Add(this.rdbSequentialInteger);
            this.pnlInputType.Controls.Add(this.rdbSequentialString);
            this.pnlInputType.Controls.Add(this.rdbRandomInteger);
            this.pnlInputType.Location = new System.Drawing.Point(119, 22);
            this.pnlInputType.Name = "pnlInputType";
            this.pnlInputType.Size = new System.Drawing.Size(147, 84);
            this.pnlInputType.TabIndex = 11;
            // 
            // lblHashingStrategy
            // 
            this.lblHashingStrategy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHashingStrategy.Location = new System.Drawing.Point(288, 3);
            this.lblHashingStrategy.Name = "lblHashingStrategy";
            this.lblHashingStrategy.Size = new System.Drawing.Size(140, 16);
            this.lblHashingStrategy.TabIndex = 10;
            this.lblHashingStrategy.Text = "Hashing Strategy";
            this.lblHashingStrategy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInputType
            // 
            this.lblInputType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInputType.Location = new System.Drawing.Point(115, 3);
            this.lblInputType.Name = "lblInputType";
            this.lblInputType.Size = new System.Drawing.Size(140, 16);
            this.lblInputType.TabIndex = 9;
            this.lblInputType.Text = "Input Type";
            this.lblInputType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "(250 - 1500)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblItems
            // 
            this.lblItems.Location = new System.Drawing.Point(8, 49);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(95, 16);
            this.lblItems.TabIndex = 6;
            this.lblItems.Text = "Items in hash table";
            this.lblItems.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtItems
            // 
            this.txtItems.BackColor = System.Drawing.Color.Gold;
            this.txtItems.Location = new System.Drawing.Point(8, 68);
            this.txtItems.Name = "txtItems";
            this.txtItems.Size = new System.Drawing.Size(97, 20);
            this.txtItems.TabIndex = 5;
            this.txtItems.Text = "500";
            this.txtItems.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblItemsOne
            // 
            this.lblItemsOne.BackColor = System.Drawing.Color.Transparent;
            this.lblItemsOne.Location = new System.Drawing.Point(34, 9);
            this.lblItemsOne.Name = "lblItemsOne";
            this.lblItemsOne.Size = new System.Drawing.Size(100, 16);
            this.lblItemsOne.TabIndex = 8;
            this.lblItemsOne.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblItemsTwo
            // 
            this.lblItemsTwo.BackColor = System.Drawing.Color.Transparent;
            this.lblItemsTwo.Location = new System.Drawing.Point(248, 9);
            this.lblItemsTwo.Name = "lblItemsTwo";
            this.lblItemsTwo.Size = new System.Drawing.Size(100, 16);
            this.lblItemsTwo.TabIndex = 9;
            this.lblItemsTwo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblItemsFive
            // 
            this.lblItemsFive.BackColor = System.Drawing.Color.Transparent;
            this.lblItemsFive.Location = new System.Drawing.Point(829, 9);
            this.lblItemsFive.Name = "lblItemsFive";
            this.lblItemsFive.Size = new System.Drawing.Size(100, 16);
            this.lblItemsFive.TabIndex = 10;
            this.lblItemsFive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblItemsThree
            // 
            this.lblItemsThree.BackColor = System.Drawing.Color.Transparent;
            this.lblItemsThree.Location = new System.Drawing.Point(453, 9);
            this.lblItemsThree.Name = "lblItemsThree";
            this.lblItemsThree.Size = new System.Drawing.Size(100, 16);
            this.lblItemsThree.TabIndex = 10;
            this.lblItemsThree.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblItemsFour
            // 
            this.lblItemsFour.BackColor = System.Drawing.Color.Transparent;
            this.lblItemsFour.Location = new System.Drawing.Point(640, 9);
            this.lblItemsFour.Name = "lblItemsFour";
            this.lblItemsFour.Size = new System.Drawing.Size(100, 16);
            this.lblItemsFour.TabIndex = 11;
            this.lblItemsFour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HashVisualization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DataStructureExamples.Properties.Resources.gradient;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(996, 599);
            this.Controls.Add(this.lblItemsFour);
            this.Controls.Add(this.lblItemsThree);
            this.Controls.Add(this.lblItemsFive);
            this.Controls.Add(this.lblItemsTwo);
            this.Controls.Add(this.lblItemsOne);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.pnlDraw);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "HashVisualization";
            this.ShowIcon = false;
            this.Text = "Hash Visualization  [Author: Josh Archer]";
            this.ResizeEnd += new System.EventHandler(this.HashVisualization_ResizeEnd);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.pnlHashingStrategy.ResumeLayout(false);
            this.pnlHashingStrategy.PerformLayout();
            this.pnlInputType.ResumeLayout(false);
            this.pnlInputType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDraw;
        private System.Windows.Forms.RadioButton rdbRandomString;
        private System.Windows.Forms.RadioButton rdbSequentialString;
        private System.Windows.Forms.RadioButton rdbRandomInteger;
        private System.Windows.Forms.RadioButton rdbSequentialInteger;
        private System.Windows.Forms.Button btnBuild;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label lblItemsOne;
        private System.Windows.Forms.Label lblItemsTwo;
        private System.Windows.Forms.Label lblItemsFive;
        private System.Windows.Forms.Label lblItemsThree;
        private System.Windows.Forms.Label lblItemsFour;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.TextBox txtItems;
        private System.Windows.Forms.Panel pnlHashingStrategy;
        private System.Windows.Forms.RadioButton rdbModTableSize;
        private System.Windows.Forms.RadioButton rdbMultiplyPrimeModPrime;
        private System.Windows.Forms.Panel pnlInputType;
        private System.Windows.Forms.Label lblHashingStrategy;
        private System.Windows.Forms.Label lblInputType;
        private System.Windows.Forms.Label lblActualHashFunction;
        private System.Windows.Forms.Label lblHashingFunction;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label label2;
    }
}