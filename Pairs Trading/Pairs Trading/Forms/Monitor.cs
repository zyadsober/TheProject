﻿using Pairs_Trading.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Pairs_Trading.Forms
{
    public partial class Monitor : Form
    {
       
        #region ' Member Variables '

        private string _fileName;
        private string _pathName;
        private int _stockCount;
        private string[] _stockNames;
        private List<List<double>> _stockPrices;
        private double _increasingDivergenceThreshold;
        private double _decreasingDivergenceThreshold;
        private string _stockName0;
        private string _stockName1;
        private int _currentDay;

        #endregion

        #region ' Constructors '

        public Monitor()
        {
            InitializeComponent();

            /* Set the initial height of the form.
            * This will change later on successful file browse. */
            this.Height = 150;

            // Initial variables.
            _fileName = string.Empty;
            _pathName = string.Empty;
            _stockCount = 0;
            _stockName0 = string.Empty;
            _stockName1 = string.Empty;
            _currentDay = 0;
            
            UISync.Init(this);
        }

        #endregion

        #region ' Event Handlers '

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            /* Create a folder browsing dialog.
             * Show the dialog */
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            DialogResult result = folderDialog.ShowDialog();

            // If the browsing return an invalid code, exit the method.
            if (result != DialogResult.OK)
            {
                return;
            }

            // Get the path.
            _pathName = folderDialog.SelectedPath;

            // Display the path.
            txtBrowse.Text = _pathName;

            // Get the names of files in the path.
            _stockNames = Directory.GetFiles(_pathName);
            
            // Display number of stocks.
            lblStockCount.Text = _stockCount.ToString();

            // Count the number of stocks contained in the folder.
            _stockCount = _stockNames.Count();

            // Set the remaining controls to visible.
            lblStockCount.Visible = true;
            lblLineCountIntro.Visible = true;
            lblMonitorMethod.Visible = true;
            cboxMonitorMethod.Visible = true;
            lblFirstStock.Visible = true;
            lblSecondStock.Visible = true;
            txtFirstStock.Visible = true;
            txtSecondStock.Visible = true;
            lblWindow.Visible = true;
            numWindow.Visible = true;
            lblDays.Visible = true;
            numDays.Visible = true;
            lblThreshold.Visible = true;
            numCorrelationThreshold.Visible = true;
            lblSTDThreshold.Visible = true;
            numSTDThreshold.Visible = true;
            lblCurrentCorrelation.Visible = true;
            txtCurrentCorrelation.Visible = true;
            txtCorrelation2.Visible = true;
            btnMonitor.Visible = true;

            // Initialize the combobox selection.
            cboxMonitorMethod.SelectedIndex = 0;

            // Update the height of the form to fit the visible controls.
            this.Height = 538;

        }

        private void btnMonitor_Click(object sender, EventArgs e)
        {
            // Define local variables.
            string line1, line2;
            int firstStock = Int32.Parse(txtFirstStock.Text);
            int secondStock = Int32.Parse(txtSecondStock.Text);
            StreamReader strReader1 = new StreamReader(_stockNames[firstStock]);
            StreamReader strReader2 = new StreamReader(_stockNames[secondStock]);
            
            // Read the first lines containing the field's names.
            line1 = strReader1.ReadLine();
            line2 = strReader2.ReadLine();

            // Create new vectors for the two stock's prices.
            _stockPrices = new List<List<double>>();
            _stockPrices.Add(new List<double>());
            _stockPrices.Add(new List<double>());

            // Read both files.
            while (!strReader1.EndOfStream && !strReader2.EndOfStream)
            {
                // Read a line from each file.
                line1 = strReader1.ReadLine();
                line2 = strReader2.ReadLine();
                try
                {
                    // Convert the date from the read line to DateTime.
                    DateTime dt1 = Convert.ToDateTime(line1.Split(',')[0]);
                    DateTime dt2 = Convert.ToDateTime(line2.Split(',')[0]);

                    // Keep reading until the dates match.
                    while (dt1.Date != dt2.Date && !strReader1.EndOfStream && !strReader2.EndOfStream)
                    {
                        while (dt1.Date < dt2.Date && !strReader1.EndOfStream)
                        {
                            line1 = strReader1.ReadLine();
                            dt1 = Convert.ToDateTime(line1.Split(',')[0]);
                        }
                        while (dt1.Date > dt2.Date && !strReader2.EndOfStream)
                        {
                            line2 = strReader2.ReadLine();
                            dt2 = Convert.ToDateTime(line2.Split(',')[0]);
                        }
                    }

                    // On a match, take the prices of both stocks.
                    if (dt1.Date == dt2.Date)
                    {
                        _stockPrices[0].Add(Convert.ToDouble((line1.Split(','))[4]));
                        _stockPrices[1].Add(Convert.ToDouble((line2.Split(','))[4]));
                    }
                }
                catch (Exception)
                {

                    continue;
                }
            }

            // Free our writing lock on the stock files.
            strReader1.Close();
            strReader2.Close();

            // Get the stock name for both stocks.
            _stockName0 = _stockNames[firstStock].Substring(_stockNames[firstStock].LastIndexOf("\\") + 1);
            _stockName0 = _stockName0.Substring(0, _stockName0.LastIndexOf(".csv"));

            _stockName1 = _stockNames[secondStock].Substring(_stockNames[secondStock].LastIndexOf("\\") + 1);
            _stockName1 = _stockName1.Substring(0, _stockName1.LastIndexOf(".csv"));
            
            // Clear our chart for new stocks.
            chart1.Series.Clear();

            // Add the stocks to the chart series.
            chart1.Series.Add(_stockName0);
            chart1.Series.Add(_stockName1);

            // Change the chart type of our series to Line.
            chart1.Series[_stockName0].ChartType = SeriesChartType.Line;
            chart1.Series[_stockName1].ChartType = SeriesChartType.Line;

            // Reset the current day count.
            _currentDay = 0;
            
            // Start our time monitoring ticking.
            timerMonitor.Start();
        }

        private void timerMonitor_Tick(object sender, EventArgs e)
        {
            if (cboxMonitorMethod.SelectedIndex == 0)
            {
                CorrelationTimerTick();
            }
            else if (cboxMonitorMethod.SelectedIndex == 1)
            {
                STDTimerTick();
            }
        }

        #endregion

        #region ' Support Methods '

        private double Correlation(List<double> stock1, List<double> stock2, int Lastday, int numberOfDays)
        {
            return Covariance(stock1, stock2, Lastday, numberOfDays) / (Std(stock1, Lastday, numberOfDays) * Std(stock2, Lastday, numberOfDays));
        }

        private double Covariance(List<double> stock1, List<double> stock2, int Lastday, int numberOfDays)
        {
            double sum = 0;
            double mean1 = Mean(stock1, Lastday, numberOfDays), mean2 = Mean(stock2, Lastday, numberOfDays);
            for (int i = Lastday - numberOfDays; i < stock1.Count && i < Lastday; i++)
                sum += (stock1[i] - mean1) * (stock2[i] - mean2);
            return sum / (numberOfDays - 1);
        }
        
        private double Std(List<double> stock, int Lastday, int numberOfDays)
        {
            double sum = 0, mean = Mean(stock, Lastday, numberOfDays);
            for (int i = Lastday - numberOfDays; i < stock.Count && i < Lastday; i++)
                sum += (stock[i] - mean) * (stock[i] - mean);
            return Math.Sqrt(sum / (numberOfDays - 1));
        }

        private double Mean(List<double> stock, int Lastday, int numberOfDays)
        {
            double sum = 0;
            for (int i = Lastday - numberOfDays; i < stock.Count && i < Lastday; i++)
                sum += stock[i];
            return sum / numberOfDays;
        }

        private double CoStd(List<double> stock1, List<double> stock2, int Lastday, int numberOfDays)
        {
            double sum = 0, mean = CoMean(stock1, stock2, Lastday, numberOfDays);
            for (int i = Lastday - numberOfDays; i < stock1.Count && i < Lastday; i++)
                sum += (stock1[i] - mean) * (stock1[i] - mean) + (stock2[i] - mean) * (stock2[i] - mean);
            return Math.Sqrt(sum / (stock1.Count - 1));
        }

        private double CoMean(List<double> stock1, List<double> stock2, int Lastday, int numberOfDays)
        {
            return (Mean(stock1, Lastday, numberOfDays) + Mean(stock2, Lastday, numberOfDays)) / 2;
        }

        private void CorrelationTimerTick()
        {
            // Plot the days up until the selected number of days.
            if (_currentDay < _stockPrices[0].Count && _currentDay < numDays.Value)
            {
                chart1.Series[_stockName0].Points.AddY(_stockPrices[0][_currentDay]);
                chart1.Series[_stockName1].Points.AddY(_stockPrices[1][_currentDay]);
                _currentDay++;
            }

            // Now increment daily and check the correlation.
            else if (_currentDay < _stockPrices[0].Count)
            {
                double correlation = Correlation(_stockPrices[0], _stockPrices[1], _currentDay, (int)numWindow.Value);

                txtCurrentCorrelation.Text = correlation.ToString();

                chart1.Series[_stockName0].Points.AddY(_stockPrices[0][_currentDay]);
                chart1.Series[_stockName1].Points.AddY(_stockPrices[1][_currentDay]);
                //if (correlation < (double)numThreshold.Value)
                //{
                //    timerMonitor.Stop();
                //    MessageBox.Show("Correlation is " + correlation);
                //    timerMonitor.Start();
                //}
                _currentDay++;
            }
            else
            {
                timerMonitor.Stop();
            }
        }
        private void STDTimerTick()
        {
            // Plot the days up until the selected number of days.
            if (_currentDay < _stockPrices[0].Count && _currentDay < numDays.Value)
            {
                chart1.Series[_stockName0].Points.AddY(_stockPrices[0][_currentDay]);
                chart1.Series[_stockName1].Points.AddY(_stockPrices[1][_currentDay]);
                _currentDay++;
            }
            // Now increment daily and check the correlation.
            else if (_currentDay < _stockPrices[0].Count)
            {
                chart1.Series[_stockName0].Points.AddY(_stockPrices[0][_currentDay]);
                chart1.Series[_stockName1].Points.AddY(_stockPrices[1][_currentDay]);

                _increasingDivergenceThreshold = CoMean(_stockPrices[0], _stockPrices[1], _currentDay, (int)numWindow.Value) +
                CoStd(_stockPrices[0], _stockPrices[1], (int)numWindow.Value, (int)numWindow.Value) * (double)numSTDThreshold.Value;
                _decreasingDivergenceThreshold = CoMean(_stockPrices[0], _stockPrices[1], _currentDay, (int)numWindow.Value) -
                    CoStd(_stockPrices[0], _stockPrices[1], (int)numWindow.Value, (int)numWindow.Value) * (double)numSTDThreshold.Value;

                if (_stockPrices[0][_currentDay] >= _increasingDivergenceThreshold ||
                    _stockPrices[0][_currentDay] <= _decreasingDivergenceThreshold)
                {
                    timerMonitor.Stop();
                    //MessageBox.Show(_stockName0 + " Is divering");
                    txtCurrentCorrelation.Text = _stockName0 + " Is diverging" + _currentDay;
                    timerMonitor.Start();
                }
                if (_stockPrices[1][_currentDay] >= _increasingDivergenceThreshold ||
                    _stockPrices[1][_currentDay] <= _decreasingDivergenceThreshold)
                {
                    timerMonitor.Stop();
                    txtCorrelation2.Text = _stockName1 + " Is diverging" + _currentDay;
                    timerMonitor.Start();
                }
                _currentDay++;
            }
            else
            {
                timerMonitor.Stop();
            }

        }

        #endregion

    }
}
