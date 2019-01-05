namespace kanban_boards.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseConstraints : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Boards", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.KanbanLists", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Cards", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cards", "Name", c => c.String());
            AlterColumn("dbo.KanbanLists", "Name", c => c.String());
            AlterColumn("dbo.Boards", "Name", c => c.String());
        }
    }
}
