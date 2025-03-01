namespace QLNT
{
    partial class EmployeeOfTheMonthForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeOfTheMonthForm));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label1 = new Label();
            guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            lb_NameRight = new Label();
            lb_NameLeft = new Label();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Britannic Bold", 72F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkKhaki;
            label1.Location = new Point(91, 691);
            label1.Name = "label1";
            label1.Size = new Size(1439, 133);
            label1.TabIndex = 4;
            label1.Text = "EMPLOYEE OF THE MONTH";
            // 
            // guna2PictureBox2
            // 
            guna2PictureBox2.BackColor = Color.Transparent;
            guna2PictureBox2.CustomizableEdges = customizableEdges1;
            guna2PictureBox2.FillColor = Color.Transparent;
            guna2PictureBox2.ImageRotate = 0F;
            guna2PictureBox2.Location = new Point(638, 288);
            guna2PictureBox2.Name = "guna2PictureBox2";
            guna2PictureBox2.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2PictureBox2.Size = new Size(340, 340);
            guna2PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            guna2PictureBox2.TabIndex = 3;
            guna2PictureBox2.TabStop = false;
            guna2PictureBox2.Click += guna2PictureBox2_Click;
            // 
            // guna2PictureBox1
            // 
            guna2PictureBox1.BackColor = Color.Transparent;
            guna2PictureBox1.CustomizableEdges = customizableEdges3;
            guna2PictureBox1.FillColor = Color.Transparent;
            guna2PictureBox1.Image = (Image)resources.GetObject("guna2PictureBox1.Image");
            guna2PictureBox1.ImageRotate = 0F;
            guna2PictureBox1.Location = new Point(294, 81);
            guna2PictureBox1.Name = "guna2PictureBox1";
            guna2PictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2PictureBox1.Size = new Size(1062, 282);
            guna2PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            guna2PictureBox1.TabIndex = 3;
            guna2PictureBox1.TabStop = false;
            // 
            // lb_NameRight
            // 
            lb_NameRight.Font = new Font("Britannic Bold", 55.2F);
            lb_NameRight.ForeColor = Color.FromArgb(64, 0, 0);
            lb_NameRight.Location = new Point(1077, 444);
            lb_NameRight.Name = "lb_NameRight";
            lb_NameRight.Size = new Size(491, 111);
            lb_NameRight.TabIndex = 4;
            lb_NameRight.Text = "Nameeee";
            lb_NameRight.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lb_NameLeft
            // 
            lb_NameLeft.Font = new Font("Britannic Bold", 55.2F);
            lb_NameLeft.ForeColor = Color.FromArgb(64, 0, 0);
            lb_NameLeft.Location = new Point(83, 444);
            lb_NameLeft.Name = "lb_NameLeft";
            lb_NameLeft.Size = new Size(463, 111);
            lb_NameLeft.TabIndex = 4;
            lb_NameLeft.Text = "Nameeee";
            lb_NameLeft.TextAlign = ContentAlignment.MiddleRight;
            // 
            // StaffOfTheMonthForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(230, 239, 230);
            ClientSize = new Size(1595, 858);
            Controls.Add(lb_NameLeft);
            Controls.Add(lb_NameRight);
            Controls.Add(label1);
            Controls.Add(guna2PictureBox2);
            Controls.Add(guna2PictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "StaffOfTheMonthForm";
            Text = "StaffOfTheMonthForm";
            Load += StaffOfTheMonthForm_Load;
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Label lb_NameRight;
        private Label lb_NameLeft;
    }
}