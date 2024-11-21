using ToDoListUS.API.Domain;

namespace ToDoListUS.API.Application;

public class AddTaskHandler
{
    private readonly TaskRepository _taskRepository;

    public AddTaskHandler(TaskRepository taskRepository)
    {
        _taskRepository = taskRepository;  
    }

    public virtual void Execute(string description)
    {
        var id = _taskRepository.NextIdentity();
        var toDoTask = new ToDoTask(id, description);
        _taskRepository.Store(toDoTask);
    }
}