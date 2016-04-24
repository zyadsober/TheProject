namespace Pairs_Trading.Forms
{
    partial class Generator
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Generator));
            this.lblIntro = new System.Windows.Forms.Label();
            this.txtBrowse = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.datePickerFirst = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.datePickerSecond = new System.Windows.Forms.DateTimePicker();
            this.lblDays = new System.Windows.Forms.Label();
            this.numInitialPrice = new System.Windows.Forms.NumericUpDown();
            this.lblInitialPrice = new System.Windows.Forms.Label();
            this.numDivergeRate = new System.Windows.Forms.NumericUpDown();
            this.lblDivergeRate = new System.Windows.Forms.Label();
            this.lblDivergeRateDays = new System.Windows.Forms.Label();
            this.lblDivergePeriodDays = new System.Windows.Forms.Label();
            this.numDivergePeriod = new System.Windows.Forms.NumericUpDown();
            this.lblDivergePeriod = new System.Windows.Forms.Label();
            this.chartStocks = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.numInitialPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDivergeRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDivergePeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartStocks)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIntro
            // 
            this.lblIntro.AutoSize = true;
            this.lblIntro.Location = new System.Drawing.Point(12, 9);
            this.lblIntro.Name = "lblIntro";
            this.lblIntro.Size = new System.Drawing.Size(270, 39);
            this.lblIntro.TabIndex = 21;
            this.lblIntro.Text = "This is a tool to generate synthetic stock data.\r\n\r\nBrowse for a folder to contai" +
    "n the generated stock data.";
            // 
            // txtBrowse
            // 
            this.txtBrowse.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtBrowse.Location = new System.Drawing.Point(15, 60);
            this.txtBrowse.Name = "txtBrowse";
            this.txtBrowse.ReadOnly = true;
            this.txtBrowse.Size = new System.Drawing.Size(420, 20);
            this.txtBrowse.TabIndex = 20;
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnBrowse.Location = new System.Drawing.Point(441, 60);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 19;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnGenerate.Location = new System.Drawing.Point(12, 251);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(113, 23);
            this.btnGenerate.TabIndex = 44;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Visible = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // datePickerFirst
            // 
            this.datePickerFirst.Location = new System.Drawing.Point(242, 94);
            this.datePickerFirst.Name = "datePickerFirst";
            this.datePickerFirst.Size = new System.Drawing.Size(200, 20);
            this.datePickerFirst.TabIndex = 51;
            this.datePickerFirst.Visible = false;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(210, 128);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(26, 13);
            this.lblDate.TabIndex = 50;
            this.lblDate.Text = "And";
            this.lblDate.Visible = false;
            // 
            // datePickerSecond
            // 
            this.datePickerSecond.Location = new System.Drawing.Point(242, 128);
            this.datePickerSecond.Name = "datePickerSecond";
            this.datePickerSecond.Size = new System.Drawing.Size(200, 20);
            this.datePickerSecond.TabIndex = 49;
            this.datePickerSecond.Visible = false;
            // 
            // lblDays
            // 
            this.lblDays.AutoSize = true;
            this.lblDays.Location = new System.Drawing.Point(12, 94);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(224, 13);
            this.lblDays.TabIndex = 48;
            this.lblDays.Text = "Create new files with data from dates between\r\n";
            this.lblDays.Visible = false;
            // 
            // numInitialPrice
            // 
            this.numInitialPrice.Location = new System.Drawing.Point(122, 159);
            this.numInitialPrice.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numInitialPrice.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numInitialPrice.Name = "numInitialPrice";
            this.numInitialPrice.Size = new System.Drawing.Size(55, 20);
            this.numInitialPrice.TabIndex = 53;
            this.numInitialPrice.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numInitialPrice.Visible = false;
            // 
            // lblInitialPrice
            // 
            this.lblInitialPrice.AutoSize = true;
            this.lblInitialPrice.Location = new System.Drawing.Point(12, 161);
            this.lblInitialPrice.Name = "lblInitialPrice";
            this.lblInitialPrice.Size = new System.Drawing.Size(104, 13);
            this.lblInitialPrice.TabIndex = 52;
            this.lblInitialPrice.Text = "Stock prices start at:\r\n";
            this.lblInitialPrice.Visible = false;
            // 
            // numDivergeRate
            // 
            this.numDivergeRate.Location = new System.Drawing.Point(91, 193);
            this.numDivergeRate.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numDivergeRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDivergeRate.Name = "numDivergeRate";
            this.numDivergeRate.Size = new System.Drawing.Size(55, 20);
            this.numDivergeRate.TabIndex = 55;
            this.numDivergeRate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDivergeRate.Visible = false;
            // 
            // lblDivergeRate
            // 
            this.lblDivergeRate.AutoSize = true;
            this.lblDivergeRate.Location = new System.Drawing.Point(12, 193);
            this.lblDivergeRate.Name = "lblDivergeRate";
            this.lblDivergeRate.Size = new System.Drawing.Size(73, 13);
            this.lblDivergeRate.TabIndex = 54;
            this.lblDivergeRate.Text = "Diverge every";
            this.lblDivergeRate.Visible = false;
            // 
            // lblDivergeRateDays
            // 
            this.lblDivergeRateDays.AutoSize = true;
            this.lblDivergeRateDays.Location = new System.Drawing.Point(152, 195);
            this.lblDivergeRateDays.Name = "lblDivergeRateDays";
            this.lblDivergeRateDays.Size = new System.Drawing.Size(31, 13);
            this.lblDivergeRateDays.TabIndex = 56;
            this.lblDivergeRateDays.Text = "Days";
            this.lblDivergeRateDays.Visible = false;
            // 
            // lblDivergePeriodDays
            // 
            this.lblDivergePeriodDays.AutoSize = true;
            this.lblDivergePeriodDays.Location = new System.Drawing.Point(152, 227);
            this.lblDivergePeriodDays.Name = "lblDivergePeriodDays";
            this.lblDivergePeriodDays.Size = new System.Drawing.Size(31, 13);
            this.lblDivergePeriodDays.TabIndex = 59;
            this.lblDivergePeriodDays.Text = "Days";
            this.lblDivergePeriodDays.Visible = false;
            // 
            // numDivergePeriod
            // 
            this.numDivergePeriod.Location = new System.Drawing.Point(91, 225);
            this.numDivergePeriod.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numDivergePeriod.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDivergePeriod.Name = "numDivergePeriod";
            this.numDivergePeriod.Size = new System.Drawing.Size(55, 20);
            this.numDivergePeriod.TabIndex = 58;
            this.numDivergePeriod.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDivergePeriod.Visible = false;
            // 
            // lblDivergePeriod
            // 
            this.lblDivergePeriod.AutoSize = true;
            this.lblDivergePeriod.Location = new System.Drawing.Point(12, 225);
            this.lblDivergePeriod.Name = "lblDivergePeriod";
            this.lblDivergePeriod.Size = new System.Drawing.Size(62, 13);
            this.lblDivergePeriod.TabIndex = 57;
            this.lblDivergePeriod.Text = "Diverge for ";
            this.lblDivergePeriod.Visible = false;
            // 
            // chartStocks
            // 
            this.chartStocks.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.Name = "ChartArea1";
            this.chartStocks.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartStocks.Legends.Add(legend1);
            this.chartStocks.Location = new System.Drawing.Point(200, 193);
            this.chartStocks.Name = "chartStocks";
            this.chartStocks.Size = new System.Drawing.Size(606, 299);
            this.chartStocks.TabIndex = 60;
            this.chartStocks.Text = "chart1";
            this.chartStocks.Visible = false;
            // 
            // Generator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 504);
            this.Controls.Add(this.chartStocks);
            this.Controls.Add(this.lblDivergePeriodDays);
            this.Controls.Add(this.numDivergePeriod);
            this.Controls.Add(this.lblDivergePeriod);
            this.Controls.Add(this.lblDivergeRateDays);
            this.Controls.Add(this.numDivergeRate);
            this.Controls.Add(this.lblDivergeRate);
            this.Controls.Add(this.numInitialPrice);
            this.Controls.Add(this.lblInitialPrice);
            this.Controls.Add(this.datePickerFirst);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.datePickerSecond);
            this.Controls.Add(this.lblDays);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.lblIntro);
            this.Controls.Add(this.txtBrowse);
            this.Controls.Add(this.btnBrowse);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Generator";
            this.Text = "Generator";
            ((System.ComponentModel.ISupportInitialize)(this.numInitialPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDivergeRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDivergePeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartStocks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIntro;
        private System.Windows.Forms.TextBox txtBrowse;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.DateTimePicker datePickerFirst;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker datePickerSecond;
        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.NumericUpDown numInitialPrice;
        private System.Windows.Forms.Label lblInitialPrice;
        private System.Windows.Forms.NumericUpDown numDivergeRate;
        private System.Windows.Forms.Label lblDivergeRate;
        private System.Windows.Forms.Label lblDivergeRateDays;
        private System.Windows.Forms.Label lblDivergePeriodDays;
        private System.Windows.Forms.NumericUpDown numDivergePeriod;
        private System.Windows.Forms.Label lblDivergePeriod;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStocks;
    }
}