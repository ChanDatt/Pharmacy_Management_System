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
    public partial class Inventories_SetWarning : Form
    {
        public Inventories_SetWarning()
        {
            InitializeComponent();
        }


        private void btn_CancelAddCategory_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
