using System;

namespace KlaviyoSharp.Tests;

/// <summary>
/// Klaviyo API Client Tests. Only tests the /client endpoints.
/// </summary>
[Trait("Category", "Client")]
public class KlaviyoClientApi_Tests : IClassFixture<KlaviyoClientApi_Tests_Fixture>
{
    private KlaviyoClientApi_Tests_Fixture Fixture { get; }
    public KlaviyoClientApi_Tests(KlaviyoClientApi_Tests_Fixture fixture)
    {
        Fixture = fixture;
    }

    /// <summary>
    /// Check that ClientApi was created successfully. Tests the constructor.
    /// </summary>
    [Fact]
    public void Setup()
    {
        Assert.NotNull(Fixture.ClientApi);
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
        //TODO: Lookup Sample Data List Id dynamically
        string _listId = "SV9J4Z";
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
/// Fixture for KlaviyoClientApi_Tests
/// </summary>
public class KlaviyoClientApi_Tests_Fixture : IAsyncLifetime
{
    public KlaviyoClientApi ClientApi { get; } = new(Config.CompanyId);
    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }

    public Task InitializeAsync()
    {
        return Task.CompletedTask;
    }
}