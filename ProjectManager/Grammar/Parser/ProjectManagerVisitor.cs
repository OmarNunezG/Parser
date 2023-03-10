//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.9.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from /Users/omar.nunez/Downloads/ProjectManager/ProjectManager/Grammar/Parser/ProjectManager.g4 by ANTLR 4.9.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="ProjectManagerParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9.2")]
[System.CLSCompliant(false)]
public interface IProjectManagerVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="ProjectManagerParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitProgram([NotNull] ProjectManagerParser.ProgramContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ProjectManagerParser.project"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitProject([NotNull] ProjectManagerParser.ProjectContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ProjectManagerParser.body"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBody([NotNull] ProjectManagerParser.BodyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ProjectManagerParser.heading"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHeading([NotNull] ProjectManagerParser.HeadingContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ProjectManagerParser.iterations"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIterations([NotNull] ProjectManagerParser.IterationsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ProjectManagerParser.iteration_body"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIteration_body([NotNull] ProjectManagerParser.Iteration_bodyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ProjectManagerParser.milestones"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMilestones([NotNull] ProjectManagerParser.MilestonesContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ProjectManagerParser.milestone"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMilestone([NotNull] ProjectManagerParser.MilestoneContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ProjectManagerParser.jobs"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitJobs([NotNull] ProjectManagerParser.JobsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ProjectManagerParser.job_body"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitJob_body([NotNull] ProjectManagerParser.Job_bodyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ProjectManagerParser.iteration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIteration([NotNull] ProjectManagerParser.IterationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ProjectManagerParser.duration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDuration([NotNull] ProjectManagerParser.DurationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ProjectManagerParser.priority"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPriority([NotNull] ProjectManagerParser.PriorityContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ProjectManagerParser.size"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSize([NotNull] ProjectManagerParser.SizeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ProjectManagerParser.labels"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLabels([NotNull] ProjectManagerParser.LabelsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ProjectManagerParser.label"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLabel([NotNull] ProjectManagerParser.LabelContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ProjectManagerParser.predecessors"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPredecessors([NotNull] ProjectManagerParser.PredecessorsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ProjectManagerParser.predcessor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPredcessor([NotNull] ProjectManagerParser.PredcessorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ProjectManagerParser.date"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDate([NotNull] ProjectManagerParser.DateContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ProjectManagerParser.start_date"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStart_date([NotNull] ProjectManagerParser.Start_dateContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ProjectManagerParser.end_date"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEnd_date([NotNull] ProjectManagerParser.End_dateContext context);
}
