using System.Text;
using ReportPortal.Shared;

namespace Prestashop.Automation.Core.Logging;

public class ReportPortalLog : ILog
{
    public void Info(string message) => Context.Current.Log.Info(message);

    public void Error(string message, Exception? ex = null)
    {
        Context.Current.Log.Error(message);

        if (ex != null)
        {
            Context.Current.Log.Error(ex.ToString());
        }
    }

    public void AttachFile(string name, string filePath)
    {
        var bytes = File.ReadAllBytes(filePath);

        Context.Current.Log.Info(name, "application/octet-stream", bytes);
    }

    public void AttachText(string name, string content)
    {
        var bytes = Encoding.UTF8.GetBytes(content);

        Context.Current.Log.Info(name, "text/plain", bytes);
    }
}
