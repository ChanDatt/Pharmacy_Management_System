using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using DataTable = System.Data.DataTable;
using TL;

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
            try
            {
                DataTable expiredProducts = new BL.InventoriesBL().getExpiredOrNearExpiredProducts();

                if (expiredProducts.Rows.Count > 0)
                {
                    dtgv_Inventories.AutoGenerateColumns = true;
                    dtgv_Inventories.DataSource = expiredProducts;
                    dtgv_Inventories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                else
                {
                    MessageBox.Show("No expired or near-expired products found.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadOutOfStockProduct()
        {
            try
            {
                DataTable oosProduct = new BL.InventoriesBL().getOutOfStockProduct();

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
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadMedicines()
        {
            try
            {
                DataTable medicinesTable = new BL.InventoriesBL().getMedicines(currentOffset, pageSize);
                dtgv_Inventories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                if (medicinesTable.Columns.Count == 0)
                {
                    MessageBox.Show("No columns found in the DataTable.");
                    return;
                }

                dtgv_Inventories.AutoGenerateColumns = true; // Ensure columns are auto-generated
                dtgv_Inventories.DataSource = medicinesTable;

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_ExpireProduct_Click(object sender, EventArgs e)
        {
            LoadExpiredOrNearExpiredProducts();
        }

        private void UpdateMedicineCountAndStock()
        {
            try
            {
                List<int> list = new BL.InventoriesBL().updateMedicineCountAndStock();

                guna2HtmlLabel4.Text = list[0].ToString(); // TotalMedicines
                guna2HtmlLabel6.Text = list[1].ToString(); // TotalStockQuantity
                guna2HtmlLabel5.Text = list[2].ToString(); // TotalExpiredProducts 
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        private void btn_Product_Click(object sender, EventArgs e)
        {
            LoadMedicines();
        }
        private void btn_OutOfStock_Click(object sender, EventArgs e)
        {
            LoadOutOfStockProduct();
        }
        private void btn_Report_Click(object sender, EventArgs e)
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

        private void btn_Restock_Click(object sender, EventArgs e)
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

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txb_FileName.Text) && System.IO.File.Exists(txb_FileName.Text))
            {
                List<MedInventory> medicines = new List<MedInventory>();
                for (int i = 0; i < dtgv_Inventories.Rows.Count; i++)
                {
                    try
                    {
                        MedInventory med = new MedInventory
                        {
                            MedicineName = dtgv_Inventories.Rows[i].Cells[1].Value.ToString(),
                            Type = dtgv_Inventories.Rows[i].Cells[2].Value.ToString(),
                            PackSizeLabel = dtgv_Inventories.Rows[i].Cells[3].Value.ToString(),
                            StockQuantity = int.Parse(dtgv_Inventories.Rows[i].Cells[4].Value.ToString()),
                            UnitPrice = decimal.Parse(dtgv_Inventories.Rows[i].Cells[5].Value.ToString()),
                            ISDiscontinued = dtgv_Inventories.Rows[i].Cells[6].Value.ToString(),
                            ManufacturerName = dtgv_Inventories.Rows[i].Cells[7].Value.ToString(),
                            Composition1 = dtgv_Inventories.Rows[i].Cells[8].Value.ToString(),
                            Composition2 = dtgv_Inventories.Rows[i].Cells[9].Value.ToString(),
                            Timestamp = DateTime.Parse(dtgv_Inventories.Rows[i].Cells[10].Value.ToString()),
                            ExperationDATE = DateTime.Parse(dtgv_Inventories.Rows[i].Cells[11].Value.ToString())
                        };
                        medicines.Add(med);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        continue;
                    }
                }
                if (new BL.InventoriesBL().AddMedicines(medicines))
                {
                    MessageBox.Show("Items saved");
                    txb_FileName.Clear();
                    LoadMedicines();
                    UpdateMedicineCountAndStock();
                }
                else
                {
                    MessageBox.Show("Error during add");
                }

            }
            else
            {
                MessageBox.Show("Please select file");
            }
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
            if (dtgv_Inventories.SelectedRows.Count > 0)
            {

                    var confirmation = MessageBox.Show("Are you sure you want to delete the selected items?", "Confirm Delete", MessageBoxButtons.YesNo);
                    if (confirmation == DialogResult.Yes)
                    {
                        List<int> midsToDelete = new List<int>();

                    foreach (DataGridViewRow row in dtgv_Inventories.SelectedRows)
                    {
                        if (row.Cells["MID"].Value != null)
                        {
                            midsToDelete.Add(Convert.ToInt32(row.Cells["MID"].Value));
                        }
                    }

                    if (new BL.InventoriesBL().DeleteMedicines(midsToDelete))
                    {
                        MessageBox.Show("Items deleted successfully");

                        foreach (DataGridViewRow row in dtgv_Inventories.SelectedRows)
                        {
                            dtgv_Inventories.Rows.Remove(row);
                        }

                        UpdateMedicineCountAndStock();
                    }
                    else
                    {
                        MessageBox.Show("Error deleting items.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }
    }
}

