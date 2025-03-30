using System.Data;
using System.Data.SqlClient;
using TL;

namespace DL
{
    public class StaffsDL : DataProvider
    {
        public string showStaffOfTheMonth() 
        {
            string getStaff = string.Empty;            
            connection();
            try
            {
                SqlDataReader reader;
                reader = MyExecuteReader("TakeEmployeeOfTheMonth", CommandType.StoredProcedure);
                while (reader.Read())
                {
                    getStaff = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                }
                reader.Close();
                return getStaff;
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

        public DataTable GetStaffsTable(string search = null)
        {
            DataTable dt = new DataTable();
            string sql = "";
            System.Data.CommandType commandType;

            if (search != null)
            {
                sql = "SELECT EID, EmployeeName, note, phone, status, salary, username, password " +
                    "FROM Employee, Users where userid = EID and EmployeeName LIKE '%" + search + "%'";
                commandType = CommandType.Text;
            }
            else
            {
                sql = "GetEmployee";
                commandType = CommandType.StoredProcedure;
            }

            connection();
            try
            {
                using (SqlDataReader reader = MyExecuteReader(sql, commandType))
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

        public int AddStaff(StaffsTL staff, UserTL user)
        {
            string sp = "sp_AddStaff";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@EID", staff.Id));
            parameters.Add(new SqlParameter("@EmployeeName", staff.Name));
            parameters.Add(new SqlParameter("@note", staff.Note));
            parameters.Add(new SqlParameter("@phone", staff.Phone));
            parameters.Add(new SqlParameter("@status", staff.Status));
            parameters.Add(new SqlParameter("@salary", staff.Salary));
            parameters.Add(new SqlParameter("@username", user.UserName));
            parameters.Add(new SqlParameter("@password", user.Password));
            try
            {
                return MyExecuteNonQuery(sp, System.Data.CommandType.StoredProcedure, parameters);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int UpdStaff(StaffsTL staff, UserTL user)
        {
            string sp = "sp_UpStaff";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@EID", staff.Id));
            parameters.Add(new SqlParameter("@EmployeeName", staff.Name));
            parameters.Add(new SqlParameter("@note", staff.Note));
            parameters.Add(new SqlParameter("@phone", staff.Phone));
            parameters.Add(new SqlParameter("@status", staff.Status));
            parameters.Add(new SqlParameter("@salary", staff.Salary));
            parameters.Add(new SqlParameter("@username", user.UserName));
            parameters.Add(new SqlParameter("@password", user.Password));
            try
            {
                return MyExecuteNonQuery(sp, System.Data.CommandType.StoredProcedure, parameters);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int DelStaff(int id)
        {
            string sp = "sp_DelStaff";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@EID", id));
            try
            {
                return MyExecuteNonQuery(sp, System.Data.CommandType.StoredProcedure, parameters);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public List<StaffsTL> SelectStaff(string searchStaff = null)
        {
            string query;
            if (searchStaff != null)
            {
                query = "SELECT EID, EmployeeName FROM Employee WHERE EmployeeName like '%" + searchStaff + "%'";
            }
            else
            {
                query = "SELECT EID, EmployeeName FROM Employee";
            }
            List<StaffsTL> list = new List<StaffsTL>();
            StaffsTL staff;
            int id = 0;
            string name = "";
            connection();
            try
            {
                SqlDataReader reader = MyExecuteReader(query, CommandType.Text);

                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                    name = reader.GetString(1);
                    staff = new StaffsTL(id, name);
                    list.Add(staff);
                }
                reader.Close();
                return list;
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
