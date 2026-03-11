using AwesomeAssertions;
using NUnit.Framework;
using Prestashop.Automation.Core.TestData.Factories;
using Prestashop.Automation.Core.TestData.Models;
using Prestashop.Automation.Ui.Pages.Commons;
using Prestashop.Automation.Ui.Pages.User;

namespace Prestashop.Tests.Ui.User;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class SuccessfulCreateAccount : UiTestBase
{
    [Test]
    public void Should_Create_Account_For_Valid_User()
    {
        // Arrange
        RegistrationUserData userData = RegistrationUserFactory.CreateValid();

        //Act
        At<RegistrationPage>(x =>
        {
            x.GoTo();
            x.FillRegisterForm(userData);
            x.SubmitUser();
        });

        //Assert
        var actualFullName = At<HeaderPage>().SignedInText;
        actualFullName.Should().Be(userData.FullName);
    }
}
