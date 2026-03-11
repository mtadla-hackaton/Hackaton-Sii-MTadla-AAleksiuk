using AwesomeAssertions;
using NUnit.Framework;
using Prestashop.Automation.Api.Domain.Product;
using Prestashop.Automation.Api.Domain.StockAvailables;
using Prestashop.Automation.Api.Factories;
using Prestashop.Tests.Api.Base;

namespace Prestashop.Tests.Api.Tests.Products;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public sealed class ProductApiTests : ApiTestBase
{
    [Test]
    public void Should_Create_New_Product()
    {
        // Arrange
        const int minValidId = 0;
        CreateProductRequest createProductRequest = CreateProductRequestFactory.CreateValid(Settings.Prestashop);

        // Act
        ProductEnvelope created = ProductsApi.CreateProduct(createProductRequest);

        // Assert
        created.Product.Id.Should().NotBeNull();

        var productId = TrackProduct(created.Product.Id!.Value);
        productId.Should().BeGreaterThan(minValidId);

        created.Product.Name.Languages.Should().NotBeEmpty();
        created.Product.Name.Languages[0].Value.Should().Be(createProductRequest.Name);
    }

    [Test]
    public void Should_Get_And_Update_Product_Quantity()
    {
        // Arrange
        const int quantityToAdd = 3;
        CreateProductRequest createProductRequest = CreateProductRequestFactory.CreateValid(Settings.Prestashop);

        // Act
        ProductEnvelope createdProduct = ProductsApi.CreateProduct(createProductRequest);

        // Assert
        createdProduct.Product.Id.Should().NotBeNull();

        var productId = TrackProduct(createdProduct.Product.Id!.Value);

        var stockAvailableId = StockAvailablesApi.GetFirstStockAvailableIdForProduct(productId);
        StockAvailableEnvelope currentState = StockAvailablesApi.GetById(stockAvailableId);

        var originalQuantity = currentState.StockAvailable.Quantity;
        var updatedQuantity = originalQuantity + quantityToAdd;

        StockAvailableEnvelope updated = StockAvailablesApi.UpdateQuantity(stockAvailableId, updatedQuantity);

        updated.StockAvailable.Id.Should().Be(stockAvailableId);
        updated.StockAvailable.ProductId.Should().Be(productId);
        updated.StockAvailable.Quantity.Should().Be(updatedQuantity);
    }

    [Test]
    public void Should_Create_Product_And_Set_Quantity_To_10()
    {
        // Arrange
        const int newQuantity = 10;
        CreateProductRequest createProductRequest = CreateProductRequestFactory.CreateValid(Settings.Prestashop);

        // Act
        ProductEnvelope createdProduct = ProductsApi.CreateProduct(createProductRequest);

        // Assert
        createdProduct.Product.Id.Should().NotBeNull();

        var productId = TrackProduct(createdProduct.Product.Id!.Value);

        var stockAvailableId = StockAvailablesApi.GetFirstStockAvailableIdForProduct(productId);
        StockAvailableEnvelope updated = StockAvailablesApi.UpdateQuantity(stockAvailableId, newQuantity);

        updated.StockAvailable.ProductId.Should().Be(productId);
        updated.StockAvailable.Quantity.Should().Be(newQuantity);
    }
}
