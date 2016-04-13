﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pairs_Trading.Forms
{
    public partial class Preprocessor : Form
    {
        #region ' Member Variables '

        private string _pathName;
        private int _stockCount;
        private string[] _stockNames;
        private Random random;
        #endregion

        #region ' Constructors '

        public Preprocessor()
        {
            InitializeComponent();

            this.Height = 150;

            _pathName = null;
            _stockCount = 0;
            random = new Random();
        }

        #endregion

        #region ' Event Handlers '

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            DialogResult result = folderDialog.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }
            _pathName = folderDialog.SelectedPath;
            txtBrowse.Text = _pathName;

            _stockNames = Directory.GetFiles(_pathName);

            _stockCount = _stockNames.Count();

            pbProgress.Maximum = _stockCount*2;

            lblStockCount.Text = _stockCount.ToString();
            lblStockCount.Visible = true;
            lblLineCountIntro.Visible = true;
            lblNewDirectory.Visible = true;
            txtNewDirectory.Visible = true;
            lblDays.Visible = true;
            datePickerFirst.Visible = true;
            lblDate.Visible = true;
            datePickerSecond.Visible = true;
            btnProcess.Visible = true;
            lblPercentage.Visible = true;
            numPercentage.Visible = true;
            lblFrequency.Visible = true;
            lblFrequencyDays.Visible = true;
            lblRecordsPercentage.Visible = true;
            numRecordsPercentage.Visible = true;
            numDays.Visible = true;

            UpdateDirectory();

            this.Height = 431;
        }

        private void numDays_ValueChanged(object sender, EventArgs e)
        {
            UpdateDirectory();
        }

        private void datePicker_ValueChanged(object sender, EventArgs e)
        {
            UpdateDirectory();
        }

        private void datePickerFirst_ValueChanged(object sender, EventArgs e)
        {
            UpdateDirectory();
        }


        private void btnProcess_Click(object sender, EventArgs e)
        {
            int[] stockLineCount = new int[_stockCount];
            int lineCount = 0;
            int maxLineCount = 0;
            pbProgress.Visible = true;
            pbProgress.Value = 0;
            btnProcess.Enabled = false;

            StreamReader strReader;
            StreamWriter strWriter;
            string line;
            for (int i = 0; i < _stockNames.Count(); i++)
            {
                lineCount = 0;

                strReader = new StreamReader(_stockNames[i]);
                string newStockName = _stockNames[i].Substring(_stockNames[i].LastIndexOf("\\"));
                System.IO.Directory.CreateDirectory(txtNewDirectory.Text);
                strWriter = new StreamWriter(txtNewDirectory.Text + newStockName);
                line = strReader.ReadLine();
                //strWriter.WriteLine(line);
                strWriter.Write(line);
                while (!strReader.EndOfStream)
                {
                    line = strReader.ReadLine();
                    try
                    {
                        DateTime dt = Convert.ToDateTime(line.Split(',')[0]);
                        
                        int r = random.Next(0, 100);
                        if (StockIsInLastDaysFromDate(datePickerFirst.Value, datePickerSecond.Value, dt)
                            && r <= numPercentage.Value)
                        {
                            //strWriter.WriteLine(line);
                            strWriter.Write("\n" + line);
                            lineCount++;
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
                strReader.Close();
                strWriter.Close();

                stockLineCount[i] = lineCount;

                // File is empty of data.
                if (lineCount < 1)
                {
                    //Delete the empty file.
                    File.Delete(txtNewDirectory.Text + newStockName);
                }
                
                // Calculate the maximum number of lines in all the files.
                if (lineCount > maxLineCount)
                {
                    maxLineCount = lineCount;
                }

                pbProgress.Value++;
            }
            
            /* Remove files which have less than the minimum percentage of
             * records with respect to the largest file. Also delete empty
             * files with no records */

            double minPercentage = (double)numRecordsPercentage.Value / 100.0;
            for (int i = 0; i < _stockNames.Count(); i++)
            {
                if ((double)stockLineCount[i] / (double)maxLineCount < minPercentage
                    || lineCount < 1)
                {
                    string newStockName = _stockNames[i].Substring(_stockNames[i].LastIndexOf("\\"));
                    File.Delete(txtNewDirectory.Text + newStockName);
                }
                pbProgress.Value++;
            }

            btnProcess.Enabled = true;
        }

        #endregion

        #region ' Support Methods '

        private bool StockIsInLastDaysFromDate(DateTime dtFirst, DateTime dtSecond, DateTime dtCurrent)
        {
            if (dtCurrent >= dtFirst && dtCurrent <= dtSecond)
            {
                return true;
            }
            return false;
        }

        private void UpdateDirectory()
        {
            txtNewDirectory.Text = _pathName + "-" + datePickerFirst.Value.Day + "-" + datePickerFirst.Value.Month
                + "-" + datePickerFirst.Value.Year + "-to-"
                + datePickerSecond.Value.Day + "-" + datePickerSecond.Value.Month + "-" + datePickerSecond.Value.Year;
        }

        #endregion

    }
}
