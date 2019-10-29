namespace DAS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScheduleDayRelModelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ScheduleDayRels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ScheduleId = c.Int(nullable: false),
                        DayName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ScheduleDayRels");
        }
    }
}
