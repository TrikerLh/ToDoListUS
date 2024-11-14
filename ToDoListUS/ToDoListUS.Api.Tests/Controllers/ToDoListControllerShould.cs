using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ReceivedExtensions;
using ToDoListUS.API.Application;
using ToDoListUS.API.Controllers;

namespace ToDoListUS.Api.Tests.Controllers;

public class ToDoListControllerShould
{
    [Test]
    public void AddTask()
    {
        var addTaskHandler = Substitute.For<AddTaskHandler>();
        var toDoListController = new ToDoListController(addTaskHandler);
        const string anyDescription = "Any Description";
        
        var response =  toDoListController.AddTask(anyDescription).Result;
        
        var createdResult = response as CreatedResult;
        createdResult?.StatusCode.Should().Be(201);
        addTaskHandler.Received().Execute(anyDescription);
    }
}