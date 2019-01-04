using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kanban_boards.Models;

namespace kanban_boards.Repository.ModelRepositories
{
    interface ICardRepository : IRepository<Card>
    {
        //Add specific contracts related to dbo.Cards
    }
}
