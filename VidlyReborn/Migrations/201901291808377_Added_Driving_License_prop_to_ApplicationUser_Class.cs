namespace VidlyReborn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Driving_License_prop_to_ApplicationUser_Class : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DrivingLicense", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DrivingLicense");
        }
    }
}
