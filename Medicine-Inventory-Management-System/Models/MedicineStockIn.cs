using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medicine_Inventory_Management_System.Models
{
    public class MedicineStockIn
    {
        [Key]
        public int M_Id { get; set; }
        public int S_Id { get; set; }
        public string SupplierName { get; set; }
        public string M_Name { get; set; }
        public string M_Description { get; set; }
        public double M_Price { get; set; }
        public int M_Quantity { get; set; }
        public string M_Location { get; set; }
        public DateTime M_ExpDate { get; set; }
    }
}