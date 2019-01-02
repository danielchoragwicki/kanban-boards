namespace kanban_boards.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedKanbanListTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KanbanLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Cards", "KanbanListId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cards", "KanbanListId");
            AddForeignKey("dbo.Cards", "KanbanListId", "dbo.KanbanLists", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cards", "KanbanListId", "dbo.KanbanLists");
            DropIndex("dbo.Cards", new[] { "KanbanListId" });
            DropColumn("dbo.Cards", "KanbanListId");
            DropTable("dbo.KanbanLists");
        }
    }
}
