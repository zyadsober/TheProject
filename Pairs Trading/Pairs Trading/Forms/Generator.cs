using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            this.Width = 834;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
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

            double rangeMin = 0.0 - (double)numInitialPrice.Value / 40.0;
            double rangeMinInitial = 0.0 - (double)numInitialPrice.Value / 100.0;
            double rangeMax = 0.0 + (double)numInitialPrice.Value / 40.0;
            double rangeMaxInitial = 0.0 + (double)numInitialPrice.Value / 100.0;
            double randomValue = 0;

            double stockCoMean = 0;

            // Clear our chart for new stocks.
            chartStocks.Series.Clear();

            // Add the stocks to the chart series.
            chartStocks.Series.Add("0");
            chartStocks.Series.Add("1");

            // Change the chart type of our series to Line.
            chartStocks.Series["0"].ChartType = SeriesChartType.Line;
            chartStocks.Series["1"].ChartType = SeriesChartType.Line;

            // Create directory if it does not exist.
            System.IO.Directory.CreateDirectory(newPath);

            StreamWriter strw1 = new StreamWriter(newPath + "\\0.csv");
            StreamWriter strw2 = new StreamWriter(newPath + "\\1.csv");

            strw1.Write("Date,Open,High,Low,Close,Volume,Ex-Dividend,Split Ratio,Adj. Open,Adj. High,Adj. Low,Adj. Close,Adj. Volume");
            strw2.Write("Date,Open,High,Low,Close,Volume,Ex-Dividend,Split Ratio,Adj. Open,Adj. High,Adj. Low,Adj. Close,Adj. Volume");

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

                strw1.Write("\n" + dt1.Year + "-" + dt1.Month + "-" + dt1.Day +
                    ",0,0,0," + stocks[0][currentDay] + ",0,0,0,0,0,0,0,0");

                strw2.Write("\n" + dt1.Year + "-" + dt1.Month + "-" + dt1.Day +
                    ",0,0,0," + stocks[1][currentDay] + ",0,0,0,0,0,0,0,0");

                chartStocks.Series["0"].Points.AddY(stocks[0][currentDay]);
                chartStocks.Series["1"].Points.AddY(stocks[1][currentDay]);

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
            strw1.Close();
            strw2.Close();
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
