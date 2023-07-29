namespace KlaviyoSharp.Tests;
[Trait("Category", "CatalogServices")]
public class CatalogServices_Tests : IClassFixture<CatalogServices_Tests_Fixture>
{
    private CatalogServices_Tests_Fixture Fixture { get; }
    public CatalogServices_Tests(CatalogServices_Tests_Fixture fixture)
    {
        Fixture = fixture;
    }

    [Fact]
    public async Task Items()
    {
        var GetCatalogItems = await Fixture.AdminApi.CatalogServices.GetCatalogItems();
        Assert.NotNull(GetCatalogItems);
        var GetCreateItemsJobs = await Fixture.AdminApi.CatalogServices.GetCreateItemsJobs();
        Assert.NotNull(GetCreateItemsJobs);
        var GetUpdateItemsJobs = await Fixture.AdminApi.CatalogServices.GetUpdateItemsJobs();
        Assert.NotNull(GetUpdateItemsJobs);
        var GetDeleteItemsJobs = await Fixture.AdminApi.CatalogServices.GetDeleteItemsJobs();
        Assert.NotNull(GetDeleteItemsJobs);
    }

    [Fact]
    public async Task Variants()
    {
        var GetCatalogVariants = await Fixture.AdminApi.CatalogServices.GetCatalogVariants();
        Assert.NotNull(GetCatalogVariants);
        var GetCreateVariantsJobs = await Fixture.AdminApi.CatalogServices.GetCreateVariantsJobs();
        Assert.NotNull(GetCreateVariantsJobs);
        var GetUpdateVariantsJobs = await Fixture.AdminApi.CatalogServices.GetUpdateVariantsJobs();
        Assert.NotNull(GetUpdateVariantsJobs);
        var GetDeleteVariantsJobs = await Fixture.AdminApi.CatalogServices.GetDeleteVariantsJobs();
        Assert.NotNull(GetDeleteVariantsJobs);
    }

    [Fact]
    public async Task Categories()
    {
        var GetCatalogCategories = await Fixture.AdminApi.CatalogServices.GetCatalogCategories();
        Assert.NotNull(GetCatalogCategories);
        var GetCreateCategoriesJobs = await Fixture.AdminApi.CatalogServices.GetCreateCategoriesJobs();
        Assert.NotNull(GetCreateCategoriesJobs);
        var GetUpdateCategoriesJobs = await Fixture.AdminApi.CatalogServices.GetUpdateCategoriesJobs();
        Assert.NotNull(GetUpdateCategoriesJobs);
        var GetDeleteCategoriesJobs = await Fixture.AdminApi.CatalogServices.GetDeleteCategoriesJobs();
        Assert.NotNull(GetDeleteCategoriesJobs);
    }

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