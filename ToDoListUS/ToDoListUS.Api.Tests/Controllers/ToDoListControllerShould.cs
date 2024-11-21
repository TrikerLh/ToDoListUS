using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ReceivedExtensions;
using ToDoListUS.API.Application;
using ToDoListUS.API.Controllers;
using ToDoListUS.API.Domain;

namespace ToDoListUS.Api.Tests.Controllers;

public class ToDoListControllerShould
{
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
}