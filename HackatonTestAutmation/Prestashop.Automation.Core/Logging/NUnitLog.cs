using NUnit.Framework;

namespace Prestashop.Automation.Core.Logging;

public class NUnitLog : ILog
{
    public void Info(string message) => TestContext.Progress.WriteLine(message);

    public void Error(string message, Exception? ex = null)
    {
        TestContext.Error.WriteLine(message);

        if (ex != null)
        {
            TestContext.Error.WriteLine(ex.ToString());
        }
    }

    public void AttachFile(string name, string filePath) => TestContext.AddTestAttachment(filePath, name);

    public void AttachText(string name, string content)
    {
        var path = Path.Combine(TestContext.CurrentContext.WorkDirectory, name);

        File.WriteAllText(path, content);

        TestContext.AddTestAttachment(path);
    }
}
