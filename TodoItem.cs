namespace ConsoleToDoApp;

class TodoItem
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public override string ToString()
    {
        string status = IsCompleted ? "[x]" : "[ ]";
        return $"{Id}. {status} {Title}";
    }
}
