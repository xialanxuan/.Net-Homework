namespace HW3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notwork : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        ActivityId = c.Int(nullable: false, identity: true),
                        Descripton = c.String(nullable: false, maxLength: 500),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ActivityId);
            
            CreateTable(
                "dbo.ProjectActivities",
                c => new
                    {
                        ProjectActivityId = c.Int(nullable: false, identity: true),
                        ActivityId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        EstimateTotalTime = c.Time(nullable: false, precision: 7),
                        TimeSpent = c.Time(nullable: false, precision: 7),
                        Project_ProjectId = c.Int(),
                    })
                .PrimaryKey(t => t.ProjectActivityId)
                .ForeignKey("dbo.Activities", t => t.ActivityId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.Project_ProjectId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ActivityId)
                .Index(t => t.ProjectId)
                .Index(t => t.Project_ProjectId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        Description = c.String(),
                        Archived = c.Boolean(nullable: false),
                        CreatorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.Users", t => t.CreatorId, cascadeDelete: true)
                .Index(t => t.CreatorId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        MiddleInit = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        Occupation = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.UserActivities",
                c => new
                    {
                        UserActivityId = c.Int(nullable: false, identity: true),
                        ActivityId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserActivityId)
                .ForeignKey("dbo.Activities", t => t.ActivityId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ActivityId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserEntries",
                c => new
                    {
                        UserEntryId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        ActivityId = c.Int(nullable: false),
                        HourlyCoust = c.Double(nullable: false),
                        HourlyBillRate = c.Double(nullable: false),
                        Billable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserEntryId)
                .ForeignKey("dbo.Activities", t => t.ActivityId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ProjectId)
                .Index(t => t.ActivityId);
            
            CreateTable(
                "dbo.TimeEntries",
                c => new
                    {
                        TimeEntryId = c.Int(nullable: false, identity: true),
                        UserEntryId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TimeEntryId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.UserEntries", t => t.UserEntryId)
                .Index(t => t.UserEntryId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Visitors",
                c => new
                    {
                        IP = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.IP);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectActivities", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.ProjectActivities", "Project_ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Projects", "CreatorId", "dbo.Users");
            DropForeignKey("dbo.UserEntries", "UserId", "dbo.Users");
            DropForeignKey("dbo.TimeEntries", "UserEntryId", "dbo.UserEntries");
            DropForeignKey("dbo.TimeEntries", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.UserEntries", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.UserEntries", "ActivityId", "dbo.Activities");
            DropForeignKey("dbo.UserActivities", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserActivities", "ActivityId", "dbo.Activities");
            DropForeignKey("dbo.ProjectActivities", "ActivityId", "dbo.Activities");
            DropIndex("dbo.TimeEntries", new[] { "ProjectId" });
            DropIndex("dbo.TimeEntries", new[] { "UserEntryId" });
            DropIndex("dbo.UserEntries", new[] { "ActivityId" });
            DropIndex("dbo.UserEntries", new[] { "ProjectId" });
            DropIndex("dbo.UserEntries", new[] { "UserId" });
            DropIndex("dbo.UserActivities", new[] { "UserId" });
            DropIndex("dbo.UserActivities", new[] { "ActivityId" });
            DropIndex("dbo.Projects", new[] { "CreatorId" });
            DropIndex("dbo.ProjectActivities", new[] { "Project_ProjectId" });
            DropIndex("dbo.ProjectActivities", new[] { "ProjectId" });
            DropIndex("dbo.ProjectActivities", new[] { "ActivityId" });
            DropTable("dbo.Visitors");
            DropTable("dbo.TimeEntries");
            DropTable("dbo.UserEntries");
            DropTable("dbo.UserActivities");
            DropTable("dbo.Users");
            DropTable("dbo.Projects");
            DropTable("dbo.ProjectActivities");
            DropTable("dbo.Activities");
        }
    }
}
