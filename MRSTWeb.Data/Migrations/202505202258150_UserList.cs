namespace MRSTWeb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserList : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ULoginDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Credential = c.String(),
                        Password = c.String(),
                        Role = c.Int(nullable: false),
                        SessionKey = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ULoginDatas");
        }
    }
}
