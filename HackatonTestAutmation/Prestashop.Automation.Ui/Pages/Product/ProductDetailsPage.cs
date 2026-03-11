using Prestashop.Automation.Core.Configuration;
using Prestashop.Automation.Ui.Pages.Base;

namespace Prestashop.Automation.Ui.Pages.Product;

public class ProductDetailsPage(IWebDriver driver, PrestashopUrls urls, TestSettings settings) : BasePage(driver, urls, settings)
{
    public IWebElement AddToCartBtn => Driver.FindElement(By.CssSelector(".btn-primary.add-to-cart"));

    public void AddToCart() => Click(AddToCartBtn);
}
