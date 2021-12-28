namespace Medicine_Inventory_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MedicineStockIns : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MedicineStockIns", "M_Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MedicineStockIns", "M_Price", c => c.Single(nullable: false));
        }
    }
}
