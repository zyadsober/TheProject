namespace Pairs_Trading.Forms
{
    partial class Monitor
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Monitor));
            this.lblStockCount = new System.Windows.Forms.Label();
            this.lblLineCountIntro = new System.Windows.Forms.Label();
            this.txtBrowse = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblIntro = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnMonitor = new System.Windows.Forms.Button();
            this.lblSecondStock = new System.Windows.Forms.Label();
            this.lblFirstStock = new System.Windows.Forms.Label();
            this.txtSecondStock = new System.Windows.Forms.TextBox();
            this.txtFirstStock = new System.Windows.Forms.TextBox();
            this.numDays = new System.Windows.Forms.NumericUpDown();
            this.lblDays = new System.Windows.Forms.Label();
            this.numThreshold = new System.Windows.Forms.NumericUpDown();
            this.lblThreshold = new System.Windows.Forms.Label();
            this.timerMonitor = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThreshold)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStockCount
            // 
            this.lblStockCount.AutoSize = true;
            this.lblStockCount.Location = new System.Drawing.Point(88, 89);
            this.lblStockCount.Name = "lblStockCount";
            this.lblStockCount.Size = new System.Drawing.Size(67, 13);
            this.lblStockCount.TabIndex = 26;
            this.lblStockCount.Text = "_stockCount";
            this.lblStockCount.Visible = false;
            // 
            // lblLineCountIntro
            // 
            this.lblLineCountIntro.AutoSize = true;
            this.lblLineCountIntro.Location = new System.Drawing.Point(12, 89);
            this.lblLineCountIntro.Name = "lblLineCountIntro";
            this.lblLineCountIntro.Size = new System.Drawing.Size(76, 13);
            this.lblLineCountIntro.TabIndex = 25;
            this.lblLineCountIntro.Text = "Stocks found: ";
            this.lblLineCountIntro.Visible = false;
            // 
            // txtBrowse
            // 
            this.txtBrowse.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtBrowse.Location = new System.Drawing.Point(15, 62);
            this.txtBrowse.Name = "txtBrowse";
            this.txtBrowse.ReadOnly = true;
            this.txtBrowse.Size = new System.Drawing.Size(420, 20);
            this.txtBrowse.TabIndex = 24;
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnBrowse.Location = new System.Drawing.Point(441, 62);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 23;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblIntro
            // 
            this.lblIntro.AutoSize = true;
            this.lblIntro.Location = new System.Drawing.Point(12, 9);
            this.lblIntro.Name = "lblIntro";
            this.lblIntro.Size = new System.Drawing.Size(388, 39);
            this.lblIntro.TabIndex = 22;
            this.lblIntro.Text = "This is a tool to monitor found pairs using downloaded and processed stock data.\r" +
    "\n\r\nBrowse for a folder containing the data to be monitored.\r\n";
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.SystemColors.Control;
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(272, 252);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(606, 235);
            this.chart1.TabIndex = 27;
            this.chart1.Text = "chart1";
            // 
            // btnMonitor
            // 
            this.btnMonitor.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnMonitor.Location = new System.Drawing.Point(15, 236);
            this.btnMonitor.Name = "btnMonitor";
            this.btnMonitor.Size = new System.Drawing.Size(220, 23);
            this.btnMonitor.TabIndex = 32;
            this.btnMonitor.Text = "Monitor";
            this.btnMonitor.UseVisualStyleBackColor = false;
            this.btnMonitor.Visible = false;
            this.btnMonitor.Click += new System.EventHandler(this.btnMonitor_Click);
            // 
            // lblSecondStock
            // 
            this.lblSecondStock.AutoSize = true;
            this.lblSecondStock.Location = new System.Drawing.Point(12, 144);
            this.lblSecondStock.Name = "lblSecondStock";
            this.lblSecondStock.Size = new System.Drawing.Size(51, 13);
            this.lblSecondStock.TabIndex = 31;
            this.lblSecondStock.Text = "Stock #2";
            this.lblSecondStock.Visible = false;
            // 
            // lblFirstStock
            // 
            this.lblFirstStock.AutoSize = true;
            this.lblFirstStock.Location = new System.Drawing.Point(12, 118);
            this.lblFirstStock.Name = "lblFirstStock";
            this.lblFirstStock.Size = new System.Drawing.Size(51, 13);
            this.lblFirstStock.TabIndex = 30;
            this.lblFirstStock.Text = "Stock #1";
            this.lblFirstStock.Visible = false;
            // 
            // txtSecondStock
            // 
            this.txtSecondStock.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtSecondStock.Location = new System.Drawing.Point(69, 141);
            this.txtSecondStock.Name = "txtSecondStock";
            this.txtSecondStock.Size = new System.Drawing.Size(100, 20);
            this.txtSecondStock.TabIndex = 29;
            this.txtSecondStock.Text = "1";
            this.txtSecondStock.Visible = false;
            // 
            // txtFirstStock
            // 
            this.txtFirstStock.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtFirstStock.Location = new System.Drawing.Point(69, 118);
            this.txtFirstStock.Name = "txtFirstStock";
            this.txtFirstStock.Size = new System.Drawing.Size(100, 20);
            this.txtFirstStock.TabIndex = 28;
            this.txtFirstStock.Text = "0";
            this.txtFirstStock.Visible = false;
            // 
            // numDays
            // 
            this.numDays.Location = new System.Drawing.Point(201, 173);
            this.numDays.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numDays.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDays.Name = "numDays";
            this.numDays.Size = new System.Drawing.Size(55, 20);
            this.numDays.TabIndex = 50;
            this.numDays.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDays.Visible = false;
            // 
            // lblDays
            // 
            this.lblDays.AutoSize = true;
            this.lblDays.Location = new System.Drawing.Point(12, 173);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(183, 13);
            this.lblDays.TabIndex = 49;
            this.lblDays.Text = "Start Monitoring after this many days: \r\n";
            this.lblDays.Visible = false;
            // 
            // numThreshold
            // 
            this.numThreshold.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numThreshold.Location = new System.Drawing.Point(201, 196);
            this.numThreshold.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numThreshold.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numThreshold.Name = "numThreshold";
            this.numThreshold.Size = new System.Drawing.Size(55, 20);
            this.numThreshold.TabIndex = 52;
            this.numThreshold.Visible = false;
            // 
            // lblThreshold
            // 
            this.lblThreshold.AutoSize = true;
            this.lblThreshold.Location = new System.Drawing.Point(12, 196);
            this.lblThreshold.Name = "lblThreshold";
            this.lblThreshold.Size = new System.Drawing.Size(106, 13);
            this.lblThreshold.TabIndex = 51;
            this.lblThreshold.Text = "Correlation threshold:\r\n";
            this.lblThreshold.Visible = false;
            // 
            // timerMonitor
            // 
            this.timerMonitor.Interval = 50;
            this.timerMonitor.Tick += new System.EventHandler(this.timerMonitor_Tick);
            // 
            // Monitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 499);
            this.Controls.Add(this.numThreshold);
            this.Controls.Add(this.lblThreshold);
            this.Controls.Add(this.numDays);
            this.Controls.Add(this.lblDays);
            this.Controls.Add(this.btnMonitor);
            this.Controls.Add(this.lblSecondStock);
            this.Controls.Add(this.lblFirstStock);
            this.Controls.Add(this.txtSecondStock);
            this.Controls.Add(this.txtFirstStock);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.lblStockCount);
            this.Controls.Add(this.lblLineCountIntro);
            this.Controls.Add(this.txtBrowse);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.lblIntro);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Monitor";
            this.Text = "Monitor";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThreshold)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStockCount;
        private System.Windows.Forms.Label lblLineCountIntro;
        private System.Windows.Forms.TextBox txtBrowse;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblIntro;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btnMonitor;
        private System.Windows.Forms.Label lblSecondStock;
        private System.Windows.Forms.Label lblFirstStock;
        private System.Windows.Forms.TextBox txtSecondStock;
        private System.Windows.Forms.TextBox txtFirstStock;
        private System.Windows.Forms.NumericUpDown numDays;
        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.NumericUpDown numThreshold;
        private System.Windows.Forms.Label lblThreshold;
        private System.Windows.Forms.Timer timerMonitor;
    }
}