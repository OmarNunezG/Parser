using System.Text;

namespace ProjectManager.Models;

public record Project
{
    public Heading Heading { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<Iteration>? Iterations { get; set; }
    public List<Job> Jobs { get; set; } = new();

    public void SetHeading(string title, string description) => Heading = new Heading(title, description);

    public void SetDates(List<DateTime> iterationDates)
    {
        iterationDates.Sort();

        StartDate = iterationDates.First();
        EndDate = iterationDates.Last();
    }

    public void AddIteration(string name, DateTime startDate, DateTime endDate)
    {
        Iterations ??= new();
        var iteration = new Iteration(name, startDate, endDate);
        Iterations.Add(iteration);
    }

    public void AddJob(string name, DateTime startDate, int duration)
    {
        var job = new Job(name, startDate, duration);
        Jobs.Add(job);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Title: {Heading.Title}");
        sb.AppendLine($"Description: {Heading.Description}");
        sb.AppendLine();
        sb.AppendLine($"Start date: {StartDate.ToLongDateString()}");
        sb.AppendLine($"End date: {EndDate.ToLongDateString()}");
        sb.AppendLine();
        if (Iterations is not null)
        {
            sb.AppendLine("Iterations:");
            foreach (var iteration in Iterations!)
            {
                sb.AppendLine($"  {iteration.Name} ({iteration.StartDate:yyyy-MM-dd} - {iteration.EndDate:yyyy-MM-dd})");
                if (iteration.Milestones is not null)
                {
                    sb.AppendLine("  Milestones:");
                    foreach (var milestone in iteration.Milestones)
                        sb.AppendLine($"    {milestone}");
                }
                sb.AppendLine();
            }
        }
        sb.AppendLine();
        sb.AppendLine("Jobs:");
        foreach (var job in Jobs)
        {
            sb.AppendLine($"  {job.Name} ({job.StartDate:yyyy-MM-dd} - {job.StartDate.AddDays(job.Duration):yyyy-MM-dd})");
            if (job.Iteration is not null)
                sb.AppendLine($"    Iteration: {job.Iteration?.Name}");
            if (job.Predecessors is not null)
                sb.AppendLine($"    Predecessors: {string.Join(", ", job.Predecessors)}");
            sb.AppendLine($"    Priority: {job.Priority}");
            sb.AppendLine($"    Size: {job.Size}");
            if (job.Labels is not null)
                sb.AppendLine($"    Labels: {string.Join(", ", job.Labels ?? new List<string>())}");
            sb.AppendLine();
        }
        return sb.ToString();
    }

    public void SaveAsMarkdown(string path)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"# {Heading.Title}");
        sb.AppendLine();
        sb.AppendLine(Heading.Description);
        sb.AppendLine();
        sb.AppendLine($"Start date: {StartDate:yyyy-MM-dd}");
        sb.AppendLine($"End date: {EndDate:yyyy-MM-dd}");
        sb.AppendLine();
        if (Iterations is not null)
        {
            sb.AppendLine("## Iterations");
            foreach (var iteration in Iterations!)
            {
                sb.AppendLine($"### {iteration.Name}");
                sb.AppendLine();
                sb.AppendLine($"Start date: {iteration.StartDate:yyyy-MM-dd}");
                sb.AppendLine($"End date: {iteration.EndDate:yyyy-MM-dd}");
                sb.AppendLine();
                if (iteration.Milestones is not null)
                {
                    sb.AppendLine("#### Milestones");
                    sb.AppendLine();
                    foreach (var milestone in iteration.Milestones)
                        sb.AppendLine($"- {milestone}");
                    sb.AppendLine();
                }
            }
        }
        sb.AppendLine();
        sb.AppendLine("## Jobs");
        sb.AppendLine();
        foreach (var job in Jobs)
        {
            sb.AppendLine($"### {job.Name}");
            sb.AppendLine();
            sb.AppendLine($"Start date: {job.StartDate:yyyy-MM-dd}");
            sb.AppendLine($"Duration: {job.Duration}");
            sb.AppendLine();
            if (job.Iteration is not null)
                sb.AppendLine($"Iteration: {job.Iteration?.Name}");
            if (job.Predecessors is not null)
                sb.AppendLine($"Predecessors: {string.Join(", ", job.Predecessors)}");
            sb.AppendLine($"Priority: {job.Priority}");
            sb.AppendLine($"Size: {job.Size}");
            if (job.Labels is not null)
                sb.AppendLine($"Labels: {string.Join(", ", job.Labels ?? new List<string>())}");
            sb.AppendLine();
        }
        File.WriteAllText(path, sb.ToString());
    }
}
