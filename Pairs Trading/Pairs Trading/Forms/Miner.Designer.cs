﻿namespace Pairs_Trading.Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Miner));
            this.lblIntro = new System.Windows.Forms.Label();
            this.lblStockCount = new System.Windows.Forms.Label();
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
            this.cboxDistanceMeasure = new System.Windows.Forms.ComboBox();
            this.lblDistanceMeasure = new System.Windows.Forms.Label();
            this.lblDTWWindow = new System.Windows.Forms.Label();
            this.numDTWWindow = new System.Windows.Forms.NumericUpDown();
            this.btnGetCorrelation = new System.Windows.Forms.Button();
            this.txtCorrelation = new System.Windows.Forms.TextBox();
            this.lblCorrelation = new System.Windows.Forms.Label();
            this.btnAllNearestNeighbors = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numStockDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWorkers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDTWWindow)).BeginInit();
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
            // lblStockCount
            // 
            this.lblStockCount.AutoSize = true;
            this.lblStockCount.Location = new System.Drawing.Point(85, 89);
            this.lblStockCount.Name = "lblStockCount";
            this.lblStockCount.Size = new System.Drawing.Size(67, 13);
            this.lblStockCount.TabIndex = 21;
            this.lblStockCount.Text = "_stockCount";
            this.lblStockCount.Visible = false;
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
            this.lblRetreiveDistance.Location = new System.Drawing.Point(9, 186);
            this.lblRetreiveDistance.Name = "lblRetreiveDistance";
            this.lblRetreiveDistance.Size = new System.Drawing.Size(292, 13);
            this.lblRetreiveDistance.TabIndex = 22;
            this.lblRetreiveDistance.Text = "Select two pairs to retrieve the DTW distance between them\r\n";
            this.lblRetreiveDistance.Visible = false;
            // 
            // txtFirstStock
            // 
            this.txtFirstStock.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtFirstStock.Location = new System.Drawing.Point(69, 213);
            this.txtFirstStock.Name = "txtFirstStock";
            this.txtFirstStock.Size = new System.Drawing.Size(100, 20);
            this.txtFirstStock.TabIndex = 23;
            this.txtFirstStock.Text = "0";
            this.txtFirstStock.Visible = false;
            // 
            // txtSecondStock
            // 
            this.txtSecondStock.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtSecondStock.Location = new System.Drawing.Point(69, 236);
            this.txtSecondStock.Name = "txtSecondStock";
            this.txtSecondStock.Size = new System.Drawing.Size(100, 20);
            this.txtSecondStock.TabIndex = 24;
            this.txtSecondStock.Text = "1";
            this.txtSecondStock.Visible = false;
            // 
            // lblFirstStock
            // 
            this.lblFirstStock.AutoSize = true;
            this.lblFirstStock.Location = new System.Drawing.Point(12, 213);
            this.lblFirstStock.Name = "lblFirstStock";
            this.lblFirstStock.Size = new System.Drawing.Size(51, 13);
            this.lblFirstStock.TabIndex = 25;
            this.lblFirstStock.Text = "Stock #1";
            this.lblFirstStock.Visible = false;
            // 
            // lblSecondStock
            // 
            this.lblSecondStock.AutoSize = true;
            this.lblSecondStock.Location = new System.Drawing.Point(12, 239);
            this.lblSecondStock.Name = "lblSecondStock";
            this.lblSecondStock.Size = new System.Drawing.Size(51, 13);
            this.lblSecondStock.TabIndex = 26;
            this.lblSecondStock.Text = "Stock #2";
            this.lblSecondStock.Visible = false;
            // 
            // btnGetDistance
            // 
            this.btnGetDistance.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnGetDistance.Location = new System.Drawing.Point(15, 262);
            this.btnGetDistance.Name = "btnGetDistance";
            this.btnGetDistance.Size = new System.Drawing.Size(220, 23);
            this.btnGetDistance.TabIndex = 27;
            this.btnGetDistance.Text = "Get DTW Distance";
            this.btnGetDistance.UseVisualStyleBackColor = false;
            this.btnGetDistance.Visible = false;
            this.btnGetDistance.Click += new System.EventHandler(this.btnGetDistance_Click);
            // 
            // lblDistance
            // 
            this.lblDistance.AutoSize = true;
            this.lblDistance.Location = new System.Drawing.Point(15, 302);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(105, 13);
            this.lblDistance.TabIndex = 28;
            this.lblDistance.Text = "Calculated Distance:";
            this.lblDistance.Visible = false;
            // 
            // txtDistance
            // 
            this.txtDistance.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtDistance.Location = new System.Drawing.Point(129, 302);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.ReadOnly = true;
            this.txtDistance.Size = new System.Drawing.Size(172, 20);
            this.txtDistance.TabIndex = 29;
            this.txtDistance.Visible = false;
            // 
            // lblNearestNeighborIntro
            // 
            this.lblNearestNeighborIntro.AutoSize = true;
            this.lblNearestNeighborIntro.Location = new System.Drawing.Point(15, 343);
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
            this.lblStock.Location = new System.Drawing.Point(15, 373);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(45, 13);
            this.lblStock.TabIndex = 32;
            this.lblStock.Text = "Stock #";
            this.lblStock.Visible = false;
            // 
            // txtStock
            // 
            this.txtStock.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtStock.Location = new System.Drawing.Point(72, 373);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(100, 20);
            this.txtStock.TabIndex = 31;
            this.txtStock.Text = "0";
            this.txtStock.Visible = false;
            // 
            // btnNearestNeighbor
            // 
            this.btnNearestNeighbor.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnNearestNeighbor.Location = new System.Drawing.Point(15, 399);
            this.btnNearestNeighbor.Name = "btnNearestNeighbor";
            this.btnNearestNeighbor.Size = new System.Drawing.Size(220, 23);
            this.btnNearestNeighbor.TabIndex = 33;
            this.btnNearestNeighbor.Text = "Get Nearest Neighbour (DTW)";
            this.btnNearestNeighbor.UseVisualStyleBackColor = false;
            this.btnNearestNeighbor.Visible = false;
            this.btnNearestNeighbor.Click += new System.EventHandler(this.btnNearestNeighbour_Click);
            // 
            // txtNearestNeighbour
            // 
            this.txtNearestNeighbour.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txtNearestNeighbour.Location = new System.Drawing.Point(129, 440);
            this.txtNearestNeighbour.Name = "txtNearestNeighbour";
            this.txtNearestNeighbour.ReadOnly = true;
            this.txtNearestNeighbour.Size = new System.Drawing.Size(172, 20);
            this.txtNearestNeighbour.TabIndex = 35;
            this.txtNearestNeighbour.Visible = false;
            // 
            // lblNearestNeighbor
            // 
            this.lblNearestNeighbor.AutoSize = true;
            this.lblNearestNeighbor.Location = new System.Drawing.Point(15, 440);
            this.lblNearestNeighbor.Name = "lblNearestNeighbor";
            this.lblNearestNeighbor.Size = new System.Drawing.Size(99, 13);
            this.lblNearestNeighbor.TabIndex = 34;
            this.lblNearestNeighbor.Text = "Nearest Neighbour:";
            this.lblNearestNeighbor.Visible = false;
            // 
            // numStockDays
            // 
            this.numStockDays.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.numStockDays.Location = new System.Drawing.Point(157, 136);
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
            this.label2.Location = new System.Drawing.Point(204, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Days";
            // 
            // chkStockDays
            // 
            this.chkStockDays.AutoSize = true;
            this.chkStockDays.Location = new System.Drawing.Point(12, 136);
            this.chkStockDays.Name = "chkStockDays";
            this.chkStockDays.Size = new System.Drawing.Size(139, 17);
            this.chkStockDays.TabIndex = 39;
            this.chkStockDays.Text = "Use stocks from the last";
            this.chkStockDays.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(337, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Number of threads to use: ";
            this.label1.Visible = false;
            // 
            // numWorkers
            // 
            this.numWorkers.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.numWorkers.Location = new System.Drawing.Point(482, 146);
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
            this.numWorkers.Visible = false;
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(12, 488);
            this.pbProgress.Maximum = 2940;
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(498, 23);
            this.pbProgress.TabIndex = 42;
            this.pbProgress.Visible = false;
            // 
            // cboxDistanceMeasure
            // 
            this.cboxDistanceMeasure.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.cboxDistanceMeasure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxDistanceMeasure.FormattingEnabled = true;
            this.cboxDistanceMeasure.Items.AddRange(new object[] {
            "DTW",
            "Euclidean"});
            this.cboxDistanceMeasure.Location = new System.Drawing.Point(217, 106);
            this.cboxDistanceMeasure.Name = "cboxDistanceMeasure";
            this.cboxDistanceMeasure.Size = new System.Drawing.Size(121, 21);
            this.cboxDistanceMeasure.TabIndex = 43;
            this.cboxDistanceMeasure.Visible = false;
            this.cboxDistanceMeasure.SelectedIndexChanged += new System.EventHandler(this.cboxDistanceMeasure_SelectedIndexChanged);
            // 
            // lblDistanceMeasure
            // 
            this.lblDistanceMeasure.AutoSize = true;
            this.lblDistanceMeasure.Location = new System.Drawing.Point(12, 109);
            this.lblDistanceMeasure.Name = "lblDistanceMeasure";
            this.lblDistanceMeasure.Size = new System.Drawing.Size(199, 13);
            this.lblDistanceMeasure.TabIndex = 44;
            this.lblDistanceMeasure.Text = "Select a distance measurement method: ";
            this.lblDistanceMeasure.Visible = false;
            // 
            // lblDTWWindow
            // 
            this.lblDTWWindow.AutoSize = true;
            this.lblDTWWindow.Location = new System.Drawing.Point(12, 162);
            this.lblDTWWindow.Name = "lblDTWWindow";
            this.lblDTWWindow.Size = new System.Drawing.Size(99, 13);
            this.lblDTWWindow.TabIndex = 45;
            this.lblDTWWindow.Text = "DTW Window size:";
            this.lblDTWWindow.Visible = false;
            // 
            // numDTWWindow
            // 
            this.numDTWWindow.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.numDTWWindow.Location = new System.Drawing.Point(157, 160);
            this.numDTWWindow.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numDTWWindow.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDTWWindow.Name = "numDTWWindow";
            this.numDTWWindow.Size = new System.Drawing.Size(41, 20);
            this.numDTWWindow.TabIndex = 46;
            this.numDTWWindow.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDTWWindow.Visible = false;
            // 
            // btnGetCorrelation
            // 
            this.btnGetCorrelation.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnGetCorrelation.Location = new System.Drawing.Point(318, 262);
            this.btnGetCorrelation.Name = "btnGetCorrelation";
            this.btnGetCorrelation.Size = new System.Drawing.Size(220, 23);
            this.btnGetCorrelation.TabIndex = 47;
            this.btnGetCorrelation.Text = "Get Correlation";
            this.btnGetCorrelation.UseVisualStyleBackColor = false;
            this.btnGetCorrelation.Visible = false;
            this.btnGetCorrelation.Click += new System.EventHandler(this.btnGetCorrelation_Click);
            // 
            // txtCorrelation
            // 
            this.txtCorrelation.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtCorrelation.Location = new System.Drawing.Point(429, 302);
            this.txtCorrelation.Name = "txtCorrelation";
            this.txtCorrelation.ReadOnly = true;
            this.txtCorrelation.Size = new System.Drawing.Size(172, 20);
            this.txtCorrelation.TabIndex = 49;
            this.txtCorrelation.Visible = false;
            // 
            // lblCorrelation
            // 
            this.lblCorrelation.AutoSize = true;
            this.lblCorrelation.Location = new System.Drawing.Point(315, 302);
            this.lblCorrelation.Name = "lblCorrelation";
            this.lblCorrelation.Size = new System.Drawing.Size(113, 13);
            this.lblCorrelation.TabIndex = 48;
            this.lblCorrelation.Text = "Calculated Correlation:";
            this.lblCorrelation.Visible = false;
            // 
            // btnAllNearestNeighbors
            // 
            this.btnAllNearestNeighbors.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAllNearestNeighbors.Location = new System.Drawing.Point(303, 399);
            this.btnAllNearestNeighbors.Name = "btnAllNearestNeighbors";
            this.btnAllNearestNeighbors.Size = new System.Drawing.Size(220, 23);
            this.btnAllNearestNeighbors.TabIndex = 50;
            this.btnAllNearestNeighbors.Text = "Get All Nearest Neighbours (DTW)";
            this.btnAllNearestNeighbors.UseVisualStyleBackColor = false;
            this.btnAllNearestNeighbors.Visible = false;
            this.btnAllNearestNeighbors.Click += new System.EventHandler(this.btnGetAllNearestNeighbors_Click);
            // 
            // Miner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.ClientSize = new System.Drawing.Size(615, 525);
            this.Controls.Add(this.btnAllNearestNeighbors);
            this.Controls.Add(this.txtCorrelation);
            this.Controls.Add(this.lblCorrelation);
            this.Controls.Add(this.btnGetCorrelation);
            this.Controls.Add(this.numDTWWindow);
            this.Controls.Add(this.lblDTWWindow);
            this.Controls.Add(this.lblDistanceMeasure);
            this.Controls.Add(this.cboxDistanceMeasure);
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
            this.Controls.Add(this.lblStockCount);
            this.Controls.Add(this.lblLineCountIntro);
            this.Controls.Add(this.txtBrowse);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.lblIntro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Miner";
            this.ShowInTaskbar = false;
            this.Text = "Miner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Miner_FormClosing);
            this.Load += new System.EventHandler(this.Miner_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numStockDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWorkers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDTWWindow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIntro;
        private System.Windows.Forms.Label lblStockCount;
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
        private System.Windows.Forms.ComboBox cboxDistanceMeasure;
        private System.Windows.Forms.Label lblDistanceMeasure;
        private System.Windows.Forms.Label lblDTWWindow;
        private System.Windows.Forms.NumericUpDown numDTWWindow;
        private System.Windows.Forms.Button btnGetCorrelation;
        private System.Windows.Forms.TextBox txtCorrelation;
        private System.Windows.Forms.Label lblCorrelation;
        private System.Windows.Forms.Button btnAllNearestNeighbors;
    }
}