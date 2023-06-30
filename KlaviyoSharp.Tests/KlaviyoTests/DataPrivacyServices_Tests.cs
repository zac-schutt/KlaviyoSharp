namespace KlaviyoSharp.Tests;
[Trait("Category", "DataPrivacyServices")]
public class DataPrivacyServices_Tests : IClassFixture<DataPrivacyServices_Tests_Fixture>
{
    private DataPrivacyServices_Tests_Fixture Fixture { get; }
    public DataPrivacyServices_Tests(DataPrivacyServices_Tests_Fixture fixture)
    {
        Fixture = fixture;
    }

    //Add Tests Here
    [Fact]
    public async Task RequestProfileDeletion()
    {
        Assert.False(true);
        //TODO: Create profile Id dynamically.
        var tempProfileId = "";
        var attributes = new Models.ProfileDeletionAttributes
        {
            ProfileId = tempProfileId
        };
        await Fixture.AdminApi.DataPrivacyServices.RequestProfileDeletion(attributes);
        //Assert.True(true);
    }

}
public class DataPrivacyServices_Tests_Fixture : IAsyncLifetime
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