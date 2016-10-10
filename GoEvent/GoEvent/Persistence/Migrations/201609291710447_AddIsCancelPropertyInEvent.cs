namespace GoEvent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsCancelPropertyInEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "IsCancel", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "IsCancel");
        }
    }
}
