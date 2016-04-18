using Pairs_Trading.Classes;
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
        #region ' Member Variables '

        private string _fileName;
        private string _pathName;
        private int _stockCount;
        private string[] _stockNames;
        private double _minDistance;
        private int _nearestNeighbour;
        private Thread _DistanceThread;
        private int _activeWorkers;

        /* _neighborThreadAlive is a custom indicator of the state of the
         * nearest neighbor thread. */
        private bool _neighborThreadAlive;

        /* _mode is an indicator of the distance measure in use.
         * _mode == -1: No mode set
         * _mode == 0 : DTW
         * _mode == 1 : Euclidean
         * This is in order to not use cross thread calls to the UI
         * Thread from the mining thread.*/
        private short _mode;

        #endregion

        #region ' Constructors '

        public Miner()
        {
            InitializeComponent();

            /* Set the initial height of the form.
             * This will change later on successful file browse. */
            this.Height = 150;

            // Initialize variables.
            _fileName = string.Empty;
            _pathName = string.Empty;
            _stockCount = 0;
            _DistanceThread = null;
            _nearestNeighbour = -1;
            _minDistance = double.MaxValue;
            _activeWorkers = 0;
            _neighborThreadAlive = false;
            _mode = -1;

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
            
            // Count the number of stocks contained in the folder.
            _stockCount = _stockNames.Count();

            // Display number of stocks.
            lblStockCount.Text = _stockCount.ToString();

            // Set progress bar max to stock count.
            pbProgress.Maximum = _stockCount;

            // Set the remaining controls to visible.
            lblStockCount.Visible = true;
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

            // Update the height of the form to fit the visible controls.
            this.Height = 564;
            
        }

        private void btnGetDistance_Click(object sender, EventArgs e)
        {
            // Reset the progress bar.
            pbProgress.Visible = true;
            pbProgress.Value = 0;

            // Update controls for state changes.
            btnGetDistance.Enabled = false;
            btnNearestNeighbor.Enabled = false;

            // Check which distance measurement method is selected.
            if (cboxDistanceMeasure.SelectedIndex == 0)
            {
                // Dispaly DTW distance.
                txtDistance.Text = GetDTWDistance(Int32.Parse(txtFirstStock.Text), Int32.Parse(txtSecondStock.Text)).ToString();
            }
            else if (cboxDistanceMeasure.SelectedIndex == 1)
            {
                // Display Euclidean distance.
                txtDistance.Text = GetEuclideanDistance(Int32.Parse(txtFirstStock.Text), Int32.Parse(txtSecondStock.Text)).ToString();
            }

            // Update controls for state changes.
            btnGetDistance.Enabled = true;
            btnNearestNeighbor.Enabled = true;
        }

        private void btnGetCorrelation_Click(object sender, EventArgs e)
        {
            // Display the correlation.
            txtCorrelation.Text = GetCorrelation(Int32.Parse(txtFirstStock.Text), Int32.Parse(txtSecondStock.Text)).ToString();
        }

        private void btnNearestNeighbour_Click(object sender, EventArgs e)
        {
            // Update controls for state changes.
            pbProgress.Visible = true;
            pbProgress.Value = 0;
            btnGetDistance.Enabled = false;
            btnNearestNeighbor.Enabled = false;

            // Get the selected stock.
            int stock = Int32.Parse(txtStock.Text);

            // Check the selected distance measurement method.
            if (cboxDistanceMeasure.SelectedIndex == 0)
            {
                // Set mode to DTW
                _mode = 0;
            }
            else if (cboxDistanceMeasure.SelectedIndex == 1)
            {
                // set mode to Euclidean
                _mode = 1;
            }

            // Create and start the main mining thread.
            _DistanceThread = new Thread(() => Work(stock, false));
            _DistanceThread.Start();
        }

        private void btnGetAllNearestNeighbors_Click(object sender, EventArgs e)
        {
            // Update controls for state changes.
            pbProgress.Visible = true;
            pbProgress.Value = 0;
            btnGetDistance.Enabled = false;
            btnNearestNeighbor.Enabled = false;
            btnGetDistance.Enabled = false;
            btnGetCorrelation.Enabled = false;
            btnAllNearestNeighbors.Enabled = false;

            // Check the selected distance measurement method.
            if (cboxDistanceMeasure.SelectedIndex == 0)
            {
                // Set mode to DTW.
                _mode = 0;
                
            }
            else if (cboxDistanceMeasure.SelectedIndex == 1)
            {
                // Set mode to Euclidean.
                _mode = 1;
                new Thread(() => AllManager()).Start();
            }

            // Start new manager thread.
            new Thread(() => AllManager()).Start();
            
        }

        private void Miner_Load(object sender, EventArgs e)
        {
            // Change selected index on load to DTW.
            cboxDistanceMeasure.SelectedIndex = 0;
        }

        private void Miner_FormClosing(object sender, FormClosingEventArgs e)
        {
            // TO-DO: Handle Closing threads.
        }

        private void cboxDistanceMeasure_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Change Interface to reflect selected distance measurement method.
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
            // Define local variables.
            StreamReader strReader;
            string line;
            List<List<double>> stockPrices = new List<List<double>>();

            /* Get the stock prices for both stocks.
             * i indicates the current stock, either first stock or second stock.
             * i == 0: first stock.
             * i == 1: second stock. */
            for (int i = 0; i < 2; i++)
            {
                // Open the stock data file.
                strReader = new StreamReader(_stockNames[(i==0?firstStock:secondStock)]);

                // Read the first line containing the field's names.
                line = strReader.ReadLine();

                // Add a new list for the comming stock data.
                stockPrices.Add(new List<double>());

                // Read the stock data from its file.
                while (!strReader.EndOfStream)
                {
                    // Read a line.
                    line = strReader.ReadLine();

                    try
                    {
                        // Convert the date from the read line to DateTime.
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
                // Free our writing lock on the file.
                strReader.Close();
            }

            return DTW(stockPrices[0], stockPrices[1], (int)numDTWWindow.Value);
            
        }

        private double GetEuclideanDistance(int firstStock, int secondStock)
        {
            // Define local variables.
            string line1, line2;
            List<List<double>> stockPrices = new List<List<double>>();

            // Open the stock data files for both stocks.
            StreamReader strReader1 = new StreamReader(_stockNames[firstStock]);
            StreamReader strReader2 = new StreamReader(_stockNames[secondStock]);

            // Read first line from each file containing the field's names.
            line1 = strReader1.ReadLine();
            line2 = strReader2.ReadLine();

            // Create new lists for the comming data.
            stockPrices.Add(new List<double>());
            stockPrices.Add(new List<double>());

            // Read stock data from the files.
            while (!strReader1.EndOfStream && !strReader2.EndOfStream)
            {
                // Read a line from each stock.
                line1 = strReader1.ReadLine();
                line2 = strReader2.ReadLine();
                try
                {
                    // Convert the dates from the files to DateTime.
                    DateTime dt1 = Convert.ToDateTime(line1.Split(',')[0]);
                    DateTime dt2 = Convert.ToDateTime(line2.Split(',')[0]);

                    // If the dates are not equal, read from the older date.
                    while (dt1.Date != dt2.Date && !strReader1.EndOfStream && !strReader2.EndOfStream)
                    {
                        while (dt1.Date < dt2.Date && !strReader1.EndOfStream)
                        {
                            // dt1 is older than dt2, read another line and get the new DateTime.
                            line1 = strReader1.ReadLine();
                            dt1 = Convert.ToDateTime(line1.Split(',')[0]);
                        }
                        while (dt1.Date > dt2.Date && !strReader2.EndOfStream)
                        {
                            // dt2 is older than dt1, read another line and get the new DateTime.
                            line2 = strReader2.ReadLine();
                            dt2 = Convert.ToDateTime(line2.Split(',')[0]);
                        }
                    }
                    // When the dates are equal, add the stock prices to our list.
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
            return Euclidean(stockPrices[0], stockPrices[1]);
        }
        
        private double Distance(double x, double y)
        {
            return Math.Abs(x - y);
        }

        private void AllManager()
        {
            //StreamWriter strw = new StreamWriter(_pathName + "\\Pairs.csv", false);
            //strw.WriteLine("Stock #1,Stock #2,Distance");
            //strw.Close();
            for (int i = 0; i < _stockCount; i++)
            {
                _DistanceThread = new Thread(() => Work(i, true));
                _neighborThreadAlive = true;
                _DistanceThread.Start();
                while (_neighborThreadAlive)
                {
                    Thread.Sleep(20);
                }
                UISync.Execute(() => pbProgress.Value++);
            }
            UISync.Execute(() =>btnGetDistance.Enabled = true);
            UISync.Execute(() =>btnNearestNeighbor.Enabled = true);
            UISync.Execute(() =>btnGetDistance.Enabled = true);
            UISync.Execute(() =>btnGetCorrelation.Enabled = true);
            UISync.Execute(() =>btnAllNearestNeighbors.Enabled = true);
        }

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

        #region ' Threading '

        private void Work(int firstStock, bool all)
        {
            double currentDistance = 0.0;
            _nearestNeighbour = -1;
            _minDistance = double.MaxValue;
            for (int i = 0; i < _stockCount; i++)
            {
                
                if (i == firstStock)
                {
                    continue;
                }

                // Wait for an available worker thread slot.
                //while (_activeWorkers >= numWorkers.Value)
                //{
                //    // Sleep to relieve the CPU.
                //    //Thread.Sleep(1);
                //}

                

                if (_mode == 0)
                {
                    currentDistance = GetDTWDistance(firstStock, i);
                }
                else if (_mode == 1)
                {
                    currentDistance = GetEuclideanDistance(firstStock, i);
                }

                if (currentDistance < _minDistance)
                {
                    _minDistance = currentDistance;
                    _nearestNeighbour = i;
                }

                //UISync.Execute(() => pbProgress.Value++);

                // Worker thread available, reserve it.
                //_activeWorkers++;

                // Create the worker thread supplied with quandl code and stock name.
                //int secondStock = i; // Fix this, this is for data race prevention.
                //new Thread(() => Worker(stock, secondStock)).Start();

                /*double currentDistance = getDTWDistance(Int32.Parse(txtStock.Text), i);
                if (currentDistance < _minDistance)
                {
                    _minDistance = currentDistance;
                    nearestNeighbour = i;
                }*/
            }

            // Wait for all workers to exit before printing a result.
            //while (_activeWorkers > 0)
            //{
            //    // Sleep to relieve the CPU.
            //    //Thread.Sleep(1);
            //}
            if (!all)
            {
                UISync.Execute(() => btnGetDistance.Enabled = true);
                UISync.Execute(() => btnNearestNeighbor.Enabled = true);
                UISync.Execute(() => btnGetDistance.Enabled = true);
                UISync.Execute(() => btnGetCorrelation.Enabled = true);
                UISync.Execute(() => btnAllNearestNeighbors.Enabled = true);
            }
            

            UISync.Execute(() => txtNearestNeighbour.Text = _nearestNeighbour.ToString());

            // Create directory if it does not exist.
            //System.IO.Directory.CreateDirectory(_pathName + @"\Pairs");

            //StreamWriter strw = new StreamWriter(_pathName + "\\Pairs\\Pairs.csv", true);
            //strw.WriteLine(firstStock.ToString() + "," + txtNearestNeighbour.Text + "," + _minDistance);
            //strw.Close();
            _neighborThreadAlive = false;
        }

        private void Worker(int firstStock, int secondStock)
        {
            double currentDistance = 0.0;

            if(_mode == 0)
            {
            currentDistance = GetDTWDistance(firstStock, secondStock);   
            }
            else if (_mode == 1)
            {
                currentDistance = GetEuclideanDistance(firstStock, secondStock);
            }

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

        #endregion

    }
}
