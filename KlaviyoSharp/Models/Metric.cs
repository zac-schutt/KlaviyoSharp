using System;
using Newtonsoft.Json;

namespace KlaviyoSharp.Models;
/// <summary>
/// A metric is a custom event that you can use to track any action that you want to measure.
/// </summary>
public class Metric : KlaviyoObject<MetricAttributes>
{
    /// <summary>
    /// Creates a new instance of the Metric class
    /// </summary>
    /// <returns></returns>
    public static new Metric Create()
    {
        return new Metric() { Type = "metric" };
    }
}
/// <summary>
/// Attributes of a metric
/// </summary>
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
    /// <summary>
    /// The type of object
    /// </summary>
    [JsonProperty("object")]
    public string Object { get; set; }
    /// <summary>
    /// The ID of the integration
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; }
    /// <summary>
    /// The name of the integration
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }
    /// <summary>
    /// The category of the integration
    /// </summary>
    [JsonProperty("category")]
    public string Category { get; set; }
}