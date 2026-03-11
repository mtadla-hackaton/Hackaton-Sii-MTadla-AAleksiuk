using AwesomeAssertions;
using NUnit.Framework;
using Prestashop.Automation.Core.Constants;
using Prestashop.Automation.TestSupport.TestData;
using Prestashop.Automation.Ui.Extenstions.WebDriver;
using Prestashop.Automation.Ui.Pages.Cart;
using Prestashop.Automation.Ui.Pages.Product;

namespace Prestashop.Tests.Ui.Cart;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class AddProductToBasket : UiTestBase
{
    [Test]
    [Repeat(1)]
    public void Should_Add_One_Product_To_Basket()
    {
        // Arrange
        CreatedProduct product = PrestashopTestDataService.CreateProductWithQuantity();
        Driver.GoToUrl(Urls.Product(product.Url));

        //Act
        At<ProductDetailsPage>(x =>
        {
            x.AddToCart();
        });

        //Assert
        At<CartPopupPage>(x =>
        {
            var productName = x.ProductName;
            var productQuantity = x.ProductQuantity;
            var expectedName = product.Name;
            productName.Should().Be(expectedName);
            productQuantity.Should().Be(TestDataConstants.Product.DefaultBuyQuantity.ToString());
        });
    }
}
