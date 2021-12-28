namespace Medicine_Inventory_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MedicineInventory2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MedicineStockIns",
                c => new
                    {
                        M_Id = c.Int(nullable: false, identity: true),
                        S_Id = c.Int(nullable: false),
                        SupplierName = c.String(),
                        M_Name = c.String(),
                        M_Description = c.String(),
                        M_Price = c.Single(nullable: false),
                        M_Quantity = c.Int(nullable: false),
                        M_Location = c.String(),
                        M_ExpDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.M_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MedicineStockIns");
        }
    }
}
