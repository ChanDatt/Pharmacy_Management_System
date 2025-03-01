using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TL;

namespace DL
{
    public class UserDL : DataProvider
    {
        public string Login(UserTL user)
        {

            string sql = "sp_Login_TagUser";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@username", user.UserName));
            parameters.Add(new SqlParameter("@password", user.Password));

            SqlParameter roleParam = new SqlParameter("@Role", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };

            parameters.Add(roleParam);

            try
            {
                MyExecuteScalar(sql, System.Data.CommandType.StoredProcedure, parameters);
                return roleParam.Value.ToString();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
