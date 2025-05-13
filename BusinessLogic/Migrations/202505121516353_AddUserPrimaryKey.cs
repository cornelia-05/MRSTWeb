namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserPrimaryKey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Password", c => c.String());
            AddColumn("dbo.Users", "Role", c => c.String());
            AddColumn("dbo.Users", "SessionKey", c => c.String());
            AlterColumn("dbo.UDbTables", "Username", c => c.String(nullable: false, maxLength: 12));
            AlterColumn("dbo.UDbTables", "Password", c => c.String(nullable: false, maxLength: 15));
            DropColumn("dbo.Users", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Name", c => c.String());
            AlterColumn("dbo.UDbTables", "Password", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.UDbTables", "Username", c => c.String(nullable: false, maxLength: 30));
            DropColumn("dbo.Users", "SessionKey");
            DropColumn("dbo.Users", "Role");
            DropColumn("dbo.Users", "Password");
        }
    }
}
