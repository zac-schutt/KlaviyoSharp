namespace KlaviyoSharp.Models;

/// <summary>
/// Metric Aggregation Result
/// </summary>
public class MetricAggregate : KlaviyoObject<MetricAggregateAttributes>
{
    /// <summary>
    /// Creates a new instance of the Metric Aggregate class
    /// </summary>
    /// <returns>Should not need to be used</returns>
    public static new MetricAggregate Create()
    {
        return new MetricAggregate() { Type = "metric-aggregate" };
    }
}

/// <summary>
/// Aggregation result attributes
/// </summary>
public class MetricAggregateAttributes
{
    /// <summary>
    /// The dates of the query range
    /// </summary>
    public List<DateTime> Dates { get; set; }
    /// <summary>
    /// Aggregation result data
    /// </summary>
    public List<MetricAggregateData> Data { get; set; }
}

/// <summary>
/// Aggregation result data
/// </summary>
public class MetricAggregateData
{
    /// <summary>
    /// List of dimensions associated with this set of measurements
    /// </summary>
    public List<string> Dimensions { get; set; }
    /// <summary>
    /// Dictionary of measurement_key, values
    /// </summary>
    public Dictionary<string, List<double?>> Measurements { get; set; }
}