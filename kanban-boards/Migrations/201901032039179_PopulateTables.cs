namespace kanban_boards.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTables : DbMigration
    {
        public override void Up()
        {

            //Boards
            Sql("SET IDENTITY_INSERT [dbo].[Boards] ON");
            Sql("INSERT INTO dbo.Boards (Id, Name, Theme) VALUES (1, 'Test', 'Green')");
            Sql("INSERT INTO dbo.Boards (Id, Name, Theme) VALUES (2, 'Test2', 'Red')");
            Sql("SET IDENTITY_INSERT [dbo].[Boards] OFF");


            //KanbanList
            Sql("SET IDENTITY_INSERT [dbo].[KanbanLists] ON");
            Sql("INSERT INTO dbo.KanbanLists (Id, Name, BoardId) VALUES (1, 'TestList', 1)");
            Sql("INSERT INTO dbo.KanbanLists (Id, Name, BoardId) VALUES (2, 'TestList', 2)");
            Sql("SET IDENTITY_INSERT [dbo].[KanbanLists] OFF");


            //Cards
            Sql(@"INSERT INTO dbo.Cards (Name, Description, StartDate, EndDate, KanbanListID) 
                            VALUES ('TestCard', 'TestDesc', '01.01.2019', '01.25.2019', 1)");

        }

        public override void Down()
        {
        }
    }
}
