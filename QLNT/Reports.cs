using System.Data;
using System.Data.SqlClient;

namespace QLNT
{
    public partial class Reports : Form
    {
        private string i = "";

        public Reports()
        {
            InitializeComponent();
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            LoadItemMSales();
        }

        private void LoadItemMSales()
        {
            try
            {
                dtgv_Reports.DataSource = new BL.ReportBL().LoadItemSales();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void LoadItemMSalesBySelectedMY(int startmonth, int endmonth, int year)
        {
            try
            {
                dtgv_Reports.DataSource = new BL.ReportBL().LoadItemMSalesBySelectedMY(startmonth, endmonth, year);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void LoadEmployeeMSales()
        {
            try
            {
                dtgv_Reports.DataSource = new BL.ReportBL().LoadEmployeeMSales();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void LoadEmployeeMSalesByMY(int startmonth, int endmonth, int year)
        {
            try
            {
                dtgv_Reports.DataSource = new BL.ReportBL().LoadEmployeeMSalesByMY(startmonth, endmonth, year);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void LoadMonthlySalesSummary()
        {
            try
            {
                dtgv_Reports.DataSource = new BL.ReportBL().LoadMonthlySalesSummary();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
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
                        new ExportFile().exportExcel(dtgv_Reports, folderBrowser.SelectedPath, "Export_Receipts");
                        MessageBox.Show("Export successful");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
            }
        }

        private void btn_Item_Click(object sender, EventArgs e)
        {
            LoadItemMSales();
            i = "Item";
        }

        private void btn_Staff_Click(object sender, EventArgs e)
        {
            i = "Staff";
            LoadEmployeeMSales();
        }

        private void btn_Sales_Click(object sender, EventArgs e)
        {
            i = "Sales";
            LoadMonthlySalesSummary();
        }

        private void btn_Find_Click(object sender, EventArgs e)
        {
            int startmonth = dtpk_StartDate.Value.Month;
            int endmonth = dtpk_EndDate.Value.Month;
            int year = dtpk_EndDate.Value.Year;
            if (i == "Item")
            {
                LoadItemMSalesBySelectedMY(startmonth, endmonth, year);
            }
            else if (i == "Staff")
            {
                LoadEmployeeMSalesByMY(startmonth, endmonth, year);
            }
            else if (i == "Sales")
            { }
        }
    }
}
