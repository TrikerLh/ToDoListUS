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

    protected bool Equals(ToDoTask other)
    {
        return _id == other._id && _description == other._description;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((ToDoTask)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_id, _description);
    }
}