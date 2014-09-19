namespace SCTRC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedMoreStuff1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ApplicationUsers", "Activity_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicationUsers", "Activity_Id", c => c.Int());
        }
    }
}
