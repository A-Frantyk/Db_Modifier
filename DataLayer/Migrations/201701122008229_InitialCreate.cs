namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DevTest",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Impressions = c.Int(),
                        AffiliateName = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DevTest");
        }
    }
}
