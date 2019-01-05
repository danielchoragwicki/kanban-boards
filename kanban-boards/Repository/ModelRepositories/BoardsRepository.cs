using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using kanban_boards.Models;

namespace kanban_boards.Repository.ModelRepositories
{
    public class BoardsRepository : Repository<Board>, IBoardsRepository
    {
        public BoardsRepository(Database.DbContext context) : base(context)
        {
        }
    }
}