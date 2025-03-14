using System;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class DashBoardBL
    {
        public List<object> showDashBoard()
        {
            try
            {
                return new DL.DashBoardDL().showDashBoard();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public List<(string Day, double TotalSales)> getWeeklyRevenue()
        {
            try
            {
                return new DL.DashBoardDL().showRevenueDay();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<(string Day, double TotalSales)> getMonthlyRevenue()
        {
            try
            {
                return new DL.DashBoardDL().showRevenueMonth();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
