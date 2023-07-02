using KlaviyoSharp.Models;
using KlaviyoSharp.Models.Filters;
using System.Threading.Tasks;

namespace KlaviyoSharp.Tests;

[Trait("Category", "ProfileServices")]
public class ProfileServices_Tests : IClassFixture<ProfileServices_Tests_Fixture>
{
    private ProfileServices_Tests_Fixture Fixture { get; }
    public ProfileServices_Tests(ProfileServices_Tests_Fixture fixture)
    {
        Fixture = fixture;
    }

    [Fact]
    public async Task GetProfiles()
    {
        var result = await Fixture.AdminApi.ProfileServices.GetProfiles(sort: "email");
        Assert.NotEmpty(result.Data);
        var res = await Fixture.AdminApi.ProfileServices.GetProfile(result.Data[0].Id);
        Assert.Equal(result.Data[0].Id, res.Data.Id);
    }

    [Fact]
    public async Task CreateAndUpdateProfile()
    {
        var result = await Fixture.AdminApi.ProfileServices.CreateProfile(Fixture.NewProfile);
        Assert.NotNull(result);
        string NewName = "Name Updated";
        var update = Profile.Create();
        update.Attributes = new() { LastName = NewName };
        update.Id = result.Data.Id;
        var updated = await Fixture.AdminApi.ProfileServices.UpdateProfile(result.Data.Id, update);
        Assert.Equal(NewName, updated.Data.Attributes.LastName);
    }

    [Fact]
    public async Task SuppressProfiles()
    {
        //Create new profile to test supression
        DataObject<Profile> result = await Fixture.AdminApi.ProfileServices.CreateProfile(Fixture.NewProfile);
        Assert.NotNull(result);

        //Suppress profile and check
        var request = ProfileSuppressionRequest.Create();
        request.Attributes = new()
        {
            Suppressions = new()
            {
                new()
                {
                    Email = result.Data.Attributes.Email
                }
            }
        };
        await Fixture.AdminApi.ProfileServices.SuppressProfiles(request);
        DataObject<Profile> check = await Fixture.AdminApi.ProfileServices.GetProfile(result.Data.Id);
        Assert.Contains(check.Data.Attributes.Subscriptions.Email.Marketing.Suppressions, x => x.Reason == "USER_SUPPRESSED");

        //Unsuppress profile and check
        var request2 = ProfileUnsuppressionRequest.Create();
        request2.Attributes = new()
        {
            Suppressions = new()
            {
                new()
                {
                    Email = result.Data.Attributes.Email
                }
            }
        };
        await Fixture.AdminApi.ProfileServices.UnsuppressProfiles(request2);
        DataObject<Profile> final = await Fixture.AdminApi.ProfileServices.GetProfile(result.Data.Id);
        Assert.DoesNotContain(final.Data.Attributes.Subscriptions.Email.Marketing.Suppressions, x => x.Reason == "USER_SUPPRESSED");
    }

    [Fact]
    public async Task SubscribeProfiles()
    {
        //Create new profile to test subscription
        DataObject<Profile> result = await Fixture.AdminApi.ProfileServices.CreateProfile(Fixture.NewProfile);
        Assert.NotNull(result);
        string ListId = (await Fixture.AdminApi.ListServices.GetLists(new() { "id" }, new Filter(FilterOperation.Equals, "name", "Sample Data List"))).Data[0].Id;
        Assert.False(string.IsNullOrEmpty(ListId));

        //Subscribe profile and check
        var request = Models.ProfileSubscriptionRequest.Create();
        request.Attributes = new()
        {
            ListId = ListId,
            Subscriptions = new()
            {
                new()
                {
                    Email = result.Data.Attributes.Email,
                    Channels = new (){Email = new (){"MARKETING"}}
                }
            }
        };
        await Fixture.AdminApi.ProfileServices.SubscribeProfiles(request);
        DataObject<Profile> check = await Fixture.AdminApi.ProfileServices.GetProfile(result.Data.Id, listFields: new() { "id" }, includedObjects: new() { "lists" });
        Thread.Sleep(1000);
        Assert.Contains(check.Data.Relationships.Lists.Data, x => x.Id == ListId);

        //Unsubscribe profile and check
        var request2 = ProfileUnsubscriptionRequest.Create();
        request2.Attributes = new()
        {
            ListId = ListId,
            Emails = new() { result.Data.Attributes.Email }
        };
        await Fixture.AdminApi.ProfileServices.UnsuscribeProfiles(request2);
        DataObject<Profile> final = await Fixture.AdminApi.ProfileServices.GetProfile(result.Data.Id, listFields: new() { "id" }, includedObjects: new() { "lists" });
        Thread.Sleep(1000);
        Assert.DoesNotContain(final.Data.Relationships.Lists.Data, x => x.Id == ListId);
    }

    [Fact]
    public async Task GetProfileLists()
    {
        var profile = (await Fixture.AdminApi.ProfileServices.GetProfiles()).Data[0];
        var result = await Fixture.AdminApi.ProfileServices.GetProfileLists(profile.Id);
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetProfileSegments()
    {
        var profile = (await Fixture.AdminApi.ProfileServices.GetProfiles()).Data[0];
        var result = await Fixture.AdminApi.ProfileServices.GetProfileSegments(profile.Id);
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetProfileRelationshipsLists()
    {
        var profile = (await Fixture.AdminApi.ProfileServices.GetProfiles()).Data[0];
        var result = await Fixture.AdminApi.ProfileServices.GetProfileRelationshipsLists(profile.Id);
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetProfileRelationshipsSegments()
    {
        var profile = (await Fixture.AdminApi.ProfileServices.GetProfiles()).Data[0];
        var result = await Fixture.AdminApi.ProfileServices.GetProfileRelationshipsSegments(profile.Id);
        Assert.NotNull(result);
    }
}
public class ProfileServices_Tests_Fixture : IAsyncLifetime
{
    public KlaviyoAdminApi AdminApi { get; } = new(Config.ApiKey);
    public Profile NewProfile
    {
        get
        {
            Profile output = Profile.Create();
            output.Attributes = new()
            {
                Email = $"test{Config.Random}@example.com",
                FirstName = $"Test-{Config.Random}",
                LastName = "Name"
            };
            return output;
        }
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }
    public Task InitializeAsync()
    {
        return Task.CompletedTask;
    }
}