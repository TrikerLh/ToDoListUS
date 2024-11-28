using ToDoListUS.API.Domain;

namespace ToDoListUS.API.Infrastructure;

public class SqlTaskRepository : TaskRepository
{
    public void Store(ToDoTask task)
    {
        throw new NotImplementedException();
    }

    public int NextIdentity()
    {
        throw new NotImplementedException();
    }
}