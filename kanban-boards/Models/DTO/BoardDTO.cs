using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kanban_boards.Models.DTO
{
    public class BoardDTO
    {

        public BoardDTO()
        {
            KanbanLists = new HashSet<KanbanListDTO>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Theme { get; set; }
        public ICollection<KanbanListDTO> KanbanLists { get; set; }
    }
}