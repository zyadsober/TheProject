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
            this.lblRetreiveDistance.Location = new System.Drawing.Point(12, 125);
            this.lblRetreiveDistance.Name = "lblRetreiveDistance";
            this.lblRetreiveDistance.Size = new System.Drawing.Size(292, 13);
            this.lblRetreiveDistance.TabIndex = 22;
            this.lblRetreiveDistance.Text = "Select two pairs to retrieve the DTW distance between them\r\n";
            this.lblRetreiveDistance.Visible = false;
            // 
            // txtFirstStock
            // 
            this.txtFirstStock.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtFirstStock.Location = new System.Drawing.Point(72, 152);
            this.txtFirstStock.Name = "txtFirstStock";
            this.txtFirstStock.Size = new System.Drawing.Size(100, 20);
            this.txtFirstStock.TabIndex = 23;
            this.txtFirstStock.Text = "0";
            this.txtFirstStock.Visible = false;
            // 
            // txtSecondStock
            // 
            this.txtSecondStock.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtSecondStock.Location = new System.Drawing.Point(72, 175);
            this.txtSecondStock.Name = "txtSecondStock";
            this.txtSecondStock.Size = new System.Drawing.Size(100, 20);
            this.txtSecondStock.TabIndex = 24;
            this.txtSecondStock.Text = "1";
            this.txtSecondStock.Visible = false;
            // 
            // lblFirstStock
            // 
            this.lblFirstStock.AutoSize = true;
            this.lblFirstStock.Location = new System.Drawing.Point(15, 152);
            this.lblFirstStock.Name = "lblFirstStock";
            this.lblFirstStock.Size = new System.Drawing.Size(51, 13);
            this.lblFirstStock.TabIndex = 25;
            this.lblFirstStock.Text = "Stock #1";
            this.lblFirstStock.Visible = false;
            // 
            // lblSecondStock
            // 
            this.lblSecondStock.AutoSize = true;
            this.lblSecondStock.Location = new System.Drawing.Point(15, 178);
            this.lblSecondStock.Name = "lblSecondStock";
            this.lblSecondStock.Size = new System.Drawing.Size(51, 13);
            this.lblSecondStock.TabIndex = 26;
            this.lblSecondStock.Text = "Stock #2";
            this.lblSecondStock.Visible = false;
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
            this.btnGetDistance.Visible = false;
            this.btnGetDistance.Click += new System.EventHandler(this.btnGetDistance_Click);
            // 
            // lblDistance
            // 
            this.lblDistance.AutoSize = true;
            this.lblDistance.Location = new System.Drawing.Point(18, 241);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(105, 13);
            this.lblDistance.TabIndex = 28;
            this.lblDistance.Text = "Calculated Distance:";
            this.lblDistance.Visible = false;
            // 
            // txtDistance
            // 
            this.txtDistance.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtDistance.Location = new System.Drawing.Point(132, 241);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.ReadOnly = true;
            this.txtDistance.Size = new System.Drawing.Size(172, 20);
            this.txtDistance.TabIndex = 29;
            this.txtDistance.Visible = false;
            // 
            // lblNearestNeighborIntro
            // 
            this.lblNearestNeighborIntro.AutoSize = true;
            this.lblNearestNeighborIntro.Location = new System.Drawing.Point(18, 282);
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
            this.lblStock.Location = new System.Drawing.Point(18, 312);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(45, 13);
            this.lblStock.TabIndex = 32;
            this.lblStock.Text = "Stock #";
            this.lblStock.Visible = false;
            // 
            // txtStock
            // 
            this.txtStock.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtStock.Location = new System.Drawing.Point(75, 312);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(100, 20);
            this.txtStock.TabIndex = 31;
            this.txtStock.Text = "0";
            this.txtStock.Visible = false;
            // 
            // btnNearestNeighbor
            // 
            this.btnNearestNeighbor.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnNearestNeighbor.Location = new System.Drawing.Point(18, 338);
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
            this.txtNearestNeighbour.Location = new System.Drawing.Point(132, 379);
            this.txtNearestNeighbour.Name = "txtNearestNeighbour";
            this.txtNearestNeighbour.ReadOnly = true;
            this.txtNearestNeighbour.Size = new System.Drawing.Size(172, 20);
            this.txtNearestNeighbour.TabIndex = 35;
            this.txtNearestNeighbour.Visible = false;
            // 
            // lblNearestNeighbor
            // 
            this.lblNearestNeighbor.AutoSize = true;
            this.lblNearestNeighbor.Location = new System.Drawing.Point(18, 379);
            this.lblNearestNeighbor.Name = "lblNearestNeighbor";
            this.lblNearestNeighbor.Size = new System.Drawing.Size(99, 13);
            this.lblNearestNeighbor.TabIndex = 34;
            this.lblNearestNeighbor.Text = "Nearest Neighbour:";
            this.lblNearestNeighbor.Visible = false;
            // 
            // Miner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 444);
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
    }
}