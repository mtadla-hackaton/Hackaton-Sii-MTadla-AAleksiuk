using Bogus;
using Prestashop.Automation.Api.Domain.Product;
using Prestashop.Automation.Core.Configuration;
using Prestashop.Automation.Core.Constants;
using Prestashop.Automation.Core.Extensions;

namespace Prestashop.Automation.Api.Factories;

public static class CreateProductRequestFactory
{
    private static Faker<CreateProductRequest> CreateFaker(PrestashopSettings settings)
    {
        return new Faker<CreateProductRequest>().RuleFor(x => x.Name, f => f.Commerce.ProductName())
            .RuleFor(x => x.Slug, (_, p) => p.Name.ToSlug())
            .RuleFor(x => x.Price, f => f.Random.Int(TestDataConstants.Product.MinPrice, TestDataConstants.Product.MaxPrice))
            .RuleFor(x => x.DefaultCategoryId, _ => settings.DefaultCategoryId)
            .RuleFor(x => x.DefaultShopId, _ => settings.DefaultShopId)
            .RuleFor(x => x.TaxRulesGroupId, _ => settings.TaxRulesGroupId);
    }

    public static CreateProductRequest CreateValid(PrestashopSettings settings) => CreateFaker(settings).Generate();
}
