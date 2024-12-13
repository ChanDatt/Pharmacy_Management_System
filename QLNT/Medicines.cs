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
    public partial class Medicines : Form
    {
        public Medicines()
        {
            InitializeComponent();
        }

        private void btn_AddMedicine_Click(object sender, EventArgs e)
        {
            Medicine_Add medicine_Add = new Medicine_Add();
            medicine_Add.ShowDialog();
        }

        private void btn_UpdateMedicine_Click(object sender, EventArgs e)
        {
            Medicines_Update medicines_Update = new Medicines_Update();
            medicines_Update.ShowDialog();
        }

        private void dtgv_Medicines_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
