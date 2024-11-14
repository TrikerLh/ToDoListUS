using Microsoft.AspNetCore.Mvc;
using ToDoListUS.API.Application;

namespace ToDoListUS.API.Controllers;

[ApiController]
[Route("api/todo")]
public class ToDoListController : Controller
{
    private readonly AddTaskHandler _addTaskHandler;

    public ToDoListController(AddTaskHandler addTaskHandler)
    {
        _addTaskHandler = addTaskHandler;
    }

    [HttpPost("AddTask")]
    public async Task<IActionResult> AddTask([FromBody]string description)
    {
        await _addTaskHandler.Execute(description);
        return Created("", null);
    }
}