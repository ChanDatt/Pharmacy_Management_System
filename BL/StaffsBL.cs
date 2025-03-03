using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TL;
using DL;
using System.Data.SqlClient;
using System.Data;

namespace BL
{
    public class StaffsBL
    {
        public string showStaffOfTheMonth()
        {
			try
			{
				return new DL.StaffsDL().showStaffOfTheMonth();
			}
			catch (SqlException ex)
			{
				throw ex;
			}
        }

        public DataTable GetStaffsTable(string search = null)
        {
            try
            {
                return new DL.StaffsDL().GetStaffsTable(search);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int AddStaff(StaffsTL staff)
        {
            try
            {
                return new StaffsDL().AddStaff(staff);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int UpdStaff(StaffsTL staff)
        {
            try
            {
                return new StaffsDL().UpdStaff(staff);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int DelStaff(int id)
        {
            try
            {
                return new StaffsDL().DelStaff(id);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public List<StaffsTL> SelectStaff()
        {
            try
            {
                return new StaffsDL().SelectStaff();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
