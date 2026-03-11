using Prestashop.Automation.Core.Configuration;
using Prestashop.Automation.Ui.Pages.Base;

namespace Prestashop.Automation.Ui.Pages.Cart;

public class CartPopupPage(IWebDriver driver, PrestashopUrls urls, TestSettings settings) : BasePage(driver, urls, settings)
{
    public By ProductNameLblSelector => By.CssSelector("#blockcart-modal .product-name");

    public string ProductName => Driver.WaitAndFind(ProductNameLblSelector).Text;
    public string ProductPrice => Driver.WaitAndFind(By.CssSelector("#blockcart-modal .product-price")).Text;
    public string ProductQuantity => Driver.WaitAndFind(By.CssSelector("#blockcart-modal .product-quantity strong")).Text;

    public void WaitToBeVisible() => Driver.WaitForVisible(ProductNameLblSelector);
}
