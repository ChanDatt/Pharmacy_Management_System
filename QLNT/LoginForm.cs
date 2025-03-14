using System.Data;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;



namespace QLNT
{
    public partial class LoginForm : Form
    {
        private SQLConnectionClass sqlConnection;
        private string currentName;
        //string placeholder_txb_User = "Username";
        //string placeholder_txb_Pass = "Password";

        string placeholder_txb_User = "oanh.admin";
        string placeholder_txb_Pass = "123";

        public string UserRole { get; private set; }
        public string CurrentName { get => currentName; set => currentName = value; }

        public LoginForm()
        {
            InitializeComponent();
            sqlConnection = new SQLConnectionClass();
        }
        private void Login_Load(object sender, EventArgs e)
        {
            // Đổi màu chữ mặc định
            this.ForeColor = ColorTranslator.FromHtml("#596869");

            // Đổi màu 2 thanh textbox
            txb_User.BackColor = ColorTranslator.FromHtml("#6C8976");
            txb_Pass.BackColor = ColorTranslator.FromHtml("#6C8976");


            // Độ bo góc cho hai đầu của form giống pill
            int radius = this.Size.Height / 2;

            // Khởi tạo GraphicsPath để tạo đường cong liền mạch
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

            // Đỏi màu cho btn_login
            btn_Login.BackColor = ColorTranslator.FromHtml("#596869");
            btn_Login.ForeColor = ColorTranslator.FromHtml("#E6EFE6");
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
