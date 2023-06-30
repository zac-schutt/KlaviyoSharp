namespace KlaviyoSharp.Tests;

/// <summary>
/// Tests for the configuration class.
/// </summary>
[Trait("Category", "Config")]
public class Config_Tests
{
    /// <summary>
    /// Looks for an environment variable called KLAVIYO_COMPANY and ensures that it's not blank.
    /// </summary>
    [Fact]
    public void CheckCompanyId()
    {
        Assert.False(string.IsNullOrEmpty(Config.CompanyId));
    }

    /// <summary>
    /// Looks for an environment variable called KLAVIYO_API_KEY and ensures that it's not blank.
    /// </summary>
    [Fact]
    public void CheckApiKey()
    {
        Assert.False(string.IsNullOrEmpty(Config.ApiKey));
    }
}