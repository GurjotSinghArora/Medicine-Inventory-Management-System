namespace Medicine_Inventory_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MedicineInventory4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OverallStockReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        B_Id = c.Int(nullable: false),
                        Med_Id = c.Int(nullable: false),
                        Med_QtyAvailable = c.Int(nullable: false),
                        Med_PriceofQtyAvailable = c.Single(nullable: false),
                        Med_QtySold = c.Int(nullable: false),
                        Med_PriceofQtySold = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OverallStockReports");
        }
    }
}
