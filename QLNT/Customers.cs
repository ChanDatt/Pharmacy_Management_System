using Microsoft.Office.Interop.Excel;
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
using DataTable = System.Data.DataTable;

namespace QLNT
{
    public partial class Customers : Form
    {
        private SQLConnectionClass sqlConnection;
        private int id;

        private void clear()
        {
            textBox1.Clear();
            txb_Name.Clear();
            txb_Age.Clear();
            txb_Phone.Clear();
            txb_Name.Focus();
        }
        public Customers()
        {
            InitializeComponent();
            sqlConnection = new SQLConnectionClass();
            LoadCustomerData();
            string[] genderlist = { "Nam", "Nu" };
            foreach (string gender in genderlist)
            {
                cb_Gender.Items.Add(gender);
            }
        }
        private void LoadCustomerData()
        {
            using (SqlConnection connection = new SqlConnection(sqlConnection.ConnectionString))
            {
                string query = "SELECT * FROM Customer";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(dataTable);
                    dtgv_Customers.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void btn_AddStaff_Click(object sender, EventArgs e)
        {
            if (txb_Name.Text != "" && cb_Gender.Text != "" && txb_Age.Text != "" && txb_Phone.Text != "")
            {
                try
                {
                    string name = txb_Name.Text;
                    int age = int.Parse(txb_Age.Text);
                    string gender = cb_Gender.Text;
                    string phone = txb_Phone.Text;
                    AddCustomer(name, age, gender, phone);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please fill in the correct format");
                }
            }
            else
            {
                MessageBox.Show("Please fill out the information");

            }
        }
        private void AddCustomer(string name, int age, string gender, string phone)
        {
            using (var connection = new SqlConnection(sqlConnection.ConnectionString))
            {
                int maxId = 0;

                foreach (DataGridViewRow row in dtgv_Customers.Rows)
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
                string query = "INSERT INTO Customer (CID, CustomerName, Age, Gender, Phone) VALUES (@CID, @CustomerName, @Age, @Gender, @Phone)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CID", newId);
                    command.Parameters.AddWithValue("@CustomerName", name);
                    command.Parameters.AddWithValue("@Age", age);
                    command.Parameters.AddWithValue("@Gender", gender);
                    command.Parameters.AddWithValue("@Phone", phone);

                    connection.Open();
                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Add successful");
                        clear();
                        LoadCustomerData();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            }
        }

        private void btn_DeleteCustomer_Click(object sender, EventArgs e)
        {
            using (var connection = new SqlConnection(sqlConnection.ConnectionString))
            {
                connection.Open();

                string query = "DELETE FROM Customer WHERE CID = @CID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CID", id);

                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show("Delete successful");
                        clear();
                        LoadCustomerData();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(sqlConnection.ConnectionString))
            {
                string query = "SELECT * FROM Customer WHERE CustomerName LIKE '%" + guna2TextBox3.Text + "%'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(dataTable);
                    dtgv_Customers.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
        private void UpdateCustomerInDatabase(int CID, string name, int age, string gender, string phone)
        {
            using (var connection = new SqlConnection(sqlConnection.ConnectionString))
            {
                string query = "UPDATE Customer SET CustomerName = @CustomerName, Age = @Age, Phone = @Phone WHERE CID = @CID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CID", CID);
                    command.Parameters.AddWithValue("@CustomerName", name);
                    command.Parameters.AddWithValue("@Age", age);
                    command.Parameters.AddWithValue("@Gender", gender);
                    command.Parameters.AddWithValue("@Phone", phone);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Record updated successfully.");
                        LoadCustomerData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}");
                    }
                }
            }
        }

        private void dtgv_Customers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0 && e.RowIndex > 0)
            {
                id = int.Parse(dtgv_Customers.Rows[e.RowIndex].Cells[0].Value.ToString());
                txb_Name.Text = dtgv_Customers.Rows[e.RowIndex].Cells[1].Value.ToString();
                txb_Age.Text = dtgv_Customers.Rows[e.RowIndex].Cells[2].Value.ToString();
                cb_Gender.Text = dtgv_Customers.Rows[e.RowIndex].Cells[3].Value.ToString();
                txb_Phone.Text = dtgv_Customers.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }

        private void txb_Update_Click(object sender, EventArgs e)
        {
            if (dtgv_Customers.Rows.Count > 0 && textBox1.Text != string.Empty)
            {
                try
                {
                    UpdateCustomerInDatabase(int.Parse(textBox1.Text), txb_Name.Text, int.Parse(txb_Age.Text), cb_Gender.Text, txb_Phone.Text);
                    id = 0;
                    clear();
                } catch(Exception ex)
                {
                    MessageBox.Show("Please fill put correct format: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please choose a row to update");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
