namespace CIS420NewWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _92517Migration : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Tests");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
    }
}
