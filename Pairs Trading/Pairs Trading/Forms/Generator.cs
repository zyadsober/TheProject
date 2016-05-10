using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Pairs_Trading.Forms
{
    public partial class Generator : Form
    {

        #region ' Member Variables '

        private string _pathName;
        private Random random;
        private bool _firstStockDiverging;
        private bool _secondStockDiverging;
        private bool _firstStockConverging;
        private bool _secondStockConverging;
        private int _daysSinceChange;
        private int _stockCount;

        #endregion

        #region ' Constructors '

        public Generator()
        {
            InitializeComponent();

            /* Set the initial height and width of the form.
             * This will change later on successful file browse. */
            this.Height = 150;
            this.Width = 554;

            // Initialize variables.

            _pathName = null;
            random = new Random();
            _firstStockDiverging = false;
            _secondStockDiverging = false;
            _firstStockConverging = false;
            _secondStockConverging = false;
            _daysSinceChange = 0;
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

            // Set the remaining controls to visible.
            lblDays.Visible = true;
            datePickerFirst.Visible = true;
            lblDate.Visible = true;
            datePickerSecond.Visible = true;
            lblInitialPrice.Visible = true;
            numInitialPrice.Visible = true;
            lblFactor.Visible = true;
            numFactor.Visible = true;
            lblFactorInitial.Visible = true;
            numFactorInitial.Visible = true;
            lblDivergeRate.Visible = true;
            lblDivergeRateDays.Visible = true;
            numDivergeRate.Visible = true;
            lblDivergePeriod.Visible = true;
            lblDivergePeriodDays.Visible = true;
            numDivergePeriod.Visible = true;
            btnGenerate.Visible = true;
            chartStocks.Visible = true;

            // Update the height and width of the form to fit the visible controls.
            this.Height = 543;
            this.Width = 942;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            _stockCount += 2;

            string newPath = _pathName + "\\Stocks_Generated-" + datePickerFirst.Value.Day + "-" + datePickerFirst.Value.Month
                + "-" + datePickerFirst.Value.Year + "-to-"
                + datePickerSecond.Value.Day + "-" + datePickerSecond.Value.Month + "-" + datePickerSecond.Value.Year;

            List<List<double>> stocks = new List<List<double>>(2);
            stocks.Add(new List<double>());
            stocks.Add(new List<double>());

            DateTime dt1 = datePickerFirst.Value;
            DateTime dt2 = datePickerSecond.Value;

            int currentDay = 0;

            _daysSinceChange = 0;

            _firstStockDiverging = false;
            _firstStockConverging = false;
            _secondStockDiverging = false;
            _secondStockConverging = false;

            double rangeMin = 0.0 - (double)numInitialPrice.Value / (double)numFactor.Value;
            double rangeMinInitial = 0.0 - (double)numInitialPrice.Value / (double)numFactorInitial.Value;
            double rangeMax = 0.0 + (double)numInitialPrice.Value / (double)numFactor.Value;
            double rangeMaxInitial = 0.0 + (double)numInitialPrice.Value / (double)numFactorInitial.Value;
            double randomValue = 0;

            double stockCoMean = 0;

            // Clear our chart for new stocks.
            chartStocks.Series.Clear();

            // Make the chart visible.
            chartStocks.Visible = true;
            lblXAxis.Visible = true;
            lblXAxis.BringToFront();
            lblYAxis.Visible = true;
            lblYAxis.BringToFront();

            // Add the stocks to the chart series.
            chartStocks.Series.Add((_stockCount - 2).ToString());
            chartStocks.Series.Add((_stockCount - 1).ToString());

            // Change the chart type of our series to Line.
            chartStocks.Series[(_stockCount - 2).ToString()].ChartType = SeriesChartType.Line;
            chartStocks.Series[(_stockCount - 1).ToString()].ChartType = SeriesChartType.Line;

            // Create directory if it does not exist.
            System.IO.Directory.CreateDirectory(newPath);

            while (dt1 <= dt2)
            {
                _daysSinceChange++;

                if (currentDay == 0)
                {
                    randomValue = rangeMinInitial + (rangeMaxInitial - rangeMinInitial) * random.NextDouble();

                    stocks[0].Add((double)numInitialPrice.Value + randomValue);

                    randomValue = rangeMinInitial + (rangeMaxInitial - rangeMinInitial) * random.NextDouble();

                    stocks[1].Add((double)numInitialPrice.Value + randomValue);
                }
                else
                {
                    // First stock is diverging.
                    if (_firstStockDiverging)
                    {
                        randomValue = rangeMax * random.NextDouble();

                        stocks[0].Add(stocks[0][currentDay - 1] + randomValue);

                        if (_daysSinceChange >= (int)numDivergePeriod.Value)
                        {
                            _firstStockDiverging = false;
                            _firstStockConverging = true;
                        }
                    }
                    // First stock is converging.
                    else if (_firstStockConverging)
                    {
                        randomValue = rangeMax * random.NextDouble();

                        stocks[0].Add(stocks[0][currentDay - 1] - randomValue);

                        if (_daysSinceChange >= (int)numDivergePeriod.Value)
                        {
                            _firstStockConverging = false;
                        }
                    }
                    // First stock is neither diverging nor converging.
                    else
                    {
                        randomValue = rangeMin + (rangeMax - rangeMin) * random.NextDouble();

                        stockCoMean = CoMean(stocks[0], stocks[1], currentDay, stocks[0].Count);

                        double biasToCoMean = stockCoMean - stocks[0][currentDay - 1];
                        biasToCoMean /= (double)numDivergeRate.Value;

                        stocks[0].Add(stocks[0][currentDay - 1] + randomValue + biasToCoMean);
                    }

                    // Second stock is diverging.
                    if (_secondStockDiverging)
                    {
                        randomValue = rangeMax * random.NextDouble();

                        stocks[1].Add(stocks[1][currentDay - 1] - randomValue);

                        if (_daysSinceChange >= (int)numDivergePeriod.Value)
                        {
                            _secondStockDiverging = false;
                            _secondStockConverging = true;
                            _daysSinceChange = 0;
                        }
                    }
                    // Second stock is converging.
                    else if (_secondStockConverging)
                    {
                        randomValue = rangeMax * random.NextDouble();

                        stocks[1].Add(stocks[1][currentDay - 1] + randomValue);

                        if (_daysSinceChange >= (int)numDivergePeriod.Value)
                        {
                            _secondStockConverging = false;
                            _daysSinceChange = 0;
                        }
                    }
                    // Second stock is neither diverging nor converging.
                    else
                    {
                        randomValue = rangeMin + (rangeMax - rangeMin) * random.NextDouble();

                        double biasToCoMean = stockCoMean - stocks[0][currentDay - 1];
                        biasToCoMean /= (double)numDivergeRate.Value;

                        stocks[1].Add(stocks[1][currentDay - 1] + randomValue + biasToCoMean);
                    }
                }



                chartStocks.Series[(_stockCount - 2).ToString()].Points.AddY(stocks[0][currentDay]);
                chartStocks.Series[(_stockCount - 1).ToString()].Points.AddY(stocks[1][currentDay]);

                if (_daysSinceChange >= (int)numDivergeRate.Value &&
                    _firstStockDiverging == false &&
                    _firstStockConverging == false &&
                    _secondStockDiverging == false &&
                    _secondStockConverging == false)
                {
                    _firstStockDiverging = true;
                    _secondStockDiverging = true;
                    _daysSinceChange = 0;
                }

                dt1 = dt1.AddDays(1);

                currentDay++;
            }

            DialogResult dialogResult = MessageBox.Show("Would you like to save this ?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                StreamWriter strw1 = new StreamWriter(newPath + "\\" + (_stockCount - 2).ToString() + ".csv");
                StreamWriter strw2 = new StreamWriter(newPath + "\\" + (_stockCount - 1).ToString() + ".csv");
                strw1.Write("Date,Close");
                strw2.Write("Date,Close");
                for (int i = 0; i < stocks[0].Count; i++)
                {
                    strw1.Write("\n" + dt1.Year + "-" + dt1.Month + "-" + dt1.Day +
                            "," + stocks[0][i]);

                    strw2.Write("\n" + dt1.Year + "-" + dt1.Month + "-" + dt1.Day +
                        "," + stocks[1][i]);
                }
                strw1.Close();
                strw2.Close();
            }
            else
                _stockCount -= 2;
        }

        #endregion

        #region ' Support Methods '

        private double CoMean(List<double> stock1, List<double> stock2, int Lastday, int numberOfDays)
        {
            return (Mean(stock1, Lastday, numberOfDays) + Mean(stock2, Lastday, numberOfDays)) / 2;
        }

        private double Mean(List<double> stock, int Lastday, int numberOfDays)
        {
            double sum = 0;
            for (int i = Lastday - numberOfDays; i < stock.Count && i < Lastday; i++)
                sum += stock[i];
            return sum / numberOfDays;
        }

        #endregion

    }
}