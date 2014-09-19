namespace SCTRC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedMoreStuff : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TeamEvents", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.TeamEvents", "Event_Id", "dbo.Events");
            DropIndex("dbo.TeamEvents", new[] { "Team_Id" });
            DropIndex("dbo.TeamEvents", new[] { "Event_Id" });
            AddColumn("dbo.Events", "Team_Id", c => c.Int());
            CreateIndex("dbo.Events", "Team_Id");
            AddForeignKey("dbo.Events", "Team_Id", "dbo.Teams", "Id");
            DropTable("dbo.TeamEvents");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TeamEvents",
                c => new
                    {
                        Team_Id = c.Int(nullable: false),
                        Event_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Team_Id, t.Event_Id });
            
            DropForeignKey("dbo.Events", "Team_Id", "dbo.Teams");
            DropIndex("dbo.Events", new[] { "Team_Id" });
            DropColumn("dbo.Events", "Team_Id");
            CreateIndex("dbo.TeamEvents", "Event_Id");
            CreateIndex("dbo.TeamEvents", "Team_Id");
            AddForeignKey("dbo.TeamEvents", "Event_Id", "dbo.Events", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TeamEvents", "Team_Id", "dbo.Teams", "Id", cascadeDelete: true);
        }
    }
}
