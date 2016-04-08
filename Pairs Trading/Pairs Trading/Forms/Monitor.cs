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
        #region ' Custom Classes '

        private class UISync
        {
            private static ISynchronizeInvoke _sync;

            public static void Init(ISynchronizeInvoke sync)
            {
                _sync = sync;
            }

            public static void Execute(System.Action action)
            {
                try
                {
                    _sync.Invoke(action, null);
                    //_sync.BeginInvoke(action, null);
                }
                catch
                {
                }
            }
        }

        #endregion

        #region ' Member Variables '

        private string _fileName;
        private string _pathName;
        private int _stockCount;
        private string[] _stockNames;
        private int _stockDownloadedCount;
        private string _apiKey;
        private int _activeWorkers;
        private List<string> _stocks;
        List<List<double>> _stockPrices;
        string _stockName0;
        string _stockName1;
        int _currentDay;

        #endregion

        #region ' Constructors '

        public Monitor()
        {
            InitializeComponent();

            // Initial variables.
            _fileName = string.Empty;
            _pathName = string.Empty;
            _stockCount = 0;
            _activeWorkers = 0;
            _stockName0 = string.Empty;
            _stockName1 = string.Empty;
            _currentDay = 0;
            
            UISync.Init(this);
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
            // Maybe filer out non-csv files?

            _stockCount = _stockNames.Count();

            /* This is how we will plot points on the chart */
            //chart1.Series["Series1"].ChartType = SeriesChartType.Line;
            //chart1.Series["Series1"].Points.AddXY(50, 50);
            //chart1.Series["Series1"].Points.AddXY(60, 70);
            //chart1.Series["Series1"].Points.AddXY(80, 30);

            lblStockCount.Text = _stockCount.ToString();
            lblStockCount.Visible = true;
            lblLineCountIntro.Visible = true;
            lblFirstStock.Visible = true;
            lblSecondStock.Visible = true;
            txtFirstStock.Visible = true;
            txtSecondStock.Visible = true;
            lblDays.Visible = true;
            numDays.Visible = true;
            lblThreshold.Visible = true;
            numThreshold.Visible = true;
            btnMonitor.Visible = true;

        }

        private void btnMonitor_Click(object sender, EventArgs e)
        {
            string line1, line2;
            int firstStock = Int32.Parse(txtFirstStock.Text);
            int secondStock = Int32.Parse(txtSecondStock.Text);

            _stockPrices = new List<List<double>>();

            StreamReader strReader1 = new StreamReader(_stockNames[firstStock]);
            StreamReader strReader2 = new StreamReader(_stockNames[secondStock]);
            line1 = strReader1.ReadLine();
            line2 = strReader2.ReadLine();

            _stockPrices.Add(new List<double>());
            _stockPrices.Add(new List<double>());
            while (!strReader1.EndOfStream && !strReader2.EndOfStream)
            {
                line1 = strReader1.ReadLine();
                line2 = strReader2.ReadLine();
                try
                {
                    DateTime dt1 = Convert.ToDateTime(line1.Split(',')[0]);
                    DateTime dt2 = Convert.ToDateTime(line2.Split(',')[0]);
                    while (dt1.Date != dt2.Date && !strReader1.EndOfStream && !strReader2.EndOfStream)
                    {
                        while (dt1.Date > dt2.Date && !strReader1.EndOfStream)
                        {
                            line1 = strReader1.ReadLine();
                            dt1 = Convert.ToDateTime(line1.Split(',')[0]);
                        }
                        while (dt1.Date < dt2.Date && !strReader2.EndOfStream)
                        {
                            line2 = strReader2.ReadLine();
                            dt2 = Convert.ToDateTime(line2.Split(',')[0]);
                        }
                    }
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

            _stockName0 = _stockNames[firstStock].Substring(_stockNames[firstStock].LastIndexOf("\\") + 1);
            _stockName0 = _stockName0.Substring(0, _stockName0.LastIndexOf(".csv"));

            _stockName1 = _stockNames[secondStock].Substring(_stockNames[secondStock].LastIndexOf("\\") + 1);
            _stockName1 = _stockName1.Substring(0, _stockName1.LastIndexOf(".csv"));

            chart1.Series.Clear();

            chart1.Series.Add(_stockName0);
            chart1.Series.Add(_stockName1);

            chart1.Series[_stockName0].ChartType = SeriesChartType.Line;
            chart1.Series[_stockName1].ChartType = SeriesChartType.Line;

            _currentDay = 0;

            timerMonitor.Start();

        }

        private void timerMonitor_Tick(object sender, EventArgs e)
        {
            // Plot the days up until the selected number of days.
            if(_currentDay <_stockPrices[0].Count && _currentDay < numDays.Value){
                chart1.Series[_stockName0].Points.AddY(_stockPrices[0][_currentDay]);
                chart1.Series[_stockName1].Points.AddY(_stockPrices[1][_currentDay]);
                _currentDay++;
            }

            // Now increment daily and check the correlation.
            else if (_currentDay < _stockPrices[0].Count)
            {
                double correlation = Correlation(_stockPrices[0], _stockPrices[1], _currentDay);
                chart1.Series[_stockName0].Points.AddY(_stockPrices[0][_currentDay]);
                chart1.Series[_stockName1].Points.AddY(_stockPrices[1][_currentDay]);
                if (correlation < (double)numThreshold.Value)
                {
                    timerMonitor.Stop();
                    MessageBox.Show("Correlation is " + correlation);
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

        #region ' Support Methods '

        private double Correlation(List<double> stock1, List<double> stock2, int days)
        {
            return Covariance(stock1, stock2, days) / (Std(stock1, days) * Std(stock2, days));
        }

        private double Covariance(List<double> stock1, List<double> stock2, int days)
        {
            double sum = 0;
            double mean1 = Mean(stock1, days), mean2 = Mean(stock2, days);
            for (int i = 0; i < stock1.Count && i < days; i++)
                sum += (stock1[i] - mean1) * (stock2[i] - mean2);
            return sum / (stock1.Count - 1);
        }

        private double Std(List<double> stock, int days)
        {
            double sum = 0, mean = Mean(stock, days); ;
            for (int i = 0; i < stock.Count && i < days; i++)
                sum += (stock[i] - mean) * (stock[i] - mean);
            return Math.Sqrt(sum / (stock.Count - 1));
        }

        private double Mean(List<double> stock, int days)
        {
            double sum = 0;
            for (int i = 0; i < stock.Count && i < days; i++)
                sum += stock[i];
            return sum / stock.Count;
        }

        #endregion

    }
}
