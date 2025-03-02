using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class InventoriesBL {
        public DataTable getMedicines(int offset, int limit)
        {
            try
            {
                return new DL.InventoriesDL().getMedicines(offset, limit);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataTable getMedicinesFromDataBase(string searchText, int limit = 100)
        {
            try
            {
                return new DL.InventoriesDL().getMedicinesFromDataBase(searchText, limit);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public DataTable getExpiredOrNearExpiredProducts()
        {
            try
            {
                return new DL.InventoriesDL().getExpiredOrNearExpiredProducts();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataTable getOutOfStockProduct()
        {
            try
            {
                return new DL.InventoriesDL().getOutOfStockProduct();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public List<int> updateMedicineCountAndStock()
        {
            try
            {
                return new DL.InventoriesDL().updateMedicineCountAndStock();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
