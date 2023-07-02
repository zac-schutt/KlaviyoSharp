using System.Collections.Generic;
using Newtonsoft.Json;

namespace KlaviyoSharp.Models;

public class ProfileSubscriptionRequest : KlaviyoObjectBasic<ProfileSubscriptionAttributes>
{
    public static new ProfileSubscriptionRequest Create()
    {
        return new ProfileSubscriptionRequest() { Type = "profile-subscription-bulk-create-job" };
    }
}

public class ProfileSubscriptionAttributes
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
    public List<ProfileSubscriptionRequestSubscription> Subscriptions { get; set; }

}

public class ProfileSubscriptionRequestSubscription
{
    /// <summary>
    /// When provided, this will provide consent for the indicated message types on the specified channels. If omitted, we will subscribe the profile to all message types on the channels corresponding to the provided identifiers.
    /// </summary>
    [JsonProperty("channels")]
    public ProfileSubscriptionRequestSubscriptionChannels Channels { get; set; }
    /// <summary>
    /// The email address to subscribe or to set on the profile if channels is specified and the email channel is omitted.
    /// </summary>
    [JsonProperty("email")]
    public string Email { get; set; }
    /// <summary>
    /// The phone number to subscribe or to set on the profile if channels is specified and the SMS channel is omitted.
    /// </summary>
    [JsonProperty("phone_number")]
    public string PhoneNumber { get; set; }
    /// <summary>
    /// The ID of the profile to subscribe. If provided, this will be used to perform the lookup.
    /// </summary>
    [JsonProperty("profile_id")]
    public string ProfileId { get; set; }


}

public class ProfileSubscriptionRequestSubscriptionChannels
{
    /// <summary>
    /// The communication types to subscribe to on the "EMAIL" Channel. Currently supports "MARKETING".
    /// </summary>
    [JsonProperty("email")]
    public List<string> Email { get; set; }
    /// <summary>
    /// The communication types to subscribe to on the "SMS" Channel. Currently supports "MARKETING".
    /// </summary>
    [JsonProperty("sms")]
    public List<string> Sms { get; set; }
}
