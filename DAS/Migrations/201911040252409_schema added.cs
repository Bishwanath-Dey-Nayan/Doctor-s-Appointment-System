namespace DAS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class schemaadded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Schedules", "AppointmentDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Schedules", "AppointmentDate", c => c.DateTime());
        }
    }
}
