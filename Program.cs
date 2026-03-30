namespace ConsoleToDoApp;

class Program
{
    static readonly TodoRepository _repo = new();

    static void Main(string[] args)
    {
        Console.WriteLine("=== Console ToDo App ===");
        Console.WriteLine("Commands: add, list, complete, delete, quit\n");

        while (true)
        {
            Console.Write("> ");
            string? input = Console.ReadLine();
            if (input is null) return; // EOF — exit cleanly
            input = input.Trim();

            if (string.IsNullOrEmpty(input)) continue;

            string[] parts = input.Split(' ', 2);
            string command = parts[0].ToLower();
            string argument = parts.Length > 1 ? parts[1] : string.Empty;

            switch (command)
            {
                case "add":
                    HandleAdd(argument);
                    break;
                case "list":
                    HandleList();
                    break;
                case "complete":
                    HandleComplete(argument);
                    break;
                case "delete":
                    HandleDelete(argument);
                    break;
                case "quit":
                case "exit":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine($"Unknown command: {command}");
                    break;
            }
        }
    }

    static void HandleAdd(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine("Usage: add <title>");
            return;
        }
        var item = _repo.Add(title);
        Console.WriteLine($"Added: {item}");
    }

    static void HandleList()
    {
        var items = _repo.GetAll();
        if (items.Count == 0)
        {
            Console.WriteLine("No tasks yet.");
            return;
        }
        foreach (var item in items)
            Console.WriteLine(item);
    }

    static void HandleComplete(string arg)
    {
        if (!int.TryParse(arg, out int id))
        {
            Console.WriteLine("Usage: complete <id>");
            return;
        }
        Console.WriteLine(_repo.Complete(id) ? $"Task {id} marked as completed." : $"Task {id} not found.");
    }

    static void HandleDelete(string arg)
    {
        if (!int.TryParse(arg, out int id))
        {
            Console.WriteLine("Usage: delete <id>");
            return;
        }
        Console.WriteLine(_repo.Delete(id) ? $"Task {id} deleted." : $"Task {id} not found.");
    }
}
