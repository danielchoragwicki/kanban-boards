﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kanban_boards.Models;

namespace kanban_boards.Repository.ModelRepositories
{
    interface IKanbanListRepository : IRepository<KanbanList>
    {
        //Add specific contracts related to dbo.KanbanLists
    }
}
