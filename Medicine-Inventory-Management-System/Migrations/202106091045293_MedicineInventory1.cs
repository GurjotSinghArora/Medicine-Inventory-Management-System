namespace Medicine_Inventory_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MedicineInventory1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SupplierRegisters",
                c => new
                    {
                        S_Id = c.Int(nullable: false, identity: true),
                        U_Id = c.Int(nullable: false),
                        S_Name = c.String(),
                        S_ContactPerson = c.String(),
                        S_Mobile = c.String(),
                        S_Address = c.String(),
                    })
                .PrimaryKey(t => t.S_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SupplierRegisters");
        }
    }
}
