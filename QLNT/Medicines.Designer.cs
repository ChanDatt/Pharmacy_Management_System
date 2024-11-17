namespace QLNT
{
    partial class Medicines
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            btn_DelMedicine = new Guna.UI2.WinForms.Guna2Button();
            btn_UpdateMedicine = new Guna.UI2.WinForms.Guna2Button();
            btn_AddMedicine = new Guna.UI2.WinForms.Guna2Button();
            lb_Categories = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lb_Search = new Guna.UI2.WinForms.Guna2HtmlLabel();
            txb_SearchMedicine = new Guna.UI2.WinForms.Guna2TextBox();
            dtgv_Medicines = new Guna.UI2.WinForms.Guna2DataGridView();
            dtgv_id = new DataGridViewTextBoxColumn();
            dtgv_CatergoryName = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dtgv_Medicines).BeginInit();
            SuspendLayout();
            // 
            // btn_DelMedicine
            // 
            btn_DelMedicine.Anchor = AnchorStyles.Top;
            btn_DelMedicine.BorderRadius = 25;
            btn_DelMedicine.CustomizableEdges = customizableEdges1;
            btn_DelMedicine.DisabledState.BorderColor = Color.DarkGray;
            btn_DelMedicine.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_DelMedicine.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_DelMedicine.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_DelMedicine.FillColor = Color.FromArgb(64, 0, 0);
            btn_DelMedicine.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_DelMedicine.ForeColor = Color.White;
            btn_DelMedicine.Location = new Point(576, 188);
            btn_DelMedicine.Name = "btn_DelMedicine";
            btn_DelMedicine.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btn_DelMedicine.Size = new Size(346, 57);
            btn_DelMedicine.TabIndex = 8;
            btn_DelMedicine.Text = "Delete";
            // 
            // btn_UpdateMedicine
            // 
            btn_UpdateMedicine.BorderRadius = 25;
            customizableEdges3.BottomLeft = false;
            customizableEdges3.TopLeft = false;
            btn_UpdateMedicine.CustomizableEdges = customizableEdges3;
            btn_UpdateMedicine.DisabledState.BorderColor = Color.DarkGray;
            btn_UpdateMedicine.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_UpdateMedicine.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_UpdateMedicine.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_UpdateMedicine.FillColor = Color.FromArgb(108, 137, 118);
            btn_UpdateMedicine.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_UpdateMedicine.ForeColor = Color.White;
            btn_UpdateMedicine.Location = new Point(287, 188);
            btn_UpdateMedicine.Name = "btn_UpdateMedicine";
            btn_UpdateMedicine.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btn_UpdateMedicine.Size = new Size(170, 57);
            btn_UpdateMedicine.TabIndex = 9;
            btn_UpdateMedicine.Text = "Update";
            btn_UpdateMedicine.Click += btn_UpdateMedicine_Click;
            // 
            // btn_AddMedicine
            // 
            btn_AddMedicine.BorderRadius = 25;
            customizableEdges5.BottomRight = false;
            customizableEdges5.TopRight = false;
            btn_AddMedicine.CustomizableEdges = customizableEdges5;
            btn_AddMedicine.DisabledState.BorderColor = Color.DarkGray;
            btn_AddMedicine.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_AddMedicine.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_AddMedicine.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_AddMedicine.FillColor = Color.FromArgb(108, 137, 118);
            btn_AddMedicine.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_AddMedicine.ForeColor = Color.White;
            btn_AddMedicine.Location = new Point(111, 188);
            btn_AddMedicine.Name = "btn_AddMedicine";
            btn_AddMedicine.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btn_AddMedicine.Size = new Size(170, 57);
            btn_AddMedicine.TabIndex = 10;
            btn_AddMedicine.Text = "Add";
            btn_AddMedicine.Click += btn_AddMedicine_Click;
            // 
            // lb_Categories
            // 
            lb_Categories.BackColor = Color.Transparent;
            lb_Categories.Font = new Font("Britannic Bold", 55.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lb_Categories.ForeColor = Color.FromArgb(89, 104, 105);
            lb_Categories.Location = new Point(51, 38);
            lb_Categories.Name = "lb_Categories";
            lb_Categories.Size = new Size(445, 103);
            lb_Categories.TabIndex = 6;
            lb_Categories.Text = "MEDICINES";
            // 
            // lb_Search
            // 
            lb_Search.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lb_Search.BackColor = Color.Transparent;
            lb_Search.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_Search.ForeColor = Color.FromArgb(89, 104, 105);
            lb_Search.Location = new Point(1048, 142);
            lb_Search.Name = "lb_Search";
            lb_Search.Size = new Size(100, 39);
            lb_Search.TabIndex = 7;
            lb_Search.Text = "Search";
            // 
            // txb_SearchMedicine
            // 
            txb_SearchMedicine.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txb_SearchMedicine.BorderColor = Color.DarkGray;
            txb_SearchMedicine.BorderRadius = 25;
            txb_SearchMedicine.CustomizableEdges = customizableEdges7;
            txb_SearchMedicine.DefaultText = "";
            txb_SearchMedicine.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txb_SearchMedicine.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txb_SearchMedicine.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txb_SearchMedicine.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txb_SearchMedicine.FillColor = Color.WhiteSmoke;
            txb_SearchMedicine.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txb_SearchMedicine.Font = new Font("Segoe UI", 9F);
            txb_SearchMedicine.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txb_SearchMedicine.Location = new Point(1032, 188);
            txb_SearchMedicine.Margin = new Padding(3, 4, 3, 4);
            txb_SearchMedicine.Name = "txb_SearchMedicine";
            txb_SearchMedicine.PasswordChar = '\0';
            txb_SearchMedicine.PlaceholderText = "";
            txb_SearchMedicine.SelectedText = "";
            txb_SearchMedicine.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txb_SearchMedicine.Size = new Size(346, 57);
            txb_SearchMedicine.TabIndex = 5;
            // 
            // dtgv_Medicines
            // 
            dtgv_Medicines.AllowUserToAddRows = false;
            dtgv_Medicines.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dtgv_Medicines.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dtgv_Medicines.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtgv_Medicines.BackgroundColor = Color.WhiteSmoke;
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
            dtgv_Medicines.Location = new Point(51, 280);
            dtgv_Medicines.Name = "dtgv_Medicines";
            dtgv_Medicines.ReadOnly = true;
            dtgv_Medicines.RowHeadersVisible = false;
            dtgv_Medicines.RowHeadersWidth = 51;
            dtgv_Medicines.Size = new Size(1365, 613);
            dtgv_Medicines.TabIndex = 4;
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
            // Medicines
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(230, 239, 230);
            ClientSize = new Size(1465, 905);
            Controls.Add(btn_DelMedicine);
            Controls.Add(btn_UpdateMedicine);
            Controls.Add(btn_AddMedicine);
            Controls.Add(lb_Categories);
            Controls.Add(lb_Search);
            Controls.Add(txb_SearchMedicine);
            Controls.Add(dtgv_Medicines);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Medicines";
            Text = "Medicines";
            ((System.ComponentModel.ISupportInitialize)dtgv_Medicines).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btn_DelMedicine;
        private Guna.UI2.WinForms.Guna2Button btn_UpdateMedicine;
        private Guna.UI2.WinForms.Guna2Button btn_AddMedicine;
        private Guna.UI2.WinForms.Guna2HtmlLabel lb_Categories;
        private Guna.UI2.WinForms.Guna2HtmlLabel lb_Search;
        private Guna.UI2.WinForms.Guna2TextBox txb_SearchMedicine;
        private Guna.UI2.WinForms.Guna2DataGridView dtgv_Medicines;
        private DataGridViewTextBoxColumn dtgv_id;
        private DataGridViewTextBoxColumn dtgv_CatergoryName;
    }
}