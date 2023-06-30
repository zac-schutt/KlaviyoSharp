namespace KlaviyoSharp.Tests;

/// <summary>
/// Tests for the configuration class.
/// </summary>
[Trait("Category", "Config")]
public class Config_Tests
{
    private readonly ITestOutputHelper output;
    public Config_Tests(ITestOutputHelper output)
    {
        this.output = output;
    }
    /// <summary>
    /// Looks for an environment variable called KLAVIYO_COMPANY and ensures that it's not blank.
    /// </summary>
    [Fact]
    public void CheckCompanyId()
    {
        string company = Config.CompanyId;
        output.WriteLine($"Company ID: {company}");
        Assert.False(string.IsNullOrEmpty(Config.CompanyId));
    }

    /// <summary>
    /// Looks for an environment variable called KLAVIYO_API_KEY and ensures that it's not blank.
    /// </summary>
    [Fact]
    public void CheckApiKey()
    {
        string key = Config.ApiKey;
        output.WriteLine($"API Key: {key}");
        Assert.False(string.IsNullOrEmpty(Config.ApiKey));
    }
}