using Newtonsoft.Json;

namespace KlaviyoSharp.Models;

public class ProfileSubscription
{
    /// <summary>
    /// When provided, this will provide consent for the indicated message types on the specified channels. If omitted, we will subscribe the profile to all message types on the channels corresponding to the provided identifiers.
    /// </summary>
    [JsonProperty("channels")]
    public Channels Channels { get; set; }
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
