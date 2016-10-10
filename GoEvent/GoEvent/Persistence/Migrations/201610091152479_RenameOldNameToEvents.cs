namespace GoEvent.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class RenameOldNameToEvents : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "ArtistId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Events", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Attendances", "EventId", "dbo.Events");
            DropForeignKey("dbo.Notifications", "Event_Id", "dbo.Events");
            DropIndex("dbo.Events", new[] { "ArtistId" });
            DropIndex("dbo.Events", new[] { "GenreId" });
            DropIndex("dbo.Attendances", new[] { "EventId" });
            DropIndex("dbo.Notifications", new[] { "Event_Id" });
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCancel = c.Boolean(nullable: false),
                        ArtistId = c.String(nullable: false, maxLength: 128),
                        DateTime = c.DateTime(nullable: false),
                        Venue = c.String(nullable: false, maxLength: 255),
                        GenreId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ArtistId, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.ArtistId)
                .Index(t => t.GenreId);
            
            AddColumn("dbo.Attendances", "EventId", c => c.Int(nullable: false));
            AddColumn("dbo.Notifications", "Event_Id", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.Attendances");
            AddPrimaryKey("dbo.Attendances", new[] { "EventId", "AttendeeId" });
            CreateIndex("dbo.Attendances", "EventId");
            CreateIndex("dbo.Notifications", "Event_Id");
            AddForeignKey("dbo.Attendances", "EventId", "dbo.Events", "Id");
            AddForeignKey("dbo.Notifications", "Event_Id", "dbo.Events", "Id", cascadeDelete: true);
            DropColumn("dbo.Attendances", "EventId");
            DropColumn("dbo.Notifications", "Event_Id");
            DropTable("dbo.Events");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCancel = c.Boolean(nullable: false),
                        ArtistId = c.String(nullable: false, maxLength: 128),
                        DateTime = c.DateTime(nullable: false),
                        Venue = c.String(nullable: false, maxLength: 255),
                        GenreId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Notifications", "Event_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Attendances", "EventId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Notifications", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.Events", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Attendances", "EventId", "dbo.Events");
            DropForeignKey("dbo.Events", "ArtistId", "dbo.AspNetUsers");
            DropIndex("dbo.Notifications", new[] { "Event_Id" });
            DropIndex("dbo.Events", new[] { "GenreId" });
            DropIndex("dbo.Attendances", new[] { "EventId" });
            DropIndex("dbo.Events", new[] { "ArtistId" });
            DropPrimaryKey("dbo.Attendances");
            AddPrimaryKey("dbo.Attendances", new[] { "EventId", "AttendeeId" });
            DropColumn("dbo.Notifications", "Event_Id");
            DropColumn("dbo.Attendances", "EventId");
            DropTable("dbo.Events");
            CreateIndex("dbo.Notifications", "Event_Id");
            CreateIndex("dbo.Attendances", "EventId");
            CreateIndex("dbo.Events", "GenreId");
            CreateIndex("dbo.Events", "ArtistId");
            AddForeignKey("dbo.Notifications", "Event_Id", "dbo.Events", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Attendances", "EventId", "dbo.Events", "Id");
            AddForeignKey("dbo.Events", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Events", "ArtistId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
