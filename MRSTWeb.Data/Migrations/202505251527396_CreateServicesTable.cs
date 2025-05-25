namespace MRSTWeb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateServicesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "ImagePath", c => c.String());
            AlterColumn("dbo.Services", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Services", "Description", c => c.String(nullable: false));
            DropColumn("dbo.Services", "ServiceName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Services", "ServiceName", c => c.String());
            AlterColumn("dbo.Services", "Description", c => c.String());
            AlterColumn("dbo.Services", "Name", c => c.String());
            DropColumn("dbo.Services", "ImagePath");
        }
    }
}
