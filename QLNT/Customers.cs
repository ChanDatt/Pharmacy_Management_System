using System.Data.SqlClient;
using TL;
using BL;

namespace QLNT
{
    public partial class Customers : Form
    {
        private int id;

        private void clear()
        {
            txb_Name.Clear();
            txb_Age.Clear();
            txb_Phone.Clear();
            txb_Name.Focus();
        }
        public Customers()
        {
            InitializeComponent();
            LoadCustomerData();

            string[] genderlist = { "Nam", "Nu" };
            foreach (string gender in genderlist)
            {
                cb_Gender.Items.Add(gender);
            }
        }
        private void LoadCustomerData()
        {
            try
            {
                dtgv_Customers.DataSource = new BL.CustomersBL().GetCustomersTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btn_AddStaff_Click(object sender, EventArgs e)
        {
            if (txb_Name.Text != "" && cb_Gender.Text != "" && txb_Age.Text != "" && txb_Phone.Text != "")
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

                try
                {
                    string name = txb_Name.Text;
                    int age = int.Parse(txb_Age.Text);
                    string gender = cb_Gender.Text;
                    string phone = txb_Phone.Text;
                    CustomersTL staff = new CustomersTL(newId, name, age, gender, phone);
                    new CustomersBL().AddCustomer(staff);
                    MessageBox.Show("Add successful");
                    clear();
                    LoadCustomerData();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please fill out the information");

            }
        }

        private void btn_DeleteCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                new CustomersBL().DelCustomer(id);
                MessageBox.Show("Delete successful");
                clear();
                LoadCustomerData();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateCustomerInDatabase(int CID, string name, int age, string gender, string phone)
        {
            try
            {
                CustomersTL customer = new CustomersTL(CID, name, age, gender, phone);
                new CustomersBL().UpdCustomer(customer);
                MessageBox.Show("Record updated successfully.");
                LoadCustomerData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void dtgv_Customers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0 && e.RowIndex >= 0)
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
            if (dtgv_Customers.Rows.Count >= 0)
            {
                try
                {
                    UpdateCustomerInDatabase(id, txb_Name.Text, int.Parse(txb_Age.Text), cb_Gender.Text, txb_Phone.Text);
                    id = 0;
                    clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please fill put correct format: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please choose a row to update");
            }
        }

        private void txb_Search_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dtgv_Customers.DataSource = new BL.CustomersBL().GetCustomersTable(txb_Search.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
