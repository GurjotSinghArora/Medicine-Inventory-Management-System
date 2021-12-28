using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medicine_Inventory_Management_System.Models
{
    public class AuthenticateUser
    {
        public string Name { get; set; }
        public int U_Id { get; set; }
        public string LoginId { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
    }
}