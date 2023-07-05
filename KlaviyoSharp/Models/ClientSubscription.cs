using System.Collections.Generic;
using Newtonsoft.Json;

namespace KlaviyoSharp.Models;
/// <summary>
/// A subscription to a list created for the client api
/// </summary>
public class ClientSubscription : KlaviyoObjectBasic<ClientSubscriptionAttributes>
{
    /// <summary>
    /// Creates a new instance of the ClientSubscription class
    /// </summary>
    /// <returns></returns>
    public static new ClientSubscription Create()
    {
        return new() { Type = "subscription" };
    }
}
/// <summary>
/// Attributes for a subscription to a list created for the client api
/// </summary>
public class ClientSubscriptionAttributes
{
    /// <summary>
    /// The list ID to add the newly subscribed profile to.
    /// </summary>
    [JsonProperty("list_id")]
    public string ListId { get; set; }
    /// <summary>
    /// A custom method detail or source to store on the consent records for this subscription.
    /// </summary>
    [JsonProperty("custom_source")]
    public string CustomSource { get; set; }
    /// <summary>
    /// Email address to create subscription and email consent record for.
    /// </summary>
    [JsonProperty("email")]
    public string Email { get; set; }
    /// <summary>
    /// Phone number to create subscription and SMS consent record for, in E.164 format.
    /// </summary>
    [JsonProperty("phone_number")]
    public string PhoneNumber { get; set; }
    /// <summary>
    /// Profile properties to set on the newly subscribed profile.
    /// </summary>
    [JsonProperty("properties")]
    public Dictionary<string, object> Properties { get; set; }
}