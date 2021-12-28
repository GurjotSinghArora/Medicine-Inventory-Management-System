using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medicine_Inventory_Management_System.Models
{
    public class SupplierRegister
    {
        [Key]
        public int S_Id { get; set; }
        public int U_Id { get; set; }
        public string S_Name { get; set; }
        public string S_ContactPerson { get; set; }
        public string S_Mobile { get; set; }
        public string S_Address { get; set; }
    }
}