using System.Text.RegularExpressions;

namespace WordCount;

public static partial class WordCounter
{
    [GeneratedRegex(@"\W+")]
    private static partial Regex GetWordsRegex();

    public static async Task<Dictionary<string, int>> GetAggregatedWordCountFromFiles(string folderPath)
    {
        var filePaths = FileReader.GetFilePathsFromDirectory(folderPath);
        var aggregatedWordCounts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        foreach (var filePath in filePaths)
        {
            await foreach (var fileContent in FileReader.ReadFile(filePath))
            {
                GetWordCountFromText(fileContent, aggregatedWordCounts);
            }
        }
        return aggregatedWordCounts;
    }

    private static void GetWordCountFromText(string text, Dictionary<string, int> wordCounts)
    {
        
        var words = GetWordsRegex().Split(text);

        foreach (var word in words)
        {
            if (wordCounts.TryGetValue(word, out var value))
            {
                wordCounts[word] = ++value;
            }
            else
            {
                wordCounts.Add(word, 1);
            }
        }
    }
}