using AwesomeAssertions;
using NUnit.Framework;
using Prestashop.Automation.Ui.Extenstions.WebDriver;
using Prestashop.Automation.Ui.Pages.Cart;
using Prestashop.Automation.Ui.Pages.Product;

namespace Prestashop.Tests.Ui.Cart;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class RemoveFromBasket : UiTestBase
{
    [Test]
    [Repeat(1)]
    public void Should_Remove_Added_Product_From_Basket()
    {
        // Arrange
        Driver.GoToUrl(Urls.ArtCategory());

        //Act
        At<ProductGridPage>(x =>
        {
            x.OpenRandomProduct();
        });

        At<ProductDetailsPage>(x =>
        {
            x.AddToCart();
        });

        At<CartPopupPage>(x =>
        {
            x.WaitToBeVisible();
        });


        Driver.GoToUrl(Urls.Cart());

        At<CartPage>(x =>
        {
            x.RemoveFromCart();
        });

        //Assert
        var NoItemsText = At<CartPage>().NoItemsLbl;
        NoItemsText.Should().Be("There are no more items in your cart");
    }
}
