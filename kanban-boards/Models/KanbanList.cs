using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace kanban_boards.Models
{
    public class KanbanList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Board Board { get; set; }
        [ForeignKey("Board")]
        public int BoardId { get; set; }

        public virtual ICollection<Card> Cards { get; set; }

    }
}