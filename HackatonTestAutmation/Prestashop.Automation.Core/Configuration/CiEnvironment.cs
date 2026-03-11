namespace Prestashop.Automation.Core.Configuration;

public static class CiEnvironment
{
    public static bool IsCi()
    {
        var explicitFlag = ReadBool("TEST_IS_CI") ?? ReadBool("CI");
        if (explicitFlag.HasValue)
        {
            return explicitFlag.Value;
        }

        return ReadBool("GITHUB_ACTIONS") == true || ReadBool("TF_BUILD") == true || ReadBool("GITLAB_CI") == true ||
               !string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("JENKINS_URL"));
    }

    private static bool? ReadBool(string name)
    {
        var v = Environment.GetEnvironmentVariable(name);
        if (string.IsNullOrWhiteSpace(v))
        {
            return null;
        }

        return v.Trim().ToLowerInvariant() switch
        {
            "1" or "true" or "yes" or "y" => true,
            "0" or "false" or "no" or "n" => false,
            _ => null
        };
    }
}
