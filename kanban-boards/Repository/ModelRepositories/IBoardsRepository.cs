using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using kanban_boards.Models;

namespace kanban_boards.Repository.ModelRepositories
{
    interface IBoardsRepository : IRepository<Board>
    {
        //Add specific contracts related to dbo.Boards
    }
}