namespace KlaviyoSharp.Tests;
[Trait("Category", "SegmentServices")]
public class SegmentServices_Tests : IClassFixture<SegmentServices_Tests_Fixture>
{
    private SegmentServices_Tests_Fixture Fixture { get; }
    public SegmentServices_Tests(SegmentServices_Tests_Fixture fixture)
    {
        Fixture = fixture;
    }

    [Fact]
    public async Task GetSegments()
    {
        var result = await Fixture.AdminApi.SegmentServices.GetSegments();
        Assert.NotEmpty(result.Data);
        var res = await Fixture.AdminApi.SegmentServices.GetSegment(result.Data[0].Id);
        Assert.Equal(result.Data[0].Id, res.Data.Id);
        var tags = await Fixture.AdminApi.SegmentServices.GetSegmentTags(result.Data[0].Id);
        Assert.NotNull(tags.Data);
        var profiles = await Fixture.AdminApi.SegmentServices.GetSegmentProfiles(result.Data[0].Id);
        Assert.NotNull(profiles.Data);
        var RelationshipsTags = await Fixture.AdminApi.SegmentServices.GetSegmentRelationshipsTags(result.Data[0].Id);
        Assert.NotNull(RelationshipsTags.Data);
        var RelationshipsProfiles = await Fixture.AdminApi.SegmentServices.GetSegmentRelationshipsProfiles(result.Data[0].Id);
        Assert.NotNull(RelationshipsProfiles.Data);
    }
    [Fact]
    public async Task UpdateSegment()
    {
        var result = await Fixture.AdminApi.SegmentServices.GetSegments();
        Assert.NotEmpty(result.Data);
        string NewName = $"Segment Name Updated {Config.Random}";
        var update = Models.Segment.Create();
        update.Attributes = new() { Name = NewName };
        update.Id = result.Data[0].Id;
        var updated = await Fixture.AdminApi.SegmentServices.UpdateSegment(result.Data[0].Id, update);
        Assert.Equal(NewName, updated.Data.Attributes.Name);
    }

}
public class SegmentServices_Tests_Fixture : IAsyncLifetime
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