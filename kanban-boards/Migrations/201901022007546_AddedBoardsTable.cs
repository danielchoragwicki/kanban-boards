namespace kanban_boards.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBoardsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Boards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Theme = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.KanbanLists", "BoardId", c => c.Int(nullable: false));
            CreateIndex("dbo.KanbanLists", "BoardId");
            AddForeignKey("dbo.KanbanLists", "BoardId", "dbo.Boards", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KanbanLists", "BoardId", "dbo.Boards");
            DropIndex("dbo.KanbanLists", new[] { "BoardId" });
            DropColumn("dbo.KanbanLists", "BoardId");
            DropTable("dbo.Boards");
        }
    }
}
