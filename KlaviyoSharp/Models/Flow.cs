using System;
using Newtonsoft.Json;

namespace KlaviyoSharp.Models;
/// <summary>
/// Flows returned from the API
/// </summary>
public class Flow : KlaviyoObject<FlowAttributes, FlowRelationships>
{
    /// <summary>
    /// Creates a new instance of the Template class
    /// </summary>
    /// <returns></returns>
    public static new Flow Create()
    {
        return new Flow() { Type = "flow" };
    }
}
/// <summary>
/// Flow relationships
/// </summary>
public class FlowRelationships
{
    /// <summary>
    /// Flow actions associated with the flow
    /// </summary>
    [JsonProperty("flow-actions")]
    public DataListObjectRelated<GenericObject> FlowActions { get; set; }
    /// <summary>
    /// Tags associated with the flow
    /// </summary>
    [JsonProperty("tags")]
    public DataListObjectRelated<GenericObject> Tags { get; set; }
}
/// <summary>
/// Flow attributes
/// </summary>
public class FlowAttributes
{
    /// <summary>
    /// Undocumented
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }
    /// <summary>
    /// Undocumented
    /// </summary>
    [JsonProperty("status")]
    public string Status { get; set; }
    /// <summary>
    /// Undocumented
    /// </summary>
    [JsonProperty("archived")]
    public bool? Archived { get; set; }
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
    [JsonProperty("trigger_type")]
    public string TriggerType { get; set; }
}