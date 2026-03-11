using Prestashop.Automation.Core.Configuration;
using Prestashop.Automation.Ui.Pages.Base;

namespace Prestashop.Automation.Ui.Pages.Checkout;

public class CheckoutPage(IWebDriver driver, PrestashopUrls urls, TestSettings settings) : BasePage(driver, urls, settings)
{
}
