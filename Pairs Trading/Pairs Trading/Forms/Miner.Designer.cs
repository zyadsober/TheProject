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
            this.lblRetreiveDistance = new System.Windows.Forms.Label();
            this.txtFirstStock = new System.Windows.Forms.TextBox();
            this.txtSecondStock = new System.Windows.Forms.TextBox();
            this.lblFirstStock = new System.Windows.Forms.Label();
            this.lblSecondStock = new System.Windows.Forms.Label();
            this.btnGetDistance = new System.Windows.Forms.Button();
            this.lblDistance = new System.Windows.Forms.Label();
            this.txtDistance = new System.Windows.Forms.TextBox();
            this.lblNearestNeighborIntro = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.btnNearestNeighbor = new System.Windows.Forms.Button();
            this.txtNearestNeighbour = new System.Windows.Forms.TextBox();
            this.lblNearestNeighbor = new System.Windows.Forms.Label();
            this.numStockDays = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.chkStockDays = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numWorkers = new System.Windows.Forms.NumericUpDown();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.numStockDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWorkers)).BeginInit();
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
            // lblRetreiveDistance
            // 
            this.lblRetreiveDistance.AutoSize = true;
            this.lblRetreiveDistance.Location = new System.Drawing.Point(6, 225);
            this.lblRetreiveDistance.Name = "lblRetreiveDistance";
            this.lblRetreiveDistance.Size = new System.Drawing.Size(292, 13);
            this.lblRetreiveDistance.TabIndex = 22;
            this.lblRetreiveDistance.Text = "Select two pairs to retrieve the DTW distance between them\r\n";
            this.lblRetreiveDistance.Visible = false;
            // 
            // txtFirstStock
            // 
            this.txtFirstStock.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtFirstStock.Location = new System.Drawing.Point(66, 252);
            this.txtFirstStock.Name = "txtFirstStock";
            this.txtFirstStock.Size = new System.Drawing.Size(100, 20);
            this.txtFirstStock.TabIndex = 23;
            this.txtFirstStock.Text = "0";
            this.txtFirstStock.Visible = false;
            // 
            // txtSecondStock
            // 
            this.txtSecondStock.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtSecondStock.Location = new System.Drawing.Point(66, 275);
            this.txtSecondStock.Name = "txtSecondStock";
            this.txtSecondStock.Size = new System.Drawing.Size(100, 20);
            this.txtSecondStock.TabIndex = 24;
            this.txtSecondStock.Text = "1";
            this.txtSecondStock.Visible = false;
            // 
            // lblFirstStock
            // 
            this.lblFirstStock.AutoSize = true;
            this.lblFirstStock.Location = new System.Drawing.Point(9, 252);
            this.lblFirstStock.Name = "lblFirstStock";
            this.lblFirstStock.Size = new System.Drawing.Size(51, 13);
            this.lblFirstStock.TabIndex = 25;
            this.lblFirstStock.Text = "Stock #1";
            this.lblFirstStock.Visible = false;
            // 
            // lblSecondStock
            // 
            this.lblSecondStock.AutoSize = true;
            this.lblSecondStock.Location = new System.Drawing.Point(9, 278);
            this.lblSecondStock.Name = "lblSecondStock";
            this.lblSecondStock.Size = new System.Drawing.Size(51, 13);
            this.lblSecondStock.TabIndex = 26;
            this.lblSecondStock.Text = "Stock #2";
            this.lblSecondStock.Visible = false;
            // 
            // btnGetDistance
            // 
            this.btnGetDistance.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnGetDistance.Location = new System.Drawing.Point(12, 301);
            this.btnGetDistance.Name = "btnGetDistance";
            this.btnGetDistance.Size = new System.Drawing.Size(154, 23);
            this.btnGetDistance.TabIndex = 27;
            this.btnGetDistance.Text = "Get Distance";
            this.btnGetDistance.UseVisualStyleBackColor = false;
            this.btnGetDistance.Visible = false;
            this.btnGetDistance.Click += new System.EventHandler(this.btnGetDistance_Click);
            // 
            // lblDistance
            // 
            this.lblDistance.AutoSize = true;
            this.lblDistance.Location = new System.Drawing.Point(12, 341);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(105, 13);
            this.lblDistance.TabIndex = 28;
            this.lblDistance.Text = "Calculated Distance:";
            this.lblDistance.Visible = false;
            // 
            // txtDistance
            // 
            this.txtDistance.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtDistance.Location = new System.Drawing.Point(126, 341);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.ReadOnly = true;
            this.txtDistance.Size = new System.Drawing.Size(172, 20);
            this.txtDistance.TabIndex = 29;
            this.txtDistance.Visible = false;
            // 
            // lblNearestNeighborIntro
            // 
            this.lblNearestNeighborIntro.AutoSize = true;
            this.lblNearestNeighborIntro.Location = new System.Drawing.Point(12, 382);
            this.lblNearestNeighborIntro.Name = "lblNearestNeighborIntro";
            this.lblNearestNeighborIntro.Size = new System.Drawing.Size(423, 13);
            this.lblNearestNeighborIntro.TabIndex = 30;
            this.lblNearestNeighborIntro.Text = "Select a pair to get its nearest neighbor with respect to the DTW distance betwee" +
    "n them";
            this.lblNearestNeighborIntro.Visible = false;
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(12, 412);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(45, 13);
            this.lblStock.TabIndex = 32;
            this.lblStock.Text = "Stock #";
            this.lblStock.Visible = false;
            // 
            // txtStock
            // 
            this.txtStock.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtStock.Location = new System.Drawing.Point(69, 412);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(100, 20);
            this.txtStock.TabIndex = 31;
            this.txtStock.Text = "0";
            this.txtStock.Visible = false;
            // 
            // btnNearestNeighbor
            // 
            this.btnNearestNeighbor.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnNearestNeighbor.Location = new System.Drawing.Point(12, 438);
            this.btnNearestNeighbor.Name = "btnNearestNeighbor";
            this.btnNearestNeighbor.Size = new System.Drawing.Size(154, 23);
            this.btnNearestNeighbor.TabIndex = 33;
            this.btnNearestNeighbor.Text = "Get Nearest Neighbour";
            this.btnNearestNeighbor.UseVisualStyleBackColor = false;
            this.btnNearestNeighbor.Visible = false;
            this.btnNearestNeighbor.Click += new System.EventHandler(this.btnNearestNeighbour_Click);
            // 
            // txtNearestNeighbour
            // 
            this.txtNearestNeighbour.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txtNearestNeighbour.Location = new System.Drawing.Point(126, 479);
            this.txtNearestNeighbour.Name = "txtNearestNeighbour";
            this.txtNearestNeighbour.ReadOnly = true;
            this.txtNearestNeighbour.Size = new System.Drawing.Size(172, 20);
            this.txtNearestNeighbour.TabIndex = 35;
            this.txtNearestNeighbour.Visible = false;
            // 
            // lblNearestNeighbor
            // 
            this.lblNearestNeighbor.AutoSize = true;
            this.lblNearestNeighbor.Location = new System.Drawing.Point(12, 479);
            this.lblNearestNeighbor.Name = "lblNearestNeighbor";
            this.lblNearestNeighbor.Size = new System.Drawing.Size(99, 13);
            this.lblNearestNeighbor.TabIndex = 34;
            this.lblNearestNeighbor.Text = "Nearest Neighbour:";
            this.lblNearestNeighbor.Visible = false;
            // 
            // numStockDays
            // 
            this.numStockDays.Location = new System.Drawing.Point(157, 111);
            this.numStockDays.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numStockDays.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numStockDays.Name = "numStockDays";
            this.numStockDays.Size = new System.Drawing.Size(41, 20);
            this.numStockDays.TabIndex = 37;
            this.numStockDays.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Days";
            // 
            // chkStockDays
            // 
            this.chkStockDays.AutoSize = true;
            this.chkStockDays.Location = new System.Drawing.Point(12, 111);
            this.chkStockDays.Name = "chkStockDays";
            this.chkStockDays.Size = new System.Drawing.Size(139, 17);
            this.chkStockDays.TabIndex = 39;
            this.chkStockDays.Text = "Use stocks from the last";
            this.chkStockDays.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Number of threads to use: ";
            // 
            // numWorkers
            // 
            this.numWorkers.Location = new System.Drawing.Point(157, 138);
            this.numWorkers.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numWorkers.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWorkers.Name = "numWorkers";
            this.numWorkers.Size = new System.Drawing.Size(41, 20);
            this.numWorkers.TabIndex = 41;
            this.numWorkers.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(9, 164);
            this.pbProgress.Maximum = 2940;
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(498, 23);
            this.pbProgress.TabIndex = 42;
            // 
            // Miner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 508);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.numWorkers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkStockDays);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numStockDays);
            this.Controls.Add(this.txtNearestNeighbour);
            this.Controls.Add(this.lblNearestNeighbor);
            this.Controls.Add(this.btnNearestNeighbor);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.lblNearestNeighborIntro);
            this.Controls.Add(this.txtDistance);
            this.Controls.Add(this.lblDistance);
            this.Controls.Add(this.btnGetDistance);
            this.Controls.Add(this.lblSecondStock);
            this.Controls.Add(this.lblFirstStock);
            this.Controls.Add(this.txtSecondStock);
            this.Controls.Add(this.txtFirstStock);
            this.Controls.Add(this.lblRetreiveDistance);
            this.Controls.Add(this.lblLineCount);
            this.Controls.Add(this.lblLineCountIntro);
            this.Controls.Add(this.txtBrowse);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.lblIntro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Miner";
            this.ShowInTaskbar = false;
            this.Text = "Miner";
            ((System.ComponentModel.ISupportInitialize)(this.numStockDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWorkers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIntro;
        private System.Windows.Forms.Label lblLineCount;
        private System.Windows.Forms.Label lblLineCountIntro;
        private System.Windows.Forms.TextBox txtBrowse;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblRetreiveDistance;
        private System.Windows.Forms.TextBox txtFirstStock;
        private System.Windows.Forms.TextBox txtSecondStock;
        private System.Windows.Forms.Label lblFirstStock;
        private System.Windows.Forms.Label lblSecondStock;
        private System.Windows.Forms.Button btnGetDistance;
        private System.Windows.Forms.Label lblDistance;
        private System.Windows.Forms.TextBox txtDistance;
        private System.Windows.Forms.Label lblNearestNeighborIntro;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Button btnNearestNeighbor;
        private System.Windows.Forms.TextBox txtNearestNeighbour;
        private System.Windows.Forms.Label lblNearestNeighbor;
        private System.Windows.Forms.NumericUpDown numStockDays;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkStockDays;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numWorkers;
        private System.Windows.Forms.ProgressBar pbProgress;
    }
}