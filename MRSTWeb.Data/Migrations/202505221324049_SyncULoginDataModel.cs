namespace MRSTWeb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SyncULoginDataModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ULoginDatas", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ULoginDatas", "Email");
        }
    }
}
