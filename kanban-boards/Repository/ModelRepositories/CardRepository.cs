using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using kanban_boards.Database;
using kanban_boards.Models;

namespace kanban_boards.Repository.ModelRepositories
{
    public class CardRepository : Repository<Card>,ICardRepository
    {
        public CardRepository(Database.DbContext context) : base(context)
        {
        }
    }
}