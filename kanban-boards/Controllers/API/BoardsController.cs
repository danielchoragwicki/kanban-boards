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
using kanban_boards.Models.DTO;

namespace kanban_boards.Controllers.API
{
    public class BoardsController : ApiController
    {
        private Database.DbContext db = new Database.DbContext();

        // GET: api/Boards
        public List<BoardDTO> GetBoards()
        {
            var boardsList = db.Boards.ToList();
            var boardsDtoList = new List<BoardDTO>();

            foreach (var board in boardsList)
            {
                boardsDtoList
                    .Add(AutoMapper.Mapper.Map<BoardDTO>(board));
            }

            return boardsDtoList;
        }

        // GET: api/Boards/5
        [ResponseType(typeof(Board))]
        public IHttpActionResult GetBoard(int id)
        {
            Board board = db.Boards.Find(id);
            if (board == null)
            {
                return NotFound();
            }

            return Ok(board);
        }

        // PUT: api/Boards/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBoard(int id, Board board)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != board.Id)
            {
                return BadRequest();
            }

            db.Entry(board).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoardExists(id))
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

        // POST: api/Boards
        [ResponseType(typeof(Board))]
        public IHttpActionResult PostBoard(Board board)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Boards.Add(board);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = board.Id }, board);
        }

        // DELETE: api/Boards/5
        [ResponseType(typeof(Board))]
        public IHttpActionResult DeleteBoard(int id)
        {
            Board board = db.Boards.Find(id);
            if (board == null)
            {
                return NotFound();
            }

            db.Boards.Remove(board);
            db.SaveChanges();

            return Ok(board);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BoardExists(int id)
        {
            return db.Boards.Count(e => e.Id == id) > 0;
        }
    }
}