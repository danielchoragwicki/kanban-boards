using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace kanban_boards.Models
{
    public class Board
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public string Theme { get; set; }
        public virtual ICollection<KanbanList> KanbanLists { get; set; }
    }
}