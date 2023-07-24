namespace KlaviyoSharp.Tests;
[Trait("Category", "CatalogServices")]
public class CatalogServices_Tests : IClassFixture<CatalogServices_Tests_Fixture>
{
    private CatalogServices_Tests_Fixture Fixture { get; }
    public CatalogServices_Tests(CatalogServices_Tests_Fixture fixture)
    {
        Fixture = fixture;
    }

    //Add Tests Here

}
public class CatalogServices_Tests_Fixture : IAsyncLifetime
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