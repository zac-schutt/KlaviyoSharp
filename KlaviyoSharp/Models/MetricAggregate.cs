using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace KlaviyoSharp.Models;

public class MetricAggregate : KlaviyoObject<MetricAggregateAttributes>
{
    public static new MetricAggregate Create()
    {
        return new MetricAggregate() { Type = "metric-aggregate" };
    }
}

public class MetricAggregateAttributes
{
    /// <summary>
    /// The dates of the query range
    /// </summary>
    [JsonProperty("dates")]
    public List<DateTime> Dates { get; set; }
    /// <summary>
    /// Aggregation result data
    /// </summary>
    [JsonProperty("data")]
    public List<MetricAggregateData> Data { get; set; }
}

public class MetricAggregateData
{
    /// <summary>
    /// List of dimensions associated with this set of measurements
    /// </summary>
    [JsonProperty("dimensions")]
    public List<string> Dimensions { get; set; }
    /// <summary>
    /// Dictionary of measurement_key, values
    /// </summary>
    [JsonProperty("measurements")]
    public Dictionary<string, List<double?>> Measurements { get; set; }
}