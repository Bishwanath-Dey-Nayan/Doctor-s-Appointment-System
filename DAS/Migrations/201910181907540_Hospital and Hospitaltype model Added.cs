namespace DAS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HospitalandHospitaltypemodelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hospitals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CityId = c.Int(nullable: false),
                        AreaId = c.Int(nullable: false),
                        HospitalTypeId = c.Int(nullable: false),
                        AdditionalAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Areas", t => t.AreaId)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .ForeignKey("dbo.HospitalTypes", t => t.HospitalTypeId)
                .Index(t => t.CityId)
                .Index(t => t.AreaId)
                .Index(t => t.HospitalTypeId);
            
            CreateTable(
                "dbo.HospitalTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Hospitals", "HospitalTypeId", "dbo.HospitalTypes");
            DropForeignKey("dbo.Hospitals", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Hospitals", "AreaId", "dbo.Areas");
            DropIndex("dbo.Hospitals", new[] { "HospitalTypeId" });
            DropIndex("dbo.Hospitals", new[] { "AreaId" });
            DropIndex("dbo.Hospitals", new[] { "CityId" });
            DropTable("dbo.HospitalTypes");
            DropTable("dbo.Hospitals");
        }
    }
}
