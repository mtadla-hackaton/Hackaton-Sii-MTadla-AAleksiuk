using NUnit.Framework;
using Prestashop.Automation.Core.Configuration;

namespace Prestashop.Automation.Ui.Helpers;

public static class FileHelper
{
    public static string GetArtifactsDirectory(TestSettings settings)
    {
        var path = Path.Combine(TestContext.CurrentContext.WorkDirectory, settings.Paths.ArtifactsDirectory);

        Directory.CreateDirectory(path);

        return path;
    }

    public static string GetScreenshotPath(TestSettings settings, string testName)
    {
        var directory = Path.Combine(GetArtifactsDirectory(settings), "screenshots");

        Directory.CreateDirectory(directory);

        var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

        var fileName = $"{testName}_{timestamp}.png";

        return Path.Combine(directory, fileName);
    }

    public static string SaveTextFile(TestSettings settings, string name, string content)
    {
        var directory = Path.Combine(GetArtifactsDirectory(settings), "logs");

        Directory.CreateDirectory(directory);

        var path = Path.Combine(directory, name);

        File.WriteAllText(path, content);

        return path;
    }
}
