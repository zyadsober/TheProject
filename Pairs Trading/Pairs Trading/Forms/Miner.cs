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
        private bool _NeighborThreadAlive;
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
            _NeighborThreadAlive = false;

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
            pbProgress.Maximum = _stockCount;

            lblLineCount.Text = _stockCount.ToString();
            lblLineCount.Visible = true;
            lblLineCountIntro.Visible = true;
            lblDistanceMeasure.Visible = true;
            cboxDistanceMeasure.Visible = true;
            lblDTWWindow.Visible = true;
            numDTWWindow.Visible = true;
            lblRetreiveDistance.Visible = true;
            lblFirstStock.Visible = true;
            lblSecondStock.Visible = true;
            txtFirstStock.Visible = true;
            txtSecondStock.Visible = true;
            btnGetDistance.Visible = true;
            lblDistance.Visible = true;
            txtDistance.Visible = true;
            btnGetCorrelation.Visible = true;
            lblCorrelation.Visible = true;
            txtCorrelation.Visible = true;
            lblNearestNeighborIntro.Visible = true;
            lblStock.Visible = true;
            txtStock.Visible = true;
            btnNearestNeighbor.Visible = true;
            lblNearestNeighbor.Visible = true;
            txtNearestNeighbour.Visible = true;
            btnAllNearestNeighbors.Visible = true;

            this.Height = 564;
            
        }

        private void btnGetDistance_Click(object sender, EventArgs e)
        {
            pbProgress.Visible = true;
            pbProgress.Value = 0;
            btnGetDistance.Enabled = false;
            btnNearestNeighbor.Enabled = false;

            if (cboxDistanceMeasure.SelectedIndex == 0)
            {
                txtDistance.Text = GetDTWDistance(Int32.Parse(txtFirstStock.Text), Int32.Parse(txtSecondStock.Text)).ToString();
            }
            else if (cboxDistanceMeasure.SelectedIndex == 1)
            {
                txtDistance.Text = GetEuclideanDistance(Int32.Parse(txtFirstStock.Text), Int32.Parse(txtSecondStock.Text)).ToString();
            }
            
            btnGetDistance.Enabled = true;
            btnNearestNeighbor.Enabled = true;
            //MessageBox.Show(DTW(stocksPrices[0],stocksPrices[1]).ToString());
        }

        private void btnGetCorrelation_Click(object sender, EventArgs e)
        {
            txtCorrelation.Text = GetCorrelation(Int32.Parse(txtFirstStock.Text), Int32.Parse(txtSecondStock.Text)).ToString();
        }

        private void btnNearestNeighbour_Click(object sender, EventArgs e)
        {
            pbProgress.Visible = true;
            pbProgress.Value = 0;
            btnGetDistance.Enabled = false;
            btnNearestNeighbor.Enabled = false;

            int stock = Int32.Parse(txtStock.Text);
            if (cboxDistanceMeasure.SelectedIndex == 0)
            {
                _DTWThread = new Thread(() => DTWWork(stock));
                _DTWThread.Start();
            }
            else if (cboxDistanceMeasure.SelectedIndex == 1)
            {
                
            }
        }

        private void btnGetAllNearestNeighbors_Click(object sender, EventArgs e)
        {
            pbProgress.Visible = true;
            pbProgress.Value = 0;
            btnGetDistance.Enabled = false;
            btnNearestNeighbor.Enabled = false;

            new Thread(() => DTWAllManager()).Start();
        }

        private void formDataRetieve_FormClosing(object sender, FormClosingEventArgs e)
        {
           //Handle thread abortions
        }

        private void Miner_Load(object sender, EventArgs e)
        {
            cboxDistanceMeasure.SelectedIndex = 0;
        }

        private void cboxDistanceMeasure_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblRetreiveDistance.Text = "Select two pairs to retrieve the " +
                cboxDistanceMeasure.Text + " distance between them";
            btnGetDistance.Text = "Get " + cboxDistanceMeasure.Text + " Distance";
            lblNearestNeighborIntro.Text = "Select a pair to get its nearest neighbor with respect to the "
            + cboxDistanceMeasure.Text + " between them";
            btnNearestNeighbor.Text = "Get Nearest Neighbour (" + cboxDistanceMeasure.Text + ")";
        }

        #endregion

        #region ' Support Methods '

        
        private bool StockIsInLastDays(DateTime dt, int days)
        {
            /* Check weather the date given is within the last given days */
            DateTime dtNow = DateTime.Now;
            if ((dtNow - dt).TotalDays <= days)
            {
                return true;
            }
            return false;
        }

        private double GetDTWDistance(int firstStock, int secondStock)
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
                        if (!chkStockDays.Checked || StockIsInLastDays(dt, Int32.Parse(numStockDays.Value.ToString())))
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

            //return DTW(stockPrices[0], stockPrices[1]);
            return DTW(stockPrices[0], stockPrices[1], (int)numDTWWindow.Value);
            
        }

        private double GetEuclideanDistance(int firstStock, int secondStock)
        {
            string line1, line2;
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

            //return DTW(stockPrices[0], stockPrices[1]);
            return Euclidean(stockPrices[0], stockPrices[1]);
        }
        
        //private double DTW(List<double> stock1, List<double> stock2)
        //{
        //    double[,] grid = new double[stock1.Count + 1, stock2.Count + 1];
        //    for (int i = 1; i < stock1.Count + 1; i++)
        //        grid[i, 0] = double.PositiveInfinity;


        //    for (int i = 1; i < stock2.Count + 1; i++)
        //        grid[0, i] = double.PositiveInfinity;
        //    grid[0, 0] = 0;
        //    for (int i = 1; i < stock1.Count + 1; i++)
        //    {
        //        for (int j = 1; j < stock2.Count + 1; j++)
        //        {
        //            grid[i, j] = Distance(stock1[i - 1], stock2[j - 1]) + Math.Min(Math.Min(grid[i - 1, j], grid[i, j - 1]), grid[i - 1, j - 1]);
        //        }
        //    }
        //    StreamWriter strw = new StreamWriter(_pathName+"\\Grid.txt");
        //    for (int i = 0; i < stock1.Count; i++)
        //    {
        //        for (int j = 0; j < stock2.Count; j++)
        //        {
        //            strw.Write(grid[i, j] + "\t");
        //        }
        //        strw.Write("\n");
        //    }
        //    strw.Close();

        //        return grid[stock1.Count, stock2.Count];
        //}

        private double DTW(List<double> stock1, List<double> stock2, int w)
        {
            double[,] grid = new double[stock1.Count + 1, stock2.Count + 1];
            w = Math.Max(w, Math.Abs(stock1.Count - stock2.Count) + 1);
            for (int i = 0; i < stock1.Count + 1; i++)
                for (int j = 0; j < stock2.Count + 1; j++)
                    grid[i, j] = double.PositiveInfinity;
            grid[0, 0] = 0;
            for (int i = 1; i < stock1.Count + 1; i++)
            {
                for (int j = Math.Max(1, i - w); j < Math.Min(stock2.Count + 1, i + w); j++)
                {
                    grid[i, j] = Distance(stock1[i - 1], stock2[j - 1]) + Math.Min(Math.Min(grid[i - 1, j], grid[i, j - 1]), grid[i - 1, j - 1]);
                }
            }
            //StreamWriter strw = new StreamWriter(_pathName + "\\Grid.txt");
            //for (int i = 0; i < stock1.Count; i++)
            //{
            //    for (int j = 0; j < stock2.Count; j++)
            //    {
            //        strw.Write(grid[i, j] + "\t");
            //    }
            //    strw.Write("\n");
            //}
            //strw.Close();
            return grid[stock1.Count, stock2.Count];
        }

        private double Distance(double x, double y)
        {
            return Math.Abs(x - y);
        }

        private void DTWAllManager()
        {
            StreamWriter strw = new StreamWriter(_pathName + "\\Pairs.csv", false);
            strw.WriteLine("Stock #1,Stock #2,Distance");
            strw.Close();
            for (int i = 0; i < _stockCount; i++)
            {
                _DTWThread = new Thread(() => DTWWork(i));
                _NeighborThreadAlive = true;
                _DTWThread.Start();
                while (_NeighborThreadAlive)
                {
                    Thread.Sleep(20);
                }
                UISync.Execute(() => pbProgress.Value++);
            }
        }

        private void DTWWork(int stock)
        {
            _minDistance = double.MaxValue;
            _nearestNeighbour = -1;
            for (int i = 0; i < _stockCount; i++)
            {
                if (i == stock)
                {
                    continue;
                }

                // Wait for an available worker thread slot.
                while (_activeWorkers >= numWorkers.Value)
                {
                    // Sleep to relieve the CPU.
                    //Thread.Sleep(1);
                }

                // Worker thread available, reserve it.
                _activeWorkers++;

                // Create the worker thread supplied with quandl code and stock name.
                int secondStock = i; // Fix this, this is for data race prevention.
                new Thread(() => DTWWorker(stock, secondStock)).Start();

                /*double currentDistance = getDTWDistance(Int32.Parse(txtStock.Text), i);
                if (currentDistance < _minDistance)
                {
                    _minDistance = currentDistance;
                    nearestNeighbour = i;
                }*/
            }

            // Wait for all workers to exit before printing a result.
            while (_activeWorkers > 0)
            {
                // Sleep to relieve the CPU.
                //Thread.Sleep(1);
            }
            UISync.Execute(() => txtNearestNeighbour.Text = _nearestNeighbour.ToString());
            StreamWriter strw = new StreamWriter(_pathName + "\\Pairs.csv", true);
            strw.WriteLine(stock.ToString() + "," + txtNearestNeighbour.Text + "," + _minDistance);
            strw.Close();
            _NeighborThreadAlive = false;
        }

        private void DTWWorker(int firstStock, int secondStock)
        {
            double currentDistance = GetDTWDistance(firstStock, secondStock);
            if (currentDistance < _minDistance)
            {
                _minDistance = currentDistance;
                _nearestNeighbour = secondStock;
            }
            //UISync.Execute(() => pbProgress.Value++);
            if (pbProgress.Value == _stockCount)
            {
                btnGetDistance.Enabled = true;
                btnNearestNeighbor.Enabled = true;
            }
            _activeWorkers--;
            //Console.WriteLine("Worker number " + secondStock + " Distance: " + _minDistance);
        }

        private double Euclidean(List<double> stock1, List<double> stock2)
        {
            double distance = 0;
            for (int i = 0; i < stock1.Count; i++)
            {
                distance += Distance(stock1[i], stock2[i]);
            }
            return distance;
        }

        private double GetCorrelation(int firstStock, int secondStock)
        {
            // Used to check that the number of lines are the same.
            int[] lineCount = new int[2];

            StreamReader strReader;
            string line;
            List<List<double>> stockPrices = new List<List<double>>(); ;
            for (int i = 0; i < 2; i++)
            {
                lineCount[i] = 0;

                strReader = new StreamReader(_stockNames[(i == 0 ? firstStock : secondStock)]);
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
                        if (!chkStockDays.Checked || StockIsInLastDays(dt, Int32.Parse(numStockDays.Value.ToString())))
                        {
                            stockPrices[i].Add(Convert.ToDouble((line.Split(','))[4]));
                            lineCount[i]++;
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
            if (lineCount[0] != lineCount[1])
            {
                // Indicate that the lines aren't of the same length by using an impossible correlation value.
                return -2;
            }
            //return DTW(stockPrices[0], stockPrices[1]);
            return Correlation(stockPrices[0], stockPrices[1]);
        }

        private double Correlation(List<double> stock1, List<double> stock2)
        {
            return Covariance(stock1, stock2) / (Std(stock1) * Std(stock2));
        }

        private double Covariance(List<double> stock1, List<double> stock2)
        {
            double sum = 0;
            double mean1 = Mean(stock1), mean2 = Mean(stock2);
            for (int i = 0; i < stock1.Count; i++)
                sum += (stock1[i] - mean1) * (stock2[i] - mean2);
            return sum / (stock1.Count - 1);
        }

        private double Std(List<double> stock)
        {
            double sum = 0, mean = Mean(stock); ;
            for (int i = 0; i < stock.Count; i++)
                sum += (stock[i] - mean) * (stock[i] - mean);
            return Math.Sqrt(sum / (stock.Count - 1));
        }

        private double Mean(List<double> stock)
        {
            double sum = 0;
            for (int i = 0; i < stock.Count; i++)
                sum += stock[i];
            return sum / stock.Count;
        }

        #endregion

    }
}
