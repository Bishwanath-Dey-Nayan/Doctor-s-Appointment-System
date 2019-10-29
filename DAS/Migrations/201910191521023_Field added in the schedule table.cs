namespace DAS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fieldaddedinthescheduletable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "SlotNo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schedules", "SlotNo");
        }
    }
}
