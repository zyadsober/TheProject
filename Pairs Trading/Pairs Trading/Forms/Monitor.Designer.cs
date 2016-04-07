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
            this.lblLineCount = new System.Windows.Forms.Label();
            this.lblLineCountIntro = new System.Windows.Forms.Label();
            this.txtBrowse = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblIntro = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblLineCount
            // 
            this.lblLineCount.AutoSize = true;
            this.lblLineCount.Location = new System.Drawing.Point(88, 89);
            this.lblLineCount.Name = "lblLineCount";
            this.lblLineCount.Size = new System.Drawing.Size(67, 13);
            this.lblLineCount.TabIndex = 26;
            this.lblLineCount.Text = "_stockCount";
            this.lblLineCount.Visible = false;
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
            // 
            // lblIntro
            // 
            this.lblIntro.AutoSize = true;
            this.lblIntro.Location = new System.Drawing.Point(12, 9);
            this.lblIntro.Name = "lblIntro";
            this.lblIntro.Size = new System.Drawing.Size(411, 39);
            this.lblIntro.TabIndex = 22;
            this.lblIntro.Text = "This is a tool to mine for pairs using downloaded stock data.\r\n\r\nBrowse for a fol" +
    "der containing stock data in CSV format obtained from the Loader tool.\r\n";
            // 
            // Monitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 472);
            this.Controls.Add(this.lblLineCount);
            this.Controls.Add(this.lblLineCountIntro);
            this.Controls.Add(this.txtBrowse);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.lblIntro);
            this.Name = "Monitor";
            this.Text = "Monitor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLineCount;
        private System.Windows.Forms.Label lblLineCountIntro;
        private System.Windows.Forms.TextBox txtBrowse;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblIntro;
    }
}