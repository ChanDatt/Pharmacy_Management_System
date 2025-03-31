using System.Drawing.Drawing2D;

namespace QLNT
{
    public partial class LoginForm : Form
    {
        private string currentName;
        string placeholder_txb_User = "Username";
        string placeholder_txb_Pass = "Password";

        public string UserRole { get; private set; }
        public string CurrentName { get => currentName; set => currentName = value; }

        public LoginForm()
        {
            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
        {
            // Độ bo góc cho hai đầu của form giống pill
            int radius = this.Size.Height / 2;

            // GraphicsPath tạo đường cong 
            GraphicsPath path = new GraphicsPath();

            // Tạo đầu tròn bên trái
            path.AddArc(new Rectangle(0, 0, this.Size.Height, this.Size.Height), 90, 180);

            // Tạo đoạn thẳng giữa form để kết nối hai đầu tròn
            path.AddLine(radius, 0, this.Size.Width - radius, 0);
            path.AddArc(new Rectangle(this.Size.Width - this.Size.Height, 0, this.Size.Height, this.Size.Height), 270, 180);
            path.AddLine(this.Size.Width - radius, this.Size.Height, radius, this.Size.Height);
            path.CloseFigure();

            this.Region = new Region(path);

            // Placeholder cho textbox
            txb_User.Text = placeholder_txb_User;
            txb_User.ForeColor = ColorTranslator.FromHtml("#E6EFE6");
            txb_Pass.Text = placeholder_txb_Pass;
            txb_Pass.ForeColor = ColorTranslator.FromHtml("#E6EFE6");
        }
        private void txb_User_Enter(object sender, EventArgs e)
        {
            if (txb_User.Text == placeholder_txb_User)
            {
                txb_User.Text = "";
                txb_User.ForeColor = ColorTranslator.FromHtml("#E6EFE6");
            }
        }
        private void txb_Pass_Enter(object sender, EventArgs e)
        {
            if (txb_Pass.Text == placeholder_txb_Pass)
            {
                txb_Pass.Text = "";
                txb_Pass.ForeColor = ColorTranslator.FromHtml("#E6EFE6");
            }
        }
        private void txb_User_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_User.Text))
            {
                txb_User.Text = placeholder_txb_User;
                txb_User.ForeColor = ColorTranslator.FromHtml("#E6EFE6");
            }
        }
        private void txb_Pass_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_Pass.Text))
            {
                txb_Pass.Text = placeholder_txb_Pass;
                txb_Pass.ForeColor = ColorTranslator.FromHtml("#E6EFE6");
            }
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btn_Login_Click(object sender, EventArgs e)
        {
            string username = txb_User.Text;
            string password = txb_Pass.Text;
            string result = new BL.UserBL().AuthenticateUser(username, password);

            if (result == "admin")
            {
                this.DialogResult = DialogResult.OK;
                currentName = txb_User.Text;
                UserRole = "admin";
            }
            else if (result == "staff")
            {
                this.DialogResult = DialogResult.OK;
                currentName = txb_User.Text;
                UserRole = "staff";
            }

            else
            {
                if (MessageBox.Show("Incorrect username or password", "Information", MessageBoxButtons.RetryCancel) == DialogResult.Retry)
                {
                    txb_User.Clear();
                    txb_Pass.Clear();
                    txb_User.Focus();
                }
                else
                {
                    Application.Exit();
                }
            }

        }
    }
}
