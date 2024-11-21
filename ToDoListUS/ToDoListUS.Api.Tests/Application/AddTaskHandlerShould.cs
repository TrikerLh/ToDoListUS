using NSubstitute;
using ToDoListUS.API.Application;
using ToDoListUS.API.Domain;

namespace ToDoListUS.Api.Tests.Application;

public class AddTaskHandlerShould
{
    [Test]
    public void CreatedAndStoreATask()
    {
        var toDoTask = new ToDoTask(1, "Task Description");
        var taskRepository = Substitute.For<TaskRepository>();
        var addTaskHandler = new AddTaskHandler(taskRepository);
        taskRepository.NextIdentity().Returns(1);

        addTaskHandler.Execute("Task Description");
        
        taskRepository.Received().Store(Arg.Is<ToDoTask>(t => t.Equals(toDoTask)));
    }
}