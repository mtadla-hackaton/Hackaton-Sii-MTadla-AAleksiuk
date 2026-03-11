using System.Runtime.CompilerServices;
using OpenQA.Selenium.Interactions;
using Prestashop.Automation.Core.Configuration;
using Prestashop.Automation.Core.Logging;
using Prestashop.Automation.Ui.Extenstions;

namespace Prestashop.Automation.Ui.Pages.Base;

public abstract class BaseElement(IWebDriver driver, PrestashopUrls urls, TestSettings settings)
{
    protected readonly Actions Actions = new(driver);
    protected readonly IWebDriver Driver = driver;
    protected readonly TestSettings Settings = settings;
    protected readonly PrestashopUrls Urls = urls;

    protected void SendKeys(IWebElement element, string valueToSet, bool clear = true,
        [CallerArgumentExpression(nameof(element))] string elementName = null)
    {
        Logger.Info($"Setting value '{valueToSet}' to '{elementName}'");
        if (clear)
        {
            element.TryToClear();
        }

        element.SendKeys(valueToSet);
    }

    protected void Click(IWebElement element, [CallerArgumentExpression(nameof(element))] string elementName = null)
    {
        var text = element.Text;

        if (string.IsNullOrWhiteSpace(text))
        {
            text = element.GetAttribute("value");
        }

        if (string.IsNullOrWhiteSpace(text))
        {
            text = "<no text>";
        }

        Logger.Info($"Clicking '{elementName}' (text: '{text}')");

        Driver.WaitForClickable(element);
        element.Click();
    }

    protected void GetRandomElement(IList<IWebElement> elements)
    {
    }
}
