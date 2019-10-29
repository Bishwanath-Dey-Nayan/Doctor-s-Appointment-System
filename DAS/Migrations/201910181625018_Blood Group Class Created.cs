namespace DAS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BloodGroupClassCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BloodGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BloodGroups");
        }
    }
}
