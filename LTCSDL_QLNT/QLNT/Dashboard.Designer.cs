namespace QLNT
{
    partial class Dashboard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            pictureBox1 = new PictureBox();
            lb_Staff = new Label();
            label1 = new Label();
            guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            pictureBox2 = new PictureBox();
            lb_BSeller = new Label();
            label4 = new Label();
            guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            pictureBox3 = new PictureBox();
            lb_Revenue = new Label();
            label6 = new Label();
            guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            pictureBox4 = new PictureBox();
            lb_Profit = new Label();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            guna2Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            guna2Panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // chart1
            // 
            chart1.BorderlineColor = Color.Black;
            chartArea2.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chart1.Legends.Add(legend2);
            chart1.Location = new Point(54, 420);
            chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chart1.Series.Add(series2);
            chart1.Size = new Size(611, 386);
            chart1.TabIndex = 0;
            chart1.Text = "chart1";
            chart1.Click += chart1_Click;
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.Transparent;
            guna2Panel1.BorderRadius = 40;
            guna2Panel1.Controls.Add(pictureBox1);
            guna2Panel1.Controls.Add(lb_Staff);
            guna2Panel1.Controls.Add(label1);
            guna2Panel1.CustomizableEdges = customizableEdges9;
            guna2Panel1.FillColor = Color.FromArgb(108, 137, 118);
            guna2Panel1.Location = new Point(36, 42);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges10;
            guna2Panel1.Size = new Size(367, 241);
            guna2Panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(18, 41);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(162, 162);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // lb_Staff
            // 
            lb_Staff.Font = new Font("Times New Roman", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_Staff.ForeColor = Color.FromArgb(230, 239, 230);
            lb_Staff.Location = new Point(186, 105);
            lb_Staff.Name = "lb_Staff";
            lb_Staff.Size = new Size(175, 98);
            lb_Staff.TabIndex = 0;
            lb_Staff.Text = "8";
            lb_Staff.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(230, 239, 230);
            label1.Location = new Point(186, 23);
            label1.Name = "label1";
            label1.Size = new Size(175, 68);
            label1.TabIndex = 0;
            label1.Text = "Staffs";
            // 
            // guna2Panel2
            // 
            guna2Panel2.BackColor = Color.Transparent;
            guna2Panel2.BorderRadius = 40;
            guna2Panel2.Controls.Add(label4);
            guna2Panel2.Controls.Add(pictureBox2);
            guna2Panel2.Controls.Add(lb_BSeller);
            guna2Panel2.CustomizableEdges = customizableEdges11;
            guna2Panel2.FillColor = Color.FromArgb(108, 137, 118);
            guna2Panel2.Location = new Point(418, 42);
            guna2Panel2.Name = "guna2Panel2";
            guna2Panel2.ShadowDecoration.CustomizableEdges = customizableEdges12;
            guna2Panel2.Size = new Size(367, 241);
            guna2Panel2.TabIndex = 1;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(14, 87);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(139, 151);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // lb_BSeller
            // 
            lb_BSeller.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_BSeller.ForeColor = Color.FromArgb(230, 239, 230);
            lb_BSeller.Location = new Point(164, 105);
            lb_BSeller.Name = "lb_BSeller";
            lb_BSeller.Size = new Size(175, 115);
            lb_BSeller.TabIndex = 0;
            lb_BSeller.Text = "dopamine";
            lb_BSeller.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(230, 239, 230);
            label4.Location = new Point(37, 23);
            label4.Name = "label4";
            label4.Size = new Size(302, 68);
            label4.TabIndex = 0;
            label4.Text = "Best Seller";
            // 
            // guna2Panel3
            // 
            guna2Panel3.BackColor = Color.Transparent;
            guna2Panel3.BorderRadius = 40;
            guna2Panel3.Controls.Add(label6);
            guna2Panel3.Controls.Add(pictureBox3);
            guna2Panel3.Controls.Add(lb_Revenue);
            guna2Panel3.CustomizableEdges = customizableEdges13;
            guna2Panel3.FillColor = Color.FromArgb(108, 137, 118);
            guna2Panel3.Location = new Point(800, 42);
            guna2Panel3.Name = "guna2Panel3";
            guna2Panel3.ShadowDecoration.CustomizableEdges = customizableEdges14;
            guna2Panel3.Size = new Size(367, 241);
            guna2Panel3.TabIndex = 1;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(18, 54);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(162, 149);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 1;
            pictureBox3.TabStop = false;
            // 
            // lb_Revenue
            // 
            lb_Revenue.Font = new Font("Times New Roman", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_Revenue.ForeColor = Color.FromArgb(230, 239, 230);
            lb_Revenue.Location = new Point(186, 105);
            lb_Revenue.Name = "lb_Revenue";
            lb_Revenue.Size = new Size(175, 98);
            lb_Revenue.TabIndex = 0;
            lb_Revenue.Text = "8";
            lb_Revenue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 34.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(230, 239, 230);
            label6.Location = new Point(132, 25);
            label6.Name = "label6";
            label6.Size = new Size(235, 65);
            label6.TabIndex = 0;
            label6.Text = "Revenue";
            // 
            // guna2Panel4
            // 
            guna2Panel4.BackColor = Color.Transparent;
            guna2Panel4.BorderRadius = 40;
            guna2Panel4.Controls.Add(pictureBox4);
            guna2Panel4.Controls.Add(lb_Profit);
            guna2Panel4.Controls.Add(label8);
            guna2Panel4.CustomizableEdges = customizableEdges15;
            guna2Panel4.FillColor = Color.FromArgb(108, 137, 118);
            guna2Panel4.Location = new Point(1182, 42);
            guna2Panel4.Name = "guna2Panel4";
            guna2Panel4.ShadowDecoration.CustomizableEdges = customizableEdges16;
            guna2Panel4.Size = new Size(367, 241);
            guna2Panel4.TabIndex = 1;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(18, 54);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(150, 149);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 1;
            pictureBox4.TabStop = false;
            // 
            // lb_Profit
            // 
            lb_Profit.Font = new Font("Times New Roman", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_Profit.ForeColor = Color.FromArgb(230, 239, 230);
            lb_Profit.Location = new Point(186, 105);
            lb_Profit.Name = "lb_Profit";
            lb_Profit.Size = new Size(175, 98);
            lb_Profit.TabIndex = 0;
            lb_Profit.Text = "8";
            lb_Profit.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Times New Roman", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(230, 239, 230);
            label8.Location = new Point(186, 23);
            label8.Name = "label8";
            label8.Size = new Size(178, 68);
            label8.TabIndex = 0;
            label8.Text = "Profit";
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(230, 239, 230);
            ClientSize = new Size(1582, 905);
            Controls.Add(guna2Panel4);
            Controls.Add(guna2Panel3);
            Controls.Add(guna2Panel2);
            Controls.Add(chart1);
            Controls.Add(guna2Panel1);
            ForeColor = SystemColors.ActiveBorder;
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            Name = "Dashboard";
            Padding = new Padding(8);
            Text = "Dashboard";
            Load += Dashboard_Load;
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            guna2Panel2.ResumeLayout(false);
            guna2Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            guna2Panel3.ResumeLayout(false);
            guna2Panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            guna2Panel4.ResumeLayout(false);
            guna2Panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private Label lb_Staff;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private PictureBox pictureBox2;
        private Label lb_BSeller;
        private Label label4;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private PictureBox pictureBox3;
        private Label lb_Revenue;
        private Label label6;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private PictureBox pictureBox4;
        private Label lb_Profit;
        private Label label8;
    }
}