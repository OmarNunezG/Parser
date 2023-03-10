using Antlr4.Runtime.Misc;
using ProjectManager.Models;

namespace ProjectManager.Grammar;

public class ProjectManagerVisitor : ProjectManagerBaseVisitor<Project>
{
    private readonly Project _project = new();

    public override Project VisitProgram([NotNull] ProjectManagerParser.ProgramContext context)
    {
        VisitChildren(context);
        return _project;
    }

    public override Project VisitHeading([NotNull] ProjectManagerParser.HeadingContext context)
    {
        var title = context.PROJECT_LBL().GetText()[2..];
        var description = context.DESCRIPTION().GetText()[2..];

        _project.SetHeading(title, description);
        return _project;
    }

    public override Project VisitIterations([NotNull] ProjectManagerParser.IterationsContext context)
    {
        var iterationDates = new List<DateTime>();
        foreach (var iteration in context.iteration_body())
        {
            var name = iteration.TEXT().GetText().Trim();
            var startDateString = iteration.date().start_date().DATE().GetText();
            var startDate = DateTime.ParseExact(startDateString, "yyyy-MM-dd", null);
            var endDateString = iteration.date().end_date().DATE().GetText();
            var endDate = DateTime.ParseExact(endDateString, "yyyy-MM-dd", null);
            _project.AddIteration(name, startDate, endDate);

            foreach (var milestone in iteration.milestones().milestone())
            {
                var milestoneName = milestone.DOUBLE_SPACED_TEXT().GetText().Trim();
                _project.Iterations?.First(i => i.Name == name)
                    .AddMilestone(milestoneName);
            }
            iterationDates.Add(startDate);
            iterationDates.Add(endDate);
        }
        _project.SetDates(iterationDates);
        return _project;
    }

    public override Project VisitJob_body([NotNull] ProjectManagerParser.Job_bodyContext context)
    {
        var start_date_string = context.start_date().DATE().GetText();
        var duration_string = context.duration().NUM().GetText();
        var job_name = context.TEXT().GetText();

        var start_date = DateTime.ParseExact(start_date_string, "yyyy-MM-dd", null);
        var end_date = start_date.AddDays(int.Parse(duration_string));
        var duration = int.Parse(duration_string);

        _project.AddJob(job_name, start_date, duration);
        VisitChildren(context);
        return _project;
    }

    public override Project VisitIteration([NotNull] ProjectManagerParser.IterationContext context)
    {
        var reference = context.TEXT().GetText().Trim();
        var iteration = _project.Iterations?.First(i => i.Name == reference);

        if (iteration is not null)
            _project.Jobs.Last().Iteration = iteration;

        return _project;
    }

    public override Project VisitPredcessor([NotNull] ProjectManagerParser.PredcessorContext context)
    {
        var reference = context.DOUBLE_SPACED_TEXT().GetText().Trim();
        var job = _project.Jobs.First(j => j.Name == reference);

        _project.Jobs.Last().AddPredecessor(job.Name);
        return base.VisitPredcessor(context);
    }

    public override Project VisitLabel([NotNull] ProjectManagerParser.LabelContext context)
    {
        var label = context.DOUBLE_SPACED_TEXT().GetText().Trim();
        _project.Jobs.Last().AddLabel(label);

        return base.VisitLabel(context);
    }
}
