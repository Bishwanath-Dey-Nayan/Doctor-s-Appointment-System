namespace DAS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chambermodelfix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Chambers", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Chambers", "Name");
        }
    }
}
