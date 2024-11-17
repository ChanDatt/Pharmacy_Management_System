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
    public partial class Categories : Form
    {
        public Categories()
        {
            InitializeComponent();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txb_Search_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_AddCategory_Click(object sender, EventArgs e)
        {
            Categories_Add addCategory = new Categories_Add();
            addCategory.ShowDialog();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Categories_Update updateCategory = new Categories_Update();
            updateCategory.ShowDialog();
        }
    }
}
