using System.Collections.Generic;
using Newtonsoft.Json;

namespace KlaviyoSharp.Models;
/// <summary>
/// Klaviyo Client Back In Stock Subscription
/// </summary>
public class ClientBackInStockSubscription : KlaviyoObject<ClientBackInStockSubscriptionAttributes, ClientBackInStockSubscriptionRelationships>
{

}
/// <summary>
/// Klaviyo Client Back In Stock Subscription Relationships
/// </summary>
public class ClientBackInStockSubscriptionRelationships
{
    /// <summary>
    /// Klaviyo Client Back In Stock Subscription Variants
    /// </summary>
    [JsonProperty("variant")]
    public DataObject<GenericObject> Variant { get; set; }
}
/// <summary>
/// Klaviyo Client Back In Stock Subscription Attributes
/// </summary>
public class ClientBackInStockSubscriptionAttributes
{
    /// <summary>
    /// The channel(s) through which the profile would like to receive the back in stock notification. This can be leveraged within a back in stock flow to notify the subscriber through their preferred channel(s).
    /// </summary>
    [JsonProperty("channels")]
    public List<string> Channels { get; set; }
    /// <summary>
    /// Profile to subscribe. Only fields required are email, or phone_number, or external_id, or anonymous_id.
    /// </summary>
    [JsonProperty("profile")]
    public DataObject<Profile> Profile { get; set; }
}