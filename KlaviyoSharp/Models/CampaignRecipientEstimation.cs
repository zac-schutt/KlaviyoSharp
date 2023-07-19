using Newtonsoft.Json;

namespace KlaviyoSharp.Models;
/// <summary>
/// Klaviyo Campaign Recipient Estimation
/// </summary>
public class CampaignRecipientEstimation : KlaviyoObject<CampaignRecipientEstimationAttributes>
{
    /// <summary>
    /// Creates a new Campaign Recipient Estimation with default values
    /// </summary>
    /// <returns></returns>
    public static new Account Create()
    {
        return new() { Type = "campaign-recipient-estimation" };
    }
}
/// <summary>
/// Campaign Recipient Estimation Attributes
/// </summary>
public class CampaignRecipientEstimationAttributes
{
    /// <summary>
    /// The estimated number of unique recipients the campaign will send to
    /// </summary>
    [JsonProperty("estimated_recipient_count")]
    public int? EstimatedRecipientCount { get; set; }
}