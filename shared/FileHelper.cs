namespace shared;

public static class FileHelper
{
    private const string InputFileName = "input.txt";
    private const string OutputFileName = "output.txt";
    
    public static List<string> GetInputLines()
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), InputFileName);
        
        return File.ReadAllLines(path).ToList(); 
    }
    
    public static void WriteOutput(string content, string fileName = OutputFileName)
    {
        var projectDirectory = GetProjectDirectory();
        
        var path = Path.Combine(projectDirectory, fileName);
        
        Console.WriteLine(content);
        File.WriteAllText(path, content);
    }

    private static string GetProjectDirectory()
    {
        var workingDirectory = Environment.CurrentDirectory;
        
        var projectBinDirectory = Directory.GetParent(workingDirectory)?.Parent?.FullName;
        if (projectBinDirectory == null)
        {
            throw new Exception("Could not find project bin directory");
        }

        var projectDirectory = Directory.GetParent(projectBinDirectory)?.FullName;
        if (projectDirectory == null)
        {
            throw new Exception("Could not find project directory");
        }

        return projectDirectory;
    }
}