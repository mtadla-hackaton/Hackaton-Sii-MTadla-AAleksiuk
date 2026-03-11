namespace Prestashop.Automation.Core.Constants;

public static class TestDataConstants
{
    public static class Date
    {
        public const string DateFormat = "MM/dd/yyyy";
    }

    public static class User
    {
        public const int MinFirstNameLength = 5;
        public const int MaxFirstNameLength = 15;

        public const int MinLastNameLength = 5;
        public const int MaxLastNameLength = 15;

        public const int PasswordLength = 10;

        public const int BirthdateMinAge = 18;
        public const int BirthdateMaxAge = 60;

        public const string EmailDomain = "example.test";

        public static readonly string[] SocialTitles =
        [
            "Mr.",
            "Mrs."
        ];
    }

    public static class Product
    {
        public const int Active = 1;
        public const int Inactive = 0;

        public const int StateEnabled = 1;
        public const int StateDisabled = 0;

        public const int MinPrice = 1;
        public const int MaxPrice = 100;

        public const int DefaultBuyQuantity = 1;
        public const int DefaultAvailableQuantity = 100;

        public const int MinimalQuantityDefault = 1;

        public const int AvailableForOrder = 1;
        public const string VisibleInCatalogAndSearch = "both";
        public const int ShowPrice = 1;
        public const int MinimalQuantity = 1;
    }
}
