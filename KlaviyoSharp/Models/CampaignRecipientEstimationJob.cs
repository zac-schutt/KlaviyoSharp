namespace KlaviyoSharp.Models;

/// <summary>
/// Klaviyo Campaign Send Job
/// </summary>
public class CampaignRecipientEstimationJob : KlaviyoObject<CampaignRecipientEstimationJobAttributes>
{
    /// <summary>
    /// Creates a new Campaign Send Job with default values
    /// </summary>
    /// <returns></returns>
    public static new Account Create()
    {
        return new() { Type = "campaign-recipient-estimation-job" };
    }
}

/// <summary>
/// Campaign Send Job Attributes
/// </summary>
public class CampaignRecipientEstimationJobAttributes
{
    /// <summary>
    /// The status of the recipient estimation job. One of: cancelled, complete, processing, queued.
    /// </summary>
    public string Status { get; set; }
    /// <summary>
    /// The ID of the campaign to perform recipient estimation
    /// </summary>
    public string Id { get; set; }
}