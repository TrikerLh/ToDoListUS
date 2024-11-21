using System.Net.Http.Json;
using NSubstitute;
using ToDoListUS.API.Domain;

namespace ToDoListUS.Api.Tests;

public class ToDoListAcceptanceTest
{
    private HttpClient _client;
    private CustomWebApplicationFactory _application;

    [TearDown]
    public void TearDown()
    {
        _application.Dispose();

        _client.Dispose();
    }
    
    [SetUp]
    public void Setup()
    {
        _application = new CustomWebApplicationFactory();
        _client = _application.CreateHttpClient();
    }

    [Test]
    public async Task AsUserIWantToAddTaskToAToDoList()
    {
        _application.taskRepository.NextIdentity().Returns(1);
        var toDoTask = new ToDoTask(1, "Write a test that fails");
        
        await _client.PostAsJsonAsync("api/todo/AddTask", "Write a test that fails");
        
        _application.taskRepository.Received().Store(Arg.Is<ToDoTask>(t => t.Equals(toDoTask)));
    }
}