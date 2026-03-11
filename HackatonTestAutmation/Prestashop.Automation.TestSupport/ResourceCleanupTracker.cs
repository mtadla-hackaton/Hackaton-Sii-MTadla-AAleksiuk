using Prestashop.Automation.Api.Api;
using Prestashop.Automation.Core.Logging;

namespace Prestashop.Automation.TestSupport;

public class ResourceCleanupTracker
{
    private readonly List<(int Id, IDeletableByIdApi Api)> _resources = [];

    public int Track(int id, IDeletableByIdApi api)
    {
        _resources.Add((id, api));
        return id;
    }

    public void Cleanup()
    {
        foreach ((int Id, IDeletableByIdApi Api) item in _resources.DistinctBy(x => (x.Id, x.Api)).ToList())
        {
            TryDelete(() => item.Api.DeleteById(item.Id));
        }
    }

    private static void TryDelete(Action deleteAction)
    {
        try
        {
            deleteAction();
        }
        catch (Exception e)
        {
            Logger.Info($"Failed to delete resource: {e.Message}");
        }
    }
}
