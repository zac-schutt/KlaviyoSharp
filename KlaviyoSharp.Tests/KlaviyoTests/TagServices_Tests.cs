namespace KlaviyoSharp.Tests;
[Trait("Category", "TagServices")]
public class TagServices_Tests : IClassFixture<TagServices_Tests_Fixture>
{
    private TagServices_Tests_Fixture Fixture { get; }
    public TagServices_Tests(TagServices_Tests_Fixture fixture)
    {
        Fixture = fixture;
    }

    [Fact]
    public async Task GetTags()
    {
        var tags = await Fixture.AdminApi.TagServices.GetTags();
        Assert.NotNull(tags);
    }
    [Fact]
    public async Task GetTagGroups(){
        var tagGroups = await Fixture.AdminApi.TagServices.GetTagGroups();
        Assert.NotNull(tagGroups);
    }

}
public class TagServices_Tests_Fixture : IAsyncLifetime
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