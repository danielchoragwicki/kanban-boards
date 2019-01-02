using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kanban_boards.Models
{
    public class Board
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Theme { get; set; }
        public virtual ICollection<KanbanList> KanbanLists { get; set; }
    }
}