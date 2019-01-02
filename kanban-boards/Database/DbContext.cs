using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using kanban_boards.Models;

namespace kanban_boards.Database
{
    public class DbContext : System.Data.Entity.DbContext
    {
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<KanbanList> KanbanLists { get; set; }


        public DbContext()
        {
            
        }

    }
}