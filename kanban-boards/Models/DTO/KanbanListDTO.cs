using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kanban_boards.Models.DTO
{
    public class KanbanListDTO
    {

        public KanbanListDTO()
        {
            Cards = new HashSet<Card>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Card> Cards { get; set; }
    }
}