using System;
using System.Collections.Generic;
using KlaviyoSharp.Infrastructure;
using Newtonsoft.Json;

namespace KlaviyoSharp.Models;

public class Campaign : KlaviyoObject<CampaignAttributes, CampaignRelationships>
{
    public static new Account Create()
    {
        return new() { Type = "account" };
    }
}
/// <summary>
/// Campaign Relationships
/// </summary>
public class CampaignRelationships
{
    /// <summary>
    /// Campaign messages associated with the Campaign
    /// </summary>
    [JsonProperty("campaign-messages")]
    public DataListObjectRelated<GenericObject> CampaignMessages { get; set; }
    /// <summary>
    /// Tags associated with the Campaign
    /// </summary>
    [JsonProperty("tags")]
    public DataListObjectRelated<GenericObject> Tags { get; set; }
}
/// <summary>
/// Campaign Attributes
/// </summary>
public class CampaignAttributes
{
    /// <summary>
    /// The campaign name
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }
    /// <summary>
    /// The current status of the campaign
    /// </summary>
    [JsonProperty("status")]
    public string Status { get; set; }
    /// <summary>
    /// Whether the campaign has been archived or not
    /// </summary>
    [JsonProperty("archived")]
    public bool? Archived { get; set; }
    /// <summary>
    /// The type of campaign
    /// </summary>
    [JsonProperty("channel")]
    public string Channel { get; set; }
    /// <summary>
    /// The audiences to be included and/or excluded from the campaign
    /// </summary>
    [JsonProperty("audiences")]
    public CampaignAudiences Audiences { get; set; }
    /// <summary>
    /// Options to use when sending a campaign
    /// </summary>
    [JsonProperty("send_options")]
    public CampaignSendOptions SendOptions { get; set; }
    /// <summary>
    /// The id of the message associated with the campaign
    /// </summary>
    [JsonProperty("message")]
    public string Message { get; set; }
    /// <summary>
    /// The tracking options associated with the campaign
    /// </summary>
    [JsonProperty("tracking_options")]
    public CampaignTrackingOptions TrackingOptions { get; set; }
    /// <summary>
    /// The send strategy the campaign will send with
    /// </summary>
    [JsonProperty("send_strategy")]
    public CampaignSendStrategy SendStrategy { get; set; }
    /// <summary>
    /// The send strategy the campaign will send with
    /// </summary>
    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }
    /// <summary>
    /// The datetime when the campaign was last updated by a user or the system
    /// </summary>
    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }
    /// <summary>
    /// The datetime when the campaign was scheduled for future sending
    /// </summary>
    [JsonProperty("scheduled_at")]
    public DateTime? ScheduledAt { get; set; }
    /// <summary>
    /// The datetime when the campaign will be / was sent or None if not yet scheduled by a send_job.
    /// </summary>
    [JsonProperty("send_time")]
    public DateTime? SendTime { get; set; }
}
/// <summary>
/// Campaign Audiences
/// </summary>
public class CampaignAudiences
{
    /// <summary>
    /// A list of included audiences
    /// </summary>
    [JsonProperty("included")]
    public List<string> Included { get; set; }
    /// <summary>
    /// An optional list of excluded audiences
    /// </summary>
    [JsonProperty("excluded")]
    public List<string> Excluded { get; set; }
}
/// <summary>
/// Campaign Send Options
/// </summary>
public class CampaignSendOptions
{
    /// <summary>
    /// Use smart sending. Defaults to True if not specified.
    /// </summary>
    [JsonProperty("use_smart_sending")]
    public bool? UseSmartSending { get; set; }
}
/// <summary>
/// Campaign Tracking Options
/// </summary>
public class CampaignTrackingOptions
{
    /// <summary>
    /// Whether the campaign is tracking open events. If not specified, uses company defaults.
    /// </summary>
    [JsonProperty("is_tracking_opens")]
    public bool? IsTrackingOpens { get; set; }
    /// <summary>
    /// Whether the campaign is tracking click events. If not specified, uses company defaults.
    /// </summary>
    [JsonProperty("is_tracking_clicks")]
    public bool? IsTrackingClicks { get; set; }
    /// <summary>
    /// Whether the campaign needs UTM parameters. If set to False, UTM params will not be used.
    /// </summary>
    [JsonProperty("is_add_utm")]
    public bool? IsAddUtm { get; set; }
    /// <summary>
    /// A list of UTM parameters. If an empty list is given and is_add_utm is True, uses company defaults.
    /// </summary>
    [JsonProperty("utm_params")]
    public List<UTMParams> UtmParams { get; set; }
}
/// <summary>
/// Campaign Send Strategy
/// </summary>
public class CampaignSendStrategy
{
    /// <summary>
    /// Describes the shape of the options object. Allowed values: ['static', 'throttled', 'immediate', 'smart_send_time']
    /// </summary>
    [JsonProperty("method")]
    public string Method { get; set; }
    /// <summary>
    /// The send configuration options the campaign will send with. These define variables that alter the send strategy and must match the given method. Intended to be used with the 'static' method.
    /// </summary>
    [JsonProperty("options_static")]
    public CampaignSendStrategyOptionsStatic OptionsStatic { get; set; }
    /// <summary>
    /// The send configuration options the campaign will send with. These define variables that alter the send strategy and must match the given method. Intended to be used with the 'throttled' method.
    /// </summary>
    [JsonProperty("options_throttled")]
    public CampaignSendStrategyOptionsThrottled OptionsThrottled { get; set; }
    /// <summary>
    /// The send configuration options the campaign will send with. These define variables that alter the send strategy and must match the given method. Intended to be used with the 'smart_send_time' method.
    /// </summary>
    [JsonProperty("options_sto")]
    public CampaignSendStrategyOptionsSto OptionsSto { get; set; }
}
/// <summary>
/// Campaign Send Strategy Options Static
/// </summary>
public class CampaignSendStrategyOptionsStatic
{
    /// <summary>
    /// The time to send at
    /// </summary>
    [JsonProperty("datetime")]
    public DateTime? DateTime { get; set; }
    /// <summary>
    /// If the campaign should be sent with local recipient timezone send (requires UTC time) or statically sent at the given time. Defaults to False.
    /// </summary>
    [JsonProperty("is_local")]
    public bool? IsLocal { get; set; }
    /// <summary>
    /// Determines if we should send to local recipient timezone if the given time has passed. Only applicable to local sends. Defaults to False.
    /// </summary>
    [JsonProperty("send_past_recipients_immmediately")]
    public bool? SendPastRecipientsImmediately { get; set; }
}
/// <summary>
/// Campaign Send Strategy Options Throttled
/// </summary>
public class CampaignSendStrategyOptionsThrottled
{
    /// <summary>
    /// The time to send at
    /// </summary>
    [JsonProperty("datetime")]
    public DateTime? DateTime { get; set; }
    /// <summary>
    /// The percentage of recipients per hour to send to. Allowed values: [10, 11, 13, 14, 17, 20, 25, 33, 50]
    /// </summary>
    [JsonProperty("throttle_percentage")]
    public int? ThrottlePercentage { get; set; }
}
/// <summary>
/// Campaign Send Strategy Options Sto
/// </summary>
public class CampaignSendStrategyOptionsSto
{
    /// <summary>
    /// The day to send on
    /// </summary>
    [JsonProperty("date")]
    public KlaviyoDateOnly Date { get; set; }
}