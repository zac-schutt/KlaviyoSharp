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

    /// <summary>
    /// Tests ClientEvent.Create
    /// </summary>
    [Fact]
    public void CreateEvent()
    {
        Fixture.ClientApi.ClientServices.CreateEvent(new Models.ClientEventRequestAttributes()
        {
            Profile = new() { { "$email", "matt.kemp@klaviyo-demo.com" } },
            Metric = new() { Name = "C# Test" },
            Time = DateTime.Now,
            Value = 12.99M,
            UniqueId = Guid.NewGuid().ToString(),
            Properties = new() { { "test", "test" } }
        }).Wait();
        Assert.True(true);
    }

    /// <summary>
    /// Tests ClientSubscription.Subscribe
    /// </summary>
    [Fact]
    public void CreateSubscription()
    {
        //Get Sample Data List ID
        string _listId = Fixture.AdminApi.ListServices.GetLists(new() { "id" }, new Filter(FilterOperation.Equals, "name", "Sample Data List")).Result.First().Id;
        Debug.WriteLine(_listId);

        Fixture.ClientApi.ClientServices.CreateSubscription(new Models.ClientSubscriptionRequestAttributes()
        {
            ListId = _listId,
            CustomSource = "C# Test",
            Email = "test@test.com",
            Properties = new() { { "test", "test" } }
        }).Wait();
        Assert.True(true);
    }

    /// <summary>
    /// Tests ClientProfile.Upsert
    /// </summary>
    [Fact]
    public void UpsertProfile()
    {
        Fixture.ClientApi.ClientServices.UpsertProfile(new Models.ClientProfileRequestAttributes()
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
                Latitude = 42.35843M,
                Longitude = -71.05977M,
                Timezone = "America/New_York",
                City = "Boston",
                Region = "MA",
                Country = "USA",
                Zip = "02110"
            },
            Properties = new() { { "Last Test", DateTime.Now.ToString() } }
        }).Wait();
        Assert.True(true);
    }
}

/// <summary>
/// Fixture for ClientServices_Tests
/// </summary>
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