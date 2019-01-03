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
    public class CardsController : ApiController
    {
        private Database.DbContext db = new Database.DbContext();

        // GET: api/Cards
        public List<CardDTO> GetCards()
        {
            var cardsList = db.Cards.ToList();
            var cardsDtoList = new List<CardDTO>();

            foreach (var card in cardsList)
            {
                cardsDtoList
                    .Add(AutoMapper.Mapper.Map<CardDTO>(card));
            }

            return cardsDtoList;
        }

        // GET: api/Cards/5
        [ResponseType(typeof(CardDTO))]
        public IHttpActionResult GetCard(int id)
        {
            var card = db.Cards.Find(id);
            if (card == null)
            {
                return NotFound();
            }

            var cardDto = AutoMapper.Mapper.Map<CardDTO>(card);
            return Ok(cardDto);
        }

        // PUT: api/Cards/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCard(int id, CardDTO cardDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cardDto.Id)
            {
                return BadRequest();
            }

            var card = AutoMapper.Mapper.Map<Card>(cardDto);
            db.Entry(card).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardExists(id))
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

        // POST: api/Cards
        [ResponseType(typeof(CardDTO))]
        public IHttpActionResult PostCard(CardDTO cardDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var card = AutoMapper.Mapper.Map<Card>(cardDto);
            db.Cards.Add(card);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = card.Id }, card);
        }

        // DELETE: api/Cards/5
        [ResponseType(typeof(Card))]
        public IHttpActionResult DeleteCard(int id)
        {
            var card = db.Cards.Find(id);
            if (card == null)
            {
                return NotFound();
            }

            db.Cards.Remove(card);
            db.SaveChanges();

            return Ok(card);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CardExists(int id)
        {
            return db.Cards.Count(e => e.Id == id) > 0;
        }
    }
}