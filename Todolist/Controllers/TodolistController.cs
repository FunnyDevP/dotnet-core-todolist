using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todolist.Dto;
using Todolist.Models;
using Todolist.Repositories;

namespace Todolist.Controllers
{
    [Route("api/todolists")]
    [ApiController]
    public class TodolistController : ControllerBase
    {
        private readonly IRepository _repository;

        public TodolistController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: api/todolists
        [HttpGet]
        public IEnumerable<TodoListDto> GetAll()
        {
            var result = _repository.GetAll();
            return result.Select(r => new TodoListDto(r.Id, r.Title, r.Description, r.CreatedAt, r.UpdatedAt));
        }

        // GET: api/todolists/1
        [HttpGet("{id}")]
        public ActionResult<TodoListDto> GetById(Guid id)
        {
            var result = _repository.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            var dto = new TodoListDto(result.Id, result.Title, result.Description, result.CreatedAt, result.UpdatedAt);
            return dto;
        }

        // POST: api/todolists
        [HttpPost]
        public IActionResult Create([FromBody] CreateOrUpdateTodoListDto data)
        {
            if (data.Title != "")
            {
                BadRequest("something error");
            }

            var newData = new TodolistModel
            {
                Id = Guid.NewGuid(),
                Title = data.Title,
                Description = data.Description,
                CreatedAt = DateTime.Now,
                UpdatedAt = null
            };


            var error = _repository.Create(newData);
            if (error != null)
            {
                Console.WriteLine(error.Message);
                return StatusCode(statusCode: StatusCodes.Status500InternalServerError);
            }

            return Created("api/todolists", newData);
        }

        // PUT: api/todolists/1
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] CreateOrUpdateTodoListDto data, Guid id)
        {
            var doc = new TodolistModel
            {
                Id = id,
                Title = data.Title,
                Description = data.Description,
                UpdatedAt = DateTime.Now
            };

            var error = _repository.Update(doc);
            if (error != null)
            {
                Console.WriteLine(error.Message);
                return StatusCode(statusCode: StatusCodes.Status500InternalServerError);
            }

            return Ok("update success");
        }

        // Delete: api/todolists/1
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var error = _repository.Delete(id);
            if (error != null)
            {
                Console.WriteLine(error.Message);
                return StatusCode(statusCode: StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }
    }
}