using System;
using Newtonsoft.Json;

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
    [JsonProperty("flow-actions")]
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
    [JsonProperty("name")]
    public string Name { get; set; }
    /// <summary>
    /// Undocumented
    /// </summary>
    [JsonProperty("channel")]
    public string Channel { get; set; }
    /// <summary>
    /// Undocumented and Obsolete. See <see href="https://developers.klaviyo.com/en/reference/get_flow_message"/>
    /// </summary>
    [JsonProperty("content")]
    [Obsolete("Marked Obsolete in Klaviyo API Docs")]
    public FlowMessageContent Content { get; set; }
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
}
/// <summary>
/// Flow Message Content. Obsolte. See <see href="https://developers.klaviyo.com/en/reference/get_flow_message"/>
/// </summary>
public class FlowMessageContent
{
    /// <summary>
    /// Undocumented. Email only.
    /// </summary>
    [JsonProperty("subject")]
    public string Subject { get; set; }
    /// <summary>
    /// Undocumented. Email only.
    /// </summary>
    [JsonProperty("from_email")]
    public string FromEmail { get; set; }
    /// <summary>
    /// Undocumented. Email only.
    /// </summary>
    [JsonProperty("from_name")]
    public string FromName { get; set; }
    /// <summary>
    /// Undocumented. Email only.
    /// </summary>
    [JsonProperty("preview_text")]
    public string PreviewText { get; set; }
    /// <summary>
    /// The label associated with the from_email
    /// </summary>
    [JsonProperty("from_label")]
    public string FromLabel { get; set; }
    /// <summary>
    /// Optional Reply-To email address
    /// </summary>
    [JsonProperty("reply_to_email")]
    public string ReplyToEmail { get; set; }
    /// <summary>
    /// Optional CC email address
    /// </summary>
    [JsonProperty("cc_email")]
    public string CcEmail { get; set; }
    /// <summary>
    /// Optional BCC email address
    /// </summary>
    [JsonProperty("bcc_email")]
    public string BccEmail { get; set; }
    /// <summary>
    /// Undocumented. SMS only.
    /// </summary>
    [JsonProperty("body")]
    public string Body { get; set; }
    /// <summary>
    /// Undocumented. SMS only.
    /// </summary>
    [JsonProperty("media")]
    public string Media { get; set; }
}