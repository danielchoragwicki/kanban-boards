namespace kanban_boards.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OptionalNulLValuesInDatesColumns : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cards", "StartDate", c => c.DateTime());
            AlterColumn("dbo.Cards", "EndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cards", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Cards", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}
