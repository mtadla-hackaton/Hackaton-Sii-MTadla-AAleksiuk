using Prestashop.Automation.Core.Configuration;

namespace Prestashop.Automation.Ui.Pages.Base;

public abstract class BasePage(IWebDriver driver, PrestashopUrls urls, TestSettings settings) : BaseElement(driver, urls, settings)
{
    public virtual void GoTo() => throw new NotImplementedException($"GoTo method is not implemented for {GetType().Name} page.");
}
