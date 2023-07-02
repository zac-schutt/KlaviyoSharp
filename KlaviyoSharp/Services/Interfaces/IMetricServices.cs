using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Models;
using KlaviyoSharp.Models.Filters;

namespace KlaviyoSharp.Services;

internal interface IMetricServices
{
    /// <summary>
    /// Get all metrics in an account.
    /// Requests can be filtered by the following fields: integration name, integration category
    /// </summary>
    /// <param name="metricFields">For more information please visit https://developers.klaviyo.com/en/v2023-06-15/reference/api-overview#sparse-fieldsets</param>
    /// <param name="filter">For more information please visit <see href="https://developers.klaviyo.com/en/v2023-06-15/reference/api-overview#filtering" />
    /// Allowed field(s) integration.name, integration.category: equals</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<Metric>> GetMetrics(List<string> metricFields = null, IFilter filter = null, CancellationToken cancellationToken = default);
    /// <summary>
    /// Get a metric with the given metric ID.
    /// </summary>
    /// <param name="metricId">Metric ID</param>
    /// <param name="metricFields">For more information please visit https://developers.klaviyo.com/en/v2023-06-15/reference/api-overview#sparse-fieldsets</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<Metric>> GetMetric(string metricId, List<string> metricFields = null, CancellationToken cancellationToken = default);
    /// <summary>
    /// Query and aggregate event data associated with a metric, including native Klaviyo metrics, integration-specific metrics, and custom events. Queries must be passed in the JSON body of your POST request.
    /// Results can be filtered and grouped by time, event, or profile dimensions.
    /// To learn more about how to use this endpoint, check out our new <see href="https://developers.klaviyo.com/en/docs/using-the-query-metric-aggregates-endpoint">Using the Query Metric Aggregates Endpoint guide</see>.
    /// </summary>
    /// <param name="metricAggregateQuery"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<MetricAggregate>> QueryMetricAggregate(MetricAggregateQuery metricAggregateQuery, CancellationToken cancellationToken = default);
}