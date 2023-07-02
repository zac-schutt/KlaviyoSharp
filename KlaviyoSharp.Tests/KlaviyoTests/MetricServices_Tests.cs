namespace KlaviyoSharp.Tests;
[Trait("Category", "MetricServices")]
public class MetricServices_Tests : IClassFixture<MetricServices_Tests_Fixture>
{
    private MetricServices_Tests_Fixture Fixture { get; }
    public MetricServices_Tests(MetricServices_Tests_Fixture fixture)
    {
        Fixture = fixture;
    }

    [Fact]
    public async Task GetMetrics()
    {
        var result = await Fixture.AdminApi.MetricServices.GetMetrics();
        Assert.NotEmpty(result.Data);
        var res = await Fixture.AdminApi.MetricServices.GetMetric(result.Data[0].Id);
        Assert.Equal(result.Data[0].Id, res.Data.Id);
    }

    [Fact]
    public async Task QueryMetricAggregate()
    {
        var metrics = await Fixture.AdminApi.MetricServices.GetMetrics();
        var metric = metrics.Data.FirstOrDefault(x => x.Attributes.Name == "C# Test");
        Assert.NotNull(metric);
        var metricAggregateQuery = Models.MetricAggregateQuery.Create();
        metricAggregateQuery.Attributes = new()
        {
            MetricId = metric.Id,
            Measurements = new List<string> { "count", "sum_value", "unique" },
            Interval = "month",
            Filter = new List<string> {
                new Models.Filters.Filter(Models.Filters.FilterOperation.GreaterOrEqual, "datetime", DateTime.UtcNow.AddMonths(-1)).ToString(),
                new Models.Filters.Filter(Models.Filters.FilterOperation.LessThan, "datetime", DateTime.UtcNow).ToString(),

            }
        };
        var result = await Fixture.AdminApi.MetricServices.QueryMetricAggregate(metricAggregateQuery);
        Assert.NotEmpty(result.Data.Attributes.Data);
    }
}
public class MetricServices_Tests_Fixture : IAsyncLifetime
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