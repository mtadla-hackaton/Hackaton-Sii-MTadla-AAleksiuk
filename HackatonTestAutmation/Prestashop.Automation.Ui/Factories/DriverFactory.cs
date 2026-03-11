using System.Drawing;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using Prestashop.Automation.Core.Configuration;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace Prestashop.Automation.Ui.Factories;

public static class DriverFactory
{
    public static IWebDriver Create(TestSettings settings)
    {
        var browser = settings.Browser.BrowserName.ToLowerInvariant();

        return browser switch
        {
            "chrome" => CreateChrome(settings),
            "firefox" => CreateFirefox(settings),
            "edge" => CreateEdge(settings),
            _ => throw new ArgumentException($"Unsupported browser: {browser}")
        };
    }

    private static IWebDriver CreateChrome(TestSettings settings)
    {
        new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);

        var options = new ChromeOptions();

        ConfigureCommonOptions(options, settings);

        var driver = new ChromeDriver(options);

        ConfigureDriver(driver, settings);

        return driver;
    }

    private static IWebDriver CreateFirefox(TestSettings settings)
    {
        new DriverManager().SetUpDriver(new FirefoxConfig());

        var options = new FirefoxOptions();

        ConfigureCommonOptions(options, settings);

        var driver = new FirefoxDriver(options);

        ConfigureDriver(driver, settings);

        return driver;
    }

    private static IWebDriver CreateEdge(TestSettings settings)
    {
        new DriverManager().SetUpDriver(new EdgeConfig());

        var options = new EdgeOptions();

        ConfigureCommonOptions(options, settings);

        var driver = new EdgeDriver(options);

        ConfigureDriver(driver, settings);

        return driver;
    }

    private static void ConfigureCommonOptions(DriverOptions options, TestSettings settings)
    {
        var headless = settings.Browser.Headless;

        if (CiEnvironment.IsCi())
        {
            headless = true;
        }

        switch (options)
        {
            case ChromeOptions chrome:

                if (headless)
                {
                    chrome.AddArgument("--headless=new");
                    chrome.AddArgument("--disable-gpu");
                }

                chrome.AddArgument("--no-sandbox");
                chrome.AddArgument("--start-maximized");
                break;

            case FirefoxOptions firefox:

                if (headless)
                {
                    firefox.AddArgument("-headless");
                }

                break;

            case EdgeOptions edge:

                if (headless)
                {
                    edge.AddArgument("--headless=new");
                }

                break;
        }
    }

    private static void ConfigureDriver(IWebDriver driver, TestSettings settings)
    {
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.Zero;

        if (!string.IsNullOrWhiteSpace(settings.Browser.WindowSize))
        {
            var parts = settings.Browser.WindowSize.Split(',');

            var width = int.Parse(parts[0]);
            var height = int.Parse(parts[1]);

            driver.Manage().Window.Size = new Size(width, height);
        }
        else
        {
            driver.Manage().Window.Maximize();
        }
    }
}
