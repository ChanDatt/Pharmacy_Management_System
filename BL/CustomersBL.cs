using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;
using TL;

namespace BL
{
    public class CustomersBL
    {
        public DataTable GetCustomersTable(string search = null)
        {
            try
            {
                return new DL.CustomersDL().GetCustomersTable(search);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int AddCustomer(CustomersTL customer)
        {
            try
            {
                return new CustomersDL().AddCustomer(customer);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int UpdCustomer(CustomersTL customer)
        {
            try
            {
                return new CustomersDL().UpdCustomer(customer);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int DelCustomer(int id)
        {
            try
            {
                return new CustomersDL().DelCustomer(id);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }


        public CustomersTL LoadCustomerData(string phoneNumber)
        {
            new CustomersDL().UpdateLastVisited(phoneNumber);
            return new CustomersDL().GetCustomersByPhone(phoneNumber);
        }
    }
}
