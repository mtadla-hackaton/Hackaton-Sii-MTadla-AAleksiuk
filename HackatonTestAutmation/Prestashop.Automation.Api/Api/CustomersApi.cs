using Prestashop.Automation.Api.Client;
using Prestashop.Automation.Api.Domain.Customers;
using Prestashop.Automation.Api.Helpers;
using Prestashop.Automation.Core.Configuration;
using RestSharp;

namespace Prestashop.Automation.Api.Api;

public class CustomersApi : IDeletableByIdApi
{
    private readonly PrestashopApiClient _client;
    private readonly PrestashopSettings _settings;

    public CustomersApi(PrestashopApiClient client, PrestashopSettings settings)
    {
        _client = client;
        _settings = settings;
    }

    public void DeleteById(int customerId) => _client.Delete($"/api/customers/{customerId}");


    public CustomerEnvelope CreateCustomer(CreateCustomerRequest request)
    {
        var payload = XmlSerialization.Serialize(new CustomerCreateEnvelope
        {
            Customer = new CustomerCreateDto
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
                DefaultGroupId = request.DefaultGroupId,
                LanguageId = request.LanguageId,
                Active = 1,
                Newsletter = 0,
                OptIn = 0,
                Associations = new CustomerAssociationsCreateDto
                {
                    Groups =
                    [
                        new CustomerGroupCreateDto { Id = request.DefaultGroupId }
                    ]
                }
            }
        });
        RestResponse createResponse = _client.PostXml("/api/customers", payload);
        return XmlSerialization.Deserialize<CustomerEnvelope>(createResponse.Content!);
    }

    public CustomerEnvelope GetById(int customerId)
    {
        RestResponse response = _client.Get($"/api/customers/{customerId}");
        return XmlSerialization.Deserialize<CustomerEnvelope>(response.Content!);
    }
}
