using Newtonsoft.Json;

namespace KlaviyoSharp.Models;

public class SmsSubscription
{
    [JsonProperty("marketing")]
    public SubscriptionMarketing Marketing { get; set; }
}
