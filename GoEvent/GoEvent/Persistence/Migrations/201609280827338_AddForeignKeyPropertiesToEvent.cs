namespace GoEvent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyPropertiesToEvent : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Events", name: "Artist_Id", newName: "ArtistId");
            RenameColumn(table: "dbo.Events", name: "Genre_Id", newName: "GenreId");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Events", name: "GenreId", newName: "Genre_Id");
            RenameColumn(table: "dbo.Events", name: "ArtistId", newName: "Artist_Id");
        }
    }
}
