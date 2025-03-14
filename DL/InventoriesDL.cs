using System.Data.SqlClient;
using System.Data;
using TL;

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

        public int GetMaxMID()
        {
            try
            {
                return (int)MyExecuteScalar("SELECT ISNULL(MAX(MID), 0) FROM MedInventory", CommandType.Text);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public bool InsertMedicine(MedInventory medicine)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@MID", medicine.MID));
            parameters.Add(new SqlParameter("@MedicineName", medicine.MedicineName));
            parameters.Add(new SqlParameter("@Type", medicine.Type));
            parameters.Add(new SqlParameter("@PackSizeLabel", medicine.PackSizeLabel));
            parameters.Add(new SqlParameter("@StockQuantity", medicine.StockQuantity));
            parameters.Add(new SqlParameter("@UnitPrice", medicine.UnitPrice));
            parameters.Add(new SqlParameter("@ISDiscontinued", medicine.ISDiscontinued));
            parameters.Add(new SqlParameter("@ManufacturerName", medicine.ManufacturerName));
            parameters.Add(new SqlParameter("@Composition1", medicine.Composition1));
            parameters.Add(new SqlParameter("@Composition2", medicine.Composition2));
            parameters.Add(new SqlParameter("@Timestamp", medicine.Timestamp));
            parameters.Add(new SqlParameter("@ExperationDATE", medicine.ExperationDATE));

            string query = @"
                SET IDENTITY_INSERT MedInventory ON;
                INSERT INTO MedInventory (MID, MedicineName, Type, Pack_Size_Label, StockQuantity, UnitPrice, ISDiscontinued, 
                    Manufacturer_name, Composition1, Composition2, timestamp, ExperationDATE) 
                VALUES (@MID, @MedicineName, @Type, @PackSizeLabel, @StockQuantity, @UnitPrice, @ISDiscontinued, 
                    @ManufacturerName, @Composition1, @Composition2, @Timestamp, @ExperationDATE);
                SET IDENTITY_INSERT MedInventory OFF;";

            try
            {
                return MyExecuteNonQuery(query, CommandType.Text, parameters) > 0;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public bool DeleteMedicine(int mid)
        {
            string query = "DELETE FROM MedInventory WHERE MID = " + mid;
            try
            {
                return MyExecuteNonQuery(query, CommandType.Text) > 0;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
