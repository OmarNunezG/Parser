using Antlr4.Runtime;
using ProjectManager.Grammar;

Console.WriteLine("Project Manager");
Console.WriteLine("---------------");
Console.WriteLine("Enter the (full) path to the file you want to parse:");
Console.Clear();

// var path = Console.ReadLine() ?? string.Empty;
var path = $"{Environment.CurrentDirectory}/Files/ProyectPlannerExample.txt";

var (visitor, tree) = BuildVisitor(path);
var project = visitor.Visit(tree);

Console.WriteLine(project);

static (ProjectManagerVisitor visitor, ProjectManagerParser.ProgramContext tree) BuildVisitor(string path)
{
    var project = File.ReadAllText(path);

    var inputStream = CharStreams.fromString(project);
    var lexer = new ProjectManagerLexer(inputStream);
    var tokenStream = new CommonTokenStream(lexer);
    var parser = new ProjectManagerParser(tokenStream);

    // Añadir custom error handler

    var tree = parser.program();
    var visitor = new ProjectManagerVisitor();

    return (visitor, tree);
}
