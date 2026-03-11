namespace Prestashop.Automation.Core.TestData.Models;

public class RegistrationUserData
{
    public string SocialTitle { get; set; } = "Mr.";
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string? Birthdate { get; set; }

    public string FullName => $"{FirstName} {LastName}";
}
