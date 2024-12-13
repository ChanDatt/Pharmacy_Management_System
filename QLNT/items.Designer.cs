namespace QLNT
{
    partial class items
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(items));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lb_Price = new Label();
            lb_Name = new Label();
            pic_Medicine = new Guna.UI2.WinForms.Guna2PictureBox();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            ((System.ComponentModel.ISupportInitialize)pic_Medicine).BeginInit();
            guna2Panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lb_Price
            // 
            lb_Price.AutoSize = true;
            lb_Price.BackColor = Color.White;
            lb_Price.Font = new Font("Britannic Bold", 16.2F, FontStyle.Bold);
            lb_Price.ForeColor = Color.FromArgb(89, 104, 105);
            lb_Price.Location = new Point(216, 28);
            lb_Price.Name = "lb_Price";
            lb_Price.Size = new Size(68, 31);
            lb_Price.TabIndex = 3;
            lb_Price.Text = "$20";
            // 
            // lb_Name
            // 
            lb_Name.AutoSize = true;
            lb_Name.BackColor = Color.White;
            lb_Name.Font = new Font("Britannic Bold", 16.2F, FontStyle.Bold);
            lb_Name.ForeColor = Color.FromArgb(89, 104, 105);
            lb_Name.Location = new Point(13, 155);
            lb_Name.Name = "lb_Name";
            lb_Name.Size = new Size(213, 31);
            lb_Name.TabIndex = 4;
            lb_Name.Text = "Medicine name";
            // 
            // pic_Medicine
            // 
            pic_Medicine.BackColor = Color.White;
            pic_Medicine.BorderRadius = 20;
            pic_Medicine.CustomizableEdges = customizableEdges1;
            pic_Medicine.Image = (Image)resources.GetObject("pic_Medicine.Image");
            pic_Medicine.ImageRotate = 0F;
            pic_Medicine.Location = new Point(13, 19);
            pic_Medicine.Name = "pic_Medicine";
            pic_Medicine.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pic_Medicine.Size = new Size(197, 133);
            pic_Medicine.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_Medicine.TabIndex = 2;
            pic_Medicine.TabStop = false;
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.Transparent;
            guna2Panel1.BorderRadius = 25;
            guna2Panel1.Controls.Add(lb_Name);
            guna2Panel1.Controls.Add(pic_Medicine);
            guna2Panel1.Controls.Add(lb_Price);
            guna2Panel1.CustomizableEdges = customizableEdges3;
            guna2Panel1.FillColor = Color.White;
            guna2Panel1.ForeColor = Color.White;
            guna2Panel1.Location = new Point(0, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Panel1.Size = new Size(287, 203);
            guna2Panel1.TabIndex = 5;
            // 
            // items
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoSize = true;
            BackColor = Color.Transparent;
            BackgroundImageLayout = ImageLayout.None;
            Controls.Add(guna2Panel1);
            Name = "items";
            Size = new Size(290, 206);
            ((System.ComponentModel.ISupportInitialize)pic_Medicine).EndInit();
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lb_Price;
        private Label lb_Name;
        private Guna.UI2.WinForms.Guna2PictureBox pic_Medicine;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
    }
}
