using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNT
{
    public partial class Receipts_Add : Form
    {
        DataGridView dgv;
        private SQLConnectionClass sqlConnection;
        public Receipts_Add(DataGridView dgv)
        {
            InitializeComponent();
            sqlConnection = new SQLConnectionClass();
            this.dgv = dgv;

            foreach (int i in Enumerable.Range(1, 20))
            {
                cb_CID.Items.Add(i);
            }
            foreach (int i in Enumerable.Range(1, 20))
            {
                cb_EID.Items.Add(i);
            }

            string[] listPayment = { "Cash", "Card", "Momo", "Zalopay" };
            foreach (string i in listPayment)
            {
                cb_Payment.Items.Add(i);
            }
        }

        private void AddReceipt(int cID, int eID, string date, decimal totalAmount, string paymentMethod, string result)
        {
            using (var connection = new SqlConnection(sqlConnection.ConnectionString))
            {
                connection.Open();
                string query = "INSERT INTO Receipt (CID, EID, Date, TotalAmount, PaymentMethod, Result) VALUES (@CID, @EID, @Date, @TotalAmount, @PaymentMethod, @Result)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    Random random = new Random();
                    command.Parameters.AddWithValue("@CID", cID);
                    command.Parameters.AddWithValue("@EID", eID);
                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue("@TotalAmount", totalAmount);
                    command.Parameters.AddWithValue("@PaymentMethod", paymentMethod);
                    command.Parameters.AddWithValue("@Result", result);

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (cb_CID.Text != "" && cb_EID.Text != "" && txb_TotalAmount.Text != "" && cb_Payment.Text != "" && txb_Result.Text != "")
                {
                    int cID = int.Parse(cb_CID.SelectedItem.ToString());
                    int eID = int.Parse(cb_CID.SelectedItem.ToString());
                    string date = dtp_Date.Value.ToShortDateString();
                    decimal totalAmount = decimal.Parse(txb_TotalAmount.Text);
                    string payMent = cb_Payment.Text;
                    string result = txb_Result.Text;
                    AddReceipt(cID, eID, date, totalAmount, payMent, result);
                    DialogResult = DialogResult.OK;
                    cb_CID.Text = string.Empty;
                    cb_EID.Text = string.Empty;
                    txb_TotalAmount.Text = string.Empty;
                    txb_Result.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Please fill out the information");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cb_CID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
