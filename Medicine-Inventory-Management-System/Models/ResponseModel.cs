using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medicine_Inventory_Management_System.Models
{
    public class ResponseModel
    {
        public  string UniqueId { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
        public string Token { get; set; }
    }
}