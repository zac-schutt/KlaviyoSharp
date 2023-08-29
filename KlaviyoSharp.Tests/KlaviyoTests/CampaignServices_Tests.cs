using KlaviyoSharp.Models.Filters;

namespace KlaviyoSharp.Tests;
[Trait("Category", "CampaignServices")]
public class CampaignServices_Tests : IClassFixture<CampaignServices_Tests_Fixture>
{
    private CampaignServices_Tests_Fixture Fixture { get; }
    public CampaignServices_Tests(CampaignServices_Tests_Fixture fixture)
    {
        Fixture = fixture;
    }

    [Fact]
    public async Task GetCampaigns()
    {
        var campaigns = await Fixture.AdminApi.CampaignServices.GetCampaigns(new Filter(FilterOperation.Equals, "messages.channel", "email"));
        Assert.NotNull(campaigns);
    }

}
public class CampaignServices_Tests_Fixture : IAsyncLifetime
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