using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace QLNT
{
    public partial class MedicineItem : UserControl
    {
        public event EventHandler<ItemClickedEventArgs> ItemClicked;

        public int MID { get; }
        public string MedicineName { get; }
        public decimal Price { get; }
        public int StockQuantity { get; } // Add stock quantity property

        public MedicineItem(int mid, string medicineName, decimal price, int stockQuantity)
        {
            MID = mid;
            MedicineName = medicineName;
            Price = price;
            StockQuantity = stockQuantity;

            this.Width = 310;

            InitializeLabels(MedicineName, Price, StockQuantity);

            // Set up click event
            this.Click += MedicineItem_Click;
            this.BackColor = Color.White;
        }

        private void MedicineItem_Click(object sender, EventArgs e)
        {
            ItemClicked?.Invoke(this, new ItemClickedEventArgs(MID, MedicineName, Price, StockQuantity));
        }



        private void InitializeLabels(string medicineName, decimal price, int stock)
        {
            // Medicine Name Label
            Label nameLabel = new Label
            {
                Text = medicineName,
                Font = new Font("Arial", 14, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(10, 10),
            };

            // Price Label
            Label priceLabel = new Label
            {
                Text = $"${price:F2}", // Format price to two decimal places
                Font = new Font("Arial", 12, FontStyle.Regular),
                AutoSize = true,
                Location = new Point(10, 40)
            };

            // Stock Label
            Label stockLabel = new Label
            {
                Text = $"Stock: {stock}",
                Font = new Font("Arial", 12, FontStyle.Regular),
                AutoSize = true,
                Location = new Point(10, 70) // Positioning adjusted for stock
            };

            // Add labels to the control
            this.Controls.Add(nameLabel);
            this.Controls.Add(priceLabel);
            this.Controls.Add(stockLabel);
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            // Fill the background with white
            g.FillRectangle(new SolidBrush(this.BackColor), this.ClientRectangle);

            // Create a graphics path for rounded rectangle
            int borderRadius = 20; // Adjust for roundness
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, borderRadius, borderRadius, 180, 90);
            path.AddArc(this.Width - borderRadius, 0, borderRadius, borderRadius, 270, 90);
            path.AddArc(this.Width - borderRadius, this.Height - borderRadius, borderRadius, borderRadius, 0, 90);
            path.AddArc(0, this.Height - borderRadius, borderRadius, borderRadius, 90, 90);
            path.CloseAllFigures();

            // Set the region to the rounded rectangle
            this.Region = new Region(path);

            // Draw the border (optional)
            g.DrawPath(new Pen(Color.Gray, 2), path);
        }

        private void MedicineItem_Load(object sender, EventArgs e)
        {

        }
    }
    public class ItemClickedEventArgs : EventArgs
{
            public int MID { get; }
            public string MedicineName { get; }
            public decimal Price { get; }
            public int StockQuantity { get; }

            public ItemClickedEventArgs(int mid, string medicineName, decimal price, int stockQuantity)
            {
                MID = mid;
                MedicineName = medicineName;
                Price = price;
                StockQuantity = stockQuantity;
            }
        }
}