using System;
using Newtonsoft.Json;

namespace KlaviyoSharp.Models;

public class Metric : KlaviyoObject<MetricAttributes>
{
    public static new Metric Create()
    {
        return new Metric() { Type = "metric" };
    }
}

public class MetricAttributes
{
    /// <summary>
    /// The name of the metric
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }
    /// <summary>
    /// Creation time in ISO 8601 format (YYYY-MM-DDTHH:MM:SS.mmmmmm)
    /// </summary>
    [JsonProperty("created")]
    public DateTime? Created { get; set; }
    /// <summary>
    /// Last updated time in ISO 8601 format (YYYY-MM-DDTHH:MM:SS.mmmmmm)
    /// </summary>
    [JsonProperty("updated")]
    public DateTime? Updated { get; set; }
    /// <summary>
    /// The integration associated with the event
    /// </summary>
    [JsonProperty("integration")]
    public MetricIntegration Integration { get; set; }
}
/// <summary>
/// !WARNING: THIS CLASS IS NOT DOCUMENTED IN THE KLAVIYO API DOCS! RECONSTRUCTED FROM THE RESPONSE OF A GET REQUEST, USE AT YOUR OWN RISK!
/// </summary>
public class MetricIntegration
{
    [JsonProperty("object")]
    public string Object { get; set; }
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("category")]
    public string Category { get; set; }
}