using System.Text.RegularExpressions;

namespace Prestashop.Automation.Core.Extensions;

public static class StringExtensions
{
    private static readonly Regex NonLetters = new("[^a-zA-Z]", RegexOptions.Compiled);

    public static string ToSafeName(this string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return value;
        }

        return NonLetters.Replace(value, "");
    }

    public static string ToSlug(this string value) => value.ToLowerInvariant().Replace(" ", "-");
}
