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

namespace QLNT
{
    public partial class Receipts : Form
    {
        private int id;
        private SQLConnectionClass sqlConnection;
        public Receipts()
        {
            InitializeComponent();
            sqlConnection = new SQLConnectionClass();
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            LoadReceiptData();
        }

        private void LoadReceiptData()
        {
            try
            {
                var receipts = sqlConnection.GetReceiptsData();
                if (receipts.Rows.Count > 0)
                {
                    dtgv_receiptinfos.DataSource = receipts;
                    dtgv_receiptinfos.AutoGenerateColumns = true;
                }
                else
                {
                    MessageBox.Show("No receipts data found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }



        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txb_Search_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (dtgv_receiptinfos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item to delete.");
                return;
            }

            var selectedRow = dtgv_receiptinfos.SelectedRows[0];
            int rid = Convert.ToInt32(selectedRow.Cells["RID"].Value); // Ensure "RID" matches your actual column name

            var confirmResult = MessageBox.Show("Are you sure you want to delete this item?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                DeleteReceiptItem(rid);
                LoadReceiptData();
            }
        }

        private void DeleteReceiptItem(int rid)
        {
            using (var connection = new SqlConnection(sqlConnection.ConnectionString))
            {
                connection.Open();
                string deleteQuery = "DELETE FROM ReceiptInfo WHERE RID = @RID; DELETE FROM Receipt WHERE RID = @RID";

                using (var command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@RID", rid);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Item deleted successfully.");
                        // Optionally refresh the DataGridView
                    }
                    else
                    {
                        MessageBox.Show("No item found with the specified RID.");
                    }
                }
            }
        }

        private void dtgv_Reports_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0 && e.RowIndex >= 0)
            {
                id = int.Parse(dtgv_receiptinfos.Rows[e.RowIndex].Cells[0].Value.ToString());
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

        private void dtp_Date_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dtp_Date_ValueChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(sqlConnection.ConnectionString))
            {
                string query = "SELECT * FROM Receipt WHERE date = '" + dtp_Date.Text + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(dataTable);
                    dtgv_receiptinfos.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void dtgv_Receipts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int rid = (int)dtgv_receiptinfos.Rows[e.RowIndex].Cells["RID"].Value;
                LoadReceiptInfoData(rid);
                dtgv_receiptinfos.Visible = true;
                dtgv_receiptinfos.Columns["RID"].Visible = false;
            }
        }
        private void LoadReceiptInfoData(int rid)
        {
            // Clear existing data in the DataGridView
            dtgv_receiptinfos.DataSource = null; // Clear the existing data source

            using (SqlConnection conn = new SqlConnection(sqlConnection.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(@"
            SELECT 
                ri.RID,
                ri.MID, 
                ri.Quantity 
            FROM 
                ReceiptInfo ri
            WHERE 
                ri.RID = @RID", conn);

                cmd.Parameters.AddWithValue("@RID", rid);

                conn.Open();

                // Create a SqlDataAdapter to fill a DataTable
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dtgv_receiptinfos.DataSource = dt;
            }
        }

        private void Receipts_Click(object sender, EventArgs e)
        {
            dtgv_receiptinfos.Visible = false;
        }

        private void dtgv_Receipts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
