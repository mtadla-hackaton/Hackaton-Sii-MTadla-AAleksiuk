using Prestashop.Automation.Api.Api;
using Prestashop.Automation.Api.Domain.Customers;
using Prestashop.Automation.Api.Domain.Product;
using Prestashop.Automation.Api.Factories;
using Prestashop.Automation.Core.Configuration;
using Prestashop.Automation.Core.Constants;

namespace Prestashop.Automation.TestSupport.TestData;

public sealed class PrestashopTestDataService
{
    private readonly ResourceCleanupTracker _cleanupTracker;
    private readonly CustomersApi _customersApi;
    private readonly ProductsApi _productsApi;
    private readonly TestSettings _settings;
    private readonly StockAvailablesApi _stockAvailablesApi;

    public PrestashopTestDataService(CustomersApi customersApi, ProductsApi productsApi, StockAvailablesApi stockAvailablesApi,
        ResourceCleanupTracker cleanupTracker, TestSettings settings)
    {
        _customersApi = customersApi;
        _productsApi = productsApi;
        _stockAvailablesApi = stockAvailablesApi;
        _cleanupTracker = cleanupTracker;
        _settings = settings;
    }

    public CreatedCustomer CreateCustomer()
    {
        CreateCustomerRequest request = CreateCustomerRequestFactory.CreateValid(_settings);
        CustomerEnvelope response = _customersApi.CreateCustomer(request);

        var id = response.Customer.Id ?? throw new InvalidOperationException("Customer id not returned");

        _cleanupTracker.Track(id, _customersApi);

        return new CreatedCustomer { Request = request, Response = response };
    }

    public CreatedProduct CreateProductWithQuantity(int quantity = TestDataConstants.Product.DefaultAvailableQuantity) =>
        CreateProduct(quantity);

    public CreatedProduct CreateProduct(int? quantity = null)
    {
        CreateProductRequest request = CreateProductRequestFactory.CreateValid(_settings.Prestashop);

        ProductEnvelope response = _productsApi.CreateProduct(request);

        var productId = response.Product.Id ?? throw new InvalidOperationException("Product id was not returned by API");

        _cleanupTracker.Track(productId, _productsApi);

        if (quantity is not null)
        {
            var stockAvailableId = _stockAvailablesApi.GetFirstStockAvailableIdForProduct(productId);

            _stockAvailablesApi.UpdateQuantity(stockAvailableId, quantity.Value);
        }

        return new CreatedProduct { Request = request, Response = response };
    }
}

public sealed class CreatedCustomer
{
    public required CreateCustomerRequest Request { get; init; }
    public required CustomerEnvelope Response { get; init; }

    public int Id => Response.Customer.Id!.Value;
    public string Email => Request.Email;
    public string Password => Request.Password;
    public string FullName => Request.FullName;
}

public sealed class CreatedProduct
{
    public required CreateProductRequest Request { get; init; }
    public required ProductEnvelope Response { get; init; }

    public int Id => Response.Product.Id!.Value;
    public string Name => Request.Name;
    public string Url => $"{Id}-{Request.Slug}";
}
