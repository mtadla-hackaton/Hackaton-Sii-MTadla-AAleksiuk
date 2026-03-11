using NUnit.Framework;

namespace Prestashop.Tests.Api.Base;

public abstract class ApiTestBase : TestWithApiBase<ApiTestBase>
{
    [TearDown]
    public void ApiTearDown() => CleanupTrackedResources();
}
