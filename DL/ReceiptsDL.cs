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
    }
}
