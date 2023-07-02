using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace KlaviyoSharp.Models;

public class Event : KlaviyoObject<EventAttributes>
{
    public static new Event Create()
    {
        return new() { Type = "event" };
    }
    [JsonProperty("relationships")]
    public EventRelationships Relationships { get; set; }
}

public class EventRelationships
{
    [JsonProperty("profiles")]
    public DataListObjectRelated<GenericObject> Profiles { get; set; }
    [JsonProperty("metrics")]
    public DataListObjectRelated<GenericObject> Metrics { get; set; }
}

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
