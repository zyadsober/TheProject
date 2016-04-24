namespace Pairs_Trading
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.btnLoader = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnMiner = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnMonitor = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnPreprocessor = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoader
            // 
            this.btnLoader.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnLoader.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoader.Location = new System.Drawing.Point(6, 45);
            this.btnLoader.Name = "btnLoader";
            this.btnLoader.Size = new System.Drawing.Size(265, 23);
            this.btnLoader.TabIndex = 0;
            this.btnLoader.Text = "Stock Data Loader";
            this.btnLoader.UseVisualStyleBackColor = false;
            this.btnLoader.Click += new System.EventHandler(this.btnLoader_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Welcome\r\nPlease select an option to continue\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.MaximumSize = new System.Drawing.Size(280, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(265, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "\r\nUse this to download the latest stock data from Quandl\r\n";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnLoader);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Location = new System.Drawing.Point(5, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 85);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1- Stock Data Loader";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnMiner);
            this.groupBox2.Location = new System.Drawing.Point(5, 296);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(277, 85);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "4- Pairs Miner";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 29);
            this.label3.MaximumSize = new System.Drawing.Size(280, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(224, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Use this tool to mine for pairs in the stock data";
            // 
            // btnMiner
            // 
            this.btnMiner.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnMiner.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMiner.Location = new System.Drawing.Point(9, 45);
            this.btnMiner.Name = "btnMiner";
            this.btnMiner.Size = new System.Drawing.Size(265, 23);
            this.btnMiner.TabIndex = 0;
            this.btnMiner.Text = "Pairs Miner";
            this.btnMiner.UseVisualStyleBackColor = false;
            this.btnMiner.Click += new System.EventHandler(this.btnMiner_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.btnMonitor);
            this.groupBox3.Location = new System.Drawing.Point(5, 380);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(277, 85);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "5- Pairs Monitor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 29);
            this.label4.MaximumSize = new System.Drawing.Size(280, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Use this tool to monitor the found pairs\r\n";
            // 
            // btnMonitor
            // 
            this.btnMonitor.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnMonitor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMonitor.Location = new System.Drawing.Point(9, 45);
            this.btnMonitor.Name = "btnMonitor";
            this.btnMonitor.Size = new System.Drawing.Size(265, 23);
            this.btnMonitor.TabIndex = 0;
            this.btnMonitor.Text = "Pairs Monitor";
            this.btnMonitor.UseVisualStyleBackColor = false;
            this.btnMonitor.Click += new System.EventHandler(this.btnMonitor_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(5, 74);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(277, 85);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "2- Data Generator";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.DarkGray;
            this.label6.Location = new System.Drawing.Point(15, 465);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(259, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Project by Mohannad Sweity and Zyad Sober. PSUT.";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.btnPreprocessor);
            this.groupBox5.Location = new System.Drawing.Point(5, 215);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(277, 85);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "3- Stock Data Preprocessor";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 16);
            this.label7.MaximumSize = new System.Drawing.Size(280, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(165, 26);
            this.label7.TabIndex = 2;
            this.label7.Text = "\r\nUse this to preprocess stock data";
            // 
            // btnPreprocessor
            // 
            this.btnPreprocessor.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnPreprocessor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreprocessor.Location = new System.Drawing.Point(6, 45);
            this.btnPreprocessor.Name = "btnPreprocessor";
            this.btnPreprocessor.Size = new System.Drawing.Size(265, 23);
            this.btnPreprocessor.TabIndex = 0;
            this.btnPreprocessor.Text = "Stock Data Preprocessor";
            this.btnPreprocessor.UseVisualStyleBackColor = false;
            this.btnPreprocessor.Click += new System.EventHandler(this.btnPreprocessor_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 147);
            this.label8.MaximumSize = new System.Drawing.Size(280, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(175, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Use this tool to generate stock data";
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnGenerate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerate.Location = new System.Drawing.Point(11, 176);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(265, 23);
            this.btnGenerate.TabIndex = 3;
            this.btnGenerate.Text = "Stock Data Generator";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.ClientSize = new System.Drawing.Size(294, 494);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pairs Trading";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnMiner;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnMonitor;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnPreprocessor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnGenerate;
    }
}

