namespace Prestashop.Automation.Core.Logging;

public class NullLog : ILog
{
    public static readonly NullLog Instance = new();

    private NullLog()
    {
    }

    public void Info(string message)
    {
    }

    public void Error(string message, Exception? ex = null)
    {
    }

    public void AttachFile(string name, string filePath)
    {
    }

    public void AttachText(string name, string content)
    {
    }
}
