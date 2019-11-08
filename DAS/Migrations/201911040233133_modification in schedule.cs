namespace DAS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificationinschedule : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "AppointmentDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schedules", "AppointmentDate");
        }
    }
}
