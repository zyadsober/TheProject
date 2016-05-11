namespace Pairs_Trading.Forms
{
    partial class Preprocessor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Preprocessor));
            this.lblIntro = new System.Windows.Forms.Label();
            this.txtBrowse = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblNewDirectory = new System.Windows.Forms.Label();
            this.txtNewDirectory = new System.Windows.Forms.TextBox();
            this.lblDays = new System.Windows.Forms.Label();
            this.datePickerSecond = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnProcess = new System.Windows.Forms.Button();
            this.lblStockCount = new System.Windows.Forms.Label();
            this.lblLineCountIntro = new System.Windows.Forms.Label();
            this.datePickerFirst = new System.Windows.Forms.DateTimePicker();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.lblPercentage = new System.Windows.Forms.Label();
            this.numPercentage = new System.Windows.Forms.NumericUpDown();
            this.lblFrequency = new System.Windows.Forms.Label();
            this.numDays = new System.Windows.Forms.NumericUpDown();
            this.lblFrequencyDays = new System.Windows.Forms.Label();
            this.numRecordsPercentage = new System.Windows.Forms.NumericUpDown();
            this.lblRecordsPercentage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRecordsPercentage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIntro
            // 
            this.lblIntro.AutoSize = true;
            this.lblIntro.Location = new System.Drawing.Point(12, 9);
            this.lblIntro.Name = "lblIntro";
            this.lblIntro.Size = new System.Drawing.Size(334, 39);
            this.lblIntro.TabIndex = 18;
            this.lblIntro.Text = "This is a tool to preprocess the stock data obtained from Quandl.com.\r\n\r\nBrowse f" +
    "or a folder containing the stock data.\r\n";
            // 
            // txtBrowse
            // 
            this.txtBrowse.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtBrowse.Location = new System.Drawing.Point(15, 60);
            this.txtBrowse.Name = "txtBrowse";
            this.txtBrowse.ReadOnly = true;
            this.txtBrowse.Size = new System.Drawing.Size(420, 20);
            this.txtBrowse.TabIndex = 17;
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnBrowse.Location = new System.Drawing.Point(441, 60);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 16;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblNewDirectory
            // 
            this.lblNewDirectory.AutoSize = true;
            this.lblNewDirectory.Location = new System.Drawing.Point(12, 118);
            this.lblNewDirectory.Name = "lblNewDirectory";
            this.lblNewDirectory.Size = new System.Drawing.Size(322, 13);
            this.lblNewDirectory.TabIndex = 19;
            this.lblNewDirectory.Text = "Newly generated CSV files will be created in the following directory:";
            this.lblNewDirectory.Visible = false;
            // 
            // txtNewDirectory
            // 
            this.txtNewDirectory.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtNewDirectory.Location = new System.Drawing.Point(12, 143);
            this.txtNewDirectory.Name = "txtNewDirectory";
            this.txtNewDirectory.ReadOnly = true;
            this.txtNewDirectory.Size = new System.Drawing.Size(420, 20);
            this.txtNewDirectory.TabIndex = 20;
            this.txtNewDirectory.Visible = false;
            // 
            // lblDays
            // 
            this.lblDays.AutoSize = true;
            this.lblDays.Location = new System.Drawing.Point(12, 183);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(224, 13);
            this.lblDays.TabIndex = 21;
            this.lblDays.Text = "Create new files with data from dates between\r\n";
            this.lblDays.Visible = false;
            // 
            // datePickerSecond
            // 
            this.datePickerSecond.Location = new System.Drawing.Point(242, 217);
            this.datePickerSecond.Name = "datePickerSecond";
            this.datePickerSecond.Size = new System.Drawing.Size(200, 20);
            this.datePickerSecond.TabIndex = 27;
            this.datePickerSecond.Visible = false;
            this.datePickerSecond.ValueChanged += new System.EventHandler(this.datePicker_ValueChanged);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(210, 217);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(26, 13);
            this.lblDate.TabIndex = 28;
            this.lblDate.Text = "And";
            this.lblDate.Visible = false;
            // 
            // btnProcess
            // 
            this.btnProcess.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnProcess.Location = new System.Drawing.Point(12, 327);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(113, 23);
            this.btnProcess.TabIndex = 29;
            this.btnProcess.Text = "Begin Preprocess";
            this.btnProcess.UseVisualStyleBackColor = false;
            this.btnProcess.Visible = false;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // lblStockCount
            // 
            this.lblStockCount.AutoSize = true;
            this.lblStockCount.Location = new System.Drawing.Point(88, 92);
            this.lblStockCount.Name = "lblStockCount";
            this.lblStockCount.Size = new System.Drawing.Size(67, 13);
            this.lblStockCount.TabIndex = 31;
            this.lblStockCount.Text = "_stockCount";
            this.lblStockCount.Visible = false;
            // 
            // lblLineCountIntro
            // 
            this.lblLineCountIntro.AutoSize = true;
            this.lblLineCountIntro.Location = new System.Drawing.Point(12, 92);
            this.lblLineCountIntro.Name = "lblLineCountIntro";
            this.lblLineCountIntro.Size = new System.Drawing.Size(76, 13);
            this.lblLineCountIntro.TabIndex = 30;
            this.lblLineCountIntro.Text = "Stocks found: ";
            this.lblLineCountIntro.Visible = false;
            // 
            // datePickerFirst
            // 
            this.datePickerFirst.Location = new System.Drawing.Point(242, 183);
            this.datePickerFirst.Name = "datePickerFirst";
            this.datePickerFirst.Size = new System.Drawing.Size(200, 20);
            this.datePickerFirst.TabIndex = 32;
            this.datePickerFirst.Visible = false;
            this.datePickerFirst.ValueChanged += new System.EventHandler(this.datePickerFirst_ValueChanged);
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(13, 356);
            this.pbProgress.Maximum = 2940;
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(498, 20);
            this.pbProgress.TabIndex = 43;
            this.pbProgress.Visible = false;
            // 
            // lblPercentage
            // 
            this.lblPercentage.AutoSize = true;
            this.lblPercentage.Location = new System.Drawing.Point(12, 247);
            this.lblPercentage.Name = "lblPercentage";
            this.lblPercentage.Size = new System.Drawing.Size(226, 13);
            this.lblPercentage.TabIndex = 44;
            this.lblPercentage.Text = "Percentage of data to include in the new files: ";
            this.lblPercentage.Visible = false;
            // 
            // numPercentage
            // 
            this.numPercentage.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.numPercentage.Location = new System.Drawing.Point(242, 247);
            this.numPercentage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPercentage.Name = "numPercentage";
            this.numPercentage.Size = new System.Drawing.Size(55, 20);
            this.numPercentage.TabIndex = 45;
            this.numPercentage.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numPercentage.Visible = false;
            // 
            // lblFrequency
            // 
            this.lblFrequency.AutoSize = true;
            this.lblFrequency.Location = new System.Drawing.Point(12, 273);
            this.lblFrequency.Name = "lblFrequency";
            this.lblFrequency.Size = new System.Drawing.Size(112, 13);
            this.lblFrequency.TabIndex = 46;
            this.lblFrequency.Text = "Take a sample every: ";
            this.lblFrequency.Visible = false;
            // 
            // numDays
            // 
            this.numDays.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.numDays.Location = new System.Drawing.Point(130, 271);
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
            this.numDays.TabIndex = 47;
            this.numDays.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDays.Visible = false;
            // 
            // lblFrequencyDays
            // 
            this.lblFrequencyDays.AutoSize = true;
            this.lblFrequencyDays.Location = new System.Drawing.Point(192, 272);
            this.lblFrequencyDays.Name = "lblFrequencyDays";
            this.lblFrequencyDays.Size = new System.Drawing.Size(31, 13);
            this.lblFrequencyDays.TabIndex = 48;
            this.lblFrequencyDays.Text = "Days";
            this.lblFrequencyDays.Visible = false;
            // 
            // numRecordsPercentage
            // 
            this.numRecordsPercentage.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.numRecordsPercentage.Location = new System.Drawing.Point(377, 297);
            this.numRecordsPercentage.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numRecordsPercentage.Name = "numRecordsPercentage";
            this.numRecordsPercentage.Size = new System.Drawing.Size(55, 20);
            this.numRecordsPercentage.TabIndex = 50;
            this.numRecordsPercentage.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numRecordsPercentage.Visible = false;
            // 
            // lblRecordsPercentage
            // 
            this.lblRecordsPercentage.AutoSize = true;
            this.lblRecordsPercentage.Location = new System.Drawing.Point(12, 299);
            this.lblRecordsPercentage.Name = "lblRecordsPercentage";
            this.lblRecordsPercentage.Size = new System.Drawing.Size(360, 13);
            this.lblRecordsPercentage.TabIndex = 49;
            this.lblRecordsPercentage.Text = "Minimum percentage of records for new files with respect to the largest file: ";
            this.lblRecordsPercentage.Visible = false;
            // 
            // Preprocessor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.ClientSize = new System.Drawing.Size(528, 392);
            this.Controls.Add(this.numRecordsPercentage);
            this.Controls.Add(this.lblRecordsPercentage);
            this.Controls.Add(this.lblFrequencyDays);
            this.Controls.Add(this.numDays);
            this.Controls.Add(this.lblFrequency);
            this.Controls.Add(this.numPercentage);
            this.Controls.Add(this.lblPercentage);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.datePickerFirst);
            this.Controls.Add(this.lblStockCount);
            this.Controls.Add(this.lblLineCountIntro);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.datePickerSecond);
            this.Controls.Add(this.lblDays);
            this.Controls.Add(this.txtNewDirectory);
            this.Controls.Add(this.lblNewDirectory);
            this.Controls.Add(this.lblIntro);
            this.Controls.Add(this.txtBrowse);
            this.Controls.Add(this.btnBrowse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Preprocessor";
            this.ShowInTaskbar = false;
            this.Text = "Preprocessor";
            ((System.ComponentModel.ISupportInitialize)(this.numPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRecordsPercentage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIntro;
        private System.Windows.Forms.TextBox txtBrowse;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblNewDirectory;
        private System.Windows.Forms.TextBox txtNewDirectory;
        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.DateTimePicker datePickerSecond;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label lblStockCount;
        private System.Windows.Forms.Label lblLineCountIntro;
        private System.Windows.Forms.DateTimePicker datePickerFirst;
        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.Label lblPercentage;
        private System.Windows.Forms.NumericUpDown numPercentage;
        private System.Windows.Forms.Label lblFrequency;
        private System.Windows.Forms.NumericUpDown numDays;
        private System.Windows.Forms.Label lblFrequencyDays;
        private System.Windows.Forms.NumericUpDown numRecordsPercentage;
        private System.Windows.Forms.Label lblRecordsPercentage;
    }
}