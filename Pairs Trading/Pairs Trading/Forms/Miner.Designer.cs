namespace Pairs_Trading.Forms
{
    partial class Miner
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
            this.lblIntro = new System.Windows.Forms.Label();
            this.lblLineCount = new System.Windows.Forms.Label();
            this.lblLineCountIntro = new System.Windows.Forms.Label();
            this.txtBrowse = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFirstStock = new System.Windows.Forms.TextBox();
            this.txtSecondStock = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGetDistance = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDistance = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.btnNearestNeighbour = new System.Windows.Forms.Button();
            this.txtNearestNeighbour = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblIntro
            // 
            this.lblIntro.AutoSize = true;
            this.lblIntro.Location = new System.Drawing.Point(9, 9);
            this.lblIntro.Name = "lblIntro";
            this.lblIntro.Size = new System.Drawing.Size(411, 39);
            this.lblIntro.TabIndex = 16;
            this.lblIntro.Text = "This is a tool to mine for pairs using downloaded stock data.\r\n\r\nBrowse for a fol" +
    "der containing stock data in CSV format obtained from the Loader tool.\r\n";
            // 
            // lblLineCount
            // 
            this.lblLineCount.AutoSize = true;
            this.lblLineCount.Location = new System.Drawing.Point(85, 89);
            this.lblLineCount.Name = "lblLineCount";
            this.lblLineCount.Size = new System.Drawing.Size(67, 13);
            this.lblLineCount.TabIndex = 21;
            this.lblLineCount.Text = "_stockCount";
            this.lblLineCount.Visible = false;
            // 
            // lblLineCountIntro
            // 
            this.lblLineCountIntro.AutoSize = true;
            this.lblLineCountIntro.Location = new System.Drawing.Point(9, 89);
            this.lblLineCountIntro.Name = "lblLineCountIntro";
            this.lblLineCountIntro.Size = new System.Drawing.Size(76, 13);
            this.lblLineCountIntro.TabIndex = 20;
            this.lblLineCountIntro.Text = "Stocks found: ";
            this.lblLineCountIntro.Visible = false;
            // 
            // txtBrowse
            // 
            this.txtBrowse.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtBrowse.Location = new System.Drawing.Point(12, 62);
            this.txtBrowse.Name = "txtBrowse";
            this.txtBrowse.ReadOnly = true;
            this.txtBrowse.Size = new System.Drawing.Size(420, 20);
            this.txtBrowse.TabIndex = 19;
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnBrowse.Location = new System.Drawing.Point(438, 62);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 18;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Select two pairs to retrieve the DTW distance between them\r\n";
            // 
            // txtFirstStock
            // 
            this.txtFirstStock.Location = new System.Drawing.Point(72, 152);
            this.txtFirstStock.Name = "txtFirstStock";
            this.txtFirstStock.Size = new System.Drawing.Size(100, 20);
            this.txtFirstStock.TabIndex = 23;
            this.txtFirstStock.Text = "0";
            // 
            // txtSecondStock
            // 
            this.txtSecondStock.Location = new System.Drawing.Point(72, 175);
            this.txtSecondStock.Name = "txtSecondStock";
            this.txtSecondStock.Size = new System.Drawing.Size(100, 20);
            this.txtSecondStock.TabIndex = 24;
            this.txtSecondStock.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Stock #1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Stock #2";
            // 
            // btnGetDistance
            // 
            this.btnGetDistance.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnGetDistance.Location = new System.Drawing.Point(18, 201);
            this.btnGetDistance.Name = "btnGetDistance";
            this.btnGetDistance.Size = new System.Drawing.Size(154, 23);
            this.btnGetDistance.TabIndex = 27;
            this.btnGetDistance.Text = "Get Distance";
            this.btnGetDistance.UseVisualStyleBackColor = false;
            this.btnGetDistance.Click += new System.EventHandler(this.btnGetDistance_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Calculated Distance:";
            // 
            // txtDistance
            // 
            this.txtDistance.Location = new System.Drawing.Point(132, 241);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.ReadOnly = true;
            this.txtDistance.Size = new System.Drawing.Size(172, 20);
            this.txtDistance.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 282);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(429, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Select a pair to get its nearest neighbour with respect to the DTW distance betwe" +
    "en them";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 312);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Stock #";
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(75, 312);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(100, 20);
            this.txtStock.TabIndex = 31;
            this.txtStock.Text = "0";
            // 
            // btnNearestNeighbour
            // 
            this.btnNearestNeighbour.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnNearestNeighbour.Location = new System.Drawing.Point(18, 338);
            this.btnNearestNeighbour.Name = "btnNearestNeighbour";
            this.btnNearestNeighbour.Size = new System.Drawing.Size(154, 23);
            this.btnNearestNeighbour.TabIndex = 33;
            this.btnNearestNeighbour.Text = "Get Nearest Neighbour";
            this.btnNearestNeighbour.UseVisualStyleBackColor = false;
            this.btnNearestNeighbour.Click += new System.EventHandler(this.btnNearestNeighbour_Click);
            // 
            // txtNearestNeighbour
            // 
            this.txtNearestNeighbour.Location = new System.Drawing.Point(132, 376);
            this.txtNearestNeighbour.Name = "txtNearestNeighbour";
            this.txtNearestNeighbour.ReadOnly = true;
            this.txtNearestNeighbour.Size = new System.Drawing.Size(172, 20);
            this.txtNearestNeighbour.TabIndex = 35;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 376);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "Nearest Neighbour:";
            // 
            // Miner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 444);
            this.Controls.Add(this.txtNearestNeighbour);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnNearestNeighbour);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDistance);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnGetDistance);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSecondStock);
            this.Controls.Add(this.txtFirstStock);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblLineCount);
            this.Controls.Add(this.lblLineCountIntro);
            this.Controls.Add(this.txtBrowse);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.lblIntro);
            this.Name = "Miner";
            this.ShowInTaskbar = false;
            this.Text = "Miner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIntro;
        private System.Windows.Forms.Label lblLineCount;
        private System.Windows.Forms.Label lblLineCountIntro;
        private System.Windows.Forms.TextBox txtBrowse;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFirstStock;
        private System.Windows.Forms.TextBox txtSecondStock;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGetDistance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDistance;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Button btnNearestNeighbour;
        private System.Windows.Forms.TextBox txtNearestNeighbour;
        private System.Windows.Forms.Label label7;
    }
}