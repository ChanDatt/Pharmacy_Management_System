using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class ReportDL : DataProvider
    {
        public DataTable LoadItemSales()
        {

            DataTable dt = new DataTable();
            string query = "EXEC dbo.LoadItemsSale;";
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

        public DataTable LoadItemMSalesBySelectedMY(int startmonth, int endmonth, int year)
        {

            DataTable dt = new DataTable();
            string query = $"select * from SalesItemView where Month BETWEEN {startmonth} AND {endmonth} and Year = {year}";
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

        public DataTable LoadEmployeeMSales()
        {

            DataTable dt = new DataTable();
            string query = $"exec CreateEmployeeSalesForMonth SELECT * FROM EmployeeMonthlySalesView";
            connection ();
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

        public DataTable LoadEmployeeMSalesByMY(int startmonth, int endmonth, int year)
        {

            DataTable dt = new DataTable();
            string query = $"SELECT * FROM EmployeeMonthlySalesView WHERE  Month BETWEEN {startmonth} AND {endmonth} and Year = {year} group by EID, EmployeeName, Receipts, TotalAmount, Month, Year";
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

        public DataTable LoadMonthlySalesSummary()
        {

            DataTable dt = new DataTable();
            string query = "exec CreateMonthlySalesSummaryView select * from MonthlySalesSummary";
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
