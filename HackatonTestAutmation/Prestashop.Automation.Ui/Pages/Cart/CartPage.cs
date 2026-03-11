using Prestashop.Automation.Core.Configuration;
using Prestashop.Automation.Ui.Pages.Base;

namespace Prestashop.Automation.Ui.Pages.Cart;

public class CartPage(IWebDriver driver, PrestashopUrls urls, TestSettings settings) : BasePage(driver, urls, settings)
{
    private IWebElement RemoveFromCartBtn => Driver.WaitAndFind(By.CssSelector(".remove-from-cart"));
    public string NoItemsLbl => Driver.WaitAndFind(By.CssSelector(".no-items")).Text;

    public void RemoveFromCart() => Click(RemoveFromCartBtn);
}
