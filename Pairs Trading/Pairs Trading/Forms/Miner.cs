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



        private void formDataRetieve_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        #endregion

        #region ' Support Methods '


        #endregion

    }
}
