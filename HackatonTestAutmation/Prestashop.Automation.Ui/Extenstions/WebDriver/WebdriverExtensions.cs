using NUnit.Framework;
using Prestashop.Automation.Core.Configuration;
using Prestashop.Automation.Core.Logging;
using Prestashop.Automation.Ui.Helpers;

namespace Prestashop.Automation.Ui.Extenstions.WebDriver;

public static class WebdriverExtensions
{
    private const int DefaultWait = 15;

    public static void TakeScreenshot(this IWebDriver driver, TestSettings settings)
    {
        try
        {
            if (driver is not ITakesScreenshot screenshotDriver)
            {
                return;
            }

            var testName = TestContext.CurrentContext.Test.Name;

            var filePath = FileHelper.GetScreenshotPath(settings, testName);

            Screenshot screenshot = screenshotDriver.GetScreenshot();

            screenshot.SaveAsFile(filePath);

            Logger.Info($"Screenshot saved: {filePath}");

            Logger.AttachFile(Path.GetFileName(filePath), filePath);
        }
        catch (Exception ex)
        {
            Logger.Error("Failed to capture screenshot", ex);
        }
    }

    public static IWebElement WaitAndFind(this IWebDriver driver, By by)
    {
        driver.WaitForVisible(by);
        return driver.FindElement(by);
    }

    public static IList<IWebElement> FindElementsGraterThenZero(this IWebDriver driver, By by)
    {
        driver.Wait().Until(x => x.FindElements(by).Count > 0);
        return driver.FindElements(by);
    }

    public static IWebElement GetElementByDefineTextFromList(this IWebDriver driver, By by, string text)
    {
        driver.Wait().Until(x => x.FindElements(by).First(y => y.Text == text));
        return driver.FindElements(by).First(x => x.Text == text);
    }

    public static WebDriverWait Wait(this IWebDriver driver, int wait = DefaultWait) => new(driver, TimeSpan.FromSeconds(wait));

    public static void WaitForVisible(this IWebDriver driver, By by)
    {
        driver.Wait()
            .Until(d =>
            {
                IWebElement? element = d.FindElement(by);
                return element != null && element.Displayed;
            });
    }


    public static void WaitForClickable(this IWebDriver driver, By by)
    {
        driver.Wait()
            .Until(d =>
            {
                IWebElement? element = d.FindElement(by);
                return element != null && element.Displayed && element.Enabled;
            });
    }

    public static void WaitForClickable(this IWebDriver driver, IWebElement element)
    {
        driver.Wait()
            .Until(d =>
            {
                return element != null && element.Displayed && element.Enabled;
            });
    }

    public static void GoToUrl(this IWebDriver driver, string address)
    {
        Logger.Info("Opening url: " + address);
        driver.Navigate().GoToUrl(address);
    }
}
