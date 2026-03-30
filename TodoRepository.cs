namespace ConsoleToDoApp;

class TodoRepository
{
    private readonly List<TodoItem> _items = new();
    private int _nextId = 1;

    public IReadOnlyList<TodoItem> GetAll() => _items.AsReadOnly();

    public TodoItem Add(string title)
    {
        var item = new TodoItem { Id = _nextId++, Title = title };
        _items.Add(item);
        return item;
    }

    public bool Complete(int id)
    {
        var item = _items.FirstOrDefault(i => i.Id == id);
        if (item is null) return false;
        item.IsCompleted = true;
        return true;
    }

    public bool Delete(int id)
    {
        var item = _items.FirstOrDefault(i => i.Id == id);
        if (item is null) return false;
        _items.Remove(item);
        return true;
    }
}
