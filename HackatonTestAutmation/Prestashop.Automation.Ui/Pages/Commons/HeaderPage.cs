using Prestashop.Automation.Core.Configuration;
using Prestashop.Automation.Ui.Pages.Base;

namespace Prestashop.Automation.Ui.Pages.Commons;

public class HeaderPage(IWebDriver driver, PrestashopUrls urls, TestSettings settings) : BasePage(driver, urls, settings)
{
    private IWebElement SignInBtn => Driver.WaitAndFind(By.CssSelector(".user-info"));
    private IWebElement SignOutBtn => Driver.WaitAndFind(By.CssSelector("a.logout"));
    private IWebElement ContactUsBtn => Driver.WaitAndFind(By.CssSelector("#contact-link"));
    private IWebElement AccountInfoLbl => Driver.WaitAndFind(By.CssSelector("span.hidden-sm-down"));
    private IWebElement ViewCustomerAccountBtn => Driver.WaitAndFind(By.CssSelector("span.hidden-sm-down"));
    public string SignedInText => ViewCustomerAccountBtn.Text;

    public void SignIn() => Click(SignInBtn);
}
