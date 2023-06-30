using System;
using Newtonsoft.Json;

namespace KlaviyoSharp.Models;

public class SubscriptionMarketing
{
    /// <summary>
    /// The consent status for marketing.
    /// </summary>
    [JsonProperty("consent")]
    public string Consent { get; set; }
    /// <summary>
    /// The timestamp when consent record or updated for marketing, in ISO 8601 format (YYYY-MM-DDTHH:MM:SS.mmmmmm).
    /// </summary>
    [JsonProperty("timestamp")]
    public DateTime? Timestamp { get; set; }
    /// <summary>
    /// The method by which the profile was subscribed to marketing.
    /// </summary>
    [JsonProperty("method")]
    public string Method { get; set; }
    /// <summary>
    /// Additional details about the method by which the profile was subscribed to marketing. This may be empty if no details were provided.
    /// </summary>
    [JsonProperty("method_detail")]
    public string MethodDetail { get; set; }
}