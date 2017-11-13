namespace CIS420NewWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class photos : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Photos");
            AlterColumn("dbo.Photos", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Photos", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Photos");
            AlterColumn("dbo.Photos", "ID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Photos", "ID");
        }
    }
}
