using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TL
{
    public class MedInventory
    {
        public int MID { get; set; }
        public string MedicineName { get; set; }
        public string Type { get; set; }
        public string PackSizeLabel { get; set; }
        public int StockQuantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string ISDiscontinued { get; set; }
        public string ManufacturerName { get; set; }
        public string Composition1 { get; set; }
        public string Composition2 { get; set; }
        public DateTime Timestamp { get; set; }
        public DateTime ExperationDATE { get; set; }
    }
}
