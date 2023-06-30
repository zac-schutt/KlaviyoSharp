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
        Assert.True(result.Count > 0);
        var res = await Fixture.AdminApi.ProfileServices.GetProfile(result[0].Id);
        Assert.Equal(result[0].Id, res.Id);
    }

    [Fact]
    public async Task CreateAndUpdateProfile()
    {
        var result = await Fixture.AdminApi.ProfileServices.CreateProfile(Fixture.NewProfile);
        Assert.NotNull(result);
        string NewName = "Name Updated";
        var update = await Fixture.AdminApi.ProfileServices.UpdateProfile(result.Id, new Models.ProfileAttributes()
        {
            LastName = NewName
        });
        Assert.Equal(NewName, update.Attributes.LastName);
    }

    [Fact]
    public async Task SuppressProfiles()
    {
        //Create new profile to test supression
        DataObject<ProfileAttributes> result = await Fixture.AdminApi.ProfileServices.CreateProfile(Fixture.NewProfile);
        Assert.NotNull(result);

        //Suppress profile and check
        await Fixture.AdminApi.ProfileServices.SuppressProfiles(new SupressionAttributes()
        {
            Suppressions = new List<SuppressionEmails>()
            {
                new SuppressionEmails()
                {
                    Email = result.Attributes.Email
                }
            }
        });
        DataObject<ProfileAttributes> check = await Fixture.AdminApi.ProfileServices.GetProfile(result.Id);
        Assert.Contains(check.Attributes.Subscriptions.Email.Marketing.Suppressions, x => x.Reason == "USER_SUPPRESSED");

        //Unsuppress profile and check
        await Fixture.AdminApi.ProfileServices.UnsuppressProfiles(new SupressionAttributes()
        {
            Suppressions = new List<SuppressionEmails>()
            {
                new SuppressionEmails()
                {
                    Email = result.Attributes.Email
                }
            }
        });
        DataObject<ProfileAttributes> final = await Fixture.AdminApi.ProfileServices.GetProfile(result.Id);
        Assert.DoesNotContain(final.Attributes.Subscriptions.Email.Marketing.Suppressions, x => x.Reason == "USER_SUPPRESSED");
    }

    [Fact]
    public async Task SubscribeProfiles()
    {
        //Create new profile to test subscription
        DataObject<ProfileAttributes> result = await Fixture.AdminApi.ProfileServices.CreateProfile(Fixture.NewProfile);
        Assert.NotNull(result);
        string ListId = (await Fixture.AdminApi.ListServices.GetLists(new() { "id" }, new Filter(FilterOperation.Equals, "name", "Sample Data List")))[0].Id;
        Assert.False(string.IsNullOrEmpty(ListId));

        //Subscribe profile and check
        await Fixture.AdminApi.ProfileServices.SubscribeProfiles(new ProfileSubscriptionAttributes()
        {
            ListId = ListId,
            Subscriptions = new List<ProfileSubscription>()
            {
                new ProfileSubscription()
                {
                    Email = result.Attributes.Email,
                    Channels = new (){Email = new (){"MARKETING"}}
                }
            }
        });
        DataObject<ProfileAttributes> check = await Fixture.AdminApi.ProfileServices.GetProfile(result.Id, listFields: new() { "id" }, includedObjects: new() { "lists" });
        Thread.Sleep(1000);
        Assert.Contains(check.Relationships["lists"].Data, x => x.Id == ListId);

        //Unsubscribe profile and check
        await Fixture.AdminApi.ProfileServices.UnsuscribeProfiles(new ProfileUnsubscriptionAttributes()
        {
            ListId = ListId,
            Emails = new() { result.Attributes.Email }
        });
        DataObject<ProfileAttributes> final = await Fixture.AdminApi.ProfileServices.GetProfile(result.Id, listFields: new() { "id" }, includedObjects: new() { "lists" });
        Thread.Sleep(1000);
        Assert.DoesNotContain(final.Relationships["lists"].Data, x => x.Id == ListId);
    }

    [Fact]
    public async Task GetProfileLists()
    {
        var profile = (await Fixture.AdminApi.ProfileServices.GetProfiles())[0];
        var result = await Fixture.AdminApi.ProfileServices.GetProfileLists(profile.Id);
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetProfileSegments()
    {
        var profile = (await Fixture.AdminApi.ProfileServices.GetProfiles())[0];
        var result = await Fixture.AdminApi.ProfileServices.GetProfileSegments(profile.Id);
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetProfileRelationshipsLists(){
        var profile = (await Fixture.AdminApi.ProfileServices.GetProfiles())[0];
        var result = await Fixture.AdminApi.ProfileServices.GetProfileRelationshipsLists(profile.Id);
        Assert.NotNull(result);
    }

     [Fact]
    public async Task GetProfileRelationshipsSegments(){
        var profile = (await Fixture.AdminApi.ProfileServices.GetProfiles())[0];
        var result = await Fixture.AdminApi.ProfileServices.GetProfileRelationshipsSegments(profile.Id);
        Assert.NotNull(result);
    }
}
public class ProfileServices_Tests_Fixture : IAsyncLifetime
{
    public KlaviyoAdminApi AdminApi { get; } = new(Config.ApiKey);
    public ProfileAttributes NewProfile => new()
    {
        Email = $"test{Config.Random}@example.com",
        FirstName = $"Test-{Config.Random}",
        LastName = "Name"
    };
    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }
    public Task InitializeAsync()
    {
        return Task.CompletedTask;
    }
}