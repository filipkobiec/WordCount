using WordCount.Exceptions;

namespace WordCount;

public static  class ConsoleManager
{
    public static string GetFolderPath()
    {
        Console.WriteLine("Please enter the folder path.");
        var path = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(path) || !Directory.Exists(path))
        {
            throw new DirectoryReadException("Invalid folder path.");
        }
        return path;
    }

    public static void PrintException(string exceptionDescription)
    {
        Console.WriteLine($"Unexpected error occured: {exceptionDescription}");
    }
    public static void PrintWordCountResult(Dictionary<string, int> wordCounts)
    {
        foreach (var wordCount in wordCounts)
        {
            Console.WriteLine($"{wordCount.Value}: {wordCount.Key}");
        }
    }
}