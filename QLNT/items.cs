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
    public partial class items : UserControl
    {
        public event EventHandler onselect = null;
        public items()
        {
            InitializeComponent();
        }


        public int id { get; set; }
        public int price { get; set; }
        public string name
        {
            get { return lb_Name.Text; }
            set { lb_Name.Text = value; }
        }
        public string pic
        {
            get { return pic_Medicine.Text; }
            set { pic_Medicine.Text = value; }
        }

        private void pic_Medicine_Click(object sender, EventArgs e)
        {
            onselect?.Invoke(this, EventArgs.Empty);
        }
    }
}
