using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Prestashop.Automation.Core.Logging;
using Prestashop.Automation.TestSupport.TestData;
using Prestashop.Automation.Ui.Extenstions.WebDriver;
using Prestashop.Automation.Ui.Factories;
using Prestashop.Automation.Ui.Navigation;
using Prestashop.Automation.Ui.Pages.Base;
using Prestashop.Tests.Api.Base;

namespace Prestashop.Tests.Ui;

public abstract class UiTestBase : TestWithApiBase<UiTestBase>
{
    protected IWebDriver Driver;
    protected PrestashopTestDataService PrestashopTestDataService;
    protected PrestashopUrls Urls;

    [SetUp]
    public void UiSetUp()
    {
        Driver = DriverFactory.Create(Settings);
        Urls = new PrestashopUrls(Settings);
        PrestashopTestDataService = new PrestashopTestDataService(CustomersApi, ProductsApi, StockAvailablesApi, _cleanupTracker, Settings);
    }

    [TearDown]
    public void UiTearDown()
    {
        CleanupTrackedResources();

        try
        {
            TestStatus status = TestContext.CurrentContext.Result.Outcome.Status;
            Logger.Info($"Test ended with status: {status}");

            if (status == TestStatus.Failed)
            {
                LogTestInfo();
            }
        }
        finally
        {
            Driver.Quit();
        }
    }

    private void LogTestInfo()
    {
        Driver.TakeScreenshot(Settings);
        Logger.Info($"Closing url {Driver.Url}");
    }


    protected TPage At<TPage>() where TPage : BasePage
    {
        Logger.Info($"Accessing page: {typeof(TPage).Name}");

        return (TPage)Activator.CreateInstance(typeof(TPage), Driver, Urls, Settings)!;
    }

    protected void At<TPage>(Action<TPage> action) where TPage : BasePage
    {
        TPage page = At<TPage>();
        action(page);
    }

    protected TResult At<TPage, TResult>(Func<TPage, TResult> func) where TPage : BasePage
    {
        TPage page = At<TPage>();
        return func(page);
    }
}
