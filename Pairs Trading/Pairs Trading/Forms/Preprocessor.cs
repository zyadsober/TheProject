using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        #endregion

        #region ' Constructors '

        public Preprocessor()
        {
            InitializeComponent();

            this.Height = 150;

            _pathName = null;
        }

        #endregion

        #region ' Event Handlers '

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            DialogResult result = folderDialog.ShowDialog();
            _pathName = folderDialog.SelectedPath;
            txtBrowse.Text = _pathName;

            lblNewDirectory.Visible = true;
            txtNewDirectory.Visible = true;
            lblDays.Visible = true;
            numDays.Visible = true;
            lblDate.Visible = true;
            datePicker.Visible = true;
            btnProcess.Visible = true;

            this.Height = 310;
        }

        #endregion

        #region ' Support Methods '
        

        #endregion
        
    }
}
