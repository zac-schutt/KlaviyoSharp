using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Infrastructure;
using KlaviyoSharp.Models;
using KlaviyoSharp.Models.Filters;

namespace KlaviyoSharp.Services;
/// <summary>
/// Klaviyo Metric Services
/// </summary>
public class MetricServices : KlaviyoServiceBase, IMetricServices
{
    /// <summary>
    /// Constructor for Klaviyo Metric Services
    /// </summary>
    /// <param name="klaviyoService"></param>
    public MetricServices(KlaviyoApiBase klaviyoService) : base("2023-06-15", klaviyoService) { }
    /// <inheritdoc />
    public async Task<DataListObject<Metric>> GetMetrics(List<string> metricFields = null, IFilter filter = null, CancellationToken cancellationToken = default)
    {
        QueryParams queryParams = new();
        queryParams.AddFieldset("metric", metricFields);
        queryParams.AddFilter(filter);

        return await _klaviyoService.HTTP<DataListObject<Metric>>(HttpMethod.Get, "metrics/", revision: _revision, query: queryParams, headers: null, data: null, cancellationToken: cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<Metric>> GetMetric(string metricId, List<string> metricFields = null, CancellationToken cancellationToken = default)
    {
        QueryParams queryParams = new();
        queryParams.AddFieldset("metric", metricFields);

        return await _klaviyoService.HTTP<DataObject<Metric>>(HttpMethod.Get, $"metrics/{metricId}/", revision: _revision, query: queryParams, headers: null, data: null, cancellationToken: cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<MetricAggregate>> QueryMetricAggregate(MetricAggregateQuery metricAggregateQuery, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<MetricAggregate>>(HttpMethod.Post, "metric-aggregates/", revision: _revision, query: null, headers: null, data: new DataObject<MetricAggregateQuery>(metricAggregateQuery), cancellationToken: cancellationToken);
    }

}
