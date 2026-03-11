using Bogus;
using Prestashop.Automation.Core.Constants;
using Prestashop.Automation.Core.Extensions;
using Prestashop.Automation.Core.TestData.Generators;
using Prestashop.Automation.Core.TestData.Models;

namespace Prestashop.Automation.Core.TestData.Factories;

public static class RegistrationUserFactory
{
    private static readonly Faker<RegistrationUserData> Faker = new Faker<RegistrationUserData>()
        .RuleFor(x => x.SocialTitle, f => f.PickRandom(TestDataConstants.User.SocialTitles))
        .RuleFor(x => x.FirstName, f => f.Name.FirstName().ToSafeName())
        .RuleFor(x => x.LastName, f => f.Name.LastName().ToSafeName())
        .RuleFor(x => x.Email, (_, u) => TestDataGenerator.Email(u.FirstName, u.LastName))
        .RuleFor(x => x.Password, f => f.Internet.Password())
        .RuleFor(x => x.Birthdate, _ => TestDataGenerator.Birthdate());

    public static RegistrationUserData CreateValid() => Faker.Generate();
}
