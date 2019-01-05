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
using kanban_boards.UnitOfWork;

namespace kanban_boards.Controllers.API
{
    public class KanbanListsController : ApiController
    {
        private IUnitOfWork _unitOfWork;
        public KanbanListsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/KanbanLists
        public List<KanbanListDTO> GetKanbanLists()
        {
            var listOfKanbanLists = _unitOfWork.KanbanLists.GetAll();
            var listOfKanbanDtos = new List<KanbanListDTO>();

            foreach (var kanbanList in listOfKanbanLists)
            {
                listOfKanbanDtos
                    .Add(AutoMapper.Mapper.Map<KanbanListDTO>(kanbanList)); 
            }

            return listOfKanbanDtos;
        }

        // GET: api/KanbanLists/5
        [ResponseType(typeof(KanbanListDTO))]
        public IHttpActionResult GetKanbanList(int id)
        {
            var kanbanList = _unitOfWork.KanbanLists.Get(id);
            if (kanbanList == null)
            {
                return NotFound();
            }

            var kanbanListDto = AutoMapper.Mapper.Map<KanbanListDTO>(kanbanList);
            return Ok(kanbanListDto);
        }

        // PUT: api/KanbanLists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKanbanList(int id, KanbanListDTO kanbanListDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kanbanListDto.Id)
            {
                return BadRequest();
            }

            var kanbanList = AutoMapper.Mapper.Map<KanbanList>(kanbanListDto);
            _unitOfWork.KanbanLists.Put(kanbanList);

            try
            {
                _unitOfWork.Complete();
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
        [ResponseType(typeof(KanbanListDTO))]
        public IHttpActionResult PostKanbanList(KanbanListDTO kanbanListDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var kanbanList = AutoMapper.Mapper.Map<KanbanList>(kanbanListDto);
            _unitOfWork.KanbanLists.Add(kanbanList);
            _unitOfWork.Complete();

            return CreatedAtRoute("DefaultApi", new { id = kanbanList.Id }, kanbanList);
        }

        // DELETE: api/KanbanLists/5
        [ResponseType(typeof(KanbanList))]
        public IHttpActionResult DeleteKanbanList(int id)
        {
            KanbanList kanbanList = _unitOfWork.KanbanLists.Get(id);
            if (kanbanList == null)
            {
                return NotFound();
            }

            _unitOfWork.KanbanLists.Delete(kanbanList);
            _unitOfWork.Complete();

            return Ok(kanbanList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KanbanListExists(int id)
        {
            return _unitOfWork.KanbanLists.Get(id) != null;
        }
    }
}