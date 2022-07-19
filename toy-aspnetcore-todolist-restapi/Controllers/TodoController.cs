using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodolistApi.Models;

namespace TodolistApi.Controllers;

[ApiController]
[Route("todos")]
public class TodoController : ControllerBase
{
    private readonly TodoContext _context;

    public TodoController(TodoContext todoContext)
    {
        _context = todoContext;
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<TodoItem>> Get(long id)
    {
        var todoItem = await _context.TodoItems.FindAsync(id);
        if (todoItem == null)
        {
            return NotFound(id);
        }

        return todoItem;
    }

    [HttpPost]
    public async Task<ActionResult<TodoItem>> Create([FromBody] TodoItem todoItem)
    {
        _context.TodoItems.Add(todoItem);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new TodoItem() { Id = todoItem.Id }, todoItem);
    }
}