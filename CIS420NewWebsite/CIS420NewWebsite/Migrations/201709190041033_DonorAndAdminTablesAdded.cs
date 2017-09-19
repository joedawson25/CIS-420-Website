namespace CIS420NewWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DonorAndAdminTablesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administrators",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Donors",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        DonationAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsMember = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Donors");
            DropTable("dbo.Administrators");
        }
    }
}
