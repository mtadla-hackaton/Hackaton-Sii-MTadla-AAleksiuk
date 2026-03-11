using Prestashop.Automation.Api.Client;
using Prestashop.Automation.Api.Domain.StockAvailables;
using Prestashop.Automation.Api.Helpers;
using Prestashop.Automation.Core.Configuration;
using RestSharp;

namespace Prestashop.Automation.Api.Api;

public class StockAvailablesApi
{
    private readonly PrestashopApiClient _client;
    private readonly PrestashopSettings Settings;

    public StockAvailablesApi(PrestashopApiClient client, PrestashopSettings settings)
    {
        _client = client;
        Settings = settings;
    }

    public int GetFirstStockAvailableIdForProduct(int productId)
    {
        RestResponse response = _client.Get("/api/stock_availables", ("filter[id_product]", $"[{productId}]"), ("display", "[id]"));

        StockAvailableReferenceListEnvelope list = XmlSerialization.Deserialize<StockAvailableReferenceListEnvelope>(response.Content!);
        StockAvailableReferenceDto? first = list.StockAvailables.Items.FirstOrDefault();
        if (first is null)
        {
            throw new InvalidOperationException($"No stock_available entry found for product id {productId}.");
        }

        var stockAvailableId = first.ResolveId();
        if (stockAvailableId <= 0)
        {
            throw new InvalidOperationException($"Could not resolve stock_available id for product id {productId}.");
        }

        return stockAvailableId;
    }

    public StockAvailableEnvelope GetById(int stockAvailableId)
    {
        RestResponse response = _client.Get($"/api/stock_availables/{stockAvailableId}");
        return XmlSerialization.Deserialize<StockAvailableEnvelope>(response.Content!);
    }

    public StockAvailableEnvelope UpdateQuantity(int stockAvailableId, int newQuantity)
    {
        StockAvailableEnvelope existing = GetById(stockAvailableId);
        existing.StockAvailable.Quantity = newQuantity;

        var payload = XmlSerialization.Serialize(existing);
        RestResponse response = _client.PutXml($"/api/stock_availables/{stockAvailableId}", payload);
        return XmlSerialization.Deserialize<StockAvailableEnvelope>(response.Content!);
    }
}
