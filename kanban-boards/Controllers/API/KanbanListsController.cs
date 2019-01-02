using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using kanban_boards.Database;
using kanban_boards.Models;

namespace kanban_boards.Controllers.API
{
    //TODO AutoMapper
    //TODO Make DTO's
    //TODO Make Controllers

    public class KanbanListsController : ApiController
    {
        private Database.DbContext db = new Database.DbContext();

        // GET: api/KanbanLists
        public IQueryable<KanbanList> GetKanbanLists()
        {
            return db.KanbanLists;
        }

        // GET: api/KanbanLists/5
        [ResponseType(typeof(KanbanList))]
        public IHttpActionResult GetKanbanList(int id)
        {
            KanbanList kanbanList = db.KanbanLists.Find(id);
            if (kanbanList == null)
            {
                return NotFound();
            }

            return Ok(kanbanList);
        }

        // PUT: api/KanbanLists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKanbanList(int id, KanbanList kanbanList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kanbanList.Id)
            {
                return BadRequest();
            }

            db.Entry(kanbanList).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KanbanListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/KanbanLists
        [ResponseType(typeof(KanbanList))]
        public IHttpActionResult PostKanbanList(KanbanList kanbanList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.KanbanLists.Add(kanbanList);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = kanbanList.Id }, kanbanList);
        }

        // DELETE: api/KanbanLists/5
        [ResponseType(typeof(KanbanList))]
        public IHttpActionResult DeleteKanbanList(int id)
        {
            KanbanList kanbanList = db.KanbanLists.Find(id);
            if (kanbanList == null)
            {
                return NotFound();
            }

            db.KanbanLists.Remove(kanbanList);
            db.SaveChanges();

            return Ok(kanbanList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KanbanListExists(int id)
        {
            return db.KanbanLists.Count(e => e.Id == id) > 0;
        }
    }
}