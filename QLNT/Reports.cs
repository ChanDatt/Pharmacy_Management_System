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
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace QLNT
{
    public partial class Reports : Form
    {
        private string i = "";
        private SQLConnectionClass sQLConnection;
        public Reports()
        {
            InitializeComponent();
            sQLConnection = new SQLConnectionClass();
            LoadItemMSales();
        }

        private void Reports_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            LoadItemMSales();
            i = "Item";
        }
        private void LoadItemMSales()
        {
            sQLConnection = new SQLConnectionClass();
            using (SqlConnection conn = new SqlConnection(sQLConnection.ConnectionString))
            {
                try
                {
                    conn.Open();
                    // Query to select data from the view
                    string query = $"EXEC dbo.LoadItemsSale;";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Bind the DataTable to the DataGridView
                    dtgv_Reports.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }
        private void LoadItemMSalesBySelectedMY(int startmonth, int endmonth, int year)
        {
            sQLConnection = new SQLConnectionClass();
            using (SqlConnection conn = new SqlConnection(sQLConnection.ConnectionString))
            {
                try
                {
                    conn.Open();
                    // Query to select data from the view
                    string query = $"select * from SalesItemView where Month BETWEEN {startmonth} AND {endmonth} and Year = {year}";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Bind the DataTable to the DataGridView
                    dtgv_Reports.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void LoadEmployeeMSales()
        {
            sQLConnection = new SQLConnectionClass();
            using (SqlConnection conn = new SqlConnection(sQLConnection.ConnectionString))
            {
                try
                {
                    conn.Open();
                    // Query to select data from the view
                    string query = $"exec CreateEmployeeSalesForMonth SELECT * FROM EmployeeMonthlySalesView";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Bind the DataTable to the DataGridView
                    dtgv_Reports.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void LoadEmployeeMSalesByMY(int startmonth, int endmonth, int year)
        {
            sQLConnection = new SQLConnectionClass();
            using (SqlConnection conn = new SqlConnection(sQLConnection.ConnectionString))
            {
                try
                {
                    conn.Open();
                    // Query to select data from the view
                    string query = $"SELECT * FROM EmployeeMonthlySalesView WHERE  Month BETWEEN {startmonth} AND {endmonth} and Year = {year} group by EID, EmployeeName, Receipts, TotalAmount, Month, Year";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Bind the DataTable to the DataGridView
                    dtgv_Reports.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            i = "Staff";
            LoadEmployeeMSales();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            i = "Sales";
            LoadMonthlySalesSummary();
        }
        private void LoadMonthlySalesSummary()
        {
            sQLConnection = new SQLConnectionClass();
            using (SqlConnection conn = new SqlConnection(sQLConnection.ConnectionString))
            {
                try
                {
                    conn.Open();
                    // Query to select data from the view
                    string query = "exec CreateMonthlySalesSummaryView\r\nselect * from MonthlySalesSummary";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Bind the DataTable to the DataGridView
                    dtgv_Reports.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
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

        private void guna2DateTimePicker2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            int startmonth = guna2DateTimePicker1.Value.Month;
            int endmonth = guna2DateTimePicker2.Value.Month;
            int year = guna2DateTimePicker2.Value.Year;
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
