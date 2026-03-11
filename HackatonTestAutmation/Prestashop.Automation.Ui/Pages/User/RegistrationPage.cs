using Prestashop.Automation.Core.Configuration;
using Prestashop.Automation.Core.TestData.Models;
using Prestashop.Automation.Ui.Pages.Base;

namespace Prestashop.Automation.Ui.Pages.User;

public class RegistrationPage(IWebDriver driver, PrestashopUrls urls, TestSettings settings) : BasePage(driver, urls, settings)
{
    private IList<IWebElement> SocialTitleLbl => Driver.FindElementsGraterThenZero(By.CssSelector("input[name='id_gender']"));
    private IWebElement FirstNameLbl => Driver.WaitAndFind(By.CssSelector("[name='firstname']"));
    private IWebElement LastNameLbl => Driver.WaitAndFind(By.CssSelector("[name='lastname']"));
    private IWebElement EmailLbl => Driver.WaitAndFind(By.CssSelector("[name='email']"));
    private IWebElement PasswordLbl => Driver.WaitAndFind(By.CssSelector("[name='password']"));
    private IWebElement BirthdateLbl => Driver.WaitAndFind(By.CssSelector("[name='birthday']"));
    private IWebElement OffersChbx => Driver.WaitAndFind(By.CssSelector("label:has(input[name='optin'])"));
    private IWebElement TermsAndConditionChbx => Driver.WaitAndFind(By.CssSelector("label:has(input[name='psgdpr'])"));
    private IWebElement NewsletterChbx => Driver.WaitAndFind(By.CssSelector("label:has(input[name='newsletter'])"));
    private IWebElement CustomerPrivacyChbx => Driver.WaitAndFind(By.CssSelector("label:has(input[name='customer_privacy'])"));
    private IWebElement SubmitBtn => Driver.WaitAndFind(By.CssSelector("button[data-link-action='save-customer']"));
    public override void GoTo() => Driver.GoToUrl(Urls.Register());

    //public void SetTitle() => Click(SocialTitleLbl);


    public void SetFirstName(string firstName) => SendKeys(FirstNameLbl, firstName);
    public void SetLastName(string lastName) => SendKeys(LastNameLbl, lastName);
    public void SetEmail(string email) => SendKeys(EmailLbl, email);
    public void SetPassword(string password) => SendKeys(PasswordLbl, password);
    public void SetBirthdayDate(string birthDate) => SendKeys(BirthdateLbl, birthDate);
    public void SetOffers() => Click(OffersChbx);
    public void SetTermsAndCondition() => Click(TermsAndConditionChbx);
    public void SetNewsletter() => Click(NewsletterChbx);
    public void SetCustomerPrivacy() => Click(CustomerPrivacyChbx);
    public void SubmitUser() => Click(SubmitBtn);

    public void FillRegisterForm(RegistrationUserData userData)
    {
        SetFirstName(userData.FirstName);
        SetLastName(userData.LastName);
        SetEmail(userData.Email);
        SetPassword(userData.Password);
        SetBirthdayDate(userData.Birthdate);
        SetOffers();
        SetTermsAndCondition();
        SetNewsletter();
        SetCustomerPrivacy();
    }
}
