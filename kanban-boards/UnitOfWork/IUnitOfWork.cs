using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kanban_boards.Repository.ModelRepositories;

namespace kanban_boards.UnitOfWork
{
    interface IUnitOfWork : IDisposable
    {
        ICardRepository Cards { get; }
        IKanbanListRepository KanbanLists { get; }
        IBoardsRepository Boards { get; }

        int Complete();
    }
}
