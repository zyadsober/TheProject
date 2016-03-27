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
            this.numDays = new System.Windows.Forms.NumericUpDown();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnProcess = new System.Windows.Forms.Button();
            this.lblLineCount = new System.Windows.Forms.Label();
            this.lblLineCountIntro = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numDays)).BeginInit();
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
            this.lblDays.Size = new System.Drawing.Size(220, 13);
            this.lblDays.TabIndex = 21;
            this.lblDays.Text = "Create new files with data containing the last \r\n";
            this.lblDays.Visible = false;
            // 
            // numDays
            // 
            this.numDays.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.numDays.Location = new System.Drawing.Point(229, 183);
            this.numDays.Maximum = new decimal(new int[] {
            40000,
            0,
            0,
            0});
            this.numDays.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDays.Name = "numDays";
            this.numDays.Size = new System.Drawing.Size(37, 20);
            this.numDays.TabIndex = 26;
            this.numDays.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDays.Visible = false;
            this.numDays.ValueChanged += new System.EventHandler(this.numDays_ValueChanged);
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(153, 217);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(200, 20);
            this.datePicker.TabIndex = 27;
            this.datePicker.Visible = false;
            this.datePicker.ValueChanged += new System.EventHandler(this.datePicker_ValueChanged);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(12, 217);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(135, 13);
            this.lblDate.TabIndex = 28;
            this.lblDate.Text = "days starting from this date:";
            this.lblDate.Visible = false;
            // 
            // btnProcess
            // 
            this.btnProcess.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnProcess.Location = new System.Drawing.Point(15, 258);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(113, 23);
            this.btnProcess.TabIndex = 29;
            this.btnProcess.Text = "Begin Preprocess";
            this.btnProcess.UseVisualStyleBackColor = false;
            this.btnProcess.Visible = false;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // lblLineCount
            // 
            this.lblLineCount.AutoSize = true;
            this.lblLineCount.Location = new System.Drawing.Point(88, 92);
            this.lblLineCount.Name = "lblLineCount";
            this.lblLineCount.Size = new System.Drawing.Size(67, 13);
            this.lblLineCount.TabIndex = 31;
            this.lblLineCount.Text = "_stockCount";
            this.lblLineCount.Visible = false;
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
            // Preprocessor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 293);
            this.Controls.Add(this.lblLineCount);
            this.Controls.Add(this.lblLineCountIntro);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.numDays);
            this.Controls.Add(this.lblDays);
            this.Controls.Add(this.txtNewDirectory);
            this.Controls.Add(this.lblNewDirectory);
            this.Controls.Add(this.lblIntro);
            this.Controls.Add(this.txtBrowse);
            this.Controls.Add(this.btnBrowse);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Preprocessor";
            this.Text = "Preprocessor";
            ((System.ComponentModel.ISupportInitialize)(this.numDays)).EndInit();
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
        private System.Windows.Forms.NumericUpDown numDays;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label lblLineCount;
        private System.Windows.Forms.Label lblLineCountIntro;
    }
}