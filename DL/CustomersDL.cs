using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TL;
using System.Security.Cryptography.X509Certificates;
using System.Globalization;
using System.Security.Cryptography;

namespace DL
{
    public class CustomersDL : DataProvider
    {
        public DataTable GetCustomersTable(string search = null)
        {
            DataTable dt = new DataTable();
            string query = "";

            if (search != null)
            {
                query = "SELECT * FROM Customer WHERE CustomerName LIKE '%" + search + "%'";
            }
            else
            {
                query = "SELECT * FROM customer";
            }

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

        public int AddCustomer(CustomersTL customer)
        {
            string query = "Insert into customer (CID, CustomerName, Age, Gender, Phone) " +
                "Values ('" + customer.Id + "','" + customer.Name + "','" + customer.Age + "','" + customer.Gender + "','" + customer.Phone + "')";
            try
            {
                return MyExecuteNonQuery(query, System.Data.CommandType.Text);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int UpdCustomer(CustomersTL customer)
        {
            string query = "UPDATE Customer SET CustomerName = '" + customer.Name
                + "', Age = '" + customer.Age
                + "', Gender = '" + customer.Gender
                + "', Phone = '" + customer.Phone
                + "' WHERE CID = '" + customer.Id + "'";

            try
            {
                return MyExecuteNonQuery(query, System.Data.CommandType.Text);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int DelCustomer(int id)
        {
            string sql = "DELETE FROM Customer WHERE " + "CID = '" + id.ToString() + "'";
            try
            {
                return MyExecuteNonQuery(sql, System.Data.CommandType.Text);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int UpdateLastVisited(string phoneNumber)
        {
            string query = "UPDATE Customer SET LastDateVisted = GETDATE() WHERE Phone = '" + phoneNumber + "'";
            try
            {
                return MyExecuteNonQuery(query, System.Data.CommandType.Text);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public CustomersTL GetCustomersByPhone(string phoneNumber)
        {
            CustomersTL customer = null;
            DataTable dt = new DataTable();
            string query = "SELECT CID, CustomerName, Phone FROM Customer WHERE Phone = '" + phoneNumber + "'";
            connection();
            try
            {
                using (SqlDataReader reader = MyExecuteReader(query, CommandType.Text))
                {
                    while (reader.Read())
                    {
                        customer = new CustomersTL(reader.GetInt32(0), reader.GetString(1));
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                disConnection();
            }
            return customer;
        }
    }

}
