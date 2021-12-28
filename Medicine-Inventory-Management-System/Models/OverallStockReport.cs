using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medicine_Inventory_Management_System.Models
{
    public class OverallStockReport
    {
        [Key]
        public int Id { get; set; }
        public int B_Id { get; set; }
        public int Med_Id { get; set; }
        public int Med_QtyAvailable { get; set; }
        public float Med_PriceofQtyAvailable { get; set; }
        public int Med_QtySold { get; set; }
        public float Med_PriceofQtySold { get; set; }
    }
}