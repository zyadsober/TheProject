using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pairs_Trading.Forms
{
    public partial class Loader : Form
    {
        

        #region ' Custom Classes '

        private class UISync
        {
            private static ISynchronizeInvoke _sync;

            public static void Init(ISynchronizeInvoke sync)
            {
                _sync = sync;
            }

            public static void Execute(Action action)
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
        private int _stockDownloadedCount;
        private string _apiKey;
        private int _activeWorkers;
        private List<string> _stocks;

        private Thread _downloadThread;

        #endregion

        #region ' Constructors '

        public Loader()
        {
            InitializeComponent();

            // Initial variables.
            _fileName = string.Empty;
            _pathName = string.Empty;
            _stockCount = 0;
            _stockDownloadedCount = 0;
            _activeWorkers = 0;
            _apiKey = string.Empty;
            _stocks = new List<string>();

            UISync.Init(this);
        }

        #endregion

        #region ' Event Handlers '

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "CVS |*.csv";
            DialogResult result = fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                // Whole path of the file.
                _fileName = fileDialog.FileName;
                _pathName = Path.GetDirectoryName(_fileName);
                txtBrowse.Text = _fileName;
                // Number of stocks, minus 1 because of the header line.
                _stockCount = File.ReadLines(fileDialog.FileName).Count() - 1;
                lblLineCount.Text = _stockCount.ToString();
                lblLineCount.Visible = true;
                lblLineCountIntro.Visible = true;
                lblRetieveIntro.Visible = true;
                lblQuandlApiIntro.Visible = true;
                txtQuandlApi.Visible = true;
                lblDownloadWorkersIntro.Visible = true;
                numDownloadWorkers.Visible = true;
                btnProcess.Visible = true;
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            btnProcess.Text = "Stop";
            txtQuandlApi.Enabled = false;

            _apiKey = txtQuandlApi.Text;

            btnBrowse.Enabled = false;
            pbDownload.Visible = true;
            pbDownload.Maximum = _stockCount;
            pbDownload.Value = 0;
            lblDownloadProgress.Visible = true;
            lblDownloadProgress.Text = "Downloaded 0/" + _stockCount;

            // Create directory if it does not exist.
            System.IO.Directory.CreateDirectory(_pathName + @"\Stocks");

            _downloadThread = new Thread(DownloadData);
            _downloadThread.Start();
        }

        private void formDataRetieve_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_downloadThread != null)
            {
                if (_downloadThread.IsAlive)
                {
                    _downloadThread.Abort();
                }
            }
        }

        #endregion

        #region ' Support Methods '

        private void DownloadData()
        {
            StreamReader reader = new StreamReader(File.OpenRead(_fileName));
            
            // Store all the stock data in one list.
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                // Ignore first line, Might change this later to a counter.
                if (line.Equals("quandl code,name"))
                {
                    continue;
                }
                _stocks.Add(line);
            }

            // Free up the file.
            reader.Close();

            foreach (string s in _stocks)
            {
                var values = s.Split('"');
                var code = values[0].Split('/');
                string stockGroup = code[0];
                string fileName = code[1].Remove(code[1].Length - 1);

                // Wait for an available worker thread slot.
                while (_activeWorkers >= numDownloadWorkers.Value)
                {
                    // Sleep to relieve the CPU.
                    Thread.Sleep(500);
                }
                
                // Worker thread available, reserve it.
                _activeWorkers++;

                // Create the worker thread supplied with quandl code and stock name.
                new Thread(() => DownloadWork(stockGroup, fileName)).Start();
            }

        }

        private void DownloadWork(string stockGroup, string fileName)
        {
            using (var client = new WebClient())
            {
                string url = "https://www.quandl.com/api/v3/datasets/" + stockGroup +
                    "/" + fileName + ".csv?api_key=" + _apiKey;
                string file = _pathName + @"\Stocks\" + fileName + ".csv";
                while(true)
                    try
                    {
                        client.DownloadFile(url, file);
                        break;
                    }
                    catch(Exception e)
                    {
                        //Sleep for 500ms then try again
                        Thread.Sleep(500);
                    }
                _stockDownloadedCount++;
                UISync.Execute(() => pbDownload.Value = _stockDownloadedCount);
                UISync.Execute(() => lblDownloadProgress.Text = "Downloaded " + _stockDownloadedCount + "/" + _stockCount);
                _activeWorkers--;
                if(_stockDownloadedCount == _stockCount)
                {
                    // All files downloaded.
                    UISync.Execute(() => lblDownloadProgress.Text = "Download Complete");
                }
            }
        }

        #endregion
    }
}
