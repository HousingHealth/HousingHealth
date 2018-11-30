namespace HH.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTaxTrsfrObsevervations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Observation_types",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IsActive = c.Boolean(nullable: false),
                        CreatedByDate = c.DateTime(nullable: false),
                        CreatedByUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedByUser_Id, cascadeDelete: true)
                .Index(t => t.CreatedByUser_Id);
            
            CreateTable(
                "dbo.Observations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        time_stamp = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedByDate = c.DateTime(nullable: false),
                        CreatedByUser_Id = c.String(nullable: false, maxLength: 128),
                        Observation_Types_ID = c.Int(),
                        Properties_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedByUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Observation_types", t => t.Observation_Types_ID)
                .ForeignKey("dbo.Properties", t => t.Properties_ID, cascadeDelete: false)
                .Index(t => t.CreatedByUser_Id)
                .Index(t => t.Observation_Types_ID)
                .Index(t => t.Properties_ID);
            
            CreateTable(
                "dbo.Tax_records",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        delinquent_amount = c.Single(nullable: false),
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
            
            CreateTable(
                "dbo.Transfers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        sale_date = c.DateTime(nullable: false),
                        sale_amount = c.Single(nullable: false),
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
            DropForeignKey("dbo.Transfers", "Properties_ID", "dbo.Properties");
            DropForeignKey("dbo.Transfers", "CreatedByUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tax_records", "Properties_ID", "dbo.Properties");
            DropForeignKey("dbo.Tax_records", "CreatedByUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Observations", "Properties_ID", "dbo.Properties");
            DropForeignKey("dbo.Observations", "Observation_Types_ID", "dbo.Observation_types");
            DropForeignKey("dbo.Observations", "CreatedByUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Observation_types", "CreatedByUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Transfers", new[] { "Properties_ID" });
            DropIndex("dbo.Transfers", new[] { "CreatedByUser_Id" });
            DropIndex("dbo.Tax_records", new[] { "Properties_ID" });
            DropIndex("dbo.Tax_records", new[] { "CreatedByUser_Id" });
            DropIndex("dbo.Observations", new[] { "Properties_ID" });
            DropIndex("dbo.Observations", new[] { "Observation_Types_ID" });
            DropIndex("dbo.Observations", new[] { "CreatedByUser_Id" });
            DropIndex("dbo.Observation_types", new[] { "CreatedByUser_Id" });
            DropTable("dbo.Transfers");
            DropTable("dbo.Tax_records");
            DropTable("dbo.Observations");
            DropTable("dbo.Observation_types");
        }
    }
}
