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
    public partial class StaffOfTheMonthForm : Form
    {
        private SQLConnectionClass sqlConnection;
        public StaffOfTheMonthForm()
        {
            InitializeComponent();
            sqlConnection = new SQLConnectionClass();
            ShowTopEmployee();
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
                // Giải phóng bộ nhớ hình ảnh cũ nếu có
                if (guna2PictureBox2.Image != null)
                {
                    guna2PictureBox2.Image.Dispose();
                }

                // Tải hình ảnh mới
                guna2PictureBox2.Image = new Bitmap(ofd.FileName);

                // Đường dẫn lưu hình ảnh mới vào thư mục của ứng dụng
                string directoryPath = AppDomain.CurrentDomain.BaseDirectory + "assets_img";
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                string newPath = Path.Combine(directoryPath, Path.GetFileName(ofd.FileName));

                // Xóa tệp nếu nó đã tồn tại
                if (File.Exists(newPath))
                {
                    File.Delete(newPath);
                }

                try
                {
                    // Lưu hình ảnh dưới định dạng PNG
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
            string getName = string.Empty;

            using (var connection = new SqlConnection(sqlConnection.ConnectionString))
            {
                SqlCommand command = new SqlCommand("TakeEmployeeOfTheMonth", connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            getName = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }

            lb_NameLeft.Text = getName;
            lb_NameRight.Text = getName;
        }
    }
}
