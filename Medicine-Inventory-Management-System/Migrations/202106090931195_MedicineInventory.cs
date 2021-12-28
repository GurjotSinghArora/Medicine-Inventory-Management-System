namespace Medicine_Inventory_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MedicineInventory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserRegisters", "U_Type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserRegisters", "U_Type");
        }
    }
}
