namespace Medicine_Inventory_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerBill1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerBills", "U_Address", c => c.String());
            DropColumn("dbo.CustomerBills", "U_Id");
            DropColumn("dbo.CustomerBills", "M_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerBills", "M_Id", c => c.Int(nullable: false));
            AddColumn("dbo.CustomerBills", "U_Id", c => c.Int(nullable: false));
            DropColumn("dbo.CustomerBills", "U_Address");
        }
    }
}
