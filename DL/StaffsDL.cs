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
                sql = "SELECT * FROM Employee WHERE EmployeeName LIKE '%" + search + "%'";
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

        public int AddStaff(StaffsTL staff)
        {
            string query = "INSERT INTO Employee (EID, EmployeeName, Note, Phone, Status, Salary, Address) " +
                "Values ('" + staff.Id + "','" + staff.Name + "','" + staff.Note + "','" + staff.Phone + "','" 
                            + staff.Status + "','" + staff.Salary + "','" + staff.Address + "')";
            try
            {
                return MyExecuteNonQuery(query, System.Data.CommandType.Text);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int UpdStaff(StaffsTL staff)
        {
            string query = "UPDATE Employee SET EmployeeName = '" + staff.Name
                + "', Phone = '" + staff.Phone
                + "', Note = '" + staff.Note
                + "', Status = '" + staff.Status
                + "', Salary = '" + staff.Salary
                + "', Address = '" + staff.Address
                + "' WHERE EID = '" + staff.Id + "'";

            try
            {
                return MyExecuteNonQuery(query, System.Data.CommandType.Text);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int DelStaff(int id)
        {
            string sql = "DELETE FROM Employee WHERE " + "EID = '" + id + "'";
            try
            {
                return MyExecuteNonQuery(sql, System.Data.CommandType.Text);
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
