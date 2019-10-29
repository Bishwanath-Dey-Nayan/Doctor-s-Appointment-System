namespace DAS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BlooddonormodelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BloodDonors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MobileNo = c.String(),
                        Email = c.String(),
                        Gender = c.String(),
                        BloodGroupId = c.Int(nullable: false),
                        cityId = c.Int(nullable: false),
                        AreaId = c.Int(nullable: false),
                        AdditionalAddress = c.String(),
                        isRequested = c.Boolean(nullable: false),
                        isConfirmed = c.Boolean(nullable: false),
                        LastBloodDonateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Areas", t => t.AreaId)
                .ForeignKey("dbo.BloodGroups", t => t.BloodGroupId)
                .ForeignKey("dbo.Cities", t => t.cityId)
                .Index(t => t.BloodGroupId)
                .Index(t => t.cityId)
                .Index(t => t.AreaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BloodDonors", "cityId", "dbo.Cities");
            DropForeignKey("dbo.BloodDonors", "BloodGroupId", "dbo.BloodGroups");
            DropForeignKey("dbo.BloodDonors", "AreaId", "dbo.Areas");
            DropIndex("dbo.BloodDonors", new[] { "AreaId" });
            DropIndex("dbo.BloodDonors", new[] { "cityId" });
            DropIndex("dbo.BloodDonors", new[] { "BloodGroupId" });
            DropTable("dbo.BloodDonors");
        }
    }
}
