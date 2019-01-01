using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kanban_boards.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}