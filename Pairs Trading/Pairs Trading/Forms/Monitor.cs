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

            Series series1;
            string[] typeArray = { "01.01.2011", "02.01.2011", "03.01.2011", "04.01.2011", "05.01.2011" };

            int[] pointsArray = { 1, 3, 9, 4, 2 };
            int i = 5;
            while (i > 0)
            {
                i--;
                series1 = this.chart1.Series.Add(typeArray[i]);
                series1.Points.AddXY("Dates", pointsArray[i]);
                series1.ChartType = SeriesChartType.Line; // THIS LINE DOES NOT WORK

            }
        }

        #region ' Event Handlers '

        #endregion

        #region ' Support Methods '

        #endregion

    }
}
