using KlaviyoSharp.Models;

namespace KlaviyoSharp.Tests;
[Trait("Category", "ListServices")]
public class ListServices_Tests : IClassFixture<ListServices_Tests_Fixture>
{
    private ListServices_Tests_Fixture Fixture { get; }
    public ListServices_Tests(ListServices_Tests_Fixture fixture)
    {
        Fixture = fixture;
    }

    [Fact]
    public async Task GetLists()
    {
        var lists = await Fixture.AdminApi.ListServices.GetLists();
        Assert.NotNull(lists);
    }

    [Fact]
    public async Task GetList()
    {
        var lists = await Fixture.AdminApi.ListServices.GetLists();
        Assert.NotEmpty(lists);
        var list = await Fixture.AdminApi.ListServices.GetList(lists[0].Id);
        Assert.NotNull(list);
    }

    [Fact]
    public async Task CRUDList()
    {
        var list = await Fixture.AdminApi.ListServices.CreateList(new ListAttributes() { Name = $"Test List - {Config.Random}" });
        Assert.NotNull(list);
        var updatedList = await Fixture.AdminApi.ListServices.UpdateList(list.Id, new ListAttributes() { Name = $"{list.Attributes.Name} - Updated" });
        Assert.NotNull(updatedList);
        Assert.Equal(list.Id, updatedList.Id);
        await Fixture.AdminApi.ListServices.DeleteList(list.Id);
        Assert.True(true);
    }

    [Fact]
    public async Task GetListTags()
    {
        var lists = await Fixture.AdminApi.ListServices.GetLists();
        Assert.NotEmpty(lists);
        var tags = await Fixture.AdminApi.ListServices.GetListTags(lists[0].Id);
        Assert.NotNull(tags);
    }

    [Fact]
    public async Task AddProfileToList()
    {
        var lists = await Fixture.AdminApi.ListServices.GetLists();
        Assert.NotEmpty(lists);
        var profiles = await Fixture.AdminApi.ProfileServices.GetProfiles(null, null, null, null);
        Assert.NotEmpty(profiles);
        await Fixture.AdminApi.ListServices.AddProfileToList(lists[0].Id, new List<string>() { profiles[0].Id });
        Assert.True(true);
    }

    [Fact]
    public async Task RemoveProfileFromList()
    {
        var lists = await Fixture.AdminApi.ListServices.GetLists();
        Assert.NotEmpty(lists);
        var profiles = await Fixture.AdminApi.ProfileServices.GetProfiles(null, null, null, null);
        Assert.NotEmpty(profiles);
        await Fixture.AdminApi.ListServices.AddProfileToList(lists[0].Id, new List<string>() { profiles[0].Id });
        await Fixture.AdminApi.ListServices.RemoveProfileFromList(lists[0].Id, new List<string>() { profiles[0].Id });
    }

    [Fact]
    public async Task GetListProfiles()
    {
        var lists = await Fixture.AdminApi.ListServices.GetLists();
        Assert.NotEmpty(lists);
        var profiles = await Fixture.AdminApi.ListServices.GetListProfiles(lists[0].Id);
        Assert.NotNull(profiles);
    }

    [Fact]
    public async Task GetListRelationshipsTags()
    {
        var lists = await Fixture.AdminApi.ListServices.GetLists();
        Assert.NotEmpty(lists);
        var relationships = await Fixture.AdminApi.ListServices.GetListRelationshipsTags(lists[0].Id);
        Assert.NotNull(relationships);
    }

    [Fact]
    public async Task GetListRelationshipsProfiles()
    {
        var lists = await Fixture.AdminApi.ListServices.GetLists();
        Assert.NotEmpty(lists);
        var relationships = await Fixture.AdminApi.ListServices.GetListRelationshipsProfiles(lists[0].Id);
        Assert.NotNull(relationships);
    }

}
public class ListServices_Tests_Fixture : IAsyncLifetime
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