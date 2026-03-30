namespace ConsoleToDoApp;

class TodoItem
{
    public int Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public DateTime? DueDate { get; set; }
    public string Priority { get; set; } = "normal";

    public bool IsOverdue =>
        DueDate.HasValue && !IsCompleted && DueDate.Value < DateTime.Now;

    public override string ToString()
    {
        string status = IsCompleted ? "[x]" : "[ ]";
        string due = DueDate.HasValue ? $" (due: {DueDate.Value:yyyy-MM-dd})" : string.Empty;
        string priority = Priority != "normal" ? $" [{Priority}]" : string.Empty;
        return $"{Id}. {status} {Title}{due}{priority}";
    }
}
