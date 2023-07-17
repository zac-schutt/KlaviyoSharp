using KlaviyoSharp.Models;

namespace KlaviyoSharp.Tests;
[Trait("Category", "FlowServices")]
public class FlowServices_Tests : IClassFixture<FlowServices_Tests_Fixture>
{
    private FlowServices_Tests_Fixture Fixture { get; }
    public FlowServices_Tests(FlowServices_Tests_Fixture fixture)
    {
        Fixture = fixture;
    }

    [Fact]
    public async Task GetFlows()
    {
        var result = await Fixture.AdminApi.FlowServices.GetFlows();
        Assert.NotEmpty(result.Data);
    }
    [Fact]
    public async Task GetFlow()
    {
        var result = await Fixture.AdminApi.FlowServices.GetFlow(Fixture.FlowId);
        Assert.NotNull(result.Data);
    }
    [Fact]
    public async Task UpdateFlow()
    {
        var update = Flow.Create();
        update.Id = Fixture.FlowId;
        update.Attributes = new() { Status = "draft" };
        var result = await Fixture.AdminApi.FlowServices.UpdateFlowStatus(Fixture.FlowId, update);
        Assert.Equal("draft", result.Data.Attributes.Status);
    }
    [Fact]
    public async Task GetFlowActionAndMessage()
    {
        var actions = await Fixture.AdminApi.FlowServices.GetFlowRelationshipsFlowActions(Fixture.FlowId);
        var result = await Fixture.AdminApi.FlowServices.GetFlowAction(actions.Data.First().Id);
        Assert.NotNull(result.Data);
        var result2 = await Fixture.AdminApi.FlowServices.GetFlowForFlowAction(result.Data.Id);
        Assert.Equal(Fixture.FlowId, result2.Data.Id);
        var result3 = await Fixture.AdminApi.FlowServices.GetMessagesForFlowAction(result.Data.Id);
        Assert.NotNull(result3);
        var result4 = await Fixture.AdminApi.FlowServices.GetFlowMessage(result3.Data.First().Id);
        Assert.NotNull(result4.Data);
        var result5 = await Fixture.AdminApi.FlowServices.GetFlowActionForMessage(result4.Data.Id);
        Assert.Equal(result.Data.Id, result5.Data.Id);
    }

    [Fact]
    public async Task GetFlowActions()
    {
        var result = await Fixture.AdminApi.FlowServices.GetFlowActionsForFlow(Fixture.FlowId);
        Assert.NotEmpty(result.Data);
    }

    [Fact]
    public async Task GetFlowTags()
    {
        var result = await Fixture.AdminApi.FlowServices.GetFlowTags(Fixture.FlowId);
        Assert.NotNull(result);
    }



}
public class FlowServices_Tests_Fixture : IAsyncLifetime
{
    public KlaviyoAdminApi AdminApi { get; } = new(Config.ApiKey);
    public string FlowId { get; set; }
    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }
    public Task InitializeAsync()
    {
        FlowId = AdminApi.FlowServices.GetFlows().Result.Data.First().Id;
        return Task.CompletedTask;
    }
}