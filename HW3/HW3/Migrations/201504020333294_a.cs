namespace HW3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activities", "Description", c => c.String(nullable: false, maxLength: 2000));
            DropColumn("dbo.Activities", "Descripton");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Activities", "Descripton", c => c.String(nullable: false, maxLength: 2000));
            DropColumn("dbo.Activities", "Description");
        }
    }
}
