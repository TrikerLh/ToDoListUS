namespace ToDoListUS.API.Domain;

public interface TaskRepository
{
    void Store(ToDoTask task);
}