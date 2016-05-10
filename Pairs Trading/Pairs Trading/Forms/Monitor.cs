using Pairs_Trading.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        private int _maxPricePredictor;
        private string[] _stockNames;
        private List<List<double>> _stockPrices;
        private double _increasingDivergenceThreshold;
        private double _decreasingDivergenceThreshold;
        private double _decreasingConvergenceThreshold;
        private double _increasingConvergenceThreshold;
        private double _longBuyProfit;
        private double _shortSellProfit;
        private double _stdMultiplier;
        private double _meanOf3days;
        private string _stockName0;
        private string _stockName1;
        private int _currentDay;
        private int _dayOfDivergence;
        private int _shortSellStock;
        private bool _firstStockDiverged;
        private bool _secondStockDiverged;
        private bool _alertSent;

        #endregion

        #region ' Constructors '

        public Monitor()
        {
            InitializeComponent();

            /* Set the initial height and width of the form.
            * This will change later on successful file browse. */
            this.Height = 150;
            this.Width = 544;

            // Initial variables.
            _fileName = string.Empty;
            _pathName = string.Empty;
            _stockCount = 0;
            _stockName0 = string.Empty;
            _stockName1 = string.Empty;
            _currentDay = 0;
            _dayOfDivergence = 0;
            _longBuyProfit = 0;
            _shortSellProfit = 0;
            _shortSellStock = 0;
            _meanOf3days = 0;
            _increasingDivergenceThreshold = 0;
            _decreasingDivergenceThreshold = 0;
            _increasingConvergenceThreshold = 0;
            _decreasingConvergenceThreshold = 0;
            _firstStockDiverged = false;
            _secondStockDiverged = false;
            _alertSent = false;

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
            lblCorrelationThreshold.Visible = true;
            numCorrelationThreshold.Visible = true;
            lblOutput.Visible = true;
            txtOutput1.Visible = true;
            txtOutput2.Visible = true;
            btnMonitor.Visible = true;
            chartStocks.Visible = true;

            // Initialize the combobox selection.
            cboxMonitorMethod.SelectedIndex = 0;

            // Update the height and width of the form to fit the visible controls.
            this.Height = 538;
            this.Width = 1106;
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
                        _stockPrices[0].Add(Convert.ToDouble((line1.Split(','))[1]));
                        _stockPrices[1].Add(Convert.ToDouble((line2.Split(','))[1]));
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
            chartStocks.Series.Clear();

            // Make the chart visible.
            chartStocks.Visible = true;
            lblXAxis.Visible = true;
            lblXAxis.BringToFront();
            lblYAxis.Visible = true;
            lblYAxis.BringToFront();

            // Add the stocks to the chart series.
            chartStocks.Series.Add(_stockName0);
            chartStocks.Series.Add(_stockName1);

            // Change the chart type of our series to Line.
            chartStocks.Series[_stockName0].ChartType = SeriesChartType.Line;

            chartStocks.Series[_stockName0].ChartType = SeriesChartType.Line;
            chartStocks.Series[_stockName0].BorderDashStyle = ChartDashStyle.DashDotDot;

            chartStocks.Series[_stockName1].ChartType = SeriesChartType.Line;

            // Reset the current day count.
            _currentDay = 0;

            // Start our time monitoring ticking.

            CaculateStdMultiplier();
            _shortSellProfit = 0;
            _longBuyProfit = 0;
            _alertSent = false;
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

        private void cboxMonitorMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxMonitorMethod.SelectedIndex == 0)
            {
                lblCorrelationThreshold.Visible = true;
                numCorrelationThreshold.Visible = true;
                lblSTDThreshold.Visible = false;
                numSTDThreshold.Visible = false;
                txtOutput2.Visible = false;
                lblMean.Visible = false;
                txtMean.Visible = false;

                lblWindow.Text = "Calculate correlation within this many days: ";

                lblOutput.Text = "Current Correlation: ";
            }
            else if (cboxMonitorMethod.SelectedIndex == 1)
            {
                lblCorrelationThreshold.Visible = false;
                numCorrelationThreshold.Visible = false;
                lblSTDThreshold.Visible = true;
                numSTDThreshold.Visible = true;
                txtOutput2.Visible = true;
                lblMean.Visible = true;
                txtMean.Visible = true;

                lblWindow.Text = "Calculate STD within this many days: ";

                lblOutput.Text = "Current STD divergance: ";
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
            return Math.Sqrt(sum / (numberOfDays - 1));
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
                chartStocks.Series[_stockName0].Points.AddY(_stockPrices[0][_currentDay]);
                chartStocks.Series[_stockName1].Points.AddY(_stockPrices[1][_currentDay]);
                _currentDay++;
            }

            // Now increment daily and check the correlation.
            else if (_currentDay < _stockPrices[0].Count)
            {
                double correlation;
                if (_currentDay % (int)numWindow.Value == 0)
                {
                    correlation = Correlation(_stockPrices[0], _stockPrices[1], _currentDay, (int)numWindow.Value);
                    txtOutput1.Text = correlation.ToString();
                }

                chartStocks.Series[_stockName0].Points.AddY(_stockPrices[0][_currentDay]);
                chartStocks.Series[_stockName1].Points.AddY(_stockPrices[1][_currentDay]);
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
                chartStocks.Series[_stockName0].Points.AddY(_stockPrices[0][_currentDay]);
                chartStocks.Series[_stockName1].Points.AddY(_stockPrices[1][_currentDay]);
                _currentDay++;
            }
            // Now increment daily and check the Divergence.
            else if (_currentDay < _stockPrices[0].Count)
            {
                chartStocks.Series[_stockName0].Points.AddY(_stockPrices[0][_currentDay]);
                chartStocks.Series[_stockName1].Points.AddY(_stockPrices[1][_currentDay]);

                if ((int)numWindow.Value <= _currentDay)
                {
                    if (_firstStockDiverged && _secondStockDiverged && !_alertSent)
                    {
                        timerMonitor.Stop();
                        if (_maxPricePredictor == 0)
                            MessageBox.Show("Both stocks are diverging, the program will send an alert for the proper time of trade");
                        else
                            MessageBox.Show("Both stocks are diverging expected to reach max price in " + _maxPricePredictor.ToString() + " days");
                        _dayOfDivergence = _currentDay;
                        _alertSent = true;
                        if (_stockPrices[0][_currentDay] > _stockPrices[1][_currentDay])
                            _shortSellStock = 0;
                        else
                            _shortSellStock = 1;
                        timerMonitor.Start();
                    }
                    if (_alertSent && _maxPricePredictor == 0)
                    {
                        timerMonitor.Stop();
                        _meanOf3days = (_stockPrices[_shortSellStock][_currentDay - 1] + _stockPrices[_shortSellStock][_currentDay - 2] + _stockPrices[_shortSellStock][_currentDay - 3]) / 3;
                        if (_stockPrices[_shortSellStock][_currentDay] < _meanOf3days)
                        {
                            DialogResult dialogResult = MessageBox.Show("Predicted maximum reached would you like to begin the trade?", "Pairs Trading Reccomendation", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                if (_shortSellStock == 0)
                                {
                                    _shortSellProfit += _stockPrices[0][_currentDay];
                                    _longBuyProfit -= _stockPrices[1][_currentDay];
                                }
                                else
                                {
                                    _shortSellProfit += _stockPrices[1][_currentDay];
                                    _longBuyProfit -= _stockPrices[0][_currentDay];
                                }
                            }
                            _maxPricePredictor = -1;
                        }
                        timerMonitor.Start();
                    }
                    else if (_alertSent && (_dayOfDivergence + _maxPricePredictor == _currentDay))
                    {
                        timerMonitor.Stop();
                        DialogResult dialogResult = MessageBox.Show("Predicted maximum reached would you like to begin the trade?", "Pairs Trading Reccomendation", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            if (_shortSellStock == 0)
                            {
                                _shortSellProfit += _stockPrices[0][_currentDay];
                                _longBuyProfit -= _stockPrices[1][_currentDay];
                            }
                            else
                            {
                                _shortSellProfit += _stockPrices[1][_currentDay];
                                _longBuyProfit -= _stockPrices[0][_currentDay];
                            }
                        }
                        timerMonitor.Start();
                    }
                    if (_alertSent && !_firstStockDiverged && !_secondStockDiverged)
                    {
                        timerMonitor.Stop();
                        if (_shortSellProfit != 0)
                        {
                            DialogResult dialogResult = MessageBox.Show("The Stocks have converged would you like to reverse the trade?", "Pairs Trading Reccomendation", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                if (_shortSellStock == 0)
                                {
                                    _shortSellProfit -= _stockPrices[0][_currentDay];
                                    _longBuyProfit += _stockPrices[1][_currentDay];
                                }
                                else
                                {
                                    _shortSellProfit -= _stockPrices[1][_currentDay];
                                    _longBuyProfit += _stockPrices[0][_currentDay];
                                }
                                MessageBox.Show("Your profit is " + (_shortSellProfit + _longBuyProfit).ToString() + " $");
                                _shortSellProfit = 0;
                                _longBuyProfit = 0;
                            }
                        }
                        else
                            MessageBox.Show("The Stocks have converged");
                        _alertSent = false;
                        if (_maxPricePredictor == -1)
                            _maxPricePredictor = 0;
                        timerMonitor.Start();
                    }
                    if (_currentDay % (int)numWindow.Value == 0 && !(_firstStockDiverged && _secondStockDiverged))
                    {
                        _increasingDivergenceThreshold = CoMean(_stockPrices[0], _stockPrices[1], _currentDay, (int)numWindow.Value) +
                        CoStd(_stockPrices[0], _stockPrices[1], _currentDay, (int)numWindow.Value) * _stdMultiplier;

                        _decreasingDivergenceThreshold = CoMean(_stockPrices[0], _stockPrices[1], _currentDay, (int)numWindow.Value) -
                            CoStd(_stockPrices[0], _stockPrices[1], _currentDay, (int)numWindow.Value) * _stdMultiplier;

                        _decreasingConvergenceThreshold = CoMean(_stockPrices[0], _stockPrices[1], _currentDay, (int)numWindow.Value) +
                        CoStd(_stockPrices[0], _stockPrices[1], _currentDay, (int)numWindow.Value) * (_stdMultiplier);

                        _increasingConvergenceThreshold = CoMean(_stockPrices[0], _stockPrices[1], _currentDay, (int)numWindow.Value) -
                            CoStd(_stockPrices[0], _stockPrices[1], _currentDay, (int)numWindow.Value) * (_stdMultiplier);
                    }
                    if (!_firstStockDiverged && (_stockPrices[0][_currentDay] >= _increasingDivergenceThreshold ||
                        _stockPrices[0][_currentDay] <= _decreasingDivergenceThreshold))
                    {
                        timerMonitor.Stop();
                        txtOutput1.Text = _stockName0 + " Is diverging" + _currentDay;
                        //MessageBox.Show(_stockName0 + " Is diverging" + _currentDay);
                        _firstStockDiverged = true;
                        timerMonitor.Start();
                    }
                    else if (_firstStockDiverged && (_stockPrices[0][_currentDay] >= _increasingConvergenceThreshold &&
                        _stockPrices[0][_currentDay] <= _decreasingConvergenceThreshold))
                    {
                        timerMonitor.Stop();
                        txtOutput1.Text = _stockName0 + " Is converging" + _currentDay;
                        //MessageBox.Show(_stockName0 + " Is converging" + _currentDay);
                        _firstStockDiverged = false;
                        timerMonitor.Start();
                    }
                    if (!_secondStockDiverged && (_stockPrices[1][_currentDay] >= _increasingDivergenceThreshold ||
                        _stockPrices[1][_currentDay] <= _decreasingDivergenceThreshold))
                    {
                        timerMonitor.Stop();
                        txtOutput2.Text = _stockName1 + " Is diverging" + _currentDay;
                        //MessageBox.Show(_stockName1 + " Is diverging" + _currentDay);
                        _secondStockDiverged = true;
                        timerMonitor.Start();
                    }
                    else if (_secondStockDiverged && (_stockPrices[1][_currentDay] >= _increasingConvergenceThreshold &&
                        _stockPrices[1][_currentDay] <= _decreasingConvergenceThreshold))
                    {
                        timerMonitor.Stop();
                        txtOutput2.Text = _stockName1 + " Is donverging" + _currentDay;
                        //MessageBox.Show(_stockName1 + " Is converging" + _currentDay);
                        _secondStockDiverged = false;
                        timerMonitor.Start();
                    }
                }
                _currentDay++;
            }
            else
            {
                timerMonitor.Stop();
            }

        }
        void CaculateStdMultiplier()
        {
            List<double> stock1Means = new List<double>();
            List<double> stock2Means = new List<double>();
            List<Tuple<int, int>> divergenceInfo = new List<Tuple<int, int>>();
            int meanWindow = 5;
            int CorrelationWindow = (int)numWindow.Value / meanWindow;
            double correlation;
            int divergenceCounter = 0;
            for (int i = 0, j = 0; i < _stockPrices[0].Count && i < numDays.Value; i++)
            {
                if (i % meanWindow == 0)
                {
                    stock1Means.Add(_stockPrices[0][i]);
                    stock2Means.Add(_stockPrices[1][i]);
                }
                else if (i % meanWindow < meanWindow - 1)
                {
                    stock1Means[j] += _stockPrices[0][i];
                    stock2Means[j] += _stockPrices[1][i];
                }
                else
                {
                    stock1Means[j] += _stockPrices[0][i];
                    stock2Means[j] += _stockPrices[1][i];
                    stock1Means[j] /= meanWindow;
                    stock2Means[j] /= meanWindow;
                    j++;
                }
            }
            int k = CorrelationWindow;
            int maxMeanIndex;
            int divergedAt = 0, MaxPriceAt = 0;
            bool forgiveOne = true;
            while (k < stock1Means.Count)
            {
                for (; k < stock1Means.Count; k++)
                {
                    correlation = Correlation(stock1Means, stock2Means, k, CorrelationWindow);
                    if (correlation < -0.5)
                    {
                        divergenceCounter++;
                        divergedAt = k * meanWindow - meanWindow;
                        maxMeanIndex = k;
                        k++;
                        forgiveOne = true;
                        while (k < stock1Means.Count)
                        {
                            if (!(Correlation(stock1Means, stock2Means, k, CorrelationWindow) < -0.6))
                                if (forgiveOne)
                                    forgiveOne = false;
                                else
                                    break;
                            if (Math.Max(stock1Means[maxMeanIndex], stock2Means[maxMeanIndex]) < Math.Max(stock1Means[k], stock2Means[k]))
                                maxMeanIndex = k;
                            k++;
                        }
                        MaxPriceAt = maxMeanIndex * meanWindow - meanWindow / 2;
                        divergenceInfo.Add(new Tuple<int, int>(divergedAt, MaxPriceAt));
                        break;
                    }
                }
            }
            if (divergenceInfo.Count == 0)
            {
                _stdMultiplier = 2;
                _maxPricePredictor = 0;
                return;
            }
            double multiplierSum = 0;
            int day;
            for (int i = 0; i < divergenceInfo.Count; i++)
            {
                _stdMultiplier = 0.5;
                day = divergenceInfo[i].Item1;
                _maxPricePredictor += (divergenceInfo[i].Item2 - day);
                while (true)
                {
                    _increasingDivergenceThreshold = CoMean(_stockPrices[0], _stockPrices[1], day, (int)numWindow.Value) +
                            CoStd(_stockPrices[0], _stockPrices[1], day, (int)numWindow.Value) * _stdMultiplier;

                    _decreasingDivergenceThreshold = CoMean(_stockPrices[0], _stockPrices[1], day, (int)numWindow.Value) -
                        CoStd(_stockPrices[0], _stockPrices[1], day, (int)numWindow.Value) * _stdMultiplier;

                    _decreasingConvergenceThreshold = CoMean(_stockPrices[0], _stockPrices[1], day, (int)numWindow.Value) +
                    CoStd(_stockPrices[0], _stockPrices[1], day, (int)numWindow.Value) * _stdMultiplier;

                    _increasingConvergenceThreshold = CoMean(_stockPrices[0], _stockPrices[1], day, (int)numWindow.Value) -
                        CoStd(_stockPrices[0], _stockPrices[1], day, (int)numWindow.Value) * _stdMultiplier;
                    if ((_stockPrices[0][day] >= _increasingDivergenceThreshold ||
                            _stockPrices[0][day] <= _decreasingDivergenceThreshold) && (
                            (_stockPrices[1][day] >= _increasingDivergenceThreshold ||
                            _stockPrices[1][day] <= _decreasingDivergenceThreshold)))
                    {
                        _stdMultiplier += 0.5;
                    }
                    else
                    {
                        multiplierSum += _stdMultiplier;
                        break;
                    }
                }
            }
            _stdMultiplier = multiplierSum / divergenceInfo.Count;
            _maxPricePredictor /= divergenceInfo.Count;
            numSTDThreshold.Value = (decimal)_stdMultiplier;
        }

        #endregion

    }
}