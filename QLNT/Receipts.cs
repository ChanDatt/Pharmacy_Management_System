using OfficeOpenXml.ConditionalFormatting.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
using DL;

namespace QLNT
{
    public partial class Receipts : Form
    {
        public Receipts()
        {
            InitializeComponent();
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            LoadReceiptData();
        }
        private void LoadReceiptData()
        {
            try
            {
                dtgv_receiptinfos.DataSource = new BL.ReceiptsBL().GetStaffsTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            using (var folderBrowser = new FolderBrowserDialog())
            {
                // Show the folder browser dialog
                DialogResult result = folderBrowser.ShowDialog();

                // Check if the user selected a folder
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowser.SelectedPath))
                {
                    string exportPath = Path.Combine(folderBrowser.SelectedPath, "Export_Receipts.xlsx"); // Specify the file name

                    try
                    {
                        new ExportFile().exportExcel(dtgv_receiptinfos, folderBrowser.SelectedPath, "Export_Receipts");
                        MessageBox.Show("Export successful");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
            }
        }

        private void dtp_Date_ValueChanged(object sender, EventArgs e)
        {
                try
                {
                    dtgv_receiptinfos.DataSource = new BL.ReceiptsBL().pickDateReceipt(dtp_Date.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
        }
    }
}
