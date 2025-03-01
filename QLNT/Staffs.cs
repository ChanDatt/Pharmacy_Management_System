using BL;
using System.Data.SqlClient;
using System.Windows.Forms;
using TL;
using DataTable = System.Data.DataTable;

namespace QLNT
{
    public partial class Staffs : Form
    {
        private System.Windows.Forms.ComboBox cmbEmployee;
        private int id;
        private SQLConnectionClass sqlConnection;
        private int newId;
        private string note;
        private string phone;
        private string status;
        private decimal salary;
        private string address;

        public Staffs()
        {
            InitializeComponent();
            LoadEmployeeData();
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
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

        private void clear()
        {
            txb_Name.Text = string.Empty;
            txb_Phone.Text = string.Empty;
            txb_Address.Text = string.Empty;
            txb_Salary.Text = string.Empty;
        }

        private void LoadEmployeeData()
        {
            try
            {
                dtgv_Staffs.DataSource = new BL.StaffsBL().GetStaffsTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
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
            try
            {
                dtgv_Staffs.DataSource = new BL.StaffsBL().GetStaffsTable(txb_SearchMedicine.Text);
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
                DialogResult result = folderBrowser.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowser.SelectedPath))
                {
                    string exportPath = Path.Combine(folderBrowser.SelectedPath, "Export_Staffs.xlsx"); 

                    try
                    {
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


        //
        //
        // Add
        //
        //
        private void AddEmployee(string name, string phone, string note, string status, decimal salary, string address)
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

            try
            {
                TL.StaffsTL staff = new TL.StaffsTL(newId, name, note, phone, status, salary, address);
                new StaffsBL().AddStaff(staff);
                MessageBox.Show("Add successful");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
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
                clear();
            }
            else
            {
                MessageBox.Show("Please fill out the information");
            }
        }

        //
        //
        // Update
        //
        //
        private void UpdateEmployeeInDatabase(int employeeId, string name, string phone, string note, string status, decimal salary, string address)
        {
            try
            {
                StaffsTL staffs = new StaffsTL(employeeId, name, note, phone, status, salary, address);
                new StaffsBL().UpdStaff(staffs);
                MessageBox.Show("Record updated successfully.");
                LoadEmployeeData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (dtgv_Staffs.Rows.Count >= 0)
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


        //
        //
        // Delete
        //
        //
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                new StaffsBL().DelStaff(id);
                MessageBox.Show("Delete successful");
                LoadEmployeeData();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("You can not delete this row. \rError:" + ex.Message);

            }
            LoadEmployeeData();
        }
    }
}