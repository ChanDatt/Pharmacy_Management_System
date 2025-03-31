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
    public partial class LoadingBar : Form
    {
        public LoadingBar()
        {
            InitializeComponent();
        }

        public void UpdateProgress(int progress)
        {
            ProgressBar.Value = progress;
        }
    }
}
