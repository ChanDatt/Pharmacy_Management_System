using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TL;
using System.Runtime.CompilerServices;

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

        public bool AddMedicines(List<MedInventory> medicines)
        {
            
            int maxMID = new DL.InventoriesDL().GetMaxMID();
            bool success = true;

            foreach (var med in medicines)
            {
                med.MID = ++maxMID; // Tạo MID mới
                if (!new DL.InventoriesDL().InsertMedicine(med))
                {
                    success = false;
                }
            }
            return success;
        }

        public bool DeleteMedicines(List<int> mids)
        {
            bool success = true;
            foreach (int mid in mids)
            {
                if (! new DL.InventoriesDL().DeleteMedicine(mid))
                {
                    success = false;
                }
            }
            return success;
        }
    }
}
