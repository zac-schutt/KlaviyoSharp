using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace KlaviyoSharp.Models;
/// <summary>
/// Klaviyo Event
/// </summary>
public class Event : KlaviyoObject<EventAttributes, EventRelationships>
{
    /// <summary>
    /// Creates a new instance of the Event class
    /// </summary>
    /// <returns></returns>
    public static new Event Create()
    {
        return new() { Type = "event" };
    }
}
/// <summary>
/// Klaviyo Event Relationships
/// </summary>
public class EventRelationships
{
    /// <summary>
    /// Klaviyo Profiles associated with the Event
    /// </summary>
    [JsonProperty("profile")]
    public DataObject<GenericObject> Profile { get; set; }
    /// <summary>
    /// Klaviyo Metrics associated with the Event
    /// </summary>
    [JsonProperty("metric")]
    public DataObject<GenericObject> Metric { get; set; }
}
/// <summary>
/// Klaviyo Event Attributes
/// </summary>
public class EventAttributes
{
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
