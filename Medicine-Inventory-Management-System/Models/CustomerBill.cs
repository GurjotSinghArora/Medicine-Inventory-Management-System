using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medicine_Inventory_Management_System.Models
{
    public class CustomerBill
    {
        [Key]
        public int B_Id { get; set; }
        public int U_Id { get; set; }
        public int M_Id { get; set; }
        public string M_Name { get; set; }
        public string B_CustomerName { get; set; }
        public int I_Quantity { get; set; }
    }
}