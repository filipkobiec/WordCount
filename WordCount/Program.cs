using WordCount;
using WordCount.Exceptions;

try
{
    var directoryPath = ConsoleManager.GetFolderPath();
    var aggregatedWordCount = await WordCounter.GetAggregatedWordCountFromFiles(directoryPath);
    ConsoleManager.PrintWordCountResult(aggregatedWordCount);
}
catch (DirectoryReadException e)
{
    ConsoleManager.PrintException(e.Message);
}
catch (FileNotFoundException)
{
    ConsoleManager.PrintException("One file could not be found");
}

