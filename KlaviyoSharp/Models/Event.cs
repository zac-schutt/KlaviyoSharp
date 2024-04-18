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
    public DataObject<GenericObject> Profile { get; set; }
    /// <summary>
    /// Klaviyo Metrics associated with the Event
    /// </summary>
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
    public string Timestamp { get; set; }
    /// <summary>
    /// Event properties, can include identifiers and extra properties
    /// </summary>
    public Dictionary<string, object> EventProperties { get; set; }
    /// <summary>
    /// Event timestamp in ISO 8601 format (YYYY-MM-DDTHH:MM:SS.mmmmmm)
    /// </summary>
    public DateTime? DateTime { get; set; }
    /// <summary>
    /// A unique identifier for the event, this can be used as a cursor in pagination
    /// </summary>
    public string Uuid { get; set; }
}
