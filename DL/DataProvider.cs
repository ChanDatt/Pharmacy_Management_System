using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace DL
{
    public class DataProvider
    {
        private SqlConnection cnn;
        public DataProvider() { 
            string sql = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            cnn = new SqlConnection(sql);
        }

        public void connection()
        {
            try
            {
                if (cnn != null || cnn.State != System.Data.ConnectionState.Open)
                {
                    cnn.Open();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void disConnection()
        {
            if(cnn != null || cnn.State == System.Data.ConnectionState.Open) {
                cnn.Close();
            }
        }

        public object MyExecuteScalar(string sql, CommandType type, List<SqlParameter> parameters = null)
        {
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = type;

            if (parameters != null)
            {
                foreach(SqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
            }

            connection();
            try
            {
                return cmd.ExecuteScalar();
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

        public SqlDataReader MyExecuteReader(string sql, CommandType type, List<SqlParameter> paramters = null)
        {
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = type;

            if(paramters != null)
            {
                foreach(SqlParameter paramter in paramters)
                {
                    cmd.Parameters.Add(paramter);
                }
            }

            try
            {
                return cmd.ExecuteReader();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int MyExecuteNonQuery(string sql, CommandType type, List<SqlParameter> paramters = null)
        {
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = type;

            if(paramters != null)
            {
                foreach(SqlParameter parameter in paramters)
                {
                    cmd.Parameters.Add(parameter);
                }
            }

            connection();
            try
            {
                return (int)cmd.ExecuteNonQuery();
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
