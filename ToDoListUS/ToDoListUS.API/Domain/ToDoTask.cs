namespace ToDoListUS.API.Domain;

public class ToDoTask
{
    private readonly int _id;
    private readonly string _description;

    public ToDoTask(int id, string description)
    {
        _id = id;
        _description = description;
    }
}