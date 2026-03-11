namespace Prestashop.Automation.Core.Helpers;

public class UrlBuilder
{
    public static string Build(Uri baseUri, params string[]? segments)
    {
        if (segments is null || segments.Length == 0)
        {
            return baseUri.ToString();
        }

        var path = string.Join("/", segments.Select(s => s.Trim('/')));

        return new Uri(baseUri, path).ToString();
    }

    public static string BuildPath(params string[]? segments)
    {
        if (segments is null || segments.Length == 0)
        {
            return string.Empty;
        }

        return string.Join("/", segments.Where(s => !string.IsNullOrWhiteSpace(s)).Select(s => s.Trim('/')));
    }
}
