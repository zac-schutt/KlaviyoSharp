namespace KlaviyoSharp.Tests;
[Trait("Category", "AccountServices")]
public class AccountServices_Tests : IClassFixture<AccountServices_Tests_Fixture>
{
    private AccountServices_Tests_Fixture Fixture { get; }
    public AccountServices_Tests(AccountServices_Tests_Fixture fixture)
    {
        Fixture = fixture;
    }

    [Fact]
    public async Task GetAccounts()
    {
        var accounts = await Fixture.AdminApi.AccountServices.GetAccounts(new List<string>() { "public_api_key" });
        Assert.Single(accounts.Data);
        var account = await Fixture.AdminApi.AccountServices.GetAccount(accounts.Data[0].Id, new List<string>() { "public_api_key", "contact_information.street_address" });
        Assert.NotNull(account.Data);
    }

}
public class AccountServices_Tests_Fixture : IAsyncLifetime
{
    public KlaviyoAdminApi AdminApi { get; } = new(new KlaviyoConfig(Config.ApiKey) { MaxDelay = 120, MaxRetries = 5 });
    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }
    public Task InitializeAsync()
    {
        return Task.CompletedTask;
    }
}