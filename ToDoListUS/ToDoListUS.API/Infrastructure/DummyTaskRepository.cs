using ToDoListUS.API.Domain;

namespace ToDoListUS.API.Infrastructure;

public class DummyTaskRepository : TaskRepository
{
    public void Store(ToDoTask task)
    {
        
    }

    public int NextIdentity()
    {
        return 0;
    }
}