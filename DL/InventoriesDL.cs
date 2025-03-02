using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TL;
using System.Collections;

namespace DL
{
    public class InventoriesDL : DataProvider
    {
        public DataTable getMedicines(int offset, int limit)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Offset", offset));
            parameters.Add(new SqlParameter("@Limit", limit));
            DataTable dt = new DataTable();
            connection();
            try
            {
                using (SqlDataReader reader = MyExecuteReader("LoadMedicine", CommandType.StoredProcedure, parameters))
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

        public DataTable getMedicinesFromDataBase(string searchText, int limit = 100)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@SearchText", searchText));
            parameters.Add(new SqlParameter("@Limit", limit));
            DataTable dt = new DataTable();
            string query = $"SELECT TOP 30 MID, MedicineName, UnitPrice, StockQuantity FROM MedInventory WHERE MedicineName LIKE '%" + searchText + "%'";
            connection();
            try
            {
                using (SqlDataReader reader = MyExecuteReader(query, CommandType.Text, parameters))
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

        public DataTable getExpiredOrNearExpiredProducts()
        {
            DateTime today = DateTime.Now;
            DateTime nearExpirationDate = today.AddDays(30);
            DataTable dt = new DataTable();
            string query = "SELECT TOP 1000 MID, MedicineName, ExperationDATE FROM MedInventory WHERE ExperationDATE <= '" + nearExpirationDate + "'";
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

        public DataTable getOutOfStockProduct()
        {
            string query = "SELECT * FROM MedInventory WHERE StockQuantity <= 5";
            DataTable dt = new DataTable();
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

        public List<int> updateMedicineCountAndStock()
        {
            int totalMedicines = 0;
            int totalStockQuantity = 0;
            int totalExpiredProducts = 0;
            connection();
            try
            {
                SqlDataReader reader;
                reader = MyExecuteReader("CountMedicinesAndStock", CommandType.StoredProcedure);
                while (reader.Read())
                {
                    totalMedicines = reader.GetInt32(0); // TotalMedicines
                    totalStockQuantity = reader.GetInt32(1); // TotalStockQuantity
                    totalExpiredProducts = reader.GetInt32(2); // TotalExpiredProducts 
                }
                reader.Close();
                List<int> list = new List<int> { totalMedicines, totalStockQuantity, totalExpiredProducts};
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
