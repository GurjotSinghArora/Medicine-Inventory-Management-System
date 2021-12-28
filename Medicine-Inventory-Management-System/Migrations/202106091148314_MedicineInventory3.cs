namespace Medicine_Inventory_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MedicineInventory3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerBills",
                c => new
                    {
                        B_Id = c.Int(nullable: false, identity: true),
                        U_Id = c.Int(nullable: false),
                        M_Id = c.Int(nullable: false),
                        B_CustomerName = c.String(),
                        I_TotalPriceEachMedicine = c.Single(nullable: false),
                        I_Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.B_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CustomerBills");
        }
    }
}
