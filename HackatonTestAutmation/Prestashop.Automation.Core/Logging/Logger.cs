namespace Prestashop.Automation.Core.Logging;

public static class Logger
{
    public static ILog Current { get; set; } = NullLog.Instance;

    public static void Info(string message) => Current.Info(message);

    public static void Error(string message, Exception? ex = null) => Current.Error(message, ex);

    public static void AttachFile(string name, string filePath) => Current.AttachFile(name, filePath);

    public static void AttachText(string name, string content) => Current.AttachText(name, content);
}
