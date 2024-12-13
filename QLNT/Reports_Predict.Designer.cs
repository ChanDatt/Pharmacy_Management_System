namespace QLNT
{
    partial class Reports_Predict
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            lb_Categories = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            textBox1 = new TextBox();
            btn_BrowseMedicine = new Guna.UI2.WinForms.Guna2Button();
            dtgv_Medicines = new Guna.UI2.WinForms.Guna2DataGridView();
            dtgv_id = new DataGridViewTextBoxColumn();
            dtgv_CatergoryName = new DataGridViewTextBoxColumn();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2Panel1.SuspendLayout();
            guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgv_Medicines).BeginInit();
            SuspendLayout();
            // 
            // lb_Categories
            // 
            lb_Categories.BackColor = Color.Transparent;
            lb_Categories.Font = new Font("Britannic Bold", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lb_Categories.ForeColor = Color.FromArgb(230, 239, 230);
            lb_Categories.Location = new Point(29, 22);
            lb_Categories.Name = "lb_Categories";
            lb_Categories.Size = new Size(255, 91);
            lb_Categories.TabIndex = 7;
            lb_Categories.Text = "Predict";
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.FromArgb(89, 104, 105);
            guna2Panel1.BorderColor = Color.FromArgb(89, 104, 105);
            guna2Panel1.BorderThickness = 5;
            guna2Panel1.Controls.Add(lb_Categories);
            guna2Panel1.CustomizableEdges = customizableEdges1;
            guna2Panel1.Location = new Point(-1, -1);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Panel1.Size = new Size(565, 130);
            guna2Panel1.TabIndex = 9;
            // 
            // guna2Panel2
            // 
            guna2Panel2.BackColor = Color.FromArgb(230, 239, 230);
            guna2Panel2.BorderColor = Color.FromArgb(89, 104, 105);
            guna2Panel2.BorderThickness = 5;
            guna2Panel2.Controls.Add(textBox1);
            guna2Panel2.Controls.Add(btn_BrowseMedicine);
            guna2Panel2.Controls.Add(dtgv_Medicines);
            guna2Panel2.Controls.Add(guna2HtmlLabel2);
            guna2Panel2.Controls.Add(guna2HtmlLabel1);
            guna2Panel2.CustomizableEdges = customizableEdges5;
            guna2Panel2.Location = new Point(-1, 118);
            guna2Panel2.Name = "guna2Panel2";
            guna2Panel2.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2Panel2.Size = new Size(565, 594);
            guna2Panel2.TabIndex = 9;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(86, 345);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(392, 110);
            textBox1.TabIndex = 17;
            textBox1.Text = "Phân tích dữ liệu bán hàng để phát hiện các đợt bùng phát bệnh (như cúm mùa, sốt xuất huyết) và cảnh báo cho cộng đồng";
            // 
            // btn_BrowseMedicine
            // 
            btn_BrowseMedicine.BorderRadius = 25;
            btn_BrowseMedicine.CustomizableEdges = customizableEdges3;
            btn_BrowseMedicine.DisabledState.BorderColor = Color.DarkGray;
            btn_BrowseMedicine.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_BrowseMedicine.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_BrowseMedicine.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_BrowseMedicine.FillColor = Color.FromArgb(89, 104, 105);
            btn_BrowseMedicine.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_BrowseMedicine.ForeColor = Color.White;
            btn_BrowseMedicine.Location = new Point(311, 489);
            btn_BrowseMedicine.Name = "btn_BrowseMedicine";
            btn_BrowseMedicine.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btn_BrowseMedicine.Size = new Size(167, 57);
            btn_BrowseMedicine.TabIndex = 16;
            btn_BrowseMedicine.Text = "OK";
            btn_BrowseMedicine.Click += btn_BrowseMedicine_Click;
            // 
            // dtgv_Medicines
            // 
            dtgv_Medicines.AllowUserToAddRows = false;
            dtgv_Medicines.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dtgv_Medicines.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dtgv_Medicines.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtgv_Medicines.BackgroundColor = Color.WhiteSmoke;
            dtgv_Medicines.BorderStyle = BorderStyle.Fixed3D;
            dtgv_Medicines.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(89, 104, 105);
            dataGridViewCellStyle2.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dtgv_Medicines.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dtgv_Medicines.ColumnHeadersHeight = 35;
            dtgv_Medicines.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dtgv_Medicines.Columns.AddRange(new DataGridViewColumn[] { dtgv_id, dtgv_CatergoryName });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.Cyan;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dtgv_Medicines.DefaultCellStyle = dataGridViewCellStyle3;
            dtgv_Medicines.GridColor = Color.Silver;
            dtgv_Medicines.Location = new Point(86, 95);
            dtgv_Medicines.Name = "dtgv_Medicines";
            dtgv_Medicines.ReadOnly = true;
            dtgv_Medicines.RowHeadersVisible = false;
            dtgv_Medicines.RowHeadersWidth = 51;
            dtgv_Medicines.Size = new Size(392, 149);
            dtgv_Medicines.TabIndex = 15;
            dtgv_Medicines.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dtgv_Medicines.ThemeStyle.AlternatingRowsStyle.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtgv_Medicines.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dtgv_Medicines.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dtgv_Medicines.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dtgv_Medicines.ThemeStyle.BackColor = Color.WhiteSmoke;
            dtgv_Medicines.ThemeStyle.GridColor = Color.Silver;
            dtgv_Medicines.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(89, 104, 105);
            dtgv_Medicines.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dtgv_Medicines.ThemeStyle.HeaderStyle.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dtgv_Medicines.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dtgv_Medicines.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dtgv_Medicines.ThemeStyle.HeaderStyle.Height = 35;
            dtgv_Medicines.ThemeStyle.ReadOnly = true;
            dtgv_Medicines.ThemeStyle.RowsStyle.BackColor = Color.White;
            dtgv_Medicines.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            dtgv_Medicines.ThemeStyle.RowsStyle.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtgv_Medicines.ThemeStyle.RowsStyle.ForeColor = Color.Cyan;
            dtgv_Medicines.ThemeStyle.RowsStyle.Height = 29;
            dtgv_Medicines.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dtgv_Medicines.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // dtgv_id
            // 
            dtgv_id.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dtgv_id.FillWeight = 6.41711235F;
            dtgv_id.HeaderText = "id";
            dtgv_id.MinimumWidth = 35;
            dtgv_id.Name = "dtgv_id";
            dtgv_id.ReadOnly = true;
            dtgv_id.Width = 35;
            // 
            // dtgv_CatergoryName
            // 
            dtgv_CatergoryName.FillWeight = 193.582886F;
            dtgv_CatergoryName.HeaderText = "Catergory name";
            dtgv_CatergoryName.MinimumWidth = 6;
            dtgv_CatergoryName.Name = "dtgv_CatergoryName";
            dtgv_CatergoryName.ReadOnly = true;
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Britannic Bold", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2HtmlLabel2.ForeColor = Color.FromArgb(64, 0, 0);
            guna2HtmlLabel2.Location = new Point(86, 296);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(153, 43);
            guna2HtmlLabel2.TabIndex = 13;
            guna2HtmlLabel2.Text = "Conclude";
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Britannic Bold", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.ForeColor = Color.FromArgb(89, 104, 105);
            guna2HtmlLabel1.Location = new Point(86, 46);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(392, 43);
            guna2HtmlLabel1.TabIndex = 14;
            guna2HtmlLabel1.Text = "Top 3 best selling items";
            // 
            // Reports_Predict
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(230, 239, 230);
            ClientSize = new Size(562, 711);
            Controls.Add(guna2Panel2);
            Controls.Add(guna2Panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Reports_Predict";
            StartPosition = FormStartPosition.CenterScreen;
            guna2Panel1.ResumeLayout(false);
            guna2Panel1.PerformLayout();
            guna2Panel2.ResumeLayout(false);
            guna2Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgv_Medicines).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lb_Categories;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private TextBox textBox1;
        private Guna.UI2.WinForms.Guna2Button btn_BrowseMedicine;
        private Guna.UI2.WinForms.Guna2DataGridView dtgv_Medicines;
        private DataGridViewTextBoxColumn dtgv_id;
        private DataGridViewTextBoxColumn dtgv_CatergoryName;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
    }
}