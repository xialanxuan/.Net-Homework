namespace HW3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserEntries", "HourlyCost", c => c.Double(nullable: false));
            DropColumn("dbo.ProjectActivities", "EstimateTotalTime");
            DropColumn("dbo.UserEntries", "HourlyCoust");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserEntries", "HourlyCoust", c => c.Double(nullable: false));
            AddColumn("dbo.ProjectActivities", "EstimateTotalTime", c => c.Time(nullable: false, precision: 7));
            DropColumn("dbo.UserEntries", "HourlyCost");
        }
    }
}
