namespace DAS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullabledatetimeinscheduleModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Schedules", "AppointmentDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Schedules", "AppointmentDate", c => c.DateTime(nullable: false));
        }
    }
}
