using KlaviyoSharp.Models;

namespace KlaviyoSharp.Tests;
[Trait("Category", "EventServices")]
public class EventServices_Tests : IClassFixture<EventServices_Tests_Fixture>
{
    private EventServices_Tests_Fixture Fixture { get; }
    public EventServices_Tests(EventServices_Tests_Fixture fixture)
    {
        Fixture = fixture;
    }

    //Add Tests Here
    [Fact]
    public async Task GetEvents()
    {
        var result = await Fixture.AdminApi.EventServices.GetEvents();
        string eventId = result.Data[0].Id;
        Assert.NotEmpty(result.Data);
        var result2 = await Fixture.AdminApi.EventServices.GetEvent(eventId);
        Assert.Equal(eventId, result2.Data.Id);
        var result3 = await Fixture.AdminApi.EventServices.GetEventMetrics(eventId);
        Assert.NotNull(result3.Data);
        var result4 = await Fixture.AdminApi.EventServices.GetEventProfiles(eventId);
        Assert.NotNull(result4.Data);
        var result5 = await Fixture.AdminApi.EventServices.GetEventRelationshipsMetrics(eventId);
        Assert.NotNull(result5.Data);
        var result6 = await Fixture.AdminApi.EventServices.GetEventRelationshipsProfiles(eventId);
        Assert.NotNull(result6.Data);
    }

    [Fact]
    public async Task CreateEvent()
    {
        var profile = (await Fixture.AdminApi.ProfileServices.GetProfiles()).Data.First();

        var newEvent = Models.EventRequest.Create();
        newEvent.Attributes = new()
        {
            Profile = new() { { "$email", profile.Attributes.Email } },
            Metric = new() { Name = "C# Test" },
            Time = DateTime.Now,
            Value = 12.99,
            UniqueId = Guid.NewGuid().ToString(),
            Properties = new() { { "test", "test" } }
        };

        Fixture.AdminApi.EventServices.CreateEvent(newEvent).Wait();
        Assert.True(true);
    }
}


public class EventServices_Tests_Fixture : IAsyncLifetime
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