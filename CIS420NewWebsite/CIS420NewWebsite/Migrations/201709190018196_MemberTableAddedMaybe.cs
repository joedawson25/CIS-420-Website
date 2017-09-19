namespace CIS420NewWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MemberTableAddedMaybe : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Members");
        }
    }
}
