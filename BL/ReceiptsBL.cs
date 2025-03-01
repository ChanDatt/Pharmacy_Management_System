using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;

namespace BL
{
    public class ReceiptsBL
    {
		public DataTable GetStaffsTable()
		{
			try
			{
				return new DL.ReceiptsDL().GetStaffsTable();
			}
			catch (SqlException ex)
			{
				throw ex;
			}
		}
        public DataTable pickDateReceipt(string pickDate)
        {
			try
			{
				return new DL.ReceiptsDL().pickDateReceipt(pickDate);
			}
			catch (SqlException ex)
			{
				throw ex;
			}
        }
    }
}
