﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pairs_Trading.Forms;

namespace Pairs_Trading
{
    public partial class MainMenu : Form
    {
        #region ' Constructors '

        public MainMenu()
        {
            InitializeComponent();
        }

        #endregion

        #region ' Event Handlers '

        private void btnLoader_Click(object sender, EventArgs e)
        {
            new Loader().ShowDialog();
        }

        private void btnMiner_Click(object sender, EventArgs e)
        {
            new Miner().ShowDialog();
        }

        private void btnMonitor_Click(object sender, EventArgs e)
        {
            new Monitor().ShowDialog();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            new Generator().ShowDialog();
        }

        private void btnPreprocessor_Click(object sender, EventArgs e)
        {
            new Preprocessor().ShowDialog();
        }

        #endregion

        
    }
}
