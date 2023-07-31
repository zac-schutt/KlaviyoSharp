using KlaviyoSharp.Models;

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

        if (GetCatalogItems.Data.Count == 0)
        {
            var GetCatalogCategories = await Fixture.AdminApi.CatalogServices.GetCatalogCategories();

            var item = CatalogItem.Create();
            item.Attributes = new()
            {

            };
            item.Relationships = new()
            {
                Categories = new()
                {
                    Data = new()
                    {
                        new("category", GetCatalogCategories.Data.First().Id)
                    }
                }
            };
            await Fixture.AdminApi.CatalogServices.CreateCatalogItem(item);
        }
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
        if (GetCatalogVariants.Data.Count == 0)
        {
            var GetCatalogItems = await Fixture.AdminApi.CatalogServices.GetCatalogItems();

            var variant = CatalogVariant.Create();
            variant.Attributes = new()
            {
                ExternalId = "TEST",
                CatalogType = "$default",
                IntegrationType = "$custom",
                Title = "test item",
                Description = "Item for testing",
                Sku = "test",
                InventoryQuantity = 0,
                Price = 100,
                Url = "https://www.test.com",
                Published = true
            };
            variant.Relationships = new()
            {
                Item = new()
                {
                    Data = new("item", GetCatalogItems.Data.First().Id)
                }
            };
            await Fixture.AdminApi.CatalogServices.CreateCatalogVariant(variant);
        }
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

        if (GetCatalogCategories.Data.Count == 0)
        {
            var category = CatalogCategory.Create();
            category.Attributes = new()
            {
                ExternalId = "Testing",
                Name = "test category",
                IntegrationType = "$custom",
                CatalogType = "$default"
            };
        }
    }

    [Fact]
    public async Task BackInStock()
    {
        var profile = Fixture.AdminApi.ProfileServices.GetProfiles().Result.Data.First();
        var variant = Fixture.AdminApi.CatalogServices.GetCatalogVariants().Result.Data.First();
        var newProfile = Profile.Create();
        newProfile.Attributes = new() { Email = profile.Attributes.Email };
        var backInStockRequest = BackInStockSubscription.Create();
        backInStockRequest.Attributes = new()
        {
            Channels = new() { "EMAIL" },
            Profile = new(newProfile)
        };
        backInStockRequest.Relationships = new()
        {
            Variant = new()
            {
                Data = new("catalog-variant", variant.Id)
            }
        };
        await Fixture.AdminApi.CatalogServices.CreateBackInStockSubscription(backInStockRequest);
        Assert.True(true);
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