namespace HH.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_HistoryScore_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HistoryScores",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RateOfComplaints = c.Int(nullable: false),
                        NumViolations = c.Int(nullable: false),
                        PaceOfResolution = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedByDate = c.DateTime(nullable: false),
                        CreatedByUser_Id = c.String(nullable: false, maxLength: 128),
                        Properties_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedByUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Properties", t => t.Properties_ID)
                .Index(t => t.CreatedByUser_Id)
                .Index(t => t.Properties_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HistoryScores", "Properties_ID", "dbo.Properties");
            DropForeignKey("dbo.HistoryScores", "CreatedByUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.HistoryScores", new[] { "Properties_ID" });
            DropIndex("dbo.HistoryScores", new[] { "CreatedByUser_Id" });
            DropTable("dbo.HistoryScores");
        }
    }
}
