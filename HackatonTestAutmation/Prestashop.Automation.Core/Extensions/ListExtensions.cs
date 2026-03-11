namespace Prestashop.Automation.Core.Extensions;

public static class ListExtensions
{
    public static T Random<T>(this IList<T> input) => input.ElementAt(new Random().Next(input.Count));
}
