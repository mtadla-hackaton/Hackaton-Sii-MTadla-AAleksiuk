using Prestashop.Automation.Core.Configuration;

namespace Prestashop.Automation.Ui.Pages.Base;

public abstract class BaseComponent : BaseElement
{
    protected readonly IWebElement Parent;


    protected BaseComponent(IWebElement parent, IWebDriver driver, PrestashopUrls urls, TestSettings settings) : base(driver, urls,
        settings) => Parent = parent;
}
