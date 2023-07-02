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
        Assert.NotEmpty(lists.Data);
        var list = await Fixture.AdminApi.ListServices.GetList(lists.Data[0].Id);
        Assert.NotNull(list);
    }

    [Fact]
    public async Task CRUDList()
    {
        var newList = Models.List.Create();
        newList.Attributes = new() { Name = $"Test List - {Config.Random}" };
        var list = await Fixture.AdminApi.ListServices.CreateList(newList);
        Assert.NotNull(list);
        var newList2 = Models.List.Create();
        newList2.Id = list.Data.Id;
        newList2.Attributes = new() { Name = $"{list.Data.Attributes.Name} - Updated" };
        var updatedList = await Fixture.AdminApi.ListServices.UpdateList(list.Data.Id, newList2);
        Assert.NotNull(updatedList);
        Assert.Equal(list.Data.Id, updatedList.Data.Id);
        await Fixture.AdminApi.ListServices.DeleteList(list.Data.Id);
        Assert.True(true);
    }

    [Fact]
    public async Task GetListTags()
    {
        var lists = await Fixture.AdminApi.ListServices.GetLists();
        Assert.NotEmpty(lists.Data);
        var tags = await Fixture.AdminApi.ListServices.GetListTags(lists.Data[0].Id);
        Assert.NotNull(tags);
    }

    [Fact]
    public async Task AddProfileToList()
    {
        var lists = await Fixture.AdminApi.ListServices.GetLists();
        Assert.NotEmpty(lists.Data);
        var profiles = await Fixture.AdminApi.ProfileServices.GetProfiles(null, null, null, null);
        Assert.NotEmpty(profiles.Data);
        await Fixture.AdminApi.ListServices.AddProfileToList(lists.Data[0].Id, new List<string>() { profiles.Data[0].Id });
        Assert.True(true);
    }

    [Fact]
    public async Task RemoveProfileFromList()
    {
        var lists = await Fixture.AdminApi.ListServices.GetLists();
        Assert.NotEmpty(lists.Data);
        var profiles = await Fixture.AdminApi.ProfileServices.GetProfiles(null, null, null, null);
        Assert.NotEmpty(profiles.Data);
        await Fixture.AdminApi.ListServices.AddProfileToList(lists.Data[0].Id, new List<string>() { profiles.Data[0].Id });
        await Fixture.AdminApi.ListServices.RemoveProfileFromList(lists.Data[0].Id, new List<string>() { profiles.Data[0].Id });
    }

    [Fact]
    public async Task GetListProfiles()
    {
        var lists = await Fixture.AdminApi.ListServices.GetLists();
        Assert.NotEmpty(lists.Data);
        var profiles = await Fixture.AdminApi.ListServices.GetListProfiles(lists.Data[0].Id);
        Assert.NotNull(profiles);
    }

    [Fact]
    public async Task GetListRelationshipsTags()
    {
        var lists = await Fixture.AdminApi.ListServices.GetLists();
        Assert.NotEmpty(lists.Data);
        var relationships = await Fixture.AdminApi.ListServices.GetListRelationshipsTags(lists.Data[0].Id);
        Assert.NotNull(relationships);
    }

    [Fact]
    public async Task GetListRelationshipsProfiles()
    {
        var lists = await Fixture.AdminApi.ListServices.GetLists();
        Assert.NotEmpty(lists.Data);
        var relationships = await Fixture.AdminApi.ListServices.GetListRelationshipsProfiles(lists.Data[0].Id);
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