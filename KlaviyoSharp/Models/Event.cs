using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace KlaviyoSharp.Models;
/// <summary>
/// Klaviyo Event
/// </summary>
public class Event : KlaviyoObject<EventAttributes>
{
    /// <summary>
    /// Creates a new instance of the Event class
    /// </summary>
    /// <returns></returns>
    public static new Event Create()
    {
        return new() { Type = "event" };
    }
    /// <summary>
    /// Relationships for the Event
    /// </summary>
    [JsonProperty("relationships")]
    public EventRelationships Relationships { get; set; }
}
/// <summary>
/// Klaviyo Event Relationships
/// </summary>
public class EventRelationships
{
    /// <summary>
    /// Klaviyo Profiles associated with the Event
    /// </summary>
    [JsonProperty("profiles")]
    public DataListObjectRelated<GenericObject> Profiles { get; set; }
    /// <summary>
    /// Klaviyo Metrics associated with the Event
    /// </summary>
    [JsonProperty("metrics")]
    public DataListObjectRelated<GenericObject> Metrics { get; set; }
}
/// <summary>
/// Klaviyo Event Attributes
/// </summary>
public class EventAttributes
{
    /// <summary>
    /// The Metric ID
    /// </summary>
    [JsonProperty("metric_id")]
    public string MetricId { get; set; }
    /// <summary>
    /// Profile ID of the associated profile, if available
    /// </summary>
    [JsonProperty("profile_id")]
    public string ProfileId { get; set; }
    /// <summary>
    /// Event timestamp in seconds
    /// </summary>
    [JsonProperty("timestamp")]
    public string Timestamp { get; set; }
    /// <summary>
    /// Event properties, can include attribution data, identifiers and extra properties
    /// </summary>
    [JsonProperty("event_properties")]
    public Dictionary<string, object> EventProperties { get; set; }
    /// <summary>
    /// Event timestamp in ISO 8601 format (YYYY-MM-DDTHH:MM:SS.mmmmmm)
    /// </summary>
    [JsonProperty("datetime")]
    public DateTime? DateTime { get; set; }
    /// <summary>
    /// A unique identifier for the event, this can be used as a cursor in pagination
    /// </summary>
    [JsonProperty("uuid")]
    public string Uuid { get; set; }
}
