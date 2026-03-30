namespace ConsoleToDoApp;

class TodoItem
{
    public int Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

    public override string ToString()
    {
        string status = IsCompleted ? "[x]" : "[ ]";
        return $"{Id}. {status} {Title}";
    }
}
