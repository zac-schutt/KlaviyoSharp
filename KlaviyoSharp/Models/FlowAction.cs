using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace KlaviyoSharp.Models;
/// <summary>
/// Flow Actions returned from the API
/// </summary>
public class FlowAction : KlaviyoObject<FlowActionAttributes, FlowActionsRelationships>
{
    /// <summary>
    /// Creates a new instance of the Template class
    /// </summary>
    /// <returns></returns>
    public static new Flow Create()
    {
        return new Flow() { Type = "flow-action" };
    }
}
/// <summary>
/// Flow actions relationships
/// </summary>
public class FlowActionsRelationships
{
    /// <summary>
    /// Flow actions associated with the flow
    /// </summary>
    [JsonProperty("flow")]
    public DataObject<GenericObject> Flow { get; set; }
    /// <summary>
    /// Flow actions associated with the flow
    /// </summary>
    [JsonProperty("flow-messages")]
    public DataListObjectRelated<GenericObject> FlowMessages { get; set; }
}
/// <summary>
/// Flow actions attributes
/// </summary>
public class FlowActionAttributes
{
    /// <summary>
    /// Undocumented
    /// </summary>
    [JsonProperty("action_type")]
    public string ActionType { get; set; }
    /// <summary>
    /// Undocumented
    /// </summary>
    [JsonProperty("status")]
    public string Status { get; set; }
    /// <summary>
    /// Undocumented
    /// </summary>
    [JsonProperty("created")]
    public DateTime? Created { get; set; }
    /// <summary>
    /// Undocumented
    /// </summary>
    [JsonProperty("updated")]
    public DateTime? Updated { get; set; }
    /// <summary>
    /// Undocumented
    /// </summary>
    [JsonProperty("settings")]
    public object Settings { get; set; }
    /// <summary>
    /// Undocumented
    /// </summary>
    [JsonProperty("tracking_options")]
    public FlowActionTrackingOptions TrackingOptions { get; set; }
    /// <summary>
    /// Undocumented
    /// </summary>
    [JsonProperty("send_options")]
    public FlowActionSendOptions SendOptions { get; set; }
    /// <summary>
    /// Undocumented
    /// </summary>
    [JsonProperty("render_options")]
    public FlowActionRenderOptions RenderOptions { get; set; }
}
/// <summary>
/// Undocumented flow action settings
/// </summary>
public class FlowActionTrackingOptions
{
    /// <summary>
    /// Undocumented
    /// </summary>
    [JsonProperty("add_utm")]
    public bool? AddUtm { get; set; }
    /// <summary>
    /// Undocumented
    /// </summary>
    [JsonProperty("utm_params")]
    public List<UTMParams> UTMParams { get; set; }
    /// <summary>
    /// Undocumented
    /// </summary>
    [JsonProperty("is_tracking_opens")]
    public bool? IsTrackingOpens { get; set; }
    /// <summary>
    /// Undocumented
    /// </summary>
    [JsonProperty("is_tracking_clicks")]
    public bool? IsTrackingClicks { get; set; }
}

/// <summary>
/// Undocumented flow action settings
/// </summary>
public class FlowActionSendOptions
{
    /// <summary>
    /// Undocumented
    /// </summary>
    [JsonProperty("use_smart_sending")]
    public bool? UseSmartSending { get; set; }
    /// <summary>
    /// Undocumented
    /// </summary>
    [JsonProperty("is_transactional")]
    public bool? IsTransactional { get; set; }
    /// <summary>
    /// Undocumented
    /// </summary>
    [JsonProperty("quiet_hours_enabled")]
    public bool? QuietHoursEnabled { get; set; }
}

/// <summary>
/// Undocumented flow action settings
/// </summary>
public class FlowActionRenderOptions
{
    /// <summary>
    /// Undocumented
    /// </summary>
    [JsonProperty("shorten_links")]
    public bool? ShortenLinks { get; set; }
    /// <summary>
    /// Undocumented
    /// </summary>
    [JsonProperty("add_org_prefix")]
    public bool? AddOrgPrefix { get; set; }
    /// <summary>
    /// Undocumented
    /// </summary>
    [JsonProperty("add_info_link")]
    public bool? AddInfoLink { get; set; }
    /// <summary>
    /// Undocumented
    /// </summary>
    [JsonProperty("add_opt_out_language")]
    public bool? AddOptOutLanguage { get; set; }
}