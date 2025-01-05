using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNT
{
    public partial class Verify : Form
    {
        private string paymentmethod;
        private decimal grandTotal;
        private decimal cash;
        string imagePath = Directory.GetParent(Application.StartupPath).ToString();
        public Verify(string paymentmethod, decimal grandTotal)
        {
            InitializeComponent();
            this.paymentmethod = paymentmethod;
            this.grandTotal = grandTotal;
            imagePaymentMethod();
        }

        private void Verify_Load(object sender, EventArgs e)
        {
           
        }

        private void imagePaymentMethod()
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            if (paymentmethod == "CreditCard")
            {
                try
                {
                    Image imageQR = Image.FromFile(imagePath + "\\assets_img\\" + "CreditCard.jpg");
                    pictureBox1.Image = imageQR;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to load image: " + ex.Message);
                }

            }
            else if (paymentmethod == "Momo")
            {
                try
                {
                    Image imageQR = Image.FromFile(imagePath + "\\assets_img\\" + "Momo.jpg");
                    pictureBox1.Image = imageQR;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to load image" + ex.Message);
                }
            }
            else if(paymentmethod == "ZaloPay")
            {
                try
                {
                    Image imageQR = Image.FromFile(imagePath + "\\assets_img\\" + "ZaloPay.jpg");
                    pictureBox1.Image = imageQR;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to load image" + ex.Message);
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
