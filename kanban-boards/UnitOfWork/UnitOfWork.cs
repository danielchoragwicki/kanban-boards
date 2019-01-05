using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using kanban_boards.Repository.ModelRepositories;

namespace kanban_boards.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Database.DbContext _context;

        public UnitOfWork(Database.DbContext context)
        {
            _context = context;
            Cards = new CardRepository(_context);
            KanbanLists = new KanbanListRepository(_context);
            Boards = new BoardsRepository(_context);
        }

        public ICardRepository Cards { get; private set; }
        public IKanbanListRepository KanbanLists { get; private set; }
        public IBoardsRepository Boards { get; private set; }
        public int Complete()
        {
           return  _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}