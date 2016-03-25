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

namespace Pairs_Trading.Forms
{
    public partial class Miner : Form
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
        private string[] _stockNames;
        private double _minDistance;
        private int _nearestNeighbour;
        private Thread _DTWThread;
        private int _activeWorkers;

        #endregion

        #region ' Constructors '

        public Miner()
        {
            InitializeComponent();

            this.Height = 150;

            // Initial variables.
            _fileName = string.Empty;
            _pathName = string.Empty;
            _stockCount = 0;
            _DTWThread = null;
            _nearestNeighbour = -1;
            _minDistance = double.MaxValue;
            _activeWorkers = 0;

            UISync.Init(this);
        }

        #endregion

        #region ' Event Handlers '

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            DialogResult result = folderDialog.ShowDialog();
            _pathName = folderDialog.SelectedPath;
            txtBrowse.Text = _pathName;

            _stockNames = Directory.GetFiles(_pathName);
            // Maybe filer out non-csv files?
            
            _stockCount = _stockNames.Count();
            lblLineCount.Text = _stockCount.ToString();
            lblLineCount.Visible = true;
            lblLineCountIntro.Visible = true;
            lblRetreiveDistance.Visible = true;
            lblFirstStock.Visible = true;
            lblSecondStock.Visible = true;
            txtFirstStock.Visible = true;
            txtSecondStock.Visible = true;
            btnGetDistance.Visible = true;
            lblDistance.Visible = true;
            txtDistance.Visible = true;
            lblNearestNeighborIntro.Visible = true;
            lblStock.Visible = true;
            txtStock.Visible = true;
            btnNearestNeighbor.Visible = true;
            lblNearestNeighbor.Visible = true;
            txtNearestNeighbour.Visible = true;

            this.Height = 547;
            
        }

        private void btnGetDistance_Click(object sender, EventArgs e)
        {
            
            txtDistance.Text = getDTWDistance(Int32.Parse(txtFirstStock.Text), Int32.Parse(txtSecondStock.Text)).ToString();
            //MessageBox.Show(DTW(stocksPrices[0],stocksPrices[1]).ToString());
        }

        private void formDataRetieve_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        #endregion


        #region ' Support Methods '

        /* Check weather the date given is within the last given days */
        private bool StockIsInLastDays(DateTime dt, int days)
        {
            DateTime dtNow = DateTime.Now;
            if ((dtNow - dt).TotalDays <= days)
            {
                return true;
            }
            return false;
        }


        private double getDTWDistance(int firstStock, int secondStock)
        {
            StreamReader strReader;
            string line;
            List<List<double>> stockPrices = new List<List<double>>();;
            for (int i = 0; i < 2; i++)
            {

                strReader = new StreamReader(_stockNames[(i==0?firstStock:secondStock)]);
                line = strReader.ReadLine();
                //stockPrices = new List<List<double>>();
                stockPrices.Add(new List<double>());
                while (!strReader.EndOfStream)
                {
                    line = strReader.ReadLine();

                    try
                    {
                        
                        DateTime dt = Convert.ToDateTime(line.Split(',')[0]);

                        /* If the checkbox for stocks within the last given days is checked,
                         * check the current stock if it is within the correct period,
                         * If the checkbox is not checked, use all the stocks*/
                        if (!chkStockDays.Checked || StockIsInLastDays(dt, 30))
                        {
                            stockPrices[i].Add(Convert.ToDouble((line.Split(','))[4]));
                        }
                        else
                        {
                            break;
                        }
                        

                    }
                    catch (Exception)
                    {

                        continue;
                    }
                }
            }
            return DTW(stockPrices[0], stockPrices[1]);
        }

        private double DTW(List<double> stock1,List<double> stock2)
        {
            double[,] grid=new double[stock1.Count+1,stock2.Count+1];
            for (int i = 1; i < stock1.Count + 1; i++)
                grid[i, 0] = double.PositiveInfinity;


            for (int i = 1; i < stock2.Count + 1; i++)
                grid[0, i] = double.PositiveInfinity;
            grid[0, 0] = 0;
            for(int i=1;i<stock1.Count+1;i++)
            {
                for(int j=1;j<stock2.Count+1;j++)
                {
                    grid[i,j]=Distance(stock1[i-1],stock2[j-1])+ Math.Min(Math.Min(grid[i-1,j],grid[i,j-1]),grid[i-1,j-1]);
                }
            }
            return grid[stock1.Count, stock2.Count];
        }
        private double Distance(double x, double y)
        {
            return Math.Abs(x - y);
        }

        #endregion

        private void btnNearestNeighbour_Click(object sender, EventArgs e)
        {
            int firstStock = Int32.Parse(txtStock.Text);
            _DTWThread = new Thread(() => DTWWork(firstStock));
            _DTWThread.Start();
        }

        private void DTWWork(int firstStock)
        {
            _minDistance = double.MaxValue;
            _nearestNeighbour = -1;
            for (int i = 0; i < _stockCount; i++)
            {
                if (i == Int32.Parse(txtStock.Text))
                {
                    continue;
                }

                // Wait for an available worker thread slot.
                while (_activeWorkers >= numWorkers.Value)
                {
                    // Sleep to relieve the CPU.
                    Thread.Sleep(500);
                }

                // Worker thread available, reserve it.
                _activeWorkers++;

                // Create the worker thread supplied with quandl code and stock name.
                int secondStock = i; // Fix this, this is for data race prevention.
                new Thread(() => DTWWorker(firstStock, secondStock)).Start();
                
                /*double currentDistance = getDTWDistance(Int32.Parse(txtStock.Text), i);
                if (currentDistance < _minDistance)
                {
                    _minDistance = currentDistance;
                    nearestNeighbour = i;
                }*/
            }
            UISync.Execute(() => txtNearestNeighbour.Text = _nearestNeighbour.ToString());
        }

        private void DTWWorker(int firstStock, int secondStock)
        {
            double currentDistance = getDTWDistance(firstStock, secondStock);
            if (currentDistance < _minDistance)
            {
                _minDistance = currentDistance;
                _nearestNeighbour = secondStock;
            }
            UISync.Execute(() => pbProgress.Value++);
            _activeWorkers--;
            //Console.WriteLine("Worker number " + secondStock + " Distance: " + _minDistance);
        }


    }
}
