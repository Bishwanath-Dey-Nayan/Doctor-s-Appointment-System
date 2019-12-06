namespace DAS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Serviceentity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Packages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        consutation_over_phone = c.String(),
                        AppointmentService = c.String(),
                        counselling_over_phone = c.String(),
                        sample_collection_report_del = c.String(),
                        free_medicine_del = c.String(),
                        med_intake_reminder = c.String(),
                        pick_drop_doc_visit = c.String(),
                        Emergency_ambulance_serv = c.String(),
                        hospitalization_cashback = c.String(),
                        out_paitent_cashback = c.String(),
                        Life_insurance = c.String(),
                        pack_type = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                        packtype_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PackTypes", t => t.packtype_ID)
                .Index(t => t.packtype_ID);
            
            CreateTable(
                "dbo.PackTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Packages", "packtype_ID", "dbo.PackTypes");
            DropIndex("dbo.Packages", new[] { "packtype_ID" });
            DropTable("dbo.PackTypes");
            DropTable("dbo.Packages");
        }
    }
}
