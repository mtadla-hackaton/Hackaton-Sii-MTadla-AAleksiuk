using Prestashop.Automation.Core.Constants;
using Prestashop.Automation.Core.Extensions;

namespace Prestashop.Automation.Core.TestData.Generators;

public static class TestDataGenerator
{
    public static string Email(string? firstName = null, string? lastName = null)
    {
        var uniquePart = Guid.NewGuid().ToString("N")[..10];

        if (string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(lastName))
        {
            return $"autotest-{uniquePart}@{TestDataConstants.User.EmailDomain}".ToLowerInvariant();
        }

        var safeFirstName = firstName?.ToSafeName().ToLowerInvariant();
        var safeLastName = lastName?.ToSafeName().ToLowerInvariant();

        return $"{safeFirstName}.{safeLastName}.{uniquePart}@{TestDataConstants.User.EmailDomain}".ToLowerInvariant();
    }

    public static string Password(int? length = null)
    {
        var finalLength = length ?? TestDataConstants.User.PasswordLength;

        var core = Guid.NewGuid().ToString("N");
        var value = $"Test!{core}";

        return value.Length <= finalLength ? value : value[..finalLength];
    }

    public static string Birthdate()
    {
        var minAge = TestDataConstants.User.BirthdateMinAge;
        var maxAge = TestDataConstants.User.BirthdateMaxAge;

        DateTime today = DateTime.Today;
        DateTime minDate = today.AddYears(-maxAge);
        DateTime maxDate = today.AddYears(-minAge);

        var range = (maxDate - minDate).Days;
        var randomDays = Random.Shared.Next(0, range + 1);
        DateTime date = minDate.AddDays(randomDays);

        return date.ToString(TestDataConstants.Date.DateFormat);
    }
}
