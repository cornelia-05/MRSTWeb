namespace MRSTWeb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPrimaryKeyToContactMessage : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ContactMessages", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.ContactMessages", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.ContactMessages", "Subject", c => c.String(nullable: false));
            AlterColumn("dbo.ContactMessages", "Message", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ContactMessages", "Message", c => c.String());
            AlterColumn("dbo.ContactMessages", "Subject", c => c.String());
            AlterColumn("dbo.ContactMessages", "Email", c => c.String());
            AlterColumn("dbo.ContactMessages", "Name", c => c.String());
        }
    }
}
