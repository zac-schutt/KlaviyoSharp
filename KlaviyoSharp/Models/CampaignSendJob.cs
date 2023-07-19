using Newtonsoft.Json;

namespace KlaviyoSharp.Models;
/// <summary>
/// Klaviyo Campaign Send Job
/// </summary>
public class CampaignSendJob : KlaviyoObject<CampaignSendJobAttributes>
{
    /// <summary>
    /// Creates a new Campaign Send Job with default values
    /// </summary>
    /// <returns></returns>
    public static new Account Create()
    {
        return new() { Type = "campaign-send-job" };
    }
}
/// <summary>
/// Campaign Send Job Attributes
/// </summary>
public class CampaignSendJobAttributes
{
    /// <summary>
    /// The status of the send job. One of: cancelled, complete, processing, queued.
    /// </summary>
    [JsonProperty("status")]
    public string Status { get; set; }
    /// <summary>
    /// The action you would like to take with this send job from among 'cancel' and 'revert'
    /// </summary>
    [JsonProperty("action")]
    public string Action { get; set; }
}