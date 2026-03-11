using AwesomeAssertions;
using NUnit.Framework;
using Prestashop.Automation.Api.Domain.Customers;
using Prestashop.Automation.Api.Factories;
using Prestashop.Tests.Api.Base;

namespace Prestashop.Tests.Api.Tests.Customer;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class CustomerApiTests : ApiTestBase
{
    [Test]
    public void Should_Create_Shop_User()
    {
        // Arrange
        const int minValidId = 0;
        CreateCustomerRequest createCustomerRequest = CreateCustomerRequestFactory.CreateValid(Settings);

        // Act
        CustomerEnvelope created = CustomersApi.CreateCustomer(createCustomerRequest);


        // Assert
        created.Customer.Id.Should().NotBeNull();
        var customerId = TrackCustomer(created.Customer.Id!.Value);
        customerId.Should().BeGreaterThan(minValidId);
        created.Customer.Email.Should().Be(createCustomerRequest.Email);
    }
}
