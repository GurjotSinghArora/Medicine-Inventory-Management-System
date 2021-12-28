using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Medicine_Inventory_Management_System.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DefaultConnection")
        { }

        public DbSet<UserRegister> UserRegisters { get; set; }
        public DbSet<SupplierRegister> SupplierRegisters { get; set; }
        public DbSet<MedicineStockIn> MedicineStockIns { get; set; }
        public DbSet<CustomerBill> CustomerBills { get; set; }
        public DbSet<OverallStockReport> OverallStockReports { get; set; }
    }
}