namespace DAS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fixedthescheduletable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "FirstAppointmentFee", c => c.Double(nullable: false));
            AddColumn("dbo.Schedules", "NextMeetingFee", c => c.String());
            DropColumn("dbo.Schedules", "Fee");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Schedules", "Fee", c => c.Double(nullable: false));
            DropColumn("dbo.Schedules", "NextMeetingFee");
            DropColumn("dbo.Schedules", "FirstAppointmentFee");
        }
    }
}
