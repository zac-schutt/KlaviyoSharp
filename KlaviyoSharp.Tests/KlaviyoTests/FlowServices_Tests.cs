namespace KlaviyoSharp.Tests;
[Trait("Category", "FlowServices")]
public class FlowServices_Tests : IClassFixture<FlowServices_Tests_Fixture>
{
    private FlowServices_Tests_Fixture Fixture { get; }
    public FlowServices_Tests(FlowServices_Tests_Fixture fixture)
    {
        Fixture = fixture;
    }

    //Add Tests Here
    //TODO: Implement

}
public class FlowServices_Tests_Fixture : IAsyncLifetime
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