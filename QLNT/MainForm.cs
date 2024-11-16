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

        //phương thức biểu các mục lên CenterPanel
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
            ShowTab(new Categories());
        }

    }
}
