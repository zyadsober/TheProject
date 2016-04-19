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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
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
            this.numCorrelationThreshold = new System.Windows.Forms.NumericUpDown();
            this.lblCorrelationThreshold = new System.Windows.Forms.Label();
            this.timerMonitor = new System.Windows.Forms.Timer(this.components);
            this.lblOutput = new System.Windows.Forms.Label();
            this.txtOutput1 = new System.Windows.Forms.TextBox();
            this.numWindow = new System.Windows.Forms.NumericUpDown();
            this.lblWindow = new System.Windows.Forms.Label();
            this.lblSTDThreshold = new System.Windows.Forms.Label();
            this.numSTDThreshold = new System.Windows.Forms.NumericUpDown();
            this.txtOutput2 = new System.Windows.Forms.TextBox();
            this.lblMonitorMethod = new System.Windows.Forms.Label();
            this.cboxMonitorMethod = new System.Windows.Forms.ComboBox();
            this.txtMean = new System.Windows.Forms.TextBox();
            this.lblMean = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCorrelationThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWindow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSTDThreshold)).BeginInit();
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
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(288, 252);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(606, 235);
            this.chart1.TabIndex = 27;
            this.chart1.Text = "chart1";
            // 
            // btnMonitor
            // 
            this.btnMonitor.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnMonitor.Location = new System.Drawing.Point(16, 275);
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
            this.lblSecondStock.Location = new System.Drawing.Point(12, 139);
            this.lblSecondStock.Name = "lblSecondStock";
            this.lblSecondStock.Size = new System.Drawing.Size(51, 13);
            this.lblSecondStock.TabIndex = 31;
            this.lblSecondStock.Text = "Stock #2";
            this.lblSecondStock.Visible = false;
            // 
            // lblFirstStock
            // 
            this.lblFirstStock.AutoSize = true;
            this.lblFirstStock.Location = new System.Drawing.Point(12, 113);
            this.lblFirstStock.Name = "lblFirstStock";
            this.lblFirstStock.Size = new System.Drawing.Size(51, 13);
            this.lblFirstStock.TabIndex = 30;
            this.lblFirstStock.Text = "Stock #1";
            this.lblFirstStock.Visible = false;
            // 
            // txtSecondStock
            // 
            this.txtSecondStock.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtSecondStock.Location = new System.Drawing.Point(69, 136);
            this.txtSecondStock.Name = "txtSecondStock";
            this.txtSecondStock.Size = new System.Drawing.Size(100, 20);
            this.txtSecondStock.TabIndex = 29;
            this.txtSecondStock.Text = "1";
            this.txtSecondStock.Visible = false;
            // 
            // txtFirstStock
            // 
            this.txtFirstStock.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtFirstStock.Location = new System.Drawing.Point(69, 113);
            this.txtFirstStock.Name = "txtFirstStock";
            this.txtFirstStock.Size = new System.Drawing.Size(100, 20);
            this.txtFirstStock.TabIndex = 28;
            this.txtFirstStock.Text = "0";
            this.txtFirstStock.Visible = false;
            // 
            // numDays
            // 
            this.numDays.Location = new System.Drawing.Point(226, 196);
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
            this.lblDays.Location = new System.Drawing.Point(13, 196);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(207, 13);
            this.lblDays.TabIndex = 49;
            this.lblDays.Text = "Monitor using with a window size(days) of: ";
            this.lblDays.Visible = false;
            // 
            // numCorrelationThreshold
            // 
            this.numCorrelationThreshold.DecimalPlaces = 2;
            this.numCorrelationThreshold.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numCorrelationThreshold.Location = new System.Drawing.Point(202, 249);
            this.numCorrelationThreshold.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCorrelationThreshold.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numCorrelationThreshold.Name = "numCorrelationThreshold";
            this.numCorrelationThreshold.Size = new System.Drawing.Size(55, 20);
            this.numCorrelationThreshold.TabIndex = 52;
            this.numCorrelationThreshold.Visible = false;
            // 
            // lblCorrelationThreshold
            // 
            this.lblCorrelationThreshold.AutoSize = true;
            this.lblCorrelationThreshold.Location = new System.Drawing.Point(13, 249);
            this.lblCorrelationThreshold.Name = "lblCorrelationThreshold";
            this.lblCorrelationThreshold.Size = new System.Drawing.Size(106, 13);
            this.lblCorrelationThreshold.TabIndex = 51;
            this.lblCorrelationThreshold.Text = "Correlation threshold:\r\n";
            this.lblCorrelationThreshold.Visible = false;
            // 
            // timerMonitor
            // 
            this.timerMonitor.Interval = 50;
            this.timerMonitor.Tick += new System.EventHandler(this.timerMonitor_Tick);
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(13, 301);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(100, 13);
            this.lblOutput.TabIndex = 53;
            this.lblOutput.Text = "Current Correlation: ";
            this.lblOutput.Visible = false;
            // 
            // txtOutput1
            // 
            this.txtOutput1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtOutput1.Location = new System.Drawing.Point(157, 301);
            this.txtOutput1.Name = "txtOutput1";
            this.txtOutput1.Size = new System.Drawing.Size(100, 20);
            this.txtOutput1.TabIndex = 54;
            this.txtOutput1.Text = "0";
            this.txtOutput1.Visible = false;
            // 
            // numWindow
            // 
            this.numWindow.Location = new System.Drawing.Point(230, 221);
            this.numWindow.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numWindow.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWindow.Name = "numWindow";
            this.numWindow.Size = new System.Drawing.Size(55, 20);
            this.numWindow.TabIndex = 56;
            this.numWindow.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWindow.Visible = false;
            // 
            // lblWindow
            // 
            this.lblWindow.AutoSize = true;
            this.lblWindow.Location = new System.Drawing.Point(13, 221);
            this.lblWindow.Name = "lblWindow";
            this.lblWindow.Size = new System.Drawing.Size(211, 13);
            this.lblWindow.TabIndex = 55;
            this.lblWindow.Text = "Calculate correlation within this many days: ";
            this.lblWindow.Visible = false;
            // 
            // lblSTDThreshold
            // 
            this.lblSTDThreshold.AutoSize = true;
            this.lblSTDThreshold.Location = new System.Drawing.Point(13, 196);
            this.lblSTDThreshold.Name = "lblSTDThreshold";
            this.lblSTDThreshold.Size = new System.Drawing.Size(79, 13);
            this.lblSTDThreshold.TabIndex = 57;
            this.lblSTDThreshold.Text = "STD Threshold";
            this.lblSTDThreshold.Visible = false;
            // 
            // numSTDThreshold
            // 
            this.numSTDThreshold.DecimalPlaces = 2;
            this.numSTDThreshold.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numSTDThreshold.Location = new System.Drawing.Point(107, 194);
            this.numSTDThreshold.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numSTDThreshold.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numSTDThreshold.Name = "numSTDThreshold";
            this.numSTDThreshold.Size = new System.Drawing.Size(55, 20);
            this.numSTDThreshold.TabIndex = 58;
            this.numSTDThreshold.Visible = false;
            // 
            // txtOutput2
            // 
            this.txtOutput2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtOutput2.Location = new System.Drawing.Point(157, 327);
            this.txtOutput2.Name = "txtOutput2";
            this.txtOutput2.Size = new System.Drawing.Size(100, 20);
            this.txtOutput2.TabIndex = 59;
            this.txtOutput2.Text = "0";
            this.txtOutput2.Visible = false;
            // 
            // lblMonitorMethod
            // 
            this.lblMonitorMethod.AutoSize = true;
            this.lblMonitorMethod.Location = new System.Drawing.Point(13, 168);
            this.lblMonitorMethod.Name = "lblMonitorMethod";
            this.lblMonitorMethod.Size = new System.Drawing.Size(141, 13);
            this.lblMonitorMethod.TabIndex = 61;
            this.lblMonitorMethod.Text = "Select a monitoring method: ";
            this.lblMonitorMethod.Visible = false;
            // 
            // cboxMonitorMethod
            // 
            this.cboxMonitorMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxMonitorMethod.FormattingEnabled = true;
            this.cboxMonitorMethod.Items.AddRange(new object[] {
            "Correlation",
            "STD"});
            this.cboxMonitorMethod.Location = new System.Drawing.Point(160, 165);
            this.cboxMonitorMethod.Name = "cboxMonitorMethod";
            this.cboxMonitorMethod.Size = new System.Drawing.Size(121, 21);
            this.cboxMonitorMethod.TabIndex = 60;
            this.cboxMonitorMethod.Visible = false;
            this.cboxMonitorMethod.SelectedIndexChanged += new System.EventHandler(this.cboxMonitorMethod_SelectedIndexChanged);
            // 
            // txtMean
            // 
            this.txtMean.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtMean.Location = new System.Drawing.Point(156, 357);
            this.txtMean.Name = "txtMean";
            this.txtMean.Size = new System.Drawing.Size(100, 20);
            this.txtMean.TabIndex = 63;
            this.txtMean.Text = "0";
            this.txtMean.Visible = false;
            // 
            // lblMean
            // 
            this.lblMean.AutoSize = true;
            this.lblMean.Location = new System.Drawing.Point(12, 357);
            this.lblMean.Name = "lblMean";
            this.lblMean.Size = new System.Drawing.Size(77, 13);
            this.lblMean.TabIndex = 62;
            this.lblMean.Text = "Current Mean: ";
            this.lblMean.Visible = false;
            // 
            // Monitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 499);
            this.Controls.Add(this.txtMean);
            this.Controls.Add(this.lblMean);
            this.Controls.Add(this.lblMonitorMethod);
            this.Controls.Add(this.cboxMonitorMethod);
            this.Controls.Add(this.txtOutput2);
            this.Controls.Add(this.numSTDThreshold);
            this.Controls.Add(this.lblSTDThreshold);
            this.Controls.Add(this.numWindow);
            this.Controls.Add(this.lblWindow);
            this.Controls.Add(this.txtOutput1);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.numCorrelationThreshold);
            this.Controls.Add(this.lblCorrelationThreshold);
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
            ((System.ComponentModel.ISupportInitialize)(this.numCorrelationThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWindow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSTDThreshold)).EndInit();
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
        private System.Windows.Forms.NumericUpDown numCorrelationThreshold;
        private System.Windows.Forms.Label lblCorrelationThreshold;
        private System.Windows.Forms.Timer timerMonitor;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.TextBox txtOutput1;
        private System.Windows.Forms.NumericUpDown numWindow;
        private System.Windows.Forms.Label lblWindow;
        private System.Windows.Forms.Label lblSTDThreshold;
        private System.Windows.Forms.NumericUpDown numSTDThreshold;
        private System.Windows.Forms.TextBox txtOutput2;
        private System.Windows.Forms.Label lblMonitorMethod;
        private System.Windows.Forms.ComboBox cboxMonitorMethod;
        private System.Windows.Forms.TextBox txtMean;
        private System.Windows.Forms.Label lblMean;
    }
}