namespace SCTRC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedIden : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Activities");
            DropPrimaryKey("dbo.Humans");
            DropPrimaryKey("dbo.Questions");
            AlterColumn("dbo.Activities", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Humans", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Questions", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Activities", "Id");
            AddPrimaryKey("dbo.Humans", "Id");
            AddPrimaryKey("dbo.Questions", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Questions");
            DropPrimaryKey("dbo.Humans");
            DropPrimaryKey("dbo.Activities");
            AlterColumn("dbo.Questions", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Humans", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Activities", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Questions", "Id");
            AddPrimaryKey("dbo.Humans", "Id");
            AddPrimaryKey("dbo.Activities", "Id");
        }
    }
}
