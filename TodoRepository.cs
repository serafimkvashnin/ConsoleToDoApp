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
        if (item is null || item.IsCompleted) return false;
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

    public bool SetDue(int id, DateTime dueDate)
    {
        var item = _items.FirstOrDefault(i => i.Id == id);
        if (item is null) return false;
        item.DueDate = dueDate;
        return true;
    }

    public IReadOnlyList<TodoItem> Search(string query)
    {
        return _items.Where(i => i.Title.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public bool SetPriority(int id, string priority)
    {
        var item = _items.FirstOrDefault(i => i.Id == id);
        if (item is null) return false;
        item.Priority = priority;
        return true;
    }

    public IReadOnlyList<TodoItem> GetPage(int page, int size)
    {
        return _items.Skip(page * size).Take(size).ToList();
    }

    public TodoItem? GetNearest()
    {
        return _items
            .Where(i => !i.IsCompleted)
            .OrderBy(i => i.DueDate)
            .FirstOrDefault();
    }

    public (int total, int completed, int pending) GetStats()
    {
        int total = _items.Count;
        int completed = _items.Count(i => i.IsCompleted);
        return (total, completed, total - completed);
    }
}
