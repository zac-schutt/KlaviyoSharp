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
        var accounts = await Fixture.AdminApi.AccountServices.GetAccounts();
        Fixture.AccountId ??= accounts.Data[0].Id;
        Assert.Single(accounts.Data);
    }
    [Fact]
    public async Task GetAccountsWithFields()
    {
        var accounts = await Fixture.AdminApi.AccountServices.GetAccounts(new List<string>() { "public_api_key" });
        Fixture.AccountId ??= accounts.Data[0].Id;
        Assert.Single(accounts.Data);
    }

    [Fact]
    public async Task GetAccount()
    {
        Fixture.AccountId ??= Fixture.AdminApi.AccountServices.GetAccounts().Result.Data[0].Id;
        var account = await Fixture.AdminApi.AccountServices.GetAccount(Fixture.AccountId);
        Assert.NotNull(account);
    }

    [Fact]
    public async Task GetAccountWithFields()
    {
        Fixture.AccountId ??= Fixture.AdminApi.AccountServices.GetAccounts().Result.Data[0].Id;
        var account = await Fixture.AdminApi.AccountServices.GetAccount(Fixture.AccountId, new List<string>() { "public_api_key","contact_information.street_address" });
        Assert.NotNull(account);
    }

}
public class AccountServices_Tests_Fixture : IAsyncLifetime
{
    public KlaviyoAdminApi AdminApi { get; } = new(Config.ApiKey);
    public string AccountId = null;
    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }
    public Task InitializeAsync()
    {
        return Task.CompletedTask;
    }
}