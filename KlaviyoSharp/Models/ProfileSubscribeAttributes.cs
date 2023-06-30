using System.Collections.Generic;
using Newtonsoft.Json;

namespace KlaviyoSharp.Models;

public class ProfileSubscriptionAttributes : AttributesObject
{
    /// <summary>
    /// The list to add the newly subscribed profiles to
    /// </summary>
    [JsonProperty("list_id")]
    public string ListId { get; set; }
    /// <summary>
    /// A custom method detail or source to store on the consent records.
    /// </summary>
    [JsonProperty("custom_source")]
    public string CustomSource { get; set; }
    /// <summary>
    /// One or more subscriptions to be created.
    /// </summary>
    [JsonProperty("subscriptions")]
    public List<ProfileSubscription> Subscriptions { get; set; }

}
