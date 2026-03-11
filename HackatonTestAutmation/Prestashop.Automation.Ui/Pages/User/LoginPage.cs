using Prestashop.Automation.Core.Configuration;
using Prestashop.Automation.Ui.Pages.Base;

namespace Prestashop.Automation.Ui.Pages.User;

public class LoginPage(IWebDriver driver, PrestashopUrls urls, TestSettings settings) : BasePage(driver, urls, settings)
{
    private IWebElement CreateAccountBtn => Driver.WaitAndFind(By.CssSelector(".no-account"));
    private IWebElement EmailLbl => Driver.WaitAndFind(By.CssSelector("[name='email']"));
    private IWebElement PasswordLbl => Driver.WaitAndFind(By.CssSelector("[name='password']"));
    private IWebElement SignInBtn => Driver.WaitAndFind(By.CssSelector("#submit-login"));
    public override void GoTo() => Driver.GoToUrl(Urls.Login());

    public void SetEmail(string email) => SendKeys(EmailLbl, email);
    public void SetPassword(string password) => SendKeys(PasswordLbl, password);
    public void SignIn() => Click(SignInBtn);
}
