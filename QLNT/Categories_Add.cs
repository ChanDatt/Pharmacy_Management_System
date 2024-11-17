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
    public partial class Categories_Add : Form
    {
        public Categories_Add()
        {
            InitializeComponent();
        }

        private void txb_Search_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_CancelAddCategory_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lb_Header_Click(object sender, EventArgs e)
        {

        }
    }
}
