namespace Pairs_Trading.Forms
{
    partial class Loader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loader));
            this.numDownloadWorkers = new System.Windows.Forms.NumericUpDown();
            this.lblDownloadWorkersIntro = new System.Windows.Forms.Label();
            this.txtQuandlApi = new System.Windows.Forms.TextBox();
            this.lblQuandlApiIntro = new System.Windows.Forms.Label();
            this.lblDownloadProgress = new System.Windows.Forms.Label();
            this.pbDownload = new System.Windows.Forms.ProgressBar();
            this.btnProcess = new System.Windows.Forms.Button();
            this.lblRetieveIntro = new System.Windows.Forms.Label();
            this.lblStockCount = new System.Windows.Forms.Label();
            this.lblLineCountIntro = new System.Windows.Forms.Label();
            this.lblIntro = new System.Windows.Forms.Label();
            this.txtBrowse = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numDownloadWorkers)).BeginInit();
            this.SuspendLayout();
            // 
            // numDownloadWorkers
            // 
            this.numDownloadWorkers.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.numDownloadWorkers.Location = new System.Drawing.Point(169, 192);
            this.numDownloadWorkers.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDownloadWorkers.Name = "numDownloadWorkers";
            this.numDownloadWorkers.Size = new System.Drawing.Size(37, 20);
            this.numDownloadWorkers.TabIndex = 25;
            this.numDownloadWorkers.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDownloadWorkers.Visible = false;
            // 
            // lblDownloadWorkersIntro
            // 
            this.lblDownloadWorkersIntro.AutoSize = true;
            this.lblDownloadWorkersIntro.Location = new System.Drawing.Point(15, 192);
            this.lblDownloadWorkersIntro.Name = "lblDownloadWorkersIntro";
            this.lblDownloadWorkersIntro.Size = new System.Drawing.Size(148, 13);
            this.lblDownloadWorkersIntro.TabIndex = 24;
            this.lblDownloadWorkersIntro.Text = "Number of download workers:";
            this.lblDownloadWorkersIntro.Visible = false;
            // 
            // txtQuandlApi
            // 
            this.txtQuandlApi.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtQuandlApi.Location = new System.Drawing.Point(100, 163);
            this.txtQuandlApi.Name = "txtQuandlApi";
            this.txtQuandlApi.Size = new System.Drawing.Size(141, 20);
            this.txtQuandlApi.TabIndex = 23;
            this.txtQuandlApi.Text = "PLzjAxnx6Byns6tN2j9R";
            this.txtQuandlApi.Visible = false;
            // 
            // lblQuandlApiIntro
            // 
            this.lblQuandlApiIntro.AutoSize = true;
            this.lblQuandlApiIntro.Location = new System.Drawing.Point(15, 166);
            this.lblQuandlApiIntro.Name = "lblQuandlApiIntro";
            this.lblQuandlApiIntro.Size = new System.Drawing.Size(84, 13);
            this.lblQuandlApiIntro.TabIndex = 22;
            this.lblQuandlApiIntro.Text = "Quandl API key:";
            this.lblQuandlApiIntro.Visible = false;
            // 
            // lblDownloadProgress
            // 
            this.lblDownloadProgress.AutoSize = true;
            this.lblDownloadProgress.Location = new System.Drawing.Point(12, 282);
            this.lblDownloadProgress.Name = "lblDownloadProgress";
            this.lblDownloadProgress.Size = new System.Drawing.Size(99, 13);
            this.lblDownloadProgress.TabIndex = 21;
            this.lblDownloadProgress.Text = "Download Progress";
            this.lblDownloadProgress.Visible = false;
            // 
            // pbDownload
            // 
            this.pbDownload.Location = new System.Drawing.Point(15, 247);
            this.pbDownload.Name = "pbDownload";
            this.pbDownload.Size = new System.Drawing.Size(498, 23);
            this.pbDownload.TabIndex = 20;
            this.pbDownload.Visible = false;
            // 
            // btnProcess
            // 
            this.btnProcess.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnProcess.Location = new System.Drawing.Point(15, 218);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 19;
            this.btnProcess.Text = "Start";
            this.btnProcess.UseVisualStyleBackColor = false;
            this.btnProcess.Visible = false;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // lblRetieveIntro
            // 
            this.lblRetieveIntro.AutoSize = true;
            this.lblRetieveIntro.Location = new System.Drawing.Point(15, 124);
            this.lblRetieveIntro.Name = "lblRetieveIntro";
            this.lblRetieveIntro.Size = new System.Drawing.Size(503, 26);
            this.lblRetieveIntro.TabIndex = 18;
            this.lblRetieveIntro.Text = "To begin the retrieval of the stock data, enter your Quandl API key and press sta" +
    "rt. This may take a while.\r\nThe data will be saved into a folder named \"Stocks\" " +
    "in the directory of the selected CSV.";
            this.lblRetieveIntro.Visible = false;
            // 
            // lblStockCount
            // 
            this.lblStockCount.AutoSize = true;
            this.lblStockCount.Location = new System.Drawing.Point(88, 87);
            this.lblStockCount.Name = "lblStockCount";
            this.lblStockCount.Size = new System.Drawing.Size(67, 13);
            this.lblStockCount.TabIndex = 17;
            this.lblStockCount.Text = "_stockCount";
            this.lblStockCount.Visible = false;
            // 
            // lblLineCountIntro
            // 
            this.lblLineCountIntro.AutoSize = true;
            this.lblLineCountIntro.Location = new System.Drawing.Point(15, 87);
            this.lblLineCountIntro.Name = "lblLineCountIntro";
            this.lblLineCountIntro.Size = new System.Drawing.Size(76, 13);
            this.lblLineCountIntro.TabIndex = 16;
            this.lblLineCountIntro.Text = "Stocks found: ";
            this.lblLineCountIntro.Visible = false;
            // 
            // lblIntro
            // 
            this.lblIntro.AutoSize = true;
            this.lblIntro.Location = new System.Drawing.Point(12, 9);
            this.lblIntro.Name = "lblIntro";
            this.lblIntro.Size = new System.Drawing.Size(393, 39);
            this.lblIntro.TabIndex = 15;
            this.lblIntro.Text = "This is a tool to retrieve the stock data in several formats from Quandl.com.\r\n\r\n" +
    "Browse for a CSV file containing stocks in the format of Quandl code, stock name" +
    ".";
            // 
            // txtBrowse
            // 
            this.txtBrowse.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtBrowse.Location = new System.Drawing.Point(15, 60);
            this.txtBrowse.Name = "txtBrowse";
            this.txtBrowse.ReadOnly = true;
            this.txtBrowse.Size = new System.Drawing.Size(420, 20);
            this.txtBrowse.TabIndex = 14;
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnBrowse.Location = new System.Drawing.Point(441, 60);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 13;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // Loader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.ClientSize = new System.Drawing.Size(528, 315);
            this.Controls.Add(this.numDownloadWorkers);
            this.Controls.Add(this.lblDownloadWorkersIntro);
            this.Controls.Add(this.txtQuandlApi);
            this.Controls.Add(this.lblQuandlApiIntro);
            this.Controls.Add(this.lblDownloadProgress);
            this.Controls.Add(this.pbDownload);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.lblRetieveIntro);
            this.Controls.Add(this.lblStockCount);
            this.Controls.Add(this.lblLineCountIntro);
            this.Controls.Add(this.lblIntro);
            this.Controls.Add(this.txtBrowse);
            this.Controls.Add(this.btnBrowse);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Loader";
            this.ShowInTaskbar = false;
            this.Text = "Loader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Loader_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numDownloadWorkers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numDownloadWorkers;
        private System.Windows.Forms.Label lblDownloadWorkersIntro;
        private System.Windows.Forms.TextBox txtQuandlApi;
        private System.Windows.Forms.Label lblQuandlApiIntro;
        private System.Windows.Forms.Label lblDownloadProgress;
        private System.Windows.Forms.ProgressBar pbDownload;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label lblRetieveIntro;
        private System.Windows.Forms.Label lblStockCount;
        private System.Windows.Forms.Label lblLineCountIntro;
        private System.Windows.Forms.Label lblIntro;
        private System.Windows.Forms.TextBox txtBrowse;
        private System.Windows.Forms.Button btnBrowse;
    }
}