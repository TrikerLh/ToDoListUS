using Microsoft.AspNetCore.Mvc;

namespace ToDoListUS.API.Controllers;

[ApiController]
[Route("api/todo")]
public class ToDoListController : Controller
{
    [HttpPost("AddTask")]
    public void AddTask([FromBody]string description)
    {
        throw new NotImplementedException();
    }
}