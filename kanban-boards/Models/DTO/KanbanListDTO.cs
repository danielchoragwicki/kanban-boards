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
            Cards = new HashSet<CardDTO>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int BoardId { get; set; }

        public ICollection<CardDTO> Cards { get; set; }

    }
}