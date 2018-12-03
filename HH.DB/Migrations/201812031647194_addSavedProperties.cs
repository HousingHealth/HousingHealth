namespace HH.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSavedProperties : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SavedProperties",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IsActive = c.Boolean(nullable: false),
                        CreatedByDate = c.DateTime(nullable: false),
                        CreatedByUser_Id = c.String(nullable: false, maxLength: 128),
                        Property_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedByUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Properties", t => t.Property_ID, cascadeDelete: false)
                .Index(t => t.CreatedByUser_Id)
                .Index(t => t.Property_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SavedProperties", "Property_ID", "dbo.Properties");
            DropForeignKey("dbo.SavedProperties", "CreatedByUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.SavedProperties", new[] { "Property_ID" });
            DropIndex("dbo.SavedProperties", new[] { "CreatedByUser_Id" });
            DropTable("dbo.SavedProperties");
        }
    }
}
