using Pairs_Trading.Classes;
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

            /* Set the initial height of the form.
             * This will change later on successful file browse. */
            this.Height = 150;

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
            /* Create a file browsing dialog.
             * Set its filter to browse for .csv files.
             * Show the dialog */
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "CSV |*.csv";
            DialogResult result = fileDialog.ShowDialog();

            // If the browsing return an invalid code, exit the method.
            if (result != DialogResult.OK)
            {
                return;
            }

            // Get the whole path of the CSV file.
            _fileName = fileDialog.FileName;

            // Get the directory of the CSV file.
            _pathName = Path.GetDirectoryName(_fileName);

            // Display the CSV file name with its path.
            txtBrowse.Text = _fileName;

            /* The stock count is the number of stocks,
             * minus 1 because of the header line 
             * which contains the field's name. */
            _stockCount = File.ReadLines(fileDialog.FileName).Count() - 1;

            // Display the stock count.
            lblStockCount.Text = _stockCount.ToString();

            // Set the remaining controls to visible.
            lblStockCount.Visible = true;
            lblLineCountIntro.Visible = true;
            lblRetieveIntro.Visible = true;
            lblQuandlApiIntro.Visible = true;
            txtQuandlApi.Visible = true;
            lblDownloadWorkersIntro.Visible = true;
            numDownloadWorkers.Visible = true;
            btnProcess.Visible = true;

            // Update the height of the form to fit the visible controls.
            this.Height = 354;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            // If the Download has started, abort downloading and notify accordingly.
            if (btnProcess.Text == "Stop")
            {
                _downloadThread.Abort();
                btnProcess.Text = "Start";
                lblDownloadProgress.Text += ", Download Stopping";
                btnProcess.Enabled = false;
                return;
            }

            // Get the API key from user.
            _apiKey = txtQuandlApi.Text;

            // Update controls for state changes.
            btnProcess.Text = "Stop";
            txtQuandlApi.Enabled = false;
            btnBrowse.Enabled = false;
            pbDownload.Visible = true;
            lblDownloadProgress.Visible = true;
            lblDownloadProgress.Text = "Downloaded 0/" + _stockCount;

            // Reset progress bar and set maximum to number of stocks to be downloaded.
            pbDownload.Maximum = _stockCount;
            pbDownload.Value = 0;

            // Create directory if it does not exist.
            System.IO.Directory.CreateDirectory(_pathName + @"\Stocks");

            // Create and start the main download thread.
            _downloadThread = new Thread(DownloadData);
            _downloadThread.Start();
        }

        private void Loader_FormClosing(object sender, FormClosingEventArgs e)
        {
            // If the main download thread exists and is still alive, abort it.
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

        private void ReverseFile(string path)
        {
            List<string> data = new List<string>();
            StreamReader strReader = new StreamReader(path);
            

            while (!strReader.EndOfStream)
            {
                data.Add(strReader.ReadLine());
                
            }
            // Free our writing lock on the file.
            strReader.Close();

            StreamWriter strWriter = new StreamWriter(path);

            strWriter.Write(data[0]);

            for(int i = data.Count-1; i>0; i--)
            {
                strWriter.Write("\n");
                strWriter.Write(data[i]);
            }

            // Free our writing lock on the file.
            strWriter.Close();
            
        }

        private void DownloadData()
        {
            // Reset variables.
            _stocks = new List<string>();
            _stockDownloadedCount = 0;

            // Open the CSV file.
            StreamReader reader = new StreamReader(File.OpenRead(_fileName));

            // Store all the stock data in one list.
            while (!reader.EndOfStream)
            {
                // Read a line.
                var line = reader.ReadLine();
                // Ignore first line containing field's name.
                if (line.Equals("quandl code,name"))
                {
                    continue;
                }
                // Add the data to our list.
                _stocks.Add(line);
            }

            // Free our writing lock on the file.
            reader.Close();

            // Download the stocks
            foreach (string s in _stocks)
            {
                // Get the stock codes in the correct format.
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
            // Use a web client to download the data.
            using (var client = new WebClient())
            {
                // Create the file URL.
                string url = "https://www.quandl.com/api/v3/datasets/" + stockGroup +
                    "/" + fileName + ".csv?api_key=" + _apiKey;

                // Create the new file path.
                string file = _pathName + @"\Stocks\" + fileName + ".csv";

                // Keep trying to download the file
                while(true)
                    try
                    {
                        // Download the file using our web client.
                        client.DownloadFile(url, file);
                        break;
                    }
                    catch
                    {
                        // If the download fails, sleep then try again
                        Thread.Sleep(500);
                    }

                // Reverse the stock data.
                ReverseFile(file);

                // Log our downloaded stock count.
                _stockDownloadedCount++;

                // Update visuals of progress.
                UISync.Execute(() => pbDownload.Value = _stockDownloadedCount);
                UISync.Execute(() => lblDownloadProgress.Text = "Downloaded " + _stockDownloadedCount + "/" + _stockCount);

                // Declare available worker slot.
                _activeWorkers--;

                // If the download has been flagged for stopping, update visuals with notification of stoppage.
                if (btnProcess.Text == "Start")
                {
                    // If this thread is not the last thread, indicate so.
                    if (_activeWorkers != 0)
                    {
                        UISync.Execute(() => lblDownloadProgress.Text += ", Download Stopping");
                    }
                    // If this thread is the last thread, indicate downloading has stopped.
                    else
                    {
                        UISync.Execute(() => lblDownloadProgress.Text += ", Download Stopped");

                        // Re-enable the download button.
                        UISync.Execute(() => btnProcess.Enabled = true);
                    }

                }

                // If all files have been downloaded, update visuals for notification. 
                if(_stockDownloadedCount == _stockCount)
                {
                    UISync.Execute(() => lblDownloadProgress.Text = "Download Complete");
                    UISync.Execute(() => btnProcess.Enabled = true);
                }
            }
        }

        
        
        #endregion

    }
}
