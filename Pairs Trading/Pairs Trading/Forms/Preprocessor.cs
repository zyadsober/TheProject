using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Pairs_Trading.Forms
{
    public partial class Preprocessor : Form
    {
        #region ' Member Variables '
        
        private string _pathName;
        private int _stockCount;
        private string[] _stockNames;
        private Random random;

        #endregion

        #region ' Constructors '

        public Preprocessor()
        {
            InitializeComponent();

            /* Set the initial height of the form.
             * This will change later on successful file browse. */
            this.Height = 150;

            // Initialize variables.

            _pathName = null;
            _stockCount = 0;
            random = new Random();
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
            lblNewDirectory.Visible = true;
            txtNewDirectory.Visible = true;
            lblDays.Visible = true;
            datePickerFirst.Visible = true;
            lblDate.Visible = true;
            datePickerSecond.Visible = true;
            btnProcess.Visible = true;
            lblPercentage.Visible = true;
            numPercentage.Visible = true;
            lblFrequency.Visible = true;
            lblFrequencyDays.Visible = true;
            lblRecordsPercentage.Visible = true;
            numRecordsPercentage.Visible = true;
            numDays.Visible = true;
            
            // Generate the new folder path for newly generated files.
            UpdateDirectory();

            // Update the height of the form to fit the visible controls.
            this.Height = 431;
        }

        private void numDays_ValueChanged(object sender, EventArgs e)
        {
            // Generate the new folder path for newly generated files.
            UpdateDirectory();
        }

        private void datePicker_ValueChanged(object sender, EventArgs e)
        {
            // Generate the new folder path for newly generated files.
            UpdateDirectory();
        }

        private void datePickerFirst_ValueChanged(object sender, EventArgs e)
        {
            // Generate the new folder path for newly generated files.
            UpdateDirectory();
        }
        
        private void btnProcess_Click(object sender, EventArgs e)
        {
            // Define local variables.
            int[] stockLineCount = new int[_stockCount];
            int lineCount = 0;
            int maxLineCount = 0;
            StreamReader strReader;
            StreamWriter strWriter;
            string line;

            // Reset the progress bar.
            pbProgress.Visible = true;
            pbProgress.Value = 0;

            // Update controls for state changes.
            btnProcess.Enabled = false;

            // Create the new directory if it doesn't exist.
            System.IO.Directory.CreateDirectory(txtNewDirectory.Text);

            for (int i = 0; i < _stockNames.Count(); i++)
            {
                // Reset current file line count.
                lineCount = 0;

                // Open the stock data file.
                strReader = new StreamReader(_stockNames[i]);

                // Get the file name of the current stock file.
                string newStockName = _stockNames[i].Substring(_stockNames[i].LastIndexOf("\\"));
                
                // Open the new stock data file.
                strWriter = new StreamWriter(txtNewDirectory.Text + newStockName);

                // Read the first line containing the field's names.
                line = strReader.ReadLine();

                // Write the first line containing the field's names.
                strWriter.Write(line);

                // copy the stock data from the original file to the new file.
                while (!strReader.EndOfStream)
                {
                    // Read a line.
                    line = strReader.ReadLine();

                    try
                    {
                        // Convert the date from the read line to DateTime.
                        DateTime dt = Convert.ToDateTime(line.Split(',')[0]);
                        
                        // Generate a random value between 0 and 100.
                        int r = random.Next(0, 100);

                        /* If the stock is in the given date range and
                         * our random value is acceptable, copy the current data. */
                        if (StockIsInLastDaysFromDate(datePickerFirst.Value, datePickerSecond.Value, dt)
                            && r <= numPercentage.Value)
                        {
                            // Write to the new file.
                            strWriter.Write("\n" + line);

                            // Increment the line counter.
                            lineCount++;
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }

                // Free our writing lock on the files.
                strReader.Close();
                strWriter.Close();

                // Update the line count for the current stock.
                stockLineCount[i] = lineCount;

                // File is empty of data.
                if (lineCount < 1)
                {
                    //Delete the empty file.
                    File.Delete(txtNewDirectory.Text + newStockName);
                }
                
                // Calculate the maximum number of lines in all the files.
                if (lineCount > maxLineCount)
                {
                    maxLineCount = lineCount;
                }

                // Update our progress.
                pbProgress.Value++;
            }

            // Reset
            pbProgress.Value = 0;
            
            /* Remove files which have less than the minimum percentage of
             * records with respect to the largest file. Also delete empty
             * files with no records */
            double minPercentage = (double)numRecordsPercentage.Value / 100.0;
            for (int i = 0; i < _stockNames.Count(); i++)
            {
                if ((double)stockLineCount[i] / (double)maxLineCount < minPercentage
                    || stockLineCount[i] < 1)
                {
                    string newStockName = _stockNames[i].Substring(_stockNames[i].LastIndexOf("\\"));
                    File.Delete(txtNewDirectory.Text + newStockName);
                }

                // Update our progress.
                pbProgress.Value++;
            }

            // Update controls for state changes.
            btnProcess.Enabled = true;
        }

        #endregion

        #region ' Support Methods '

        private bool StockIsInLastDaysFromDate(DateTime dtFirst, DateTime dtSecond, DateTime dtCurrent)
        {
            if (dtCurrent >= dtFirst && dtCurrent <= dtSecond)
            {
                return true;
            }
            return false;
        }

        private void UpdateDirectory()
        {
            txtNewDirectory.Text = _pathName + "-" + datePickerFirst.Value.Day + "-" + datePickerFirst.Value.Month
                + "-" + datePickerFirst.Value.Year + "-to-"
                + datePickerSecond.Value.Day + "-" + datePickerSecond.Value.Month + "-" + datePickerSecond.Value.Year;
        }

        #endregion

    }
}
