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
    public DataObject<GenericObject> Flow { get; set; }
    /// <summary>
    /// Flow actions associated with the flow
    /// </summary>
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
    public string ActionType { get; set; }
    /// <summary>
    /// Undocumented
    /// </summary>
    public string Status { get; set; }
    /// <summary>
    /// Undocumented
    /// </summary>
    public DateTime? Created { get; set; }
    /// <summary>
    /// Undocumented
    /// </summary>
    public DateTime? Updated { get; set; }
    /// <summary>
    /// Undocumented
    /// </summary>
    public object Settings { get; set; }
    /// <summary>
    /// Undocumented
    /// </summary>
    public FlowActionTrackingOptions TrackingOptions { get; set; }
    /// <summary>
    /// Undocumented
    /// </summary>
    public FlowActionSendOptions SendOptions { get; set; }
    /// <summary>
    /// Undocumented
    /// </summary>
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
    public bool? AddUtm { get; set; }
    /// <summary>
    /// Undocumented
    /// </summary>
    public List<UTMParams> UtmParams { get; set; }
    /// <summary>
    /// Undocumented
    /// </summary>
    public bool? IsTrackingOpens { get; set; }
    /// <summary>
    /// Undocumented
    /// </summary>
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
    public bool? UseSmartSending { get; set; }
    /// <summary>
    /// Undocumented
    /// </summary>
    public bool? IsTransactional { get; set; }
    /// <summary>
    /// Undocumented
    /// </summary>
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
    public bool? ShortenLinks { get; set; }
    /// <summary>
    /// Undocumented
    /// </summary>
    public bool? AddOrgPrefix { get; set; }
    /// <summary>
    /// Undocumented
    /// </summary>
    public bool? AddInfoLink { get; set; }
    /// <summary>
    /// Undocumented
    /// </summary>
    public bool? AddOptOutLanguage { get; set; }
}