using Microsoft.AspNetCore.Http.HttpResults;
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
    public  Task<IResult> AddTask([FromBody]string description)
    {
        _addTaskHandler.Execute(description);
        return Task.FromResult(Results.Created());
    }
}