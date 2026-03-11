using Bogus;
using Prestashop.Automation.Api.Domain.Customers;
using Prestashop.Automation.Core.Configuration;
using Prestashop.Automation.Core.TestData.Generators;

namespace Prestashop.Automation.Api.Factories;

public static class CreateCustomerRequestFactory
{
    private static Faker<CreateCustomerRequest> CreateFaker(TestSettings settings)
    {
        return new Faker<CreateCustomerRequest>().RuleFor(x => x.FirstName, f => f.Name.FirstName())
            .RuleFor(x => x.LastName, f => f.Name.LastName())
            .RuleFor(x => x.Email, (_, u) => TestDataGenerator.Email(u.FirstName, u.LastName))
            .RuleFor(x => x.Password, f => f.Internet.Password(12))
            .RuleFor(x => x.DefaultGroupId, _ => settings.Prestashop.DefaultCustomerGroupId)
            .RuleFor(x => x.LanguageId, _ => settings.Prestashop.LanguageId);
    }

    public static CreateCustomerRequest CreateValid(TestSettings settings) => CreateFaker(settings).Generate();
}
