using Prestashop.Automation.Core.Configuration;
using Prestashop.Automation.Ui.Pages.Base;

namespace Prestashop.Automation.Ui.Pages.Product;

public class ProductMiniaturePage(IWebElement parent, IWebDriver driver, PrestashopUrls urls, TestSettings settings)
    : BaseComponent(parent, driver, urls, settings)
{
    private IWebElement NameLabel => parent.FindElement(By.CssSelector(".h3.product-title > a"));
    public string Name => NameLabel.Text;

    public void Open() => Click(NameLabel);
}
