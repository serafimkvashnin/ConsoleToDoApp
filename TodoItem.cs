namespace ConsoleToDoApp;

class TodoItem
{
    public int Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public DateTime? DueDate { get; set; }

    public override string ToString()
    {
        string status = IsCompleted ? "[x]" : "[ ]";
        string due = DueDate.HasValue ? $" (due: {DueDate.Value:yyyy-MM-dd})" : string.Empty;
        return $"{Id}. {status} {Title}{due}";
    }
}
