namespace KlaviyoSharp.Models;

/// <summary>
///
/// </summary>
public class MetricAggregateQuery : KlaviyoObject<MetricAggregateQueryAttributes>
{
    /// <summary>
    /// Creates a new instance of the Metric Aggregate Query class
    /// </summary>
    /// <returns></returns>
    public static new MetricAggregateQuery Create()
    {
        return new MetricAggregateQuery() { Type = "metric-aggregate" };
    }
}

/// <summary>
/// Attributes of a metric aggregate query
/// </summary>
public class MetricAggregateQueryAttributes
{
    /// <summary>
    /// The metric ID used in the aggregation.
    /// </summary>
    public string MetricId { get; set; }
    /// <summary>
    /// Optional pagination cursor to iterate over large result sets
    /// </summary>
    public string PageCursor { get; set; }
    /// <summary>
    /// Measurement key, e.g. unique, sum_value, count
    /// </summary>
    public List<string> Measurements { get; set; }
    /// <summary>
    /// Aggregation interval, e.g. "hour", "day", "week", "month"
    /// </summary>
    public string Interval { get; set; }
    /// <summary>
    /// Alter the maximum number of returned rows in a single page of aggregation results
    /// </summary>
    public int? PageSize { get; set; }
    /// <summary>
    /// Optional attribute(s) used for partitioning by the aggregation function
    /// </summary>
    public List<string> By { get; set; }
    /// <summary>
    /// Provide fields to limit the returned data
    /// </summary>
    public List<string> ReturnFields { get; set; }
    /// <summary>
    /// List of filters, must include time range using ISO 8601 format (YYYY-MM-DDTHH:MM:SS.mmmmmm).
    /// These filters follow a similar format to those in GET requests, the primary difference is that this endpoint asks for a list.
    /// The time range can be filtered by providing a greater-or-equal and a less-than filter on the datetime field.
    /// </summary>
    /// <remarks>
    /// A <see cref="Filters.IFilter"/> can be cast to string to get a valid filter string.
    /// </remarks>
    public List<string> Filter { get; set; }
    /// <summary>
    /// The timezone used for processing the query, e.g. 'America/New_York'.
    /// This field is validated against a list of common timezones from the <see href="https://www.iana.org/time-zones">IANA Time Zone Database</see>.
    /// While most are supported, a few notable exceptions are Factory, Europe/Kyiv and Pacific/Kanton. This field is case-sensitive.
    /// </summary>
    public string Timezone { get; set; }
    /// <summary>
    /// Provide a sort key (e.g. -$message)
    /// </summary>
    public string Sort { get; set; }
}