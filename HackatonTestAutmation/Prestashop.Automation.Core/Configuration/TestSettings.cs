using Microsoft.Extensions.Configuration;

namespace Prestashop.Automation.Core.Configuration;

public class TestSettings
{
    public required PrestashopSettings Prestashop { get; init; }
    public required Timeouts Timeouts { get; init; }
    public required BrowserSettings Browser { get; init; }
    public required Paths Paths { get; init; }
}

public class Paths
{
    public required string ArtifactsDirectory { get; init; }
}

public class PrestashopSettings
{
    public required Uri BaseUrl { get; init; }

    public Uri ApiBaseUrl => new(BaseUrl, "api/");

    public string? ApiKey { get; init; }

    public required int LanguageId { get; init; }
    public required int DefaultCategoryId { get; init; }
    public required int DefaultShopId { get; init; }
    public required int TaxRulesGroupId { get; init; }
    public required int DefaultCustomerGroupId { get; init; }
}

public class Timeouts
{
    public int UiExplicitWait { get; init; }
}

public class BrowserSettings
{
    public string BrowserName { get; init; }
    public bool Headless { get; init; }
    public string WindowSize { get; init; }
}

public static class SettingsLoader
{
    public static TestSettings Load<TUserSecretsMarker>(string basePath = ".") where TUserSecretsMarker : class
    {
        IConfigurationRoot cfg = new ConfigurationBuilder().SetBasePath(basePath)
            .AddJsonFile("appsettings.json", false)
            .AddUserSecrets<TUserSecretsMarker>(true)
            .AddEnvironmentVariables()
            .Build();

        TestSettings settings = cfg.Get<TestSettings>() ?? throw new InvalidOperationException("Configuration could not be loaded.");

        Validate(settings);
        return settings;
    }

    private static void Validate(TestSettings s)
    {
        if (s.Prestashop is null)
        {
            throw new InvalidOperationException("Prestashop section is required.");
        }

        if (s.Prestashop.BaseUrl is null)
        {
            throw new InvalidOperationException("Prestashop:BaseUrl is required.");
        }

        if (s.Prestashop.LanguageId <= 0)
        {
            throw new InvalidOperationException("Prestashop:LanguageId must be greater than 0.");
        }

        if (s.Prestashop.DefaultCategoryId <= 0)
        {
            throw new InvalidOperationException("Prestashop:DefaultCategoryId must be greater than 0.");
        }

        if (s.Prestashop.DefaultShopId <= 0)
        {
            throw new InvalidOperationException("Prestashop:DefaultShopId must be greater than 0.");
        }

        if (s.Prestashop.TaxRulesGroupId <= 0)
        {
            throw new InvalidOperationException("Prestashop:TaxRulesGroupId must be greater than 0.");
        }


        if (string.IsNullOrWhiteSpace(s.Prestashop.ApiKey))
        {
            throw new ArgumentException("""
                                        ApiKey is missing.

                                        For local execution add in secrets.json:

                                        {
                                          "ApiKey": "YOUR_API_KEY"
                                        }

                                        On CI/CD set env variable: TEST_ApiKey=YOUR_API_KEY
                                        """);
        }
    }
}
