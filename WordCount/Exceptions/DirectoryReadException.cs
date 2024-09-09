namespace WordCount.Exceptions;

public class DirectoryReadException : Exception
{
    public DirectoryReadException(string message) : base(message) {}
}