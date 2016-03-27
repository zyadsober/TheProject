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
    public partial class Preprocessor : Form
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

        private string _pathName;
        private int _stockCount;
        private string[] _stockNames;

        #endregion

        #region ' Constructors '

        public Preprocessor()
        {
            InitializeComponent();

            this.Height = 150;

            _pathName = null;
            _stockCount = 0;
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

            _stockCount = _stockNames.Count();
            lblLineCount.Text = _stockCount.ToString();
            lblLineCount.Visible = true;
            lblLineCountIntro.Visible = true;
            lblNewDirectory.Visible = true;
            txtNewDirectory.Visible = true;
            lblDays.Visible = true;
            numDays.Visible = true;
            lblDate.Visible = true;
            datePicker.Visible = true;
            btnProcess.Visible = true;

            UpdateDirectory();

            this.Height = 332;
        }

        #endregion

        #region ' Support Methods '

        private void UpdateDirectory()
        {
            txtNewDirectory.Text = _pathName + "-" + numDays.Value.ToString() + "-days-from-"
                + datePicker.Value.Day + "/" + datePicker.Value.Month + "/" + datePicker.Value.Year;
        }

        #endregion

        private void numDays_ValueChanged(object sender, EventArgs e)
        {
            UpdateDirectory();
        }

        private void datePicker_ValueChanged(object sender, EventArgs e)
        {
            UpdateDirectory();
        }
        
    }
}
