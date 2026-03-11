using Prestashop.Automation.Core.Configuration;
using Prestashop.Automation.Core.Helpers;

namespace Prestashop.Automation.Ui.Navigation;

public class PrestashopUrls(TestSettings settings)
{
    private readonly Uri _baseUri = settings.Prestashop.BaseUrl;

    public string Home() => UrlBuilder.Build(_baseUri);

    public string Login() => UrlBuilder.Build(_baseUri, "login");

    public string Register() => UrlBuilder.Build(_baseUri, "registration");

    public string Cart() => UrlBuilder.Build(_baseUri, "cart?action=show");
    public string ArtCategory() => UrlBuilder.Build(_baseUri, "9-art");

    public string Product(string productSlug) => UrlBuilder.Build(_baseUri, $"{productSlug}.html");

    public string Category(string categorySlug) => UrlBuilder.Build(_baseUri, categorySlug);
}
