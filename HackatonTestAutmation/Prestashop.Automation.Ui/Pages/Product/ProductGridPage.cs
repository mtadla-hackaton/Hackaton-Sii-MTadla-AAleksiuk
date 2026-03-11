using Prestashop.Automation.Core.Configuration;
using Prestashop.Automation.Core.Extensions;
using Prestashop.Automation.Ui.Pages.Base;

namespace Prestashop.Automation.Ui.Pages.Product;

public class ProductGridPage(IWebDriver driver, PrestashopUrls urls, TestSettings settings) : BasePage(driver, urls, settings)
{
    public IList<ProductMiniaturePage> ProductsMiniatures =>
        Driver.FindElementsGraterThenZero(By.CssSelector(".product-miniature"))
            .Select(item => new ProductMiniaturePage(item, Driver, Urls, Settings))
            .ToList();

    public IEnumerable<string> GetProductsNames => ProductsMiniatures.Select(item => item.Name);

    public void OpenRandomProduct() => ProductsMiniatures.Random().Open();
}
