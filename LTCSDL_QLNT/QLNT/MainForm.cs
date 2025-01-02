using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace QLNT
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        //phương thức biểu di các mục lên CenterPanel
        public void ShowTab(Form f)
        {
            CenterPanel.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            CenterPanel.Controls.Add(f);
            f.Show();
        }
        private void btn_Dashboard_Click(object sender, EventArgs e)
        {
            ShowTab(new Dashboard());
        }

        private void btn_Categories_Click(object sender, EventArgs e)
        {
            ShowTab(new Receipts());
        }

        private void btn_Medicines_Click(object sender, EventArgs e)
        {

        }

        private void btn_Staffs_Click(object sender, EventArgs e)
        {
            ShowTab(new Staffs());
        }

        private void btn_Customers_Click(object sender, EventArgs e)
        {
            ShowTab(new Customers());
        }

        private void btn_Reports_Click(object sender, EventArgs e)
        {

            ShowTab(new Reports());
        }

        private void btn_Inventories_Click(object sender, EventArgs e)
        {
            ShowTab(new Inventories());
        }

        private void btn_POS_Click(object sender, EventArgs e)
        {
            POS pos = new POS(lb_Name.Text);
            pos.ShowDialog();
        }

        private void btn_Suppliers_Click(object sender, EventArgs e)
        {
            ShowTab(new Suppliers());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm lg = new LoginForm();
            DialogResult = lg.ShowDialog();
            if (DialogResult == DialogResult.OK)
            {
                lb_Name.Text = lg.CurrentName;
                this.Show();

                // Extract the role from the CurrentName
                string[] nameParts = lg.CurrentName.Split('.');
                if (nameParts.Length > 1 && nameParts[1] == "staff") // Check if the second part is "staff"
                {
                    btn_Staffs.Visible = false; // Hide the Staffs button
                    btn_Dashboard.Visible = false;                         // You can hide other buttons as needed
                    btn_Inventories.Visible = false; // Example: hide Inventories button
                    btn_Reports.Visible = false; // Example: hide Reports button
                }
            }
            ShowTab(new StaffOfTheMonthForm());
        }

        private void btn_Receipts_Click(object sender, EventArgs e)
        {
            ShowTab(new Receipts());
        }

        private void CenterPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CenterPanel_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
