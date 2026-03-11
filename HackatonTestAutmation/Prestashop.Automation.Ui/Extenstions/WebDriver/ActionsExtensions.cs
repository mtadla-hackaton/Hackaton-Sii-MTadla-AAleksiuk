using OpenQA.Selenium.Interactions;

namespace Prestashop.Automation.Ui.Extenstions.WebDriver;

public static class ActionsExtensions
{
    public static void FocusToElement(this Actions driverActions, IWebElement webElement) =>
        driverActions.MoveToElement(webElement).Perform();

    public static void MouseOverExtension(this Actions driverActions, IWebElement webElement)
    {
        driverActions.MoveToElement(webElement);
        driverActions.Build().Perform();
    }
}
