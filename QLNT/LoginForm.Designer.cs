namespace QLNT

{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            pB_logo = new PictureBox();
            lb_ShortChau = new Label();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            txb_Pass = new TextBox();
            txb_Blind = new TextBox();
            btn_Login = new Button();
            pictureBox3 = new PictureBox();
            txb_User = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pB_logo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pB_logo
            // 
            pB_logo.BackColor = Color.WhiteSmoke;
            pB_logo.ErrorImage = null;
            pB_logo.Image = (Image)resources.GetObject("pB_logo.Image");
            pB_logo.Location = new Point(509, 11);
            pB_logo.Name = "pB_logo";
            pB_logo.Size = new Size(280, 280);
            pB_logo.SizeMode = PictureBoxSizeMode.StretchImage;
            pB_logo.TabIndex = 2;
            pB_logo.TabStop = false;
            // 
            // lb_ShortChau
            // 
            lb_ShortChau.AutoSize = true;
            lb_ShortChau.BackColor = Color.Transparent;
            lb_ShortChau.Font = new Font("Britannic Bold", 49.8000031F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lb_ShortChau.Location = new Point(403, 296);
            lb_ShortChau.Name = "lb_ShortChau";
            lb_ShortChau.Size = new Size(519, 93);
            lb_ShortChau.TabIndex = 1;
            lb_ShortChau.Text = "SHORT CHAU";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.WhiteSmoke;
            pictureBox2.ErrorImage = null;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(459, 420);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(55, 51);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.WhiteSmoke;
            pictureBox1.ErrorImage = null;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(459, 505);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(55, 51);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // txb_Pass
            // 
            txb_Pass.BackColor = Color.FromArgb(108, 137, 118);
            txb_Pass.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            txb_Pass.Location = new Point(520, 519);
            txb_Pass.Multiline = true;
            txb_Pass.Name = "txb_Pass";
            txb_Pass.Size = new Size(322, 37);
            txb_Pass.TabIndex = 3;
            txb_Pass.Enter += txb_Pass_Enter;
            txb_Pass.Leave += txb_Pass_Leave;
            // 
            // txb_Blind
            // 
            txb_Blind.Location = new Point(737, 203);
            txb_Blind.Name = "txb_Blind";
            txb_Blind.Size = new Size(10, 27);
            txb_Blind.TabIndex = 0;
            // 
            // btn_Login
            // 
            btn_Login.BackColor = Color.FromArgb(89, 104, 105);
            btn_Login.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Login.ForeColor = Color.FromArgb(230, 239, 230);
            btn_Login.Location = new Point(541, 614);
            btn_Login.Name = "btn_Login";
            btn_Login.Size = new Size(219, 48);
            btn_Login.TabIndex = 4;
            btn_Login.Text = "Login";
            btn_Login.UseVisualStyleBackColor = false;
            btn_Login.Click += btn_Login_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.ErrorImage = null;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(1028, 52);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(51, 48);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            // 
            // txb_User
            // 
            txb_User.BackColor = Color.FromArgb(108, 137, 118);
            txb_User.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            txb_User.Location = new Point(520, 434);
            txb_User.Multiline = true;
            txb_User.Name = "txb_User";
            txb_User.Size = new Size(322, 37);
            txb_User.TabIndex = 3;
            txb_User.Enter += txb_User_Enter;
            txb_User.Leave += txb_User_Leave;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.Black;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1300, 700);
            Controls.Add(pictureBox3);
            Controls.Add(pB_logo);
            Controls.Add(btn_Login);
            Controls.Add(txb_User);
            Controls.Add(txb_Pass);
            Controls.Add(lb_ShortChau);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox2);
            Controls.Add(txb_Blind);
            DoubleBuffered = true;
            ForeColor = Color.FromArgb(89, 104, 105);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += Login_Load;
            ((System.ComponentModel.ISupportInitialize)pB_logo).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pB_logo;
        private Label lb_ShortChau;
        private Panel pnl_User;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Panel pnl_Password;
        private TextBox txb_Pass;
        private Button btn_Blind;
        private TextBox txb_Blind;
        private Button btn_Login;
        private PictureBox pictureBox3;
        private TextBox txb_User;
    }
}
