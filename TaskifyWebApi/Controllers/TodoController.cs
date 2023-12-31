﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.Net;
using TaskifyWebApi.Models;
using TaskifyWebApi.Services.TodoService;

namespace TaskifyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {

        private TodoService _todoService;
        public TodoController(TodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Todo>>> GetAllTodos()
        {
            var result = await _todoService.GetAllTodos();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<List<Todo>>> GetSingleTodo(int id)
        {
            var result =  await _todoService.GetSingleTodo(id);
            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpPost]

        public async Task<ActionResult> AddTodo(string title, string description, bool iscomplete)
        {
            var result = await _todoService.AddTodo(title, description, iscomplete);
            return Ok(result);
        }


        [HttpDelete("{id}")]

        public async Task <ActionResult> DeleteTodo(int id)
        {
            var result = await _todoService.DeleteTodo(id);
            return Ok(result);
        }


        [HttpPut("{id}")]

        public async Task<ActionResult> UpdateTask(int id, Todo todo)
        {
            var result = await _todoService.UpdateTodo(id,todo);
            return Ok(result);

        }
    }
}
