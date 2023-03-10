namespace ProjectManager.Models;

public record Iteration(string Name, DateTime StartDate, DateTime EndDate)
{
    public List<string>? Milestones { get; set; }

    public void AddMilestone(string milestone)
    {
        Milestones ??= new();
        Milestones.Add(milestone);
    }
}
