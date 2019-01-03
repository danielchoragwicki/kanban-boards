namespace kanban_boards.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatePeopleTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.People (Name, Age) VALUES ('Maciej', 23)");
            Sql("INSERT INTO dbo.People (Name, Age) VALUES ('Janusz', 23)");
        }
        
        public override void Down()
        {
        }
    }
}
