namespace WordCount;

public static class FileReader
{
    public static IEnumerable<string> GetFilePathsFromDirectory(string directoryPath)
    {
        return Directory.GetFiles(directoryPath, "*.txt");
    }

    public static IAsyncEnumerable<string> ReadFile(string filePath)
    {
        return File.ReadLinesAsync(filePath);
    }
}