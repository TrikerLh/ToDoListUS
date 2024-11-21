namespace ToDoListUS.API.Domain;

public interface TaskRepository
{
    public void Store(ToDoTask task);
    public int NextIdentity();
}