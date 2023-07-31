using KlaviyoSharp.Models;
using KlaviyoSharp.Models.Filters;

namespace KlaviyoSharp.Tests;

/// <summary>
/// Klaviyo API Client Tests. Only tests the /client endpoints.
/// </summary>
[Trait("Category", "ClientServices")]
public class ClientServices_Tests : IClassFixture<ClientServices_Tests_Fixture>
{
    private ClientServices_Tests_Fixture Fixture { get; }
    public ClientServices_Tests(ClientServices_Tests_Fixture fixture)
    {
        Fixture = fixture;
    }

    [Fact]
    public async Task CreateEvent()
    {
        var profile = (await Fixture.AdminApi.ProfileServices.GetProfiles()).Data.First();
        var newEvent = EventRequest.Create();
        Profile profile1 = Profile.Create();
        profile1.Attributes = new() { Email = profile.Attributes.Email };
        var metric = Metric.Create();
        metric.Attributes = new() { Name = "C# Test" };
        newEvent.Attributes = new()
        {
            Profile = new(profile1),
            Metric = new(metric),
            Time = DateTime.Now,
            Value = 12.99,
            UniqueId = Guid.NewGuid().ToString(),
            Properties = new() { { "test", "test" } }
        };

        Fixture.ClientApi.ClientServices.CreateEvent(newEvent).Wait();
        Assert.True(true);
    }

    [Fact]
    public void CreateSubscription()
    {
        //Get Sample Data List ID
        string _listId = Fixture.AdminApi.ListServices.GetLists(new() { "id" }, new Filter(FilterOperation.Equals, "name", "Sample Data List")).Result.Data.First().Id;
        Debug.WriteLine(_listId);
        var profile = Profile.Create();
        profile.Attributes = new() { Email = "test@test.com" };
        var newSubscription = Models.ClientSubscription.Create();
        newSubscription.Attributes = new()
        {
            CustomSource = "C# Test",
            Profile = new(profile)
        };
        newSubscription.Relationships = new()
        {
            List = new(new() { Type = "list", Id = _listId })
        };
        Fixture.ClientApi.ClientServices.CreateSubscription(newSubscription).Wait();
        Assert.True(true);
    }

    [Fact]
    public void UpsertProfile()
    {
        var newProfile = Models.ClientProfile.Create();

        newProfile.Attributes = new()
        {
            Id = "01H42N4KX4N2NV2CT2595KCG6Z",
            Email = "test@test.com",
            FirstName = "Test",
            LastName = "Profile",
            ExternalId = "TestAccount",
            Organization = "Test Organization",
            Title = "Test Title",
            ImageUrl = "https://dummyimage.com/300",
            Location = new()
            {
                Address1 = "1 Main St",
                Address2 = "Suite 101",
                Latitude = 42.35843,
                Longitude = -71.05977,
                Timezone = "America/New_York",
                City = "Boston",
                Region = "MA",
                Country = "USA",
                Zip = "02110"
            },
            Properties = new() { { "Last Test", DateTime.Now.ToString() } }
        };

        Fixture.ClientApi.ClientServices.UpsertProfile(newProfile).Wait();
        Assert.True(true);
    }

    [Fact]
    public async void PushTokens()
    {
        //GitHub Issue #12 tracks an issue with this test.
        //Should be able to confirm that the endpoint is working with a correctly configured account and request.

        var profile = (await Fixture.AdminApi.ProfileServices.GetProfiles()).Data.First();
        var tokenProfile = Profile.Create();
        tokenProfile.Attributes = new() { Email = profile.Attributes.Email };
        var pushToken = PushToken.Create();
        pushToken.Attributes = new()
        {
            Token = "1234567890",
            Platform = "android",
            EnablementStatus = "AUTHORIZED",
            Vendor = "apns",
            Background = "AVAILABLE",
            Profile = new(tokenProfile),
            DeviceMetadata = new()
            {
                DeviceId = "1234567890",
                KlaviyoSdk = "swift",
                SdkVersion = "1.0.0",
                DeviceModel = "iPhone12,1",
                OsName = "ios",
                OsVersion = "14.0",
                Manufacturer = "Apple",
                AppName = "KlaviyoSharp",
                AppVersion = System.Reflection.Assembly.GetAssembly(typeof(KlaviyoClientApi)).GetName().Version.ToString(),
                AppBuild = "1",
                AppId = "com.test.app",
                Environment = "debug"
            }
        };
        try
        {
            Fixture.ClientApi.ClientServices.CreateOrUpdateClientPushToken(pushToken).Wait();
        }
        catch (Exception ex)
        {
            //Catch the exception if the company is not setup for push tokens.
            Assert.IsType<KlaviyoException>(ex.InnerException);
            Assert.Equal("Company is not able to process push tokens", ex.InnerException.Message);
        }

        var pushTokenUnregister = PushTokenUnregister.Create();
        pushTokenUnregister.Attributes = new()
        {
            Token = pushToken.Attributes.Token,
            Platform = pushToken.Attributes.Platform,
            Vendor = pushToken.Attributes.Vendor,
            Profile = new(tokenProfile)
        };

        try
        {
            Fixture.ClientApi.ClientServices.UnregisterClientPushToken(pushTokenUnregister).Wait();
        }
        catch (Exception ex)
        {
            //Catch the exception if the company is not setup for push tokens.
            Assert.IsType<KlaviyoException>(ex.InnerException);
            Assert.Equal("Company is not able to process push tokens", ex.InnerException.Message);
        }
        Assert.True(true);
    }
}

public class ClientServices_Tests_Fixture : IAsyncLifetime
{
    public KlaviyoClientApi ClientApi { get; } = new(Config.CompanyId);
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