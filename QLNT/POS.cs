using BL;
using Guna.UI2.WinForms;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing.Printing;
using TL;

namespace QLNT
{
    public partial class POS : Form
    {
        private int currentOffset = 0;
        private const int pageSize = 200;
        private CustomersTL customer;
        private StaffsTL staff;
        private string note;
        private string paymentmethod;
        private decimal totalAmount = 0;
        private decimal grandTotal = 0;
        private int rowIndex = 0;

        private LoadingBar loading;
        private BackgroundWorker worker;
        public POS(string currentName)
        {
            InitializeComponent();
            InitializeBackgroundWorker();
        }

        private void POS_Load(object sender, EventArgs e)
        {
            loading = new LoadingBar();
            loading.Show();
            worker.RunWorkerAsync();
            SelectStaff();

            dtgv_items.CellValueChanged += dtgv_items_CellValueChanged;
            lb_AmountPaid.TextAlignment = ContentAlignment.MiddleRight;
            lb_GrandTotal.TextAlignment = ContentAlignment.MiddleRight;
        }

        private void InitializeBackgroundWorker()
        {
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            worker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadMedicines(); 
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            loading.UpdateProgress(e.ProgressPercentage);
        }


        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            loading.Close();
        }

        private void LoadMedicines(string searchText = "")
        {
            try
            {
                DataTable medicines;

                int totalRecords;
                if (string.IsNullOrEmpty(searchText))
                {
                    medicines = new BL.InventoriesBL().getMedicines(currentOffset, pageSize);
                    totalRecords = medicines.Rows.Count; 
                }
                else
                {
                    medicines = new BL.InventoriesBL().getMedicinesFromDataBase(searchText);
                    totalRecords = medicines.Rows.Count; 
                }

                flop_Items.Controls.Clear();

                int progress = 0, recordsFetched = 0;

                foreach (DataRow row in medicines.Rows)
                {
                    int mid = Convert.ToInt32(row["MID"]);
                    string medicineName = row["MedicineName"].ToString();
                    decimal price = Convert.ToDecimal(row["UnitPrice"]);
                    price += price * (decimal)0.08;
                    int stockQuantity = Convert.ToInt32(row["StockQuantity"]);

                    MedicineItem medicineItem = new MedicineItem(mid, medicineName, price, stockQuantity);
                    medicineItem.ItemClicked += MedicineItem_ItemClicked;

                    flop_Items.Invoke((MethodInvoker)delegate { flop_Items.Controls.Add(medicineItem); });

                    recordsFetched++;
                    progress = (recordsFetched * 100) / totalRecords;
                    worker.ReportProgress(progress);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MedicineItem_ItemClicked(object sender, ItemClickedEventArgs e)
        {
            bool itemExists = false;

            foreach (DataGridViewRow row in dtgv_items.Rows)
            {
                if (Convert.ToInt32(row.Cells["MID"].Value) == e.MID)
                {
                    // Increment the quantity
                    int currentQuantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                    row.Cells["Quantity"].Value = currentQuantity + 1;

                    // Update total price
                    decimal totalPrice = (currentQuantity + 1) * e.Price;
                    row.Cells["TotalPrice"].Value = totalPrice;

                    itemExists = true;
                    break;
                }
            }

            // If the item does not exist, add a new row
            if (!itemExists)
            {
                DataGridViewRow newRow = dtgv_items.Rows[dtgv_items.Rows.Add()];
                newRow.Cells["MID"].Value = e.MID; // Store the MID in the DataGridView
                newRow.Cells["Items"].Value = e.MedicineName;
                newRow.Cells["UnitPrice"].Value = e.Price;
                newRow.Cells["Quantity"].Value = 1; // Set initial quantity to 1
                newRow.Cells["TotalPrice"].Value = e.Price; // Set total price
            }
        }

        // Usage in TextChanged event
        private void txb_Search_TextChanged(object sender, EventArgs e)
        {
            string searchText = txb_Search.Text;
            LoadMedicines(searchText);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lb_Date.Text = DateTime.Now.ToLongTimeString() + "  " + DateTime.Now.ToShortDateString();
        }

        private void btn_Pay_POS_Click(object sender, EventArgs e)
        {
            if (cb_Customer.Text != "" && cb_Staff.Text != "" && paymentmethod != null && dtgv_items.Rows.Count > 0)
            {
                if (paymentmethod != "Cash")
                {
                    if (new Verify(paymentmethod, grandTotal).ShowDialog() == DialogResult.OK)
                    {
                        printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
                        printDocument1.BeginPrint += new PrintEventHandler(printDocument1_BeginPrint);

                        PrintDocument printDocument = new PrintDocument();

                        // Thiết lập kích thước hóa đơn (80mm x 200mm)
                        PaperSize paperSize = new PaperSize("Receipt", 315, 787);

                        printDocument1.DefaultPageSettings.PaperSize = paperSize;
                        printDocument1.DefaultPageSettings.Margins = new Margins(10, 10, 10, 10);
                        printPreviewDialog1.Document = printDocument1;
                        try
                        {
                            printPreviewDialog1.ShowDialog();
                            UpdateReceiptAndInfo();

                            printDocument1.Print();
                            ClearPOS();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Failed to process: " + $"{ex.Message}");
                        }
                    }
                }
                else if (paymentmethod == "Cash")
                {
                    if (new Cash(grandTotal).ShowDialog() == DialogResult.OK)
                    {
                        printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
                        printDocument1.BeginPrint += new PrintEventHandler(printDocument1_BeginPrint);

                        PrintDocument printDocument = new PrintDocument();

                        // size of the receipt (80mm x 200mm)
                        PaperSize paperSize = new PaperSize("Receipt", 315, 787);

                        printDocument1.DefaultPageSettings.PaperSize = paperSize;
                        printDocument1.DefaultPageSettings.Margins = new Margins(10, 10, 10, 10);
                        printPreviewDialog1.Document = printDocument1;
                        try
                        {
                            printPreviewDialog1.ShowDialog();
                            UpdateReceiptAndInfo();

                            printDocument1.Print();
                            ClearPOS();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Failed to process: " + $"{ex.Message}");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please fill in all information");
            }
        }

        private void printDocument1_BeginPrint(object sender, PrintEventArgs e)
        {
            rowIndex = 0;
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            var pathImage = Directory.GetParent(Application.StartupPath);
            Graphics g = e.Graphics;
            Font fontTitle = new Font("Space Mono", 25, FontStyle.Bold);
            Font fontHeader = new Font("Space Mono", 10, FontStyle.Regular);
            Font fontContent = new Font("Space Mono", 6, FontStyle.Regular);
            Font fontBoldContent = new Font("Space Mono", 10, FontStyle.Bold);

            int pageWidth = printDocument1.DefaultPageSettings.PaperSize.Width; // Chiều rộng giấy
            int y = 20;
            int pageHeight = printDocument1.DefaultPageSettings.PaperSize.Height; // Chiều cao giấy
            int margin = 10;

            // Căn phải
            float xTotalAmount = e.MarginBounds.Right - g.MeasureString(totalAmount.ToString("C"), fontBoldContent).Width;
            float xTax = e.MarginBounds.Right - g.MeasureString("8%", fontBoldContent).Width;
            float xGrandTotal = e.MarginBounds.Right - g.MeasureString(grandTotal.ToString("C"), fontBoldContent).Width;


            // Biến theo dõi số sản phẩm đã in
            int rowIndex = 0;
            bool hasMorePages = false;

            // Hàm tính tọa độ X để căn giữa
            float CenterText(string text, Font font)
            {
                SizeF textSize = g.MeasureString(text, font);
                return (pageWidth - textSize.Width) / 2;
            }

            try
            {
                Image logo = Image.FromFile(pathImage + "\\assets_img\\SC_logo.png");
                int logoWidth = 100; // Chiều rộng logo
                int logoHeight = 100; // Chiều cao logo
                g.DrawImage(logo, new Rectangle((pageWidth - logoWidth) / 2, y, logoWidth, logoHeight));
                y += logoHeight + 10; // Cập nhật vị trí Y
            }
            catch
            {
                g.DrawString("LOGO NOT FOUND", fontHeader, Brushes.Red, new PointF(CenterText("LOGO NOT FOUND", fontHeader), y));
                y += 40;
            }

            // Tiêu đề cửa hàng
            g.DrawString("SHORT CHAU", fontTitle, Brushes.Black, new PointF(CenterText("SHORT CHAU", fontTitle), y));
            y += 70;
            g.DrawString("Date: " + lb_Date.Text, fontHeader, Brushes.Black, new PointF(10, y));
            y += 20; // Reduced space
            g.DrawString("Customer: " + customer.Name, fontHeader, Brushes.Black, new PointF(10, y));
            y += 20; // Reduced space
            g.DrawString("Staff: " + staff.Name, fontHeader, Brushes.Black, new PointF(10, y));
            y += 20; // Reduced space
            g.DrawString("Note: " + note, fontHeader, Brushes.Black, new PointF(10, y));
            y += 20; // Reduced space
            g.DrawString("Payment Method: " + paymentmethod, fontHeader, Brushes.Black, new PointF(10, y));
            y += 20; // Reduced space


            // Dòng kẻ
            g.DrawLine(Pens.Black, new PointF(10, y), new PointF(pageWidth - 10, y));
            y += 10;

            // Header bảng chi tiết sản phẩm
            g.DrawString("Name", fontBoldContent, Brushes.Black, new PointF(10, y));
            g.DrawString("Qty", fontBoldContent, Brushes.Black, new PointF(pageWidth / 2 - 15, y));
            g.DrawString("Price", fontBoldContent, Brushes.Black, new PointF(pageWidth - 110, y));
            g.DrawString("Total", fontBoldContent, Brushes.Black, new PointF(pageWidth - 50, y));
            y += 30;

            int colNameWidth = (int)(pageWidth * 0.5);
            int colQtyWidth = (int)(pageWidth * 0.15);
            int colPriceWidth = (int)(pageWidth * 0.2);
            int colTotalWidth = (int)(pageWidth * 0.15);

            int xName = 10; // Lề trái
            int xQty = xName + colNameWidth;
            int xPrice = xQty + colQtyWidth;
            int xTotal = xPrice + colPriceWidth;

            // Chi tiết sản phẩm từ DataGridView

            while (rowIndex < dtgv_items.Rows.Count)
            {
                DataGridViewRow row = dtgv_items.Rows[rowIndex];
                if (row.Cells[0].Value != null)
                {
                    string productName = row.Cells[0].Value.ToString();
                    int quantity = Convert.ToInt32(row.Cells[3].Value);
                    decimal price = Convert.ToDecimal(row.Cells[2].Value);
                    decimal total = quantity * price;

                    // Kiểm tra nếu vượt quá chiều cao trang
                    if (y + 20 > pageHeight - margin)
                    {
                        hasMorePages = true;
                        break;
                    }

                    // Vẽ thông tin sản phẩm
                    g.DrawString(productName, fontContent, Brushes.Black, new RectangleF(xName, y, colNameWidth, 20));
                    g.DrawString(quantity.ToString(), fontContent, Brushes.Black, new RectangleF(xQty, y, colQtyWidth, 20));
                    g.DrawString(price.ToString("C"), fontContent, Brushes.Black, new RectangleF(xPrice, y, colPriceWidth, 20));
                    g.DrawString(total.ToString("C"), fontContent, Brushes.Black, new RectangleF(xTotal, y, colTotalWidth, 20));
                    y += 20;
                }
                rowIndex++;
            }

            // Dòng kẻ
            if (!hasMorePages)
            {
                g.DrawLine(Pens.Black, new PointF(10, y), new PointF(pageWidth - 10, y));
                y += 10;

                g.DrawString("Total Amount", fontBoldContent, Brushes.Black, new PointF(10, y));
                g.DrawString(totalAmount.ToString("C"), fontBoldContent, Brushes.Black, xTotalAmount, y);
                y += 20;

                g.DrawString("Tax", fontBoldContent, Brushes.Black, new PointF(10, y));
                g.DrawString("8%", fontBoldContent, Brushes.Black, xTax, y);
                y += 30;

                g.DrawLine(Pens.Black, new PointF(10, y), new PointF(pageWidth - 10, y));
                y += 10;

                // Tổng cộng
                g.DrawString("Grand Total", fontBoldContent, Brushes.Black, new PointF(10, y));
                g.DrawString(grandTotal.ToString("C"), fontBoldContent, Brushes.Black, xGrandTotal, y);
                y += 30;

                g.DrawString("THANK YOU!", fontBoldContent, Brushes.Black, new PointF(CenterText("THANK YOU!", fontBoldContent), y));
            }

            e.HasMorePages = hasMorePages;
            if (paymentmethod != "Cash")
            {
                try
                {
                    Image qrcode = Image.FromFile(pathImage + @$"\assets_img\{paymentmethod}.jpg");
                    int logoWidth = 100; // Chiều rộng logo
                    int logoHeight = 100; // Chiều cao logo
                    g.DrawImage(qrcode, new Rectangle((pageWidth - logoWidth) / 2, y, logoWidth, logoHeight));
                    y += logoHeight + 10; // Cập nhật vị trí Y
                }
                catch
                {
                    g.DrawString("LOGO NOT FOUND", fontHeader, Brushes.Red, new PointF(CenterText("LOGO NOT FOUND", fontHeader), y));
                    y += 40;
                }
            }
        }

        private void dtgv_items_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtgv_items.Columns["Quantity"].Index && e.RowIndex >= 0)
            {
                if (int.TryParse(dtgv_items.Rows[e.RowIndex].Cells["Quantity"].Value.ToString(), out int newQuantity))
                {
                    if (newQuantity == 0)
                    {
                        dtgv_items.Rows.RemoveAt(e.RowIndex);
                    }
                    else
                    {
                        decimal unitPrice = Convert.ToDecimal(dtgv_items.Rows[e.RowIndex].Cells["UnitPrice"].Value);
                        decimal newTotalPrice = newQuantity * unitPrice;
                        dtgv_items.Rows[e.RowIndex].Cells["TotalPrice"].Value = newTotalPrice;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid value", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            UpdateTotalAmount();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (dtgv_items.CurrentRow != null && !dtgv_items.CurrentRow.IsNewRow)
            {
                // Lấy dòng hiện tại
                DataGridViewRow currentRow = dtgv_items.CurrentRow;

                if (int.TryParse(currentRow.Cells["Quantity"].Value?.ToString(), out int currentQuantity))
                {
                    int newQuantity = currentQuantity + 1;
                    currentRow.Cells["Quantity"].Value = newQuantity;

                    if (decimal.TryParse(currentRow.Cells["UnitPrice"].Value?.ToString(), out decimal unitPrice))
                    {
                        decimal newTotalPrice = newQuantity * unitPrice;
                        currentRow.Cells["TotalPrice"].Value = newTotalPrice;
                    }

                    UpdateTotalAmount();
                }
            }
            else
            {
                MessageBox.Show("Please choose a row you want to add", "Notification");
            }
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            if (dtgv_items.CurrentRow != null && !dtgv_items.CurrentRow.IsNewRow)
            {
                DataGridViewRow currentRow = dtgv_items.CurrentRow;

                if (int.TryParse(currentRow.Cells["Quantity"].Value?.ToString(), out int currentQuantity) && currentQuantity > 0)
                {
                    int newQuantity = currentQuantity - 1;
                    currentRow.Cells["Quantity"].Value = newQuantity;
                    try
                    {
                        if (newQuantity == 0)
                        {
                            dtgv_items.Rows.Remove(currentRow);
                        }
                        else
                        {
                            if (decimal.TryParse(currentRow.Cells["UnitPrice"].Value?.ToString(), out decimal unitPrice))
                            {
                                decimal newTotalPrice = newQuantity * unitPrice;
                                currentRow.Cells["TotalPrice"].Value = newTotalPrice;
                            }
                        }
                        UpdateTotalAmount();
                    }
                    catch
                    {
                        MessageBox.Show("Delete successfull");
                    }

                }
            }
            else
            {
                MessageBox.Show("Please choose a row you want to minus", "Notification");
            }
        }

        private void UpdateTotalAmount()
        {
            totalAmount = 0;
            foreach (DataGridViewRow row in dtgv_items.Rows)
            {
                if (decimal.TryParse(row.Cells["TotalPrice"].Value?.ToString(), out decimal rowTotal))
                {
                    totalAmount += rowTotal;
                }
            }

            // Cập nhật hiển thị tổng cộng
            lb_TotalAmount.Text = Math.Round(totalAmount, 2).ToString("C");
            grandTotal = totalAmount + totalAmount * (decimal)0.08;
            lb_AmountPaid.Text = Math.Round(grandTotal, 2).ToString("C");
        }




        ///////////////// CUSTOMERS COMBO_BOX ///////////////////// 
        private void LoadCustomerData(string phoneNumber)
        {
            try
            {
                CustomersTL customer = new BL.CustomersBL().LoadCustomerData(phoneNumber);
                if (customer != null)
                {
                    cb_Customer.Items.Clear();
                    cb_Customer.Items.Add(new { Text = customer.Name, Value = customer.Id });
                    cb_Customer.DisplayMember = "Text";
                    cb_Customer.ValueMember = "Value";
                    cb_Customer.DroppedDown = false;
                }
                else
                {
                    MessageBox.Show("No customers found.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cb_Customer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cb_Customer.DroppedDown)
                {
                    if (cb_Customer.SelectedIndex >= 0)
                    {
                        var selectedItem = cb_Customer.SelectedItem as CustomersTL;
                        if (selectedItem != null)
                        {
                            cb_Customer.Text = selectedItem.Name;
                            cb_Customer.SelectedIndex = 0;
                        }
                    }
                }
                else
                {
                    string searchText = cb_Customer.Text;
                    LoadCustomerData(searchText);
                }

                e.SuppressKeyPress = true;
            }
        }
        private void cb_Customer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Customer.SelectedItem != null)
            {
                var selectedCustomer = (dynamic)cb_Customer.SelectedItem;
                int selectedCustomerId = selectedCustomer.Value;
                string selectedCustomerName = selectedCustomer.Text;

                customer = new CustomersTL(selectedCustomerId, selectedCustomerName);
            }
        }

        ////////////////////////////////////////////////////////
        ///////////////// STAFFS COMBO_BOX ///////////////////// 
        private void SelectStaff(string searchStaff = null)
        {
            cb_Staff.DataSource = null;
            try
            {
                List<StaffsTL> list = new StaffsBL().SelectStaff(searchStaff);
                cb_Staff.DataSource = list;
                if (cb_Staff.Items.Count > 0)
                {
                    cb_Staff.DisplayMember = "Name";
                    cb_Staff.ValueMember = "Id";
                    cb_Staff.SelectedIndex = -1;
                    if (searchStaff != null)
                    {
                        cb_Staff.DroppedDown = true;
                    }
                }
                else
                {
                    MessageBox.Show("No staff found.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cb_Staff_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Staff.SelectedItem != null)
            {
                var selectedStaff = (dynamic)cb_Staff.SelectedItem;
                int selectedStaffId = selectedStaff.Id;
                string selectedStaffName = selectedStaff.Name;
                staff = new StaffsTL(selectedStaffId, selectedStaffName);
            }
        }

        private void cb_Staff_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cb_Staff.DroppedDown)
                {
                    var selectedItem = cb_Staff.SelectedItem as StaffsTL;
                    if (selectedItem != null)
                    {
                        cb_Staff.Text = selectedItem.Name;

                        if (cb_Staff.Items.Count > 0)
                        {
                            cb_Staff.SelectedIndex = 0;
                        }
                    }
                }
                else
                {
                    string searchText = cb_Staff.Text;
                    SelectStaff(searchText);
                }
                e.SuppressKeyPress = true;
            }
        }
        //////////////////////////////////////////////////////////


        private void flop_Items_Scroll(object sender, EventArgs e)
        {
            if (flop_Items.VerticalScroll.Value + flop_Items.ClientSize.Height >= flop_Items.VerticalScroll.Maximum - 10)
            {
                currentOffset += pageSize;
                LoadMedicines();
            }
        }
        private void SetPaymentMethod(string method, Guna2Button selectedButton)
        {
            paymentmethod = method;

            btn_Cash.BorderThickness = 0;
            btn_Card.BorderThickness = 0;
            btn_Momo.BorderThickness = 0;
            btn_Zalo.BorderThickness = 0;

            selectedButton.BorderThickness = 9;
        }

        private void btn_Cash_Click(object sender, EventArgs e)
        {
            SetPaymentMethod("Cash", btn_Cash);
        }

        private void btn_Card_Click(object sender, EventArgs e)
        {
            SetPaymentMethod("CreditCard", btn_Card);
        }

        private void btn_Momo_Click(object sender, EventArgs e)
        {
            SetPaymentMethod("Momo", btn_Momo);
        }

        private void btn_Zalo_Click(object sender, EventArgs e)
        {
            SetPaymentMethod("ZaloPay", btn_Zalo);
        }

        private void txb_Note_TextChanged(object sender, EventArgs e)
        {
            note = txb_Note.Text;
        }

        private void UpdateReceiptAndInfo()
        {
            int customerId = customer.Id;
            int staffId = staff.Id;
            decimal totalAmount = grandTotal;
            string paymentMethod = paymentmethod;
            string result = note;
            List<(int MID, int Quantity)> items = new List<(int, int)>();

            try
            {
                foreach (DataGridViewRow row in dtgv_items.Rows)
                {
                    if (row.IsNewRow) continue;

                    int mid = Convert.ToInt32(row.Cells["MID"].Value);
                    int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);

                    items.Add((mid, quantity));
                }
                new BL.ReceiptsBL().CreateReceipt(customerId, staffId, totalAmount, paymentMethod, result, items);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ClearPOS()
        {
            txb_Search.Text = string.Empty;
            cb_Customer.Text = string.Empty;
            cb_Staff.Text = string.Empty;
            txb_Note.Text = string.Empty;
            lb_AmountPaid.Text = "0.00";
            lb_TotalAmount.Text = "0.00";
            btn_Card.BorderThickness = 0;
            btn_Momo.BorderThickness = 0;
            btn_Zalo.BorderThickness = 0;
            btn_Cash.BorderThickness = 0;
            dtgv_items.Rows.Clear();
        }

        private void dtgv_items_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dtgv_items.Columns[e.ColumnIndex].Name == "Quantity")
            {
                string inputValue = e.FormattedValue.ToString();

                if (!int.TryParse(inputValue, out int result))
                {
                    MessageBox.Show("Invalid value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
                else
                {
                    e.Cancel = false;
                }
            }
        }


        ///
        ///
        /// Recycle Bin
        /// 
        ///
        string imagePath = Directory.GetParent(Application.StartupPath).ToString();

        private void pic_Recycle_Bin_Click(object sender, EventArgs e)
        {
            if (dtgv_items.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dtgv_items.SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        dtgv_items.Rows.Remove(row);
                    }
                }
                UpdateTotalAmount();
            }
            else
            {
                MessageBox.Show("Please choose a row you want to delete", "Notification");
            }
        }

        private void pic_Recycle_Bin_MouseEnter(object sender, EventArgs e)
        {
            pic_Recycle_Bin.Image = Image.FromFile(imagePath + "\\assets_img\\" + "recycle-bin.png");
        }

        private void pic_Recycle_Bin_MouseLeave(object sender, EventArgs e)
        {
            pic_Recycle_Bin.Image = Image.FromFile(imagePath + "\\assets_img\\" + "bin.png");
        }

        private void btn_Exist_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
