using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class ReceiptsDL : DataProvider
    {
        public DataTable GetStaffsTable()
        {
            DataTable dt = new DataTable();
            string query = "select * from Receipt";
            connection();
            try
            {
                using (SqlDataReader reader = MyExecuteReader(query, CommandType.Text))
                {
                    dt.Load(reader);
                }
                return dt;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                disConnection();
            }
        }

        public DataTable pickDateReceipt(string pickDate)
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM Receipt WHERE date = '" + pickDate + "'";
            connection();
            try
            {
                using (SqlDataReader reader = MyExecuteReader(query, CommandType.Text))
                {
                    dt.Load(reader);
                }
                return dt;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                disConnection();
            }
        }

        public int InsertReceipt(int customerId, int staffId, decimal totalAmount, string paymentMethod, string result)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@CID", customerId));
            parameters.Add(new SqlParameter("@EID", staffId));
            parameters.Add(new SqlParameter("@TotalAmount", totalAmount));
            parameters.Add(new SqlParameter("@PaymentMethod", paymentMethod));
            parameters.Add(new SqlParameter("@Result", result));

            string query = @"
                INSERT INTO Receipt (CID, EID, Date, TotalAmount, PaymentMethod, Result) 
                VALUES (@CID, @EID, GETDATE(), @TotalAmount, @PaymentMethod, @Result);
                SELECT SCOPE_IDENTITY();";
            try
            {
                return Convert.ToInt32(MyExecuteScalar(query, System.Data.CommandType.Text, parameters));
            }
            catch (SqlException ex)
            {
                throw ex;
            } 
        }

        public void InsertReceiptInfo(int receiptId, List<(int MID, int Quantity)> items)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            string query = "INSERT INTO ReceiptInfo (RID, MID, Quantity) VALUES (@RID, @MID, @Quantity);";
            parameters.Add(new SqlParameter("@RID", receiptId));

            try
            {
                foreach (var item in items)
                {
                    parameters.Clear();
                    parameters.Add(new SqlParameter("@RID", receiptId));
                    parameters.Add(new SqlParameter("@MID", item.MID));
                    parameters.Add(new SqlParameter("@Quantity", item.Quantity));

                    MyExecuteNonQuery(query, CommandType.Text, parameters);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
