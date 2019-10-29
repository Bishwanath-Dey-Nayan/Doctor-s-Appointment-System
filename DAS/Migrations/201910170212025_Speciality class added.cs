namespace DAS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Specialityclassadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Specialities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Doctors", "SpecialityId", c => c.Int(nullable: false));
            CreateIndex("dbo.Doctors", "SpecialityId");
            AddForeignKey("dbo.Doctors", "SpecialityId", "dbo.Specialities", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "SpecialityId", "dbo.Specialities");
            DropIndex("dbo.Doctors", new[] { "SpecialityId" });
            DropColumn("dbo.Doctors", "SpecialityId");
            DropTable("dbo.Specialities");
        }
    }
}
