using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNT
{
    public partial class CashVerify : Form
    {
        private decimal cash;
        private decimal grandTotal;
        public CashVerify(string cash, decimal grandTotal)
        {
            InitializeComponent();
            this.cash = decimal.Parse(cash);
            this.grandTotal = grandTotal;
        }

        private void CashVerify_Load(object sender, EventArgs e)
        {
            lb_GrandTotal.Text = Math.Round(grandTotal, 2).ToString("C");
            lb_Cash.Text = Math.Round(cash, 2).ToString("C");
            lb_Change.Text = (cash - grandTotal).ToString("C");
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
