namespace QLNT
{
    partial class Receipts
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lb_Search = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btn_Export = new Guna.UI2.WinForms.Guna2Button();
            btn_Update = new Guna.UI2.WinForms.Guna2Button();
            lb_Categories = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            dtgv_receiptinfos = new Guna.UI2.WinForms.Guna2DataGridView();
            dtp_Date = new Guna.UI2.WinForms.Guna2DateTimePicker();
            guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgv_receiptinfos).BeginInit();
            SuspendLayout();
            // 
            // lb_Search
            // 
            lb_Search.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lb_Search.BackColor = Color.Transparent;
            lb_Search.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_Search.ForeColor = Color.FromArgb(89, 104, 105);
            lb_Search.Location = new Point(1065, 142);
            lb_Search.Name = "lb_Search";
            lb_Search.Size = new Size(82, 39);
            lb_Search.TabIndex = 2;
            lb_Search.Text = "Filter";
            // 
            // btn_Export
            // 
            btn_Export.BorderRadius = 25;
            btn_Export.CustomizableEdges = customizableEdges1;
            btn_Export.DisabledState.BorderColor = Color.DarkGray;
            btn_Export.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_Export.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_Export.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_Export.FillColor = Color.FromArgb(64, 0, 0);
            btn_Export.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Export.ForeColor = Color.White;
            btn_Export.Location = new Point(86, 187);
            btn_Export.Name = "btn_Export";
            btn_Export.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btn_Export.Size = new Size(278, 57);
            btn_Export.TabIndex = 3;
            btn_Export.Text = "Export";
            btn_Export.Click += btn_Export_Click;
            // 
            // btn_Update
            // 
            btn_Update.Anchor = AnchorStyles.Top;
            btn_Update.BorderRadius = 25;
            btn_Update.CustomizableEdges = customizableEdges3;
            btn_Update.DisabledState.BorderColor = Color.DarkGray;
            btn_Update.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_Update.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_Update.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_Update.FillColor = Color.FromArgb(64, 0, 0);
            btn_Update.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Update.ForeColor = Color.White;
            btn_Update.Location = new Point(579, 187);
            btn_Update.Name = "btn_Update";
            btn_Update.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btn_Update.Size = new Size(310, 57);
            btn_Update.TabIndex = 3;
            btn_Update.Text = "Delete";
            btn_Update.Click += guna2Button1_Click;
            // 
            // lb_Categories
            // 
            lb_Categories.BackColor = Color.Transparent;
            lb_Categories.Font = new Font("Britannic Bold", 55.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lb_Categories.ForeColor = Color.FromArgb(89, 104, 105);
            lb_Categories.Location = new Point(51, 38);
            lb_Categories.Name = "lb_Categories";
            lb_Categories.Size = new Size(395, 103);
            lb_Categories.TabIndex = 2;
            lb_Categories.Text = "RECEIPTS";
            // 
            // guna2Panel1
            // 
            guna2Panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            guna2Panel1.BackColor = Color.FromArgb(89, 104, 105);
            guna2Panel1.Controls.Add(dtgv_receiptinfos);
            guna2Panel1.CustomizableEdges = customizableEdges5;
            guna2Panel1.Location = new Point(39, 269);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            guna2Panel1.Size = new Size(1387, 607);
            guna2Panel1.TabIndex = 4;
            // 
            // dtgv_receiptinfos
            // 
            dtgv_receiptinfos.AllowUserToAddRows = false;
            dtgv_receiptinfos.AllowUserToDeleteRows = false;
            dtgv_receiptinfos.AllowUserToResizeColumns = false;
            dtgv_receiptinfos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(230, 239, 230);
            dataGridViewCellStyle1.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(89, 104, 105);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(192, 255, 192);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(89, 104, 105);
            dtgv_receiptinfos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dtgv_receiptinfos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtgv_receiptinfos.BackgroundColor = Color.LightGray;
            dtgv_receiptinfos.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(89, 104, 105);
            dataGridViewCellStyle2.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(108, 137, 118);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dtgv_receiptinfos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dtgv_receiptinfos.ColumnHeadersHeight = 35;
            dtgv_receiptinfos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(230, 239, 230);
            dataGridViewCellStyle3.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(89, 104, 105);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(171, 209, 181);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(89, 104, 105);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dtgv_receiptinfos.DefaultCellStyle = dataGridViewCellStyle3;
            dtgv_receiptinfos.GridColor = Color.Silver;
            dtgv_receiptinfos.Location = new Point(11, 5);
            dtgv_receiptinfos.Name = "dtgv_receiptinfos";
            dtgv_receiptinfos.ReadOnly = true;
            dtgv_receiptinfos.RowHeadersVisible = false;
            dtgv_receiptinfos.RowHeadersWidth = 51;
            dtgv_receiptinfos.Size = new Size(1365, 591);
            dtgv_receiptinfos.TabIndex = 20;
            dtgv_receiptinfos.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dtgv_receiptinfos.ThemeStyle.AlternatingRowsStyle.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtgv_receiptinfos.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dtgv_receiptinfos.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dtgv_receiptinfos.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dtgv_receiptinfos.ThemeStyle.BackColor = Color.LightGray;
            dtgv_receiptinfos.ThemeStyle.GridColor = Color.Silver;
            dtgv_receiptinfos.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(89, 104, 105);
            dtgv_receiptinfos.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dtgv_receiptinfos.ThemeStyle.HeaderStyle.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dtgv_receiptinfos.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dtgv_receiptinfos.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dtgv_receiptinfos.ThemeStyle.HeaderStyle.Height = 35;
            dtgv_receiptinfos.ThemeStyle.ReadOnly = true;
            dtgv_receiptinfos.ThemeStyle.RowsStyle.BackColor = Color.White;
            dtgv_receiptinfos.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            dtgv_receiptinfos.ThemeStyle.RowsStyle.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtgv_receiptinfos.ThemeStyle.RowsStyle.ForeColor = Color.Cyan;
            dtgv_receiptinfos.ThemeStyle.RowsStyle.Height = 29;
            dtgv_receiptinfos.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dtgv_receiptinfos.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dtgv_receiptinfos.CellClick += dtgv_Reports_CellClick;
            dtgv_receiptinfos.CellContentClick += dtgv_Receipts_CellContentClick;
            dtgv_receiptinfos.CellDoubleClick += dtgv_Receipts_CellDoubleClick;
            // 
            // dtp_Date
            // 
            dtp_Date.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtp_Date.BackColor = Color.Transparent;
            dtp_Date.BorderRadius = 25;
            dtp_Date.Checked = true;
            dtp_Date.CustomizableEdges = customizableEdges7;
            dtp_Date.FillColor = Color.FromArgb(230, 239, 230);
            dtp_Date.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dtp_Date.ForeColor = Color.Black;
            dtp_Date.Format = DateTimePickerFormat.Short;
            dtp_Date.Location = new Point(1049, 187);
            dtp_Date.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtp_Date.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtp_Date.Name = "dtp_Date";
            dtp_Date.ShadowDecoration.CustomizableEdges = customizableEdges8;
            dtp_Date.Size = new Size(310, 57);
            dtp_Date.TabIndex = 11;
            dtp_Date.TextAlign = HorizontalAlignment.Center;
            dtp_Date.Value = new DateTime(2024, 11, 19, 14, 58, 16, 433);
            dtp_Date.CheckedChanged += dtp_Date_CheckedChanged;
            dtp_Date.ValueChanged += dtp_Date_ValueChanged;
            // 
            // Receipts
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(230, 239, 230);
            ClientSize = new Size(1465, 905);
            Controls.Add(dtp_Date);
            Controls.Add(guna2Panel1);
            Controls.Add(btn_Update);
            Controls.Add(btn_Export);
            Controls.Add(lb_Categories);
            Controls.Add(lb_Search);
            ForeColor = Color.Cyan;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Receipts";
            Text = "Categories";
            Click += Receipts_Click;
            guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtgv_receiptinfos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Guna.UI2.WinForms.Guna2HtmlLabel lb_Search;
        private Guna.UI2.WinForms.Guna2Button btn_Export;
        private Guna.UI2.WinForms.Guna2Button btn_Update;
        private Guna.UI2.WinForms.Guna2HtmlLabel lb_Categories;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtp_Date;
        private Guna.UI2.WinForms.Guna2DataGridView dtgv_receiptinfos;
    }
}