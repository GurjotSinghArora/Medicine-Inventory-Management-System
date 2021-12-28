namespace Medicine_Inventory_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserRegisters",
                c => new
                    {
                        U_Id = c.Int(nullable: false, identity: true),
                        U_Name = c.String(),
                        U_Password = c.String(),
                        U_Email = c.String(),
                        U_Mobile = c.String(),
                        U_Address = c.String(),
                        U_LoginId = c.String(),
                    })
                .PrimaryKey(t => t.U_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserRegisters");
        }
    }
}
