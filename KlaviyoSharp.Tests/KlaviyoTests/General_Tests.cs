namespace KlaviyoSharp.Tests;
[Trait("Category", "General")]
public class General_Tests : IClassFixture<General_Tests_Fixture>
{
    private General_Tests_Fixture Fixture { get; }
    public General_Tests(General_Tests_Fixture fixture)
    {
        Fixture = fixture;
    }

    [Fact]
    public async Task TooManyRetries()
    {
        // Get Accounts endoint is limited to 1 request per second. Easy one to force a retry on.
        KlaviyoAdminApi AdminApi = new(new KlaviyoConfig(Config.ApiKey) { MaxRetries = 0, MaxDelay = 1 });
        try
        {
            for (int i = 0; i < 10; i++)
            {
                var accounts = await AdminApi.AccountServices.GetAccounts();
            }
        }
        catch (ApplicationException ex)
        {
            Assert.True(ex.Message.Contains("Too many retries"), ex.Message);
        }

    }

     [Fact]
    public async Task RetryTooLong()
    {
        // Get Accounts endoint is limited to 1 request per second. Easy one to force a retry on.
        KlaviyoAdminApi AdminApi = new(new KlaviyoConfig(Config.ApiKey) { MaxRetries = 10, MaxDelay = 1 });
        try
        {
            for (int i = 0; i < 10; i++)
            {
                var accounts = await AdminApi.AccountServices.GetAccounts();
            }
        }
        catch (ApplicationException ex)
        {
            Assert.True(ex.Message.Contains("Retry-After is too high"), ex.Message);
        }

    }

}
public class General_Tests_Fixture : IAsyncLifetime
{
    public KlaviyoAdminApi AdminApi { get; } = new(Config.ApiKey);
    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }
    public Task InitializeAsync()
    {
        return Task.CompletedTask;
    }
}