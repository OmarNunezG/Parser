namespace ProjectManager.Models;

public class Job
{
    public string Name { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public int Duration { get; set; }
    public Iteration? Iteration { get; set; }
    public List<string>? Predecessors { get; set; }
    public int Priority { get; set; } = 0;
    public int Size { get; set; } = 0;
    public List<string>? Labels { get; set; }

    public Job(string name, DateTime startDate, int duration)
    {
        Name = name;
        StartDate = startDate;
        Duration = duration;
    }

    public Job SetIteration(Project project, string name)
    {
        try
        {
            Iteration = project.Iterations?.First(i => i.Name == name);
        }
        catch (InvalidOperationException)
        {
            throw new InvalidOperationException($"Iteration {name} does not exist.");
        }
        return this;
    }

    public Job AddPredecessor(string name)
    {
        Predecessors ??= new();
        Predecessors.Add(name);
        return this;
    }

    public Job SetPriority(int priority)
    {
        Priority = priority;
        return this;
    }

    public Job SetSize(int size)
    {
        Size = size;
        return this;
    }

    public Job AddLabel(string label)
    {
        Labels ??= new();
        Labels.Add(label);
        return this;
    }
}
