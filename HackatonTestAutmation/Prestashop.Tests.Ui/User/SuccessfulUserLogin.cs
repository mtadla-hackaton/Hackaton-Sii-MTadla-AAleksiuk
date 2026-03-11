using AwesomeAssertions;
using NUnit.Framework;
using Prestashop.Automation.TestSupport.TestData;
using Prestashop.Automation.Ui.Pages.Commons;
using Prestashop.Automation.Ui.Pages.User;

namespace Prestashop.Tests.Ui.User;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class SuccessfulUserLogin : UiTestBase
{
    [Test]
    [Repeat(1)]
    public void Should_Login_User_Successfully()
    {
        // Arrange
        CreatedCustomer customer = PrestashopTestDataService.CreateCustomer();

        //Assert
        At<LoginPage>(x =>
        {
            x.GoTo();
            x.SetEmail(customer.Email);
            x.SetPassword(customer.Password);
            x.SignIn();
        });

        At<HeaderPage>(x => x.SignedInText.Should().Be($"{customer.FullName}"));
    }
}
