using Newtonsoft.Json;

namespace KlaviyoSharp.Models;

public class EmailSubscriptionMarketing : SubscriptionMarketing
{
    /// <summary>
    /// Additional detail provided by the caller when the profile was subscribed. This may be empty if no details were provided.
    /// </summary>
    [JsonProperty("custom_method_detail")]
    public string CustomMethodDetail { get; set; }
    /// <summary>
    /// Whether the profile was subscribed to email marketing using a double opt-in.
    /// </summary>
    [JsonProperty("double_optin")]
    public bool? DoubleOptIn { get; set; }
    /// <summary>
    /// The global email marketing suppressions for this profile.
    /// </summary>
    [JsonProperty("suppressions")]
    public EmailSupression Suppressions { get; set; }
    /// <summary>
    /// The list suppressions for this profile.
    /// </summary>
    [JsonProperty("list_suppressions")]
    public ListSupression ListSuppressions { get; set; }
}
