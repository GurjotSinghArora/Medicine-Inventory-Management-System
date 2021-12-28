using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medicine_Inventory_Management_System.Models
{
    public class UserRegister
    {
        [Key]
        public int U_Id { get; set; }
        public string U_Name { get; set; }
        public string U_Password { get; set; }
        public string U_Email { get; set; }
        public string U_Mobile { get; set; }
        public string U_Address { get; set; }
        public string U_LoginId { get; set; }
        public string U_Type { get; set; }
    }
}