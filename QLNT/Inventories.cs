using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using DataTable = System.Data.DataTable;
using Microsoft.Office.Interop.Excel;
using ScrollBars = System.Windows.Forms.ScrollBars;
using System.Windows.Forms;


namespace QLNT
{
    public partial class Inventories : Form
    {
        private SQLConnectionClass sqlConnection;
        private int currentOffset = 0;
        private const int pageSize = 200;
        public Inventories()
        {
            InitializeComponent();
            sqlConnection = new SQLConnectionClass();
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            LoadMedicines(); // Load medicines when the form loads
            UpdateMedicineCountAndStock();

        }
        private void LoadExpiredOrNearExpiredProducts()
        {
            DataTable expiredProducts = sqlConnection.GetExpiredOrNearExpiredProducts();

            if (expiredProducts.Rows.Count > 0)
            {
                dtgv_Inventories.AutoGenerateColumns = true; // Ensure columns are auto-generated
                dtgv_Inventories.DataSource = expiredProducts;
                dtgv_Inventories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                MessageBox.Show("No expired or near-expired products found.");
            }
        }
        private void LoadOutOfStockProduct()
        {
            DataTable oosProduct = sqlConnection.GetOutOfStockProduct();

            if (oosProduct.Rows.Count > 0)
            {
                dtgv_Inventories.AutoGenerateColumns = true; // Ensure columns are auto-generated
                dtgv_Inventories.DataSource = oosProduct;
                dtgv_Inventories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            }
            else
            {
                MessageBox.Show("No product is out of stock ");
            }
        }

        private void LoadMedicines()
        {
            DataTable medicinesTable = sqlConnection.GetMedicines(currentOffset, pageSize);
            dtgv_Inventories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            if (medicinesTable.Columns.Count == 0)
            {
                MessageBox.Show("No columns found in the DataTable.");
                return;
            }

            dtgv_Inventories.AutoGenerateColumns = true; // Ensure columns are auto-generated
            dtgv_Inventories.DataSource = medicinesTable;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            LoadExpiredOrNearExpiredProducts();
        }

        private void UpdateMedicineCountAndStock()
        {
            int totalMedicines = 0;
            int totalStockQuantity = 0;
            int totalExpiredProducts = 0;

            using (var connection = new SqlConnection(sqlConnection.ConnectionString)) // Replace with your connection string
            {
                SqlCommand command = new SqlCommand("CountMedicinesAndStock", connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            totalMedicines = reader.GetInt32(0); // TotalMedicines
                            totalStockQuantity = reader.GetInt32(1); // TotalStockQuantity
                            totalExpiredProducts = reader.GetInt32(2); // TotalExpiredProducts
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }


            // Update the labels
            guna2HtmlLabel4.Text = $"{totalMedicines}";
            guna2HtmlLabel6.Text = $"{totalStockQuantity}";
            guna2HtmlLabel5.Text = $"{totalExpiredProducts}";
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            LoadMedicines();
        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            LoadOutOfStockProduct();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            using (var folderBrowser = new FolderBrowserDialog())
            {
                // Show the folder browser dialog
                DialogResult result = folderBrowser.ShowDialog();

                // Check if the user selected a folder
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowser.SelectedPath))
                {
                    string exportPath = Path.Combine(folderBrowser.SelectedPath, "Export_Inventory.xlsx"); // Specify the file name

                    try
                    {
                        // Call the export method with the full path
                        new ExportFile().exportExcel(dtgv_Inventories, folderBrowser.SelectedPath, "Export_Inventory");
                        MessageBox.Show("Export successful");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
            }
        }


        private void btn_Browse_Click(object sender, EventArgs e)
        {

            OpenFileDialog filedialog = new OpenFileDialog();
            filedialog.Title = "Select File";
            filedialog.FileName = txb_FileName.Text;
            filedialog.Filter = "Excel Sheet (*.xlsx)|*.xls|All Files (*.*)|*.*";
            filedialog.FilterIndex = 1;
            filedialog.RestoreDirectory = true;
            if (filedialog.ShowDialog() == DialogResult.OK)
            {
                txb_FileName.Text = filedialog.FileName;
            }
        }


        private void guna2Button5_Click(object sender, EventArgs e)
        {
            try
            {
                //restock
                OleDbConnection cnstr = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txb_FileName.Text + ";Extended Properties='Excel 12.0 Xml;HDR=YES;'");
                cnstr.Open();
                OleDbDataAdapter theDataAdapter = new OleDbDataAdapter("Select * from [Sheet1$]", cnstr);
                DataSet theSD = new DataSet();
                DataTable dt = new DataTable();
                theDataAdapter.Fill(dt);
                this.dtgv_Inventories.DataSource = dt.DefaultView;
            }
            catch
            {
                MessageBox.Show("Please upload excel file");
            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_FileName.Text) &&
                System.IO.File.Exists(txb_FileName.Text))
            {
                using (var connection = new SqlConnection(sqlConnection.ConnectionString))
                {
                    connection.Open();

                    try
                    {
                        for (int i = 0; i < dtgv_Inventories.Rows.Count; i++)
                        {
                            // Lấy giá trị MID cao nhất hiện có
                            SqlCommand maxMidCmd = new SqlCommand("SELECT ISNULL(MAX(MID), 0) FROM MedInventory", connection);
                            int maxMid = (int)maxMidCmd.ExecuteScalar();
                            int newMid = maxMid + 1; // Tạo giá trị MID mới

                            SqlCommand cmd = new SqlCommand(@"SET IDENTITY_INSERT MedInventory ON; 
        INSERT INTO MedInventory (MID, MedicineName, Type, Pack_Size_Label, StockQuantity, UnitPrice, ISDiscontinued, 
            Manufacturer_name, Composition1, Composition2, timestamp, ExperationDATE) 
        VALUES (@MID, @MedicineName, @Type, @PackSizeLabel, @StockQuantity, @UnitPrice, @ISDiscontinued, 
            @ManufacturerName, @Composition1, @Composition2, @Timestamp, @ExperationDATE) SET IDENTITY_INSERT MedInventory OFF;", connection);

                            // Thêm tham số cho câu lệnh
                            cmd.Parameters.AddWithValue("@MID", newMid); // Sử dụng MID mới
                            cmd.Parameters.AddWithValue("@MedicineName", dtgv_Inventories.Rows[i].Cells[1].Value.ToString());
                            cmd.Parameters.AddWithValue("@Type", dtgv_Inventories.Rows[i].Cells[2].Value.ToString());
                            cmd.Parameters.AddWithValue("@PackSizeLabel", dtgv_Inventories.Rows[i].Cells[3].Value.ToString());
                            cmd.Parameters.AddWithValue("@StockQuantity", int.Parse(dtgv_Inventories.Rows[i].Cells[4].Value.ToString()));
                            cmd.Parameters.AddWithValue("@UnitPrice", Decimal.Parse(dtgv_Inventories.Rows[i].Cells[5].Value.ToString()));
                            cmd.Parameters.AddWithValue("@ISDiscontinued", dtgv_Inventories.Rows[i].Cells[6].Value.ToString());
                            cmd.Parameters.AddWithValue("@ManufacturerName", dtgv_Inventories.Rows[i].Cells[7].Value.ToString());
                            cmd.Parameters.AddWithValue("@Composition1", dtgv_Inventories.Rows[i].Cells[8].Value.ToString());
                            cmd.Parameters.AddWithValue("@Composition2", dtgv_Inventories.Rows[i].Cells[9].Value.ToString());
                            cmd.Parameters.AddWithValue("@Timestamp", DateTime.Parse(dtgv_Inventories.Rows[i].Cells[10].Value.ToString()));
                            cmd.Parameters.AddWithValue("@ExperationDATE", DateTime.Parse(dtgv_Inventories.Rows[i].Cells[11].Value.ToString()));

                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Có lỗi khi chèn dữ liệu: " + ex.Message);
                                continue;
                            }
                        }
                        MessageBox.Show("Items saved");
                        LoadMedicines(); // Load medicines when the form loads
                        UpdateMedicineCountAndStock();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
            else
            {
                MessageBox.Show("Please select file");
            }

        }
        private void guna2HtmlLabel6_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void dtgv_Inventories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Check if Ctrl + A is pressed
            if (keyData == (Keys.Control | Keys.A))
            {
                SelectAllRows();
                return true; // Indicate that the key has been handled
            }

            // Check if Delete key is pressed
            if (keyData == Keys.Delete)
            {
                DeleteSelectedRows();
                return true; // Indicate that the key has been handled
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void SelectAllRows()
        {
            // Select all rows in the DataGridView
            dtgv_Inventories.SelectAll();
        }

        private void DeleteSelectedRows()
        {
            // Check if there are any selected rows
            if (dtgv_Inventories.SelectedRows.Count > 0)
            {
                using (var connection = new SqlConnection(sqlConnection.ConnectionString))
                {
                    connection.Open();
                    // Confirm deletion
                    var confirmation = MessageBox.Show("Are you sure you want to delete the selected items?", "Confirm Delete", MessageBoxButtons.YesNo);
                    if (confirmation == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dtgv_Inventories.SelectedRows)
                        {
                            // Assuming MID is the column name for the primary key
                            int mid = Convert.ToInt32(row.Cells["MID"].Value);

                            // Prepare the DELETE command
                            string query = "Update MedInventory SET StockQuantity = 0 where MID = @mid";
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@mid", mid);
                                command.ExecuteNonQuery(); // Execute the delete command
                            }

                            dtgv_Inventories.Rows.Remove(row); // Remove row from DataGridView
                        }

                    }
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            try
            {
                // Đọc dữ liệu từ file Excel
                OleDbConnection cnstr = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txb_FileName.Text + ";Extended Properties='Excel 12.0 Xml;HDR=YES;'");
                cnstr.Open();
                OleDbDataAdapter theDataAdapter = new OleDbDataAdapter("Select * from [Sheet1$]", cnstr);
                DataTable dt = new DataTable();
                theDataAdapter.Fill(dt);

                // Giả sử bạn có một cột tên là "ProductID" trong Excel
                List<string> MIDToDelete = new List<string>();

                foreach (DataRow row in dt.Rows)
                {
                    // Thêm ProductID vào danh sách
                    MIDToDelete.Add(row["MID"].ToString());
                }

                // Đóng kết nối Excel
                cnstr.Close();

                // Kết nối đến cơ sở dữ liệu SQL
                using (var connection = new SqlConnection(sqlConnection.ConnectionString))
                {
                    connection.Open();

                    foreach (string MID in MIDToDelete)
                    {
                        using (SqlCommand sqlCommand = new SqlCommand("DELETE FROM MedTransactions WHERE MID = @MID", connection))
                        {
                            sqlCommand.Parameters.AddWithValue("@MID", MID);
                            sqlCommand.ExecuteNonQuery();
                        }
                        // Thực hiện xóa sản phẩm
                        using (SqlCommand sqlCommand = new SqlCommand("DELETE FROM MedInventory WHERE MID = @MID", connection))
                        {
                            sqlCommand.Parameters.AddWithValue("@MID", MID);
                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Products deleted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}

