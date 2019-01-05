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
using AutoMapper;
using kanban_boards.Database;
using kanban_boards.Models;
using kanban_boards.Models.DTO;
using kanban_boards.UnitOfWork;

namespace kanban_boards.Controllers.API
{
    public class BoardsController : ApiController
    {
        private IUnitOfWork _unitOfWork;
        public BoardsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Boards
        public List<BoardDTO> GetBoards()
        {
            var boardsList = _unitOfWork.Boards.GetAll();
            var boardsDtoList = new List<BoardDTO>();

            foreach (var board in boardsList)
            {
                boardsDtoList
                    .Add(AutoMapper.Mapper.Map<BoardDTO>(board));
            }

            return boardsDtoList;
        }

        // GET: api/Boards/5
        [ResponseType(typeof(BoardDTO))]
        public IHttpActionResult GetBoard(int id)
        {
            Board board = _unitOfWork.Boards.Get(id);
            if (board == null)
            {
                return NotFound();
            }
            var boardDto = AutoMapper.Mapper.Map<BoardDTO>(board);
            return Ok(boardDto);
        }

        // PUT: api/Boards/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBoard(int id, BoardDTO boardDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != boardDto.Id)
            {
                return BadRequest();
            }

            var board = AutoMapper.Mapper.Map<Board>(boardDto);
            _unitOfWork.Boards.Put(board);

            try
            {
                _unitOfWork.Complete();
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
        [ResponseType(typeof(BoardDTO))]
        public IHttpActionResult PostBoard(BoardDTO boardDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var board = AutoMapper.Mapper.Map<Board>(boardDto);
            _unitOfWork.Boards.Add(board);
            _unitOfWork.Complete();

            return CreatedAtRoute("DefaultApi", new { id = board.Id }, board);
        }

        // DELETE: api/Boards/5
        [ResponseType(typeof(Board))]
        public IHttpActionResult DeleteBoard(int id)
        {
            Board board = _unitOfWork.Boards.Get(id);
            if (board == null)
            {
                return NotFound();
            }

            _unitOfWork.Boards.Delete(board);
            _unitOfWork.Complete();

            return Ok(board);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BoardExists(int id)
        {
            return _unitOfWork.Boards.Get(id) != null;
        }
    }
}