namespace SCTRC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedEvent : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Activities", "EventId", "dbo.Events");
            DropForeignKey("dbo.Questions", "EventId", "dbo.Events");
            DropForeignKey("dbo.Humans", "EventId", "dbo.Events");
            DropIndex("dbo.Activities", new[] { "EventId" });
            DropIndex("dbo.Questions", new[] { "EventId" });
            DropIndex("dbo.Humans", new[] { "EventId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Humans", "EventId");
            CreateIndex("dbo.Questions", "EventId");
            CreateIndex("dbo.Activities", "EventId");
            AddForeignKey("dbo.Humans", "EventId", "dbo.Events", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Questions", "EventId", "dbo.Events", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Activities", "EventId", "dbo.Events", "Id", cascadeDelete: true);
        }
    }
}
