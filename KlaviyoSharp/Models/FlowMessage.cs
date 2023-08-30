namespace KlaviyoSharp.Models;

/// <summary>
/// Flow Messages returned from the API
/// </summary>
public class FlowMessage : KlaviyoObject<FlowMessageAttributes, FlowMessageRelationships>
{
    /// <summary>
    /// Creates a new instance of the Template class
    /// </summary>
    /// <returns></returns>
    public static new Flow Create()
    {
        return new Flow() { Type = "flow-message" };
    }
}

/// <summary>
/// Flow Messages relationships
/// </summary>
public class FlowMessageRelationships
{
    /// <summary>
    /// Flow actions associated with the flow
    /// </summary>
    public DataListObjectRelated<GenericObject> FlowActions { get; set; }
}

/// <summary>
/// Flow Messages attributes
/// </summary>
public class FlowMessageAttributes
{
    /// <summary>
    /// Undocumented
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Undocumented
    /// </summary>
    public string Channel { get; set; }
    /// <summary>
    /// Undocumented and Obsolete. See <see href="https://developers.klaviyo.com/en/reference/get_flow_message"/>
    /// </summary>
    [Obsolete("Marked Obsolete in Klaviyo API Docs")]
    public FlowMessageContent Content { get; set; }
    /// <summary>
    /// Undocumented
    /// </summary>
    public DateTime? Created { get; set; }
    /// <summary>
    /// Undocumented
    /// </summary>
    public DateTime? Updated { get; set; }
}

/// <summary>
/// Flow Message Content. Obsolte. See <see href="https://developers.klaviyo.com/en/reference/get_flow_message"/>
/// </summary>
public class FlowMessageContent
{
    /// <summary>
    /// Undocumented. Email only.
    /// </summary>
    public string Subject { get; set; }
    /// <summary>
    /// Undocumented. Email only.
    /// </summary>
    public string FromEmail { get; set; }
    /// <summary>
    /// Undocumented. Email only.
    /// </summary>
    public string FromName { get; set; }
    /// <summary>
    /// Undocumented. Email only.
    /// </summary>
    public string PreviewText { get; set; }
    /// <summary>
    /// The label associated with the from_email
    /// </summary>
    public string FromLabel { get; set; }
    /// <summary>
    /// Optional Reply-To email address
    /// </summary>
    public string ReplyToEmail { get; set; }
    /// <summary>
    /// Optional CC email address
    /// </summary>
    public string CcEmail { get; set; }
    /// <summary>
    /// Optional BCC email address
    /// </summary>
    public string BccEmail { get; set; }
    /// <summary>
    /// Undocumented. SMS only.
    /// </summary>
    public string Body { get; set; }
    /// <summary>
    /// Undocumented. SMS only.
    /// </summary>
    public string Media { get; set; }
}