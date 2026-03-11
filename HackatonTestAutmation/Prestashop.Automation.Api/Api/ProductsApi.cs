using Prestashop.Automation.Api.Client;
using Prestashop.Automation.Api.Domain.Product;
using Prestashop.Automation.Api.Helpers;
using Prestashop.Automation.Core.Configuration;
using Prestashop.Automation.Core.Constants;
using RestSharp;

namespace Prestashop.Automation.Api.Api;

public class ProductsApi : IDeletableByIdApi
{
    private readonly PrestashopApiClient _client;
    private readonly PrestashopSettings _settings;

    public ProductsApi(PrestashopApiClient client, PrestashopSettings settings)
    {
        _client = client;
        _settings = settings;
    }

    public void DeleteById(int productId) => _client.Delete($"/api/products/{productId}");

    public ProductEnvelope CreateProduct(CreateProductRequest request)
    {
        var payload = XmlSerialization.Serialize(new ProductCreateEnvelope
        {
            Product = new ProductCreateDto
            {
                DefaultCategoryId = request.DefaultCategoryId,
                TaxRulesGroupId = request.TaxRulesGroupId,
                DefaultShopId = request.DefaultShopId,
                Active = TestDataConstants.Product.Active,
                State = TestDataConstants.Product.StateEnabled,
                Price = request.Price,
                Name = BuildLocalizedField(request.Name),
                LinkRewrite = BuildLocalizedField(request.Slug),
                AvailableForOrder = request.AvailableForOrder,
                Visibility = request.Visibility,
                ShowPrice = request.ShowPrice,
                MinimalQuantity = request.MinimalQuantity,
                Associations = new ProductAssociationsCreateDto
                {
                    Categories =
                    [
                        new ProductCategoryCreateDto { Id = request.DefaultCategoryId }
                    ]
                }
            }
        });
        RestResponse createResponse = _client.PostXml("/api/products", payload);
        return XmlSerialization.Deserialize<ProductEnvelope>(createResponse.Content!);
    }

    public ProductEnvelope GetById(int productId)
    {
        RestResponse response = _client.Get($"/api/products/{productId}");
        return XmlSerialization.Deserialize<ProductEnvelope>(response.Content!);
    }

    private ProductLocalizedFieldCreateDto BuildLocalizedField(string value)
    {
        return new ProductLocalizedFieldCreateDto
        {
            Languages =
            [
                new ProductLanguageCreateDto { Id = _settings.LanguageId, Value = value }
            ]
        };
    }
}
