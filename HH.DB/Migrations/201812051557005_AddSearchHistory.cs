namespace HH.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSearchHistory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SearchHistories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IsActive = c.Boolean(nullable: false),
                        CreatedByDate = c.DateTime(nullable: false),
                        CreatedByUser_Id = c.String(nullable: false, maxLength: 128),
                        Properties_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedByUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Properties", t => t.Properties_ID, cascadeDelete: false)
                .Index(t => t.CreatedByUser_Id)
                .Index(t => t.Properties_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SearchHistories", "Properties_ID", "dbo.Properties");
            DropForeignKey("dbo.SearchHistories", "CreatedByUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.SearchHistories", new[] { "Properties_ID" });
            DropIndex("dbo.SearchHistories", new[] { "CreatedByUser_Id" });
            DropTable("dbo.SearchHistories");
        }
    }
}
