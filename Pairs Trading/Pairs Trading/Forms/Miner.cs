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
        private string[] stockNames;

        #endregion

        #region ' Constructors '

        public Miner()
        {
            InitializeComponent();

            // Initial variables.
            _fileName = string.Empty;
            _pathName = string.Empty;
            _stockCount = 0;

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

            stockNames = Directory.GetFiles(_pathName);
            // Maybe filer out non-csv files?

            _stockCount = stockNames.Count();
            lblLineCount.Text = _stockCount.ToString();
            lblLineCount.Visible = true;
            lblLineCountIntro.Visible = true;
            /*lblRetieveIntro.Visible = true;
            lblQuandlApiIntro.Visible = true;
            txtQuandlApi.Visible = true;
            lblDownloadWorkersIntro.Visible = true;
            numDownloadWorkers.Visible = true;
            btnProcess.Visible = true;*/

            
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

        private double getDTWDistance(int firstStock, int secondStock)
        {
            StreamReader strReader;
            string line;
            List<List<double>> stockPrices = new List<List<double>>();;
            for (int i = 0; i < 2; i++)
            {
                strReader = new StreamReader(stockNames[(i==0?firstStock:secondStock)]);
                line = strReader.ReadLine();
                //stockPrices = new List<List<double>>();
                stockPrices.Add(new List<double>());
                while (!strReader.EndOfStream)
                {
                    line = strReader.ReadLine();

                    try
                    {
                        stockPrices[i].Add(Convert.ToDouble((line.Split(','))[4]));
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
            double minDistance = double.MaxValue;
            int nearestNeighbour = -1;
            for(int i = 0;  i < _stockCount; i++)
            {
                if (i == Int32.Parse(txtStock.Text))
                {
                    continue;
                }
                double currentDistance = getDTWDistance(Int32.Parse(txtStock.Text), i);
                if (currentDistance < minDistance)
                {
                    minDistance = currentDistance;
                    nearestNeighbour = i;
                }
            }
            txtNearestNeighbour.Text = nearestNeighbour.ToString();
            
        }


    }
}
