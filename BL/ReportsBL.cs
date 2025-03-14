using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;

namespace BL
{
    public class ReportBL
    {
        public DataTable LoadItemSales()
        {
            try
            {
                return new DL.ReportDL().LoadItemSales();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataTable LoadItemMSalesBySelectedMY(int startmonth, int endmonth, int year)
        {
            try
            {
                return new DL.ReportDL().LoadItemMSalesBySelectedMY(startmonth, endmonth, year);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataTable LoadEmployeeMSales()
        {
            try
            {
                return new DL.ReportDL().LoadEmployeeMSales();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataTable LoadEmployeeMSalesByMY(int startmonth, int endmonth, int year)
        {
            try
            {
                return new DL.ReportDL().LoadEmployeeMSalesByMY(startmonth, endmonth, year);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataTable LoadMonthlySalesSummary()
        {
            try
            {
                return new DL.ReportDL().LoadMonthlySalesSummary();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
