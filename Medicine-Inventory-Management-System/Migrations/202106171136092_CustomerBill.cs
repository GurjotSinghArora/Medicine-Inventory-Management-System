namespace Medicine_Inventory_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerBill : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerBills", "M_Name", c => c.String());
            DropColumn("dbo.CustomerBills", "I_TotalPriceEachMedicine");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerBills", "I_TotalPriceEachMedicine", c => c.Single(nullable: false));
            DropColumn("dbo.CustomerBills", "M_Name");
        }
    }
}
