using Newtonsoft.Json;

namespace KlaviyoSharp.Models;

public class ProfileSubscriptions
{
    /// <summary>
    /// The email channel subscription.
    /// </summary>
    [JsonProperty("email")]
    public EmailSubscription Email { get; set; }
    /// <summary>
    /// The SMS channel subscription.
    /// </summary>
    [JsonProperty("sms")]
    public SmsSubscription Sms { get; set; }
}
