using NUnit.Framework;
using Prestashop.Automation.Api.Api;
using Prestashop.Automation.Api.Client;
using Prestashop.Automation.Core.Base;
using Prestashop.Automation.Core.Logging;
using Prestashop.Automation.TestSupport;

namespace Prestashop.Tests.Api.Base;

public abstract class TestWithApiBase<TUserSecretsMarker> : TestBase<TUserSecretsMarker> where TUserSecretsMarker : class
{
    protected ResourceCleanupTracker _cleanupTracker;
    protected CustomersApi CustomersApi;
    protected ProductsApi ProductsApi;
    protected StockAvailablesApi StockAvailablesApi;

    [SetUp]
    public void ApiCommonSetUp()
    {
        var client = new PrestashopApiClient(Settings);
        CustomersApi = new CustomersApi(client, Settings.Prestashop);
        ProductsApi = new ProductsApi(client, Settings.Prestashop);
        StockAvailablesApi = new StockAvailablesApi(client, Settings.Prestashop);
        _cleanupTracker = new ResourceCleanupTracker();
    }

    protected int TrackCustomer(int customerId) => _cleanupTracker.Track(customerId, CustomersApi);
    protected int TrackProduct(int productId) => _cleanupTracker.Track(productId, ProductsApi);

    protected void CleanupTrackedResources()
    {
        try
        {
            _cleanupTracker.Cleanup();
        }
        catch (Exception ex)
        {
            Logger.Error($"Cleanup failed: {ex}");
        }
    }
}
