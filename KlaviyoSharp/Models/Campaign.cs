using System;
using System.Collections.Generic;
using KlaviyoSharp.Infrastructure;

namespace KlaviyoSharp.Models;

/// <summary>
/// Klaviyo Campaign
/// </summary>
public class Campaign : KlaviyoObject<CampaignAttributes, CampaignRelationships>
{
    /// <summary>
    /// Creates a new Campaign with default values
    /// </summary>
    /// <returns></returns>
    public static new Account Create()
    {
        return new() { Type = "campaign" };
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
    public DataListObjectRelated<GenericObject> CampaignMessages { get; set; }
    /// <summary>
    /// Tags associated with the Campaign
    /// </summary>
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
    public string Name { get; set; }
    /// <summary>
    /// The current status of the campaign
    /// </summary>
    public string Status { get; set; }
    /// <summary>
    /// Whether the campaign has been archived or not
    /// </summary>
    public bool? Archived { get; set; }
    /// <summary>
    /// The type of campaign
    /// </summary>
    public string Channel { get; set; }
    /// <summary>
    /// The audiences to be included and/or excluded from the campaign
    /// </summary>
    public CampaignAudiences Audiences { get; set; }
    /// <summary>
    /// Options to use when sending a campaign
    /// </summary>
    public CampaignSendOptions SendOptions { get; set; }
    /// <summary>
    /// The tracking options associated with the campaign
    /// </summary>
    public CampaignTrackingOptions TrackingOptions { get; set; }
    /// <summary>
    /// The send strategy the campaign will send with
    /// </summary>
    public CampaignSendStrategy SendStrategy { get; set; }
    /// <summary>
    /// The send strategy the campaign will send with
    /// </summary>
    public DateTime? CreatedAt { get; set; }
    /// <summary>
    /// The datetime when the campaign was last updated by a user or the system
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
    /// <summary>
    /// The datetime when the campaign was scheduled for future sending
    /// </summary>
    public DateTime? ScheduledAt { get; set; }
    /// <summary>
    /// The datetime when the campaign will be / was sent or None if not yet scheduled by a send_job.
    /// </summary>
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
    public List<string> Included { get; set; }
    /// <summary>
    /// An optional list of excluded audiences
    /// </summary>
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
    public bool? IsTrackingOpens { get; set; }
    /// <summary>
    /// Whether the campaign is tracking click events. If not specified, uses company defaults.
    /// </summary>
    public bool? IsTrackingClicks { get; set; }
    /// <summary>
    /// Whether the campaign needs UTM parameters. If set to False, UTM params will not be used.
    /// </summary>
    public bool? IsAddUtm { get; set; }
    /// <summary>
    /// A list of UTM parameters. If an empty list is given and is_add_utm is True, uses company defaults.
    /// </summary>
    public List<UTMParams> UtmParams { get; set; }
}

/// <summary>
/// Campaign Send Strategy
/// </summary>
public class CampaignSendStrategy
{
    /// <summary>
    /// Describes the shape of the options object. Allowed values: ['static', 'throttled', 'immediate',
    /// 'smart_send_time']
    /// </summary>
    public string Method { get; set; }
    /// <summary>
    /// The send configuration options the campaign will send with. These define variables that alter the send strategy
    /// and must match the given method. Intended to be used with the 'static' method.
    /// </summary>
    public CampaignSendStrategyOptionsStatic OptionsStatic { get; set; }
    /// <summary>
    /// The send configuration options the campaign will send with. These define variables that alter the send strategy
    /// and must match the given method. Intended to be used with the 'throttled' method.
    /// </summary>
    public CampaignSendStrategyOptionsThrottled OptionsThrottled { get; set; }
    /// <summary>
    /// The send configuration options the campaign will send with. These define variables that alter the send strategy
    /// and must match the given method. Intended to be used with the 'smart_send_time' method.
    /// </summary>
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
    public DateTime? DateTime { get; set; }
    /// <summary>
    /// If the campaign should be sent with local recipient timezone send (requires UTC time) or statically sent at the
    /// given time. Defaults to False.
    /// </summary>
    public bool? IsLocal { get; set; }
    /// <summary>
    /// Determines if we should send to local recipient timezone if the given time has passed. Only applicable to local
    /// sends. Defaults to False.
    /// </summary>
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
    public DateTime? DateTime { get; set; }
    /// <summary>
    /// The percentage of recipients per hour to send to. Allowed values: [10, 11, 13, 14, 17, 20, 25, 33, 50]
    /// </summary>
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
    public KlaviyoDateOnly Date { get; set; }
}