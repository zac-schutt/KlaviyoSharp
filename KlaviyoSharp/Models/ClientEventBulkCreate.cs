namespace KlaviyoSharp.Models;

/// <summary>
/// Klaviyo Client Event Bulk Create Request
/// </summary>
public class ClientEventBulkCreate: KlaviyoObject<ClientEventBulkCreateAttributes>
{
    /// <summary>
    /// Creates a new instance of the Klaviyo Client Event Bulk Create with default values
    /// </summary>
    /// <returns></returns>
    public static new ClientEventBulkCreate Create() => new() { Type = "event-bulk-create" };
}

/// <summary>
/// Klaviyo Client Event Bulk Create Attributes
/// </summary>
public class ClientEventBulkCreateAttributes
{
    /// <summary>
    /// Profile to create events for.
    /// </summary>
    public DataObject<PatchProfile> Profile { get; set; }
    /// <summary>
    /// List of events to create for this profile.
    /// </summary>
    public DataListObject<EventRequest> Events { get; set; }
}