using Prestashop.Automation.Core.Configuration;
using RestSharp;
using RestSharp.Authenticators;

namespace Prestashop.Automation.Api.Client;

public class PrestashopApiClient
{
    private readonly RestClient _client;

    public PrestashopApiClient(TestSettings settings)
    {
        var options = new RestClientOptions(settings.Prestashop.BaseUrl)
        {
            Authenticator = new HttpBasicAuthenticator(settings.Prestashop.ApiKey, string.Empty)
        };

        _client = new RestClient(options);
    }

    public RestResponse Get(string resource, params (string Name, string Value)[] query)
    {
        RestRequest request = CreateRequest(resource, Method.Get, query);
        return Execute(request);
    }

    public RestResponse PostXml(string resource, string xmlBody, params (string Name, string Value)[] query)
    {
        RestRequest request = CreateRequest(resource, Method.Post, query);
        request.AddStringBody(xmlBody, ContentType.Xml);
        return Execute(request);
    }

    public RestResponse PutXml(string resource, string xmlBody, params (string Name, string Value)[] query)
    {
        RestRequest request = CreateRequest(resource, Method.Put, query);
        request.AddStringBody(xmlBody, ContentType.Xml);
        return Execute(request);
    }

    public RestResponse Delete(string resource, params (string Name, string Value)[] query)
    {
        RestRequest request = CreateRequest(resource, Method.Delete, query);
        return Execute(request);
    }

    private static RestRequest CreateRequest(string resource, Method method, params (string Name, string Value)[] query)
    {
        var request = new RestRequest(resource, method);
        request.AddHeader("Accept", "application/xml");

        foreach ((string Name, string Value) item in query)
        {
            request.AddQueryParameter(item.Name, item.Value);
        }

        return request;
    }

    private RestResponse Execute(RestRequest request)
    {
        RestResponse response = _client.Execute(request);
        if (response.IsSuccessful)
        {
            return response;
        }

        var content = string.IsNullOrWhiteSpace(response.Content) ? "No response body." : response.Content;
        throw new InvalidOperationException(
            $"PrestaShop API request failed. StatusCode: {(int)response.StatusCode}. Error: {response.ErrorMessage ?? "none"}. Body: {content}");
    }
}
