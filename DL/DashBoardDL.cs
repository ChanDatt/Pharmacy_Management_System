using System;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TL;

namespace DL
{
    public class DashBoardDL : DataProvider
    {
        int totalStaffs = 0;
        string getBestSeller = string.Empty;
        decimal getRevenue = 0;
        decimal getProfit = 0;
        DateTime getDate;
        decimal getTotalSalesOneDay = 0;
        List<object> listDashBoard = new List<object>();
        public List<object> showDashBoard()
        {
            string getStaff = string.Empty;
            connection();
            try
            {
                SqlDataReader reader;
                reader = MyExecuteReader("TakeDataToDashBoard", CommandType.StoredProcedure);
                while (reader.Read())
                {
                    totalStaffs = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                    getBestSeller = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                    getRevenue = reader.IsDBNull(2) ? 0 : reader.GetDecimal(2);
                    getProfit = reader.IsDBNull(3) ? 0 : reader.GetDecimal(3);
                }
                listDashBoard.AddRange(new List<object> { totalStaffs, getBestSeller, getRevenue, getProfit });
                reader.Close();
                return listDashBoard;
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

        public List<(string Day, double TotalSales)> showRevenueDay()
        {
            var revenueDaily = new List<(string, double)>();
            connection();
            try
            {
                SqlDataReader reader;
                reader = MyExecuteReader("GetWeeklyRevenue", CommandType.StoredProcedure);
                while (reader.Read())
                {
                    string day = reader["DayMonth"]?.ToString() ?? "Unknown";
                    double totalSales = reader["TotalSales"] != DBNull.Value ? Convert.ToDouble(reader["TotalSales"]) : 0;
                    revenueDaily.Add((day, totalSales));
                }
                return revenueDaily;
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

        public List<(string Day, double TotalSales)> showRevenueMonth()
        {
            var revenueDaily = new List<(string, double)>();
            connection();
            try
            {
                SqlDataReader reader;
                reader = MyExecuteReader("GetMonthlyRevenue", CommandType.StoredProcedure);
                while (reader.Read())
                {
                    string day = reader["MonthYear"]?.ToString() ?? "Unknown";
                    double totalSales = reader["TotalSales"] != DBNull.Value ? Convert.ToDouble(reader["TotalSales"]) : 0;
                    revenueDaily.Add((day, totalSales));
                }
                return revenueDaily;
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
