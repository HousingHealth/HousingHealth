namespace HH.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Observation_types",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 255),
                        IsActive = c.Boolean(nullable: false),
                        CreatedByDate = c.DateTime(nullable: false),
                        CreatedByUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedByUser_Id, cascadeDelete: true)
                .Index(t => t.CreatedByUser_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Observations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        time_stamp = c.DateTime(nullable: false),
                        value = c.String(maxLength: 255),
                        IsActive = c.Boolean(nullable: false),
                        CreatedByDate = c.DateTime(nullable: false),
                        CreatedByUser_Id = c.String(nullable: false, maxLength: 128),
                        Observation_Types_ID = c.Int(),
                        Properties_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedByUser_Id, cascadeDelete: false)
                .ForeignKey("dbo.Observation_types", t => t.Observation_Types_ID)
                .ForeignKey("dbo.Properties", t => t.Properties_ID, cascadeDelete: true)
                .Index(t => t.CreatedByUser_Id)
                .Index(t => t.Observation_Types_ID)
                .Index(t => t.Properties_ID);
            
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        towner = c.String(),
                        parcel = c.String(),
                        number = c.String(),
                        street = c.String(),
                        pclass = c.String(),
                        yrbuilt = c.Int(nullable: false),
                        date = c.DateTime(nullable: false),
                        lsaleamt = c.Decimal(nullable: false, precision: 18, scale: 2),
                        luc = c.String(),
                        luc_descr = c.String(),
                        BLOCK10 = c.String(),
                        BLOCKGR10 = c.String(),
                        tract10 = c.String(),
                        MAILNAME = c.String(),
                        mailname1 = c.String(),
                        MAIL_STREET_DIRECTION = c.String(),
                        MAIL_STREET_NAME = c.String(),
                        MAIL_STREET_NUMBER = c.String(),
                        MAIL_STREET_SUFFIX = c.String(),
                        MAIL_CITY = c.String(),
                        MAIL_STATE = c.String(),
                        MAIL_ZIPCODE = c.String(),
                        TOTAL_NET_DELQ_BALANCE = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedByDate = c.DateTime(nullable: false),
                        CreatedByUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedByUser_Id, cascadeDelete: true)
                .Index(t => t.CreatedByUser_Id);
            
            CreateTable(
                "dbo.OwnershipFreqs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        mailname1 = c.String(),
                        count = c.Single(nullable: false),
                        percent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsActive = c.Boolean(nullable: false),
                        CreatedByDate = c.DateTime(nullable: false),
                        CreatedByUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedByUser_Id, cascadeDelete: true)
                .Index(t => t.CreatedByUser_Id);
            
            CreateTable(
                "dbo.RentalRegistrations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RR_ID = c.String(),
                        RR_File_Date = c.DateTime(nullable: false),
                        RR_Address = c.String(),
                        RR_PPN = c.String(),
                        RR_Units = c.Single(nullable: false),
                        RR_status = c.String(),
                        RR_owner = c.String(),
                        RR_owner_orig = c.String(),
                        RR_owner_add = c.String(),
                        RR_addl_contact = c.String(),
                        RR_addl_contact_orig = c.String(),
                        RR_addl_contact_relation = c.String(),
                        RR_addl_contact_address = c.String(),
                        parcel1 = c.String(),
                        parlength = c.Single(nullable: false),
                        parcel = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedByDate = c.DateTime(nullable: false),
                        CreatedByUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedByUser_Id, cascadeDelete: true)
                .Index(t => t.CreatedByUser_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
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
            
            CreateTable(
                "dbo.Tax_records",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 255),
                        address_street_number = c.String(maxLength: 32),
                        address_street_name = c.String(maxLength: 32),
                        address_street_direction = c.String(maxLength: 32),
                        address_street_suffix = c.String(maxLength: 32),
                        address_city = c.String(maxLength: 32),
                        address_state = c.String(maxLength: 32),
                        address_zip = c.String(maxLength: 32),
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
            DropForeignKey("dbo.SavedProperties", "Property_ID", "dbo.Properties");
            DropForeignKey("dbo.SavedProperties", "CreatedByUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.RentalRegistrations", "CreatedByUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.OwnershipFreqs", "CreatedByUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Observations", "Properties_ID", "dbo.Properties");
            DropForeignKey("dbo.Properties", "CreatedByUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Observations", "Observation_Types_ID", "dbo.Observation_types");
            DropForeignKey("dbo.Observations", "CreatedByUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Observation_types", "CreatedByUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Transfers", new[] { "Properties_ID" });
            DropIndex("dbo.Transfers", new[] { "CreatedByUser_Id" });
            DropIndex("dbo.Tax_records", new[] { "Properties_ID" });
            DropIndex("dbo.Tax_records", new[] { "CreatedByUser_Id" });
            DropIndex("dbo.SavedProperties", new[] { "Property_ID" });
            DropIndex("dbo.SavedProperties", new[] { "CreatedByUser_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.RentalRegistrations", new[] { "CreatedByUser_Id" });
            DropIndex("dbo.OwnershipFreqs", new[] { "CreatedByUser_Id" });
            DropIndex("dbo.Properties", new[] { "CreatedByUser_Id" });
            DropIndex("dbo.Observations", new[] { "Properties_ID" });
            DropIndex("dbo.Observations", new[] { "Observation_Types_ID" });
            DropIndex("dbo.Observations", new[] { "CreatedByUser_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Observation_types", new[] { "CreatedByUser_Id" });
            DropTable("dbo.Transfers");
            DropTable("dbo.Tax_records");
            DropTable("dbo.SavedProperties");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RentalRegistrations");
            DropTable("dbo.OwnershipFreqs");
            DropTable("dbo.Properties");
            DropTable("dbo.Observations");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Observation_types");
        }
    }
}
