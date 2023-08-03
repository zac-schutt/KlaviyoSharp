using Newtonsoft.Json;

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
    [JsonProperty("profile")]
    public DataObject<PatchProfile> Profile { get; set; }
    /// <summary>
    ///
    /// </summary>
    [JsonProperty("events")]
    public DataListObject<EventRequest> Events { get; set; }
}