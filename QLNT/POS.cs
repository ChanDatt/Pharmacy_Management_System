using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLNT
{
    public partial class POS : Form
    {
        private SQLConnectionClass sqlConnection;
        private int currentOffset = 0;
        private const int pageSize = 200;

        public class Customer
        {
            public int CID { get; set; }
            public string Name { get; set; }
        }

        public class Staff
        {
            public int EID { get; set; }
            public string Name { get; set; }
        }
        private Customer customer;
        private Staff staff;
        private string note;
        private string paymentmethod;
        private decimal totalAmount = 0;
        private decimal grandTotal = 0;
        public POS(string currentName)
        {
            InitializeComponent();
            sqlConnection = new SQLConnectionClass();
            bool isConnected = sqlConnection.TestConnection();
            if (!isConnected)
            {
                MessageBox.Show("Connection failed. Check your settings.");
            }
            LoadMedicines();
            flowLayoutPanel2.Scroll += MedicinesPanel_Scroll;
            guna2TextBox1.TextChanged += Guna2TextBox1_TextChanged;
            dtgv_items.CellValueChanged += Dtgv_items_CellValueChanged;
        }
        private void LoadMedicines(string searchText = "")
        {
            try
            {
                DataTable medicines = string.IsNullOrEmpty(searchText)
                ? new BL.InventoriesBL().getMedicines(currentOffset, pageSize)
                : new BL.InventoriesBL().getMedicinesFromDataBase(searchText);

                flowLayoutPanel2.Controls.Clear();

                foreach (DataRow row in medicines.Rows)
                {
                    int mid = Convert.ToInt32(row["MID"]);
                    string medicineName = row["MedicineName"].ToString();
                    decimal price = Convert.ToDecimal(row["UnitPrice"]);
                    price += price * (decimal)0.08;
                    int stockQuantity = Convert.ToInt32(row["StockQuantity"]); // Get stock quantity

                    MedicineItem medicineItem = new MedicineItem(mid, medicineName, price, stockQuantity);
                    medicineItem.ItemClicked += MedicineItem_ItemClicked;

                    flowLayoutPanel2.Controls.Add(medicineItem);
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
        private void Guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            string searchText = guna2TextBox1.Text; // Get the current text from the textbox
            LoadMedicines(searchText); // Load medicines based on the search text
        }



        private void MedicinesPanel_Scroll(object sender, EventArgs e)
        {
            // Check if the user has scrolled to the bottom of the panel
            if (flowLayoutPanel2.VerticalScroll.Value + flowLayoutPanel2.ClientSize.Height >= flowLayoutPanel2.VerticalScroll.Maximum - 10) // Adjust threshold if needed
            {
                currentOffset += pageSize; // Prepare for next load
                LoadMedicines(); // Load more medicines
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            lb_Date.Text = DateTime.Now.ToLongTimeString() + "  " + DateTime.Now.ToShortDateString();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Pay_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox2.Text != "" && paymentmethod != null && dtgv_items.Rows.Count > 0)
            {
                if (paymentmethod != "Cash")
                {
                    if (new Verify(paymentmethod, grandTotal).ShowDialog() == DialogResult.OK)
                    {
                        printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
                        printDocument1.BeginPrint += new PrintEventHandler(printDocument1_BeginPrint);

                        // Tạo đối tượng PrintDocument
                        PrintDocument printDocument = new PrintDocument();

                        // Thiết lập kích thước hóa đơn (80mm x 200mm)
                        PaperSize paperSize = new PaperSize("Receipt", 315, 787); // Kích thước tính bằng 100ths of an inch (80mm x 200mm)

                        printDocument1.DefaultPageSettings.PaperSize = paperSize;
                        printDocument1.DefaultPageSettings.Margins = new Margins(10, 10, 10, 10);
                        printPreviewDialog1.Document = printDocument1;
                        try
                        {
                            printPreviewDialog1.ShowDialog();
                            UpdateReceiptAndInfo();

                            // Finally, print the document
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

                        // Tạo đối tượng PrintDocument
                        PrintDocument printDocument = new PrintDocument();

                        // Thiết lập kích thước hóa đơn (80mm x 200mm)
                        PaperSize paperSize = new PaperSize("Receipt", 315, 787); // Kích thước tính bằng 100ths of an inch (80mm x 200mm)

                        printDocument1.DefaultPageSettings.PaperSize = paperSize;
                        printDocument1.DefaultPageSettings.Margins = new Margins(10, 10, 10, 10);
                        printPreviewDialog1.Document = printDocument1;
                        try
                        {
                            printPreviewDialog1.ShowDialog();
                            UpdateReceiptAndInfo();

                            // Finally, print the document
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

        private int rowIndex = 0;

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

        private void Dtgv_items_CellValueChanged(object sender, DataGridViewCellEventArgs e)
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


        private void guna2Button2_Click(object sender, EventArgs e)
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

        private void guna2Button3_Click(object sender, EventArgs e)
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


        private void POS_Load(object sender, EventArgs e)
        {
            lb_AmountPaid.TextAlignment = ContentAlignment.MiddleRight;
            lb_GrandTotal.TextAlignment = ContentAlignment.MiddleRight;
        }

        private void comboBox1_KeyDown_1(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (comboBox1.DroppedDown)
                {
                    if (comboBox1.SelectedIndex >= 0) // Kiểm tra xem có mục nào được chọn
                    {
                        var selectedItem = comboBox1.SelectedItem as Customer;
                        if (selectedItem != null) // Kiểm tra kiểu dữ liệu
                        {
                            comboBox1.Text = selectedItem.Name; // Gán tên vào comboBox1
                            comboBox1.SelectedIndex = 0; // Chọn mục đầu tiên trong comboBox1 (nếu cần)
                        }
                    }
                }
                else
                {
                    string searchText = comboBox1.Text;
                    LoadCustomerData(searchText); // Tìm kiếm nhân viên
                }

                e.SuppressKeyPress = true; // Ngăn chặn hành động mặc định của Enter
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                var selectedCustomer = (dynamic)comboBox1.SelectedItem; // Use dynamic to access properties
                int selectedCustomerId = selectedCustomer.Value; // Get the ID
                string selectedCustomerName = selectedCustomer.Text; // Get the Name

                // Update your customer object or UI as needed
                customer = new Customer { CID = selectedCustomerId, Name = selectedCustomerName };
            }
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (comboBox2.DroppedDown)
                {
                    if (comboBox2.SelectedIndex >= 0) // Kiểm tra xem có mục nào được chọn
                    {
                        var selectedItem = comboBox2.SelectedItem as Staff;
                        if (selectedItem != null)
                        {
                            comboBox1.Text = selectedItem.Name;
                            comboBox1.SelectedIndex = 0;
                        }
                    }
                }
                else
                {
                    string searchText = comboBox2.Text;
                    SelectStaff(searchText); // Tìm kiếm nhân viên
                }

                e.SuppressKeyPress = true; // Ngăn chặn hành động mặc định của Enter
            }
        }


        private void btn_Cash_Click(object sender, EventArgs e)
        {
            paymentmethod = "Cash";
            btn_Card.BorderThickness = 0;
            btn_Momo.BorderThickness = 0;
            btn_Zalo.BorderThickness = 0;
            btn_Cash.BorderThickness = 9;
        }

        private void btn_Card_Click(object sender, EventArgs e)
        {
            paymentmethod = "CreditCard";
            btn_Cash.BorderThickness = 0;
            btn_Momo.BorderThickness = 0;
            btn_Zalo.BorderThickness = 0;
            btn_Card.BorderThickness = 9;
        }

        private void btn_Momo_Click(object sender, EventArgs e)
        {
            paymentmethod = "Momo";
            btn_Card.BorderThickness = 0;
            btn_Cash.BorderThickness = 0;
            btn_Zalo.BorderThickness = 0;
            btn_Momo.BorderThickness = 9;
        }

        private void btn_Zalo_Click(object sender, EventArgs e)
        {
            paymentmethod = "ZaloPay";
            btn_Card.BorderThickness = 0;
            btn_Momo.BorderThickness = 0;
            btn_Cash.BorderThickness = 0;
            btn_Zalo.BorderThickness = 9;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null)
            {
                var selectedStaff = (dynamic)comboBox2.SelectedItem; // Use dynamic to access properties
                int selectedStaffId = selectedStaff.EID; // Get the ID
                string selectedStaffName = selectedStaff.Name; // Get the Name
                staff = new Staff { EID = selectedStaffId, Name = selectedStaffName };
            }
        }

        private Customer LoadCustomerData(string phoneNumber)
        {
            Customer customer = null; // Initialize customer to null

            using (SqlConnection conn = new SqlConnection(sqlConnection.ConnectionString))
            {
                conn.Open();
                string query = @"
            SELECT CID, CustomerName 
            FROM Customer 
            WHERE Phone LIKE @PhoneNumber;
            UPDATE Customer SET LastDateVisted = GETDATE() WHERE Phone LIKE @PhoneNumber;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        comboBox1.Items.Clear(); // Clear previous results
                        while (reader.Read())
                        {
                            // Create a new customer object
                            customer = new Customer
                            {
                                CID = (int)reader["CID"],
                                Name = (string)reader["CustomerName"]
                            };

                            // Add to the ComboBox with the customer ID as the Tag
                            comboBox1.Items.Add(new { Text = customer.Name, Value = customer.CID });
                        }

                        // Automatically drop down the ComboBox if items were found
                        if (comboBox1.Items.Count > 0)
                        {
                            comboBox1.DisplayMember = "Text"; // Set display member
                            comboBox1.ValueMember = "Value"; // Set value member
                            comboBox1.DroppedDown = true; // Open the dropdown
                        }
                        else
                        {
                            MessageBox.Show("No customers found."); // Inform user if no customers are found
                        }
                    }
                }
            }

            return customer; // Return the customer object
        }
        private void SelectStaff(string employeeName)
        {
            using (SqlConnection conn = new SqlConnection(sqlConnection.ConnectionString))
            {
                conn.Open();
                string query = "SELECT EID, EmployeeName FROM Employee WHERE EmployeeName LIKE @EmployeeName";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EmployeeName", $"%{employeeName}%");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        comboBox2.Items.Clear(); // Clear previous results
                        while (reader.Read())
                        {
                            // Create an anonymous object with ID and Name
                            staff = new Staff
                            {
                                EID = (int)reader["EID"],
                                Name = (string)reader["EmployeeName"]
                            };

                            // Add the anonymous object to the ComboBox
                            comboBox2.Items.Add(staff);
                        }

                        // Automatically drop down the ComboBox if items were found
                        if (comboBox2.Items.Count > 0)
                        {
                            comboBox2.DisplayMember = "Name"; // Set display member
                            comboBox2.ValueMember = "Id"; // Set value member
                            comboBox2.DroppedDown = true; // Open the dropdown
                        }
                        else
                        {
                            MessageBox.Show("No staff found.");
                            return;
                        }
                    }
                }
            }
        }

        private void txb_Note_TextChanged(object sender, EventArgs e)
        {
            note = txb_Note.Text;
        }

        private void UpdateReceiptAndInfo()
        {
            using (var connection = new SqlConnection(sqlConnection.ConnectionString))
            {
                connection.Open();
                string insertReceiptQuery = @"
            INSERT INTO Receipt (CID, EID, Date, TotalAmount, PaymentMethod, Result) 
            VALUES (@CID, @EID, GETDATE(), @TotalAmount, @PaymentMethod, @Result);
            SELECT SCOPE_IDENTITY();"; // This will return the new RID

                int newRID;

                using (var command = new SqlCommand(insertReceiptQuery, connection))
                {
                    command.Parameters.AddWithValue("@CID", customer.CID); // Replace with actual CID
                    command.Parameters.AddWithValue("@EID", staff.EID); // Replace with actual EID
                    command.Parameters.AddWithValue("@TotalAmount", grandTotal); // Replace with actual TotalAmount
                    command.Parameters.AddWithValue("@PaymentMethod", paymentmethod); // Replace with actual PaymentMethod
                    command.Parameters.AddWithValue("@Result", note); // Replace with actual Result

                    newRID = Convert.ToInt32(command.ExecuteScalar()); // Get the new RID
                }

                string insertReceiptInfoQuery = @"
    INSERT INTO ReceiptInfo (RID, MID, Quantity) 
    VALUES (@RID, @MID, @Quantity);";

                using (var command = new SqlCommand(insertReceiptInfoQuery, connection))
                {
                    // Set the RID outside the loop as it remains the same for all items
                    command.Parameters.AddWithValue("@RID", newRID); // Use the new RID

                    foreach (DataGridViewRow row in dtgv_items.Rows)
                    {
                        if (row.IsNewRow) continue; // Skip the new row placeholder
                                                    // Get MID and Quantity from the DataGridView
                        int mid = Convert.ToInt32(row.Cells["MID"].Value); // Replace "MID" with your actual column name
                        int quantity = Convert.ToInt32(row.Cells["Quantity"].Value); // Replace "Quantity" with your actual column name

                        // Clear previous parameters and add new ones for each item
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@RID", newRID);
                        command.Parameters.AddWithValue("@MID", mid);
                        command.Parameters.AddWithValue("@Quantity", quantity);

                        command.ExecuteNonQuery(); // Execute the insert for each item
                    }
                }
            }
        }
        private void ClearPOS()
        {
            guna2TextBox1.Text = string.Empty;
            comboBox1.Text = string.Empty;
            comboBox2.Text = string.Empty;
            txb_Note.Text = string.Empty;
            lb_AmountPaid.Text = "0.00";
            lb_TotalAmount.Text = "0.00";
            btn_Card.BorderThickness = 0;
            btn_Momo.BorderThickness = 0;
            btn_Zalo.BorderThickness = 0;
            btn_Cash.BorderThickness = 0;
            dtgv_items.Rows.Clear();
        }




        string imagePath = Directory.GetParent(Application.StartupPath).ToString();
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(imagePath + "\\assets_img\\" + "recycle-bin.png");
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(imagePath + "\\assets_img\\" + "bin.png");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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
    }
}
