using BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNT
{
    public partial class EmployeeOfTheMonthForm : Form
    {
        public EmployeeOfTheMonthForm()
        {
            InitializeComponent();
            ShowTopEmployee();
        }
        private void StaffOfTheMonthForm_Load(object sender, EventArgs e)
        {
            string directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets_img");
            string imagePath = Path.Combine(directoryPath, "profile_image.png");

            if (File.Exists(imagePath))
            {
                // Load the saved image
                guna2PictureBox2.Image = new Bitmap(imagePath);
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images (.jpg, .png)|*.png;*.jpg";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Dispose of the old image to free up memory
                if (guna2PictureBox2.Image != null)
                {
                    guna2PictureBox2.Image.Dispose();
                    guna2PictureBox2.Image = null; // Release the reference
                }

                // Load the new image
                guna2PictureBox2.Image = new Bitmap(ofd.FileName);

                // Define the directory path to save the new image
                string directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets_img");
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                string newPath = Path.Combine(directoryPath, "profile_image.png"); // Fixed name for profile image

                // Delete the file if it already exists
                if (File.Exists(newPath))
                {
                    File.Delete(newPath);
                }

                try
                {
                    // Save the image in PNG format
                    guna2PictureBox2.Image.Save(newPath, System.Drawing.Imaging.ImageFormat.Png);
                    MessageBox.Show("Image saved successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving image: " + ex.Message);
                }
            }
        }

        private void ShowTopEmployee()
        {
            try
            {
                string getEmployee = new StaffsBL().showStaffOfTheMonth();
                lb_NameLeft.Text = getEmployee;
                lb_NameRight.Text = getEmployee;
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }


        }
    }
}
