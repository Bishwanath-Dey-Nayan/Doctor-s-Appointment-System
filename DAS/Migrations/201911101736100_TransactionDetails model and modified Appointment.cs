namespace DAS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionDetailsmodelandmodifiedAppointment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TransactionDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AppointmentId = c.Int(nullable: false),
                        MobileNo = c.String(),
                        TransactionID = c.String(),
                        isconfirmed = c.Boolean(nullable: false),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Appointments", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "Email");
            DropTable("dbo.TransactionDetails");
        }
    }
}
