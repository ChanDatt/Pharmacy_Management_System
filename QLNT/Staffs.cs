using Guna.UI2.WinForms;
using OfficeOpenXml;
using System;
using Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography;
using DataTable = System.Data.DataTable;
using OfficeOpenXml.Style;
using System.IO;
using System.Windows.Forms;


namespace QLNT
{
    public partial class Staffs : Form
    {
        private System.Windows.Forms.ComboBox cmbEmployee;
        private int id;
        private SQLConnectionClass sqlConnection;

        public Staffs()
        {
            InitializeComponent();
            sqlConnection = new SQLConnectionClass(); // Initialize SQLConnectionClass
            LoadEmployeeData();
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            //dtgv_Staffs.CellDoubleClick += dtgv_Staffs_CellDoubleClick;
            //dtgv_Staffs.CellEndEdit += dtgv_Staffs_CellEndEdit;
            string[] statuslist = { "active", "inactive" };
            foreach (string status in statuslist)
            {
                cb_Status.Items.Add(status);
            }

            string[] notelist = { "Admin", "Employee" };
            foreach (string note in notelist)
            {
                cb_Note.Items.Add(note);
            }
        }

        private void LoadEmployeeData()
        {
            try
            {
                var employees = sqlConnection.GetEmployeeData();
                if (employees.Rows.Count > 0)
                {
                    dtgv_Staffs.DataSource = employees;
                    dtgv_Staffs.AutoGenerateColumns = true;
                }
                else
                {
                    MessageBox.Show("No employee data found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void AddEmployee(string name, string phone, string note, string status, decimal salary, string address)
        {
            using (var connection = new SqlConnection(sqlConnection.ConnectionString))
            {
                int maxId = 0;

                foreach (DataGridViewRow row in dtgv_Staffs.Rows)
                {
                    if (row.Cells[0] != null)
                    {
                        int currentId = Convert.ToInt32(row.Cells[0].Value);
                        if (currentId > maxId)
                        {
                            maxId = currentId;
                        }
                    }
                }
                int newId = maxId + 1;

                connection.Open();
                string query = "INSERT INTO Employee (EID, EmployeeName, Note, Phone, Status, Salary, Address) VALUES (@EID, @EmployeeName, @Note, @Phone, @Status, @Salary, @Address)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    Random random = new Random();       
                    command.Parameters.AddWithValue("@EID", newId);
                    command.Parameters.AddWithValue("@EmployeeName", name);
                    command.Parameters.AddWithValue("@Note", note);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Status", status);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@Salary", salary);

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
        }
        private void DeleteEmployee(int EID)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (txb_Name.Text != "" && txb_Phone.Text != "" && txb_Address.Text != "" && txb_Salary.Text != "")
            {
                string name = txb_Name.Text;
                string phone = txb_Phone.Text;
                string note = cb_Note.Text;
                string status = cb_Status.Text;
                string address = txb_Address.Text;
                decimal salary = decimal.Parse(txb_Salary.Text);
                AddEmployee(name, phone, note, status, salary, address);
                LoadEmployeeData();
                txb_Name.Text = string.Empty;
                txb_Phone.Text = string.Empty;
                txb_Address.Text = string.Empty;
                txb_Salary.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Please fill out the information");
            }
        }

        private void dtgv_Staffs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UpdateEmployeeInDatabase(int employeeId, string name, string phone, string note, string status, decimal salary, string address)
        {
            using (var connection = new SqlConnection(sqlConnection.ConnectionString))
            {
                string query = "UPDATE Employee SET EmployeeName = @EmployeeName, Phone = @Phone, Note = @Note, Status = @Status, Salary = @Salary, Address = @Address WHERE EID = @EID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EID", employeeId);
                    command.Parameters.AddWithValue("@EmployeeName", name);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Note", note);
                    command.Parameters.AddWithValue("@Status", status);
                    command.Parameters.AddWithValue("@Salary", salary);
                    command.Parameters.AddWithValue("@Address", address);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Record updated successfully.");
                        LoadEmployeeData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}");
                    }
                }
            }
        }



        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            using (var folderBrowser = new FolderBrowserDialog())
            {
                // Show the folder browser dialog
                DialogResult result = folderBrowser.ShowDialog();

                // Check if the user selected a folder
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowser.SelectedPath))
                {
                    string exportPath = Path.Combine(folderBrowser.SelectedPath, "Export_Staffs.xlsx"); // Specify the file name

                    try
                    {
                        // Call the export method with the full path
                        new ExportFile().exportExcel(dtgv_Staffs, folderBrowser.SelectedPath, "Export_Staffs");
                        MessageBox.Show("Export successful");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
            }
        }


        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            using (var connection = new SqlConnection(sqlConnection.ConnectionString))
            {
                string query = "DELETE FROM Employee where EID = @EID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    try
                    {
                        command.Parameters.AddWithValue("@EID", id);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Delete successful");
                        LoadEmployeeData();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("You can not delete this row. \rError:" + ex.Message);
                    }
                }
            }
            LoadEmployeeData();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (dtgv_Staffs.Rows.Count > 0)
            {
                try
                {
                    UpdateEmployeeInDatabase(id, txb_Name.Text, txb_Phone.Text, cb_Note.Text, cb_Status.Text, decimal.Parse(txb_Salary.Text), txb_Address.Text);

                }
                catch (Exception)
                {
                    MessageBox.Show("Please fill out the information");
                }
            }
            else
            {
                MessageBox.Show("Please choose a row to update");
            }
        }

        private void dtgv_Staffs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0 && e.RowIndex >= 0)
            {
                id = int.Parse(dtgv_Staffs.Rows[e.RowIndex].Cells[0].Value.ToString());
                txb_Name.Text = dtgv_Staffs.Rows[e.RowIndex].Cells[1].Value.ToString();
                cb_Note.Text = dtgv_Staffs.Rows[e.RowIndex].Cells[2].Value.ToString();
                txb_Phone.Text = dtgv_Staffs.Rows[e.RowIndex].Cells[3].Value.ToString();
                cb_Status.Text = dtgv_Staffs.Rows[e.RowIndex].Cells[4].Value.ToString();
                txb_Salary.Text = dtgv_Staffs.Rows[e.RowIndex].Cells[5].Value.ToString();
                txb_Address.Text = dtgv_Staffs.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
        }
        private void txb_SearchMedicine_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(sqlConnection.ConnectionString))
            {
                string query = "SELECT * FROM Employee WHERE EmployeeName LIKE '%" + txb_SearchMedicine.Text + "%'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(dataTable);
                    dtgv_Staffs.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void dtgv_Staffs_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}