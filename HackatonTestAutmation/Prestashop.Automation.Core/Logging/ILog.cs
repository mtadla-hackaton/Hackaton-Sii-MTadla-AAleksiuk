namespace Prestashop.Automation.Core.Logging;

public interface ILog
{
    void Info(string message);

    void Error(string message, Exception? ex = null);

    void AttachFile(string name, string filePath);

    void AttachText(string name, string content);
}
