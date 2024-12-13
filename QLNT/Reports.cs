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
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void Reports_Load(object sender, EventArgs e)
        {

        }

        private void btn_ReportPredict_Click(object sender, EventArgs e)
        {
            Reports_Predict reportPredict = new Reports_Predict();
            reportPredict.ShowDialog();
        }
    }
}
