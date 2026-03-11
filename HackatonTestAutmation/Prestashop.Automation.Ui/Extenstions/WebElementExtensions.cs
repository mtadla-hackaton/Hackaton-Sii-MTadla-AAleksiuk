namespace Prestashop.Automation.Ui.Extenstions;

public static class WebElementExtensions
{
    public static string GetValue(this IWebElement element) => element.GetAttribute("value");
    public static string GetUrl(this IWebElement element) => element.GetAttribute("href");
    public static string GetClassName(this IWebElement element) => element.GetAttribute("class");

    public static bool HasEmptyText(this IWebElement element) => element.Text.Trim().Length == 0;

    public static bool HasEmptyValue(this IWebElement element) => element.GetValue().Trim().Length == 0;

    public static void TryToClear(this IWebElement element)
    {
        element.Clear();

        if (element.GetValue() != string.Empty)
        {
            element.SendKeys(Keys.Control + "a" + Keys.Delete);
        }

        if (element.GetValue() != string.Empty)
        {
            throw new Exception("Clearing element failed");
        }
    }
}
