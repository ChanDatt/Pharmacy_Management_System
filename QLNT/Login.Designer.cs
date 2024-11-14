namespace QLNT

{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            pB_logo = new PictureBox();
            lb_ShortChau = new Label();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            txb_User = new TextBox();
            txb_Pass = new TextBox();
            txb_Blind = new TextBox();
            btn_Login = new Button();
            lb_fgpw = new Label();
            ((System.ComponentModel.ISupportInitialize)pB_logo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
            pictureBox2.Location = new Point(433, 409);
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
            pictureBox1.Location = new Point(433, 512);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(55, 51);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // txb_User
            // 
            txb_User.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            txb_User.Location = new Point(494, 423);
            txb_User.Multiline = true;
            txb_User.Name = "txb_User";
            txb_User.Size = new Size(385, 37);
            txb_User.TabIndex = 2;
            txb_User.Enter += txb_User_Enter;
            txb_User.Leave += txb_User_Leave;
            // 
            // txb_Pass
            // 
            txb_Pass.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            txb_Pass.Location = new Point(494, 526);
            txb_Pass.Multiline = true;
            txb_Pass.Name = "txb_Pass";
            txb_Pass.Size = new Size(385, 37);
            txb_Pass.TabIndex = 3;
            txb_Pass.Enter += txb_Pass_Enter;
            txb_Pass.Leave += txb_Pass_Leave;
            // 
            // txb_Blind
            // 
            txb_Blind.Location = new Point(810, 253);
            txb_Blind.Name = "txb_Blind";
            txb_Blind.Size = new Size(10, 27);
            txb_Blind.TabIndex = 0;
            // 
            // btn_Login
            // 
            btn_Login.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Login.Location = new Point(709, 629);
            btn_Login.Name = "btn_Login";
            btn_Login.Size = new Size(167, 43);
            btn_Login.TabIndex = 4;
            btn_Login.Text = "Login";
            btn_Login.UseVisualStyleBackColor = true;
            // 
            // lb_fgpw
            // 
            lb_fgpw.AutoSize = true;
            lb_fgpw.BackColor = Color.Transparent;
            lb_fgpw.Font = new Font("Times New Roman", 12F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            lb_fgpw.ForeColor = Color.Transparent;
            lb_fgpw.Location = new Point(716, 566);
            lb_fgpw.Name = "lb_fgpw";
            lb_fgpw.Size = new Size(160, 23);
            lb_fgpw.TabIndex = 5;
            lb_fgpw.Text = "Forgot password?";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.Black;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1300, 700);
            Controls.Add(lb_fgpw);
            Controls.Add(btn_Login);
            Controls.Add(txb_Pass);
            Controls.Add(txb_User);
            Controls.Add(lb_ShortChau);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox2);
            Controls.Add(pB_logo);
            Controls.Add(txb_Blind);
            DoubleBuffered = true;
            ForeColor = SystemColors.ActiveCaptionText;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += Login_Load;
            ((System.ComponentModel.ISupportInitialize)pB_logo).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private TextBox txb_User;
        private TextBox txb_Pass;
        private Button btn_Blind;
        private TextBox txb_Blind;
        private Button btn_Login;
        private Label lb_fgpw;
    }
}
