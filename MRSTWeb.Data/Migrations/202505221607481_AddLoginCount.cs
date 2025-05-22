namespace MRSTWeb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLoginCount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ULoginDatas", "LoginCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ULoginDatas", "LoginCount");
        }
    }
}
