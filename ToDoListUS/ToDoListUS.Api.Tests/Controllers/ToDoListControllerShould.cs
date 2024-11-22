using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ReceivedExtensions;
using ToDoListUS.API.Application;
using ToDoListUS.API.Controllers;
using ToDoListUS.API.Domain;
using static System.Net.Mime.MediaTypeNames;

namespace ToDoListUS.Api.Tests.Controllers;

public class ToDoListControllerShould
{

	private HttpClient _client;
	private CustomWebApplicationFactory _application;

	[TearDown]
	public void TearDown() {
		_application.Dispose();

		_client.Dispose();
	}

	[SetUp]
	public void Setup() {
		_application = new CustomWebApplicationFactory();
		_client = _application.CreateHttpClient();
	}


	[Test]
    public async Task AddTask()
    {
        var taskRepository = Substitute.For<TaskRepository>();
        var addTaskHandler = Substitute.For<AddTaskHandler>(taskRepository);
        var toDoListController = new ToDoListController(addTaskHandler);
        const string anyDescription = "Any Description";
        
        var response =  (Created)await toDoListController.AddTask(anyDescription);
        
        response.StatusCode.Should().Be(201);
        addTaskHandler.Received().Execute(anyDescription);
    }


	[Test]
	public async Task AddTask2() {
		const string anyDescription = "Any Description";

		var response = await _client.PostAsJsonAsync("api/todo/AddTask", anyDescription);

		response.StatusCode.Should().Be(HttpStatusCode.Created);
		_application.addTaskHandler.Received().Execute(anyDescription);
	}
}