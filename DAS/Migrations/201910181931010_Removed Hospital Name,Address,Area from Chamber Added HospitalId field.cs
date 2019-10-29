namespace DAS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedHospitalNameAddressAreafromChamberAddedHospitalIdfield : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Chambers", "HospitalID", c => c.Int(nullable: false));
            CreateIndex("dbo.Chambers", "HospitalID");
            AddForeignKey("dbo.Chambers", "HospitalID", "dbo.Hospitals", "Id");
            DropColumn("dbo.Chambers", "HospitalName");
            DropColumn("dbo.Chambers", "Area");
            DropColumn("dbo.Chambers", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Chambers", "Address", c => c.String());
            AddColumn("dbo.Chambers", "Area", c => c.String());
            AddColumn("dbo.Chambers", "HospitalName", c => c.String());
            DropForeignKey("dbo.Chambers", "HospitalID", "dbo.Hospitals");
            DropIndex("dbo.Chambers", new[] { "HospitalID" });
            DropColumn("dbo.Chambers", "HospitalID");
        }
    }
}
