using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medicine_Inventory_Management_System.Models
{
    public class Register
    {
        public string Name { get; set; }
        public string LoginId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }
    }
}