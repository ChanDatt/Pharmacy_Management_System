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
    public partial class Cash : Form
    {
        private string cash;
        private decimal grandTotal;

        public string getCash { get => cash; set => cash = value; }

        public Cash(decimal grandTotal)
        {
            InitializeComponent();
            this.grandTotal = grandTotal;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (grandTotal <= decimal.Parse(txb_Cash.Text))
            {
                if (new CashVerify(txb_Cash.Text, grandTotal).ShowDialog() == DialogResult.OK) {
                    this.Close();
                    this.DialogResult = DialogResult.OK;
                }
            }
            else
            {
                MessageBox.Show("Cash mush to greater than total");
                txb_Cash.Clear();
            }
        }

        private void txb_Cash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; 
            }
        }
    }
}
