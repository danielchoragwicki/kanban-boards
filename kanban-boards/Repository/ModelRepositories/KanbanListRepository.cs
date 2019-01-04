using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using kanban_boards.Models;

namespace kanban_boards.Repository.ModelRepositories
{
    public class KanbanListRepository : Repository<KanbanList>, IKanbanListRepository
    {
        public KanbanListRepository(Database.DbContext context) : base(context)
        {

        }
    }
}