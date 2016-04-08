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

        #endregion

        #region ' Constructors '

        public Monitor()
        {
            InitializeComponent();
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
            btnMonitor.Visible = true;

        }

        private void btnMonitor_Click(object sender, EventArgs e)
        {
            string line1, line2;
            int firstStock = Int32.Parse(txtFirstStock.Text);
            int secondStock = Int32.Parse(txtSecondStock.Text);
            List<List<double>> stockPrices = new List<List<double>>();
            StreamReader strReader1 = new StreamReader(_stockNames[firstStock]);
            StreamReader strReader2 = new StreamReader(_stockNames[secondStock]);
            line1 = strReader1.ReadLine();
            line2 = strReader2.ReadLine();

            stockPrices.Add(new List<double>());
            stockPrices.Add(new List<double>());
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
                        stockPrices[0].Add(Convert.ToDouble((line1.Split(','))[4]));
                        stockPrices[1].Add(Convert.ToDouble((line2.Split(','))[4]));
                    }
                }
                catch (Exception)
                {

                    continue;
                }
            }

            string stockName0 = _stockNames[firstStock].Substring(_stockNames[firstStock].LastIndexOf("\\") + 1);
            stockName0 = stockName0.Substring(0, stockName0.LastIndexOf(".csv"));
            string stockName1 = _stockNames[secondStock].Substring(_stockNames[secondStock].LastIndexOf("\\") + 1);
            stockName1 = stockName1.Substring(0, stockName1.LastIndexOf(".csv"));

            chart1.Series.Clear();

            chart1.Series.Add(stockName0);
            chart1.Series.Add(stockName1);

            chart1.Series[stockName0].ChartType = SeriesChartType.Line;
            chart1.Series[stockName1].ChartType = SeriesChartType.Line;

            for (int i = 0; i < stockPrices[0].Count && i < numDays.Value; i++)
            {
                chart1.Series[stockName0].Points.AddY(stockPrices[0][i]);
                chart1.Series[stockName1].Points.AddY(stockPrices[1][i]);
            }
        }

        #endregion

        #region ' Support Methods '

        #endregion

    }
}
