using Newtonsoft.Json;

namespace KlaviyoSharp.Models;

public class EmailSubscription
{
    /// <summary>
    /// The email marketing subscription.
    /// </summary>
    [JsonProperty("marketing")]
    public EmailSubscriptionMarketing Marketing { get; set; }
}
