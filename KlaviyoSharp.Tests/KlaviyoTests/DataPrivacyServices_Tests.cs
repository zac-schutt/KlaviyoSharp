using System.Linq;
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
        //Create new profile to test deletion
        var tempProfileId = Fixture.AdminApi.ProfileServices.CreateProfile(new()
        {
            Email = $"test{Config.Random}@example.com",
            FirstName = $"Test-{Config.Random}",
            LastName = "Name"
        }).Result.Id;
        var attributes = new Models.ProfileDeletionAttributes
        {
            ProfileId = tempProfileId
        };

        //Request profile deletion
        await Fixture.AdminApi.DataPrivacyServices.RequestProfileDeletion(attributes);

        //Check if profile is deleted by looking for a not_found error
        try
        {
            var output = Fixture.AdminApi.ProfileServices.GetProfile(tempProfileId, null, null, null, null, null).Result;
            Assert.Null(output);
        }
        catch (Exception ex)
        {
            Assert.NotNull(ex.InnerException);
            if (ex.InnerException != null) Assert.Equal("not_found", ((KlaviyoException)ex.InnerException).InternalErrors[0].Code);
        }
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