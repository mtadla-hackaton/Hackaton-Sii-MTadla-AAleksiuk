using NUnit.Framework;
using Prestashop.Automation.Core.Configuration;
using Prestashop.Automation.Core.Logging;

namespace Prestashop.Automation.Core.Base;

public abstract class TestBase<TUserSecretsMarker> where TUserSecretsMarker : class
{
    private static readonly ILog LocalLog = new NUnitLog();
    private static readonly ILog CiLog = new ReportPortalLog();
    protected TestSettings Settings { get; private set; }

    [SetUp]
    public void BaseSetUp()
    {
        Settings = SettingsLoader.Load<TUserSecretsMarker>(TestContext.CurrentContext.TestDirectory);

        Logger.Current = CiEnvironment.IsCi() ? CiLog : LocalLog;
    }
}
