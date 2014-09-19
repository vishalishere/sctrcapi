namespace SCTRC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedIdToGuid : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "UserId", c => c.Int(nullable: false));
        }
    }
}
