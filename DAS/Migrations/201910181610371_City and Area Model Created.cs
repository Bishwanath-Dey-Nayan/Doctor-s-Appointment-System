namespace DAS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CityandAreaModelCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CityId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DoctorRegistrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Designation = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        SpecialityId = c.Int(nullable: false),
                        MobileNo = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        BMDCNo = c.String(nullable: false),
                        Description = c.String(),
                        Degree_Spec = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 255),
                        ConfirmPassword = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Areas", "CityId", "dbo.Cities");
            DropIndex("dbo.Areas", new[] { "CityId" });
            DropTable("dbo.DoctorRegistrations");
            DropTable("dbo.Cities");
            DropTable("dbo.Areas");
        }
    }
}
