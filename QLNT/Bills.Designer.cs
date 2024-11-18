namespace QLNT
{
    partial class Bills
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            lb_Categories = new Guna.UI2.WinForms.Guna2HtmlLabel();
            dtgv_Categories = new Guna.UI2.WinForms.Guna2DataGridView();
            dtgv_id = new DataGridViewTextBoxColumn();
            dtgv_CatergoryName = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dtgv_Categories).BeginInit();
            SuspendLayout();
            // 
            // lb_Categories
            // 
            lb_Categories.BackColor = Color.Transparent;
            lb_Categories.Font = new Font("Britannic Bold", 55.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lb_Categories.ForeColor = Color.FromArgb(89, 104, 105);
            lb_Categories.Location = new Point(51, 38);
            lb_Categories.Name = "lb_Categories";
            lb_Categories.Size = new Size(233, 103);
            lb_Categories.TabIndex = 3;
            lb_Categories.Text = "BILLS";
            // 
            // dtgv_Categories
            // 
            dtgv_Categories.AllowUserToAddRows = false;
            dtgv_Categories.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dtgv_Categories.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dtgv_Categories.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtgv_Categories.BackgroundColor = Color.WhiteSmoke;
            dtgv_Categories.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(89, 104, 105);
            dataGridViewCellStyle2.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dtgv_Categories.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dtgv_Categories.ColumnHeadersHeight = 35;
            dtgv_Categories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dtgv_Categories.Columns.AddRange(new DataGridViewColumn[] { dtgv_id, dtgv_CatergoryName });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.Cyan;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dtgv_Categories.DefaultCellStyle = dataGridViewCellStyle3;
            dtgv_Categories.GridColor = Color.Silver;
            dtgv_Categories.Location = new Point(51, 170);
            dtgv_Categories.Name = "dtgv_Categories";
            dtgv_Categories.ReadOnly = true;
            dtgv_Categories.RowHeadersVisible = false;
            dtgv_Categories.RowHeadersWidth = 51;
            dtgv_Categories.Size = new Size(1365, 683);
            dtgv_Categories.TabIndex = 4;
            dtgv_Categories.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dtgv_Categories.ThemeStyle.AlternatingRowsStyle.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtgv_Categories.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dtgv_Categories.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dtgv_Categories.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dtgv_Categories.ThemeStyle.BackColor = Color.WhiteSmoke;
            dtgv_Categories.ThemeStyle.GridColor = Color.Silver;
            dtgv_Categories.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(89, 104, 105);
            dtgv_Categories.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dtgv_Categories.ThemeStyle.HeaderStyle.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dtgv_Categories.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dtgv_Categories.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dtgv_Categories.ThemeStyle.HeaderStyle.Height = 35;
            dtgv_Categories.ThemeStyle.ReadOnly = true;
            dtgv_Categories.ThemeStyle.RowsStyle.BackColor = Color.White;
            dtgv_Categories.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            dtgv_Categories.ThemeStyle.RowsStyle.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtgv_Categories.ThemeStyle.RowsStyle.ForeColor = Color.Cyan;
            dtgv_Categories.ThemeStyle.RowsStyle.Height = 29;
            dtgv_Categories.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dtgv_Categories.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
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
            // Bills
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(230, 239, 230);
            ClientSize = new Size(1465, 905);
            Controls.Add(dtgv_Categories);
            Controls.Add(lb_Categories);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Bills";
            Text = "Bills";
            ((System.ComponentModel.ISupportInitialize)dtgv_Categories).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lb_Categories;
        private Guna.UI2.WinForms.Guna2DataGridView dtgv_Categories;
        private DataGridViewTextBoxColumn dtgv_id;
        private DataGridViewTextBoxColumn dtgv_CatergoryName;
    }
}