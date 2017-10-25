namespace CIS420NewWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _102517 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        PhotoName = c.String(),
                        Description = c.String(),
                        Content = c.Binary(),
                        ContentLength = c.Int(nullable: false),
                        ContentType = c.String(),
                        DateUploaded = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Photos");
        }
    }
}
