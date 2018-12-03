namespace HH.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectFixedLengthFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Observation_types", "name", c => c.String(maxLength: 255));
            AddColumn("dbo.Observations", "value", c => c.String(maxLength: 255));
            AddColumn("dbo.Tax_records", "name", c => c.String(maxLength: 255));
            AddColumn("dbo.Tax_records", "address_street_number", c => c.String(maxLength: 32));
            AddColumn("dbo.Tax_records", "address_street_name", c => c.String(maxLength: 32));
            AddColumn("dbo.Tax_records", "address_street_direction", c => c.String(maxLength: 32));
            AddColumn("dbo.Tax_records", "address_street_suffix", c => c.String(maxLength: 32));
            AddColumn("dbo.Tax_records", "address_city", c => c.String(maxLength: 32));
            AddColumn("dbo.Tax_records", "address_state", c => c.String(maxLength: 32));
            AddColumn("dbo.Tax_records", "address_zip", c => c.String(maxLength: 32));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tax_records", "address_zip");
            DropColumn("dbo.Tax_records", "address_state");
            DropColumn("dbo.Tax_records", "address_city");
            DropColumn("dbo.Tax_records", "address_street_suffix");
            DropColumn("dbo.Tax_records", "address_street_direction");
            DropColumn("dbo.Tax_records", "address_street_name");
            DropColumn("dbo.Tax_records", "address_street_number");
            DropColumn("dbo.Tax_records", "name");
            DropColumn("dbo.Observations", "value");
            DropColumn("dbo.Observation_types", "name");
        }
    }
}
