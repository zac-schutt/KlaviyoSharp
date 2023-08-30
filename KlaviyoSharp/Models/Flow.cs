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
    public DataListObjectRelated<GenericObject> FlowActions { get; set; }
    /// <summary>
    /// Tags associated with the flow
    /// </summary>
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
    public string Name { get; set; }
    /// <summary>
    /// Undocumented
    /// </summary>
    public string Status { get; set; }
    /// <summary>
    /// Undocumented
    /// </summary>
    public bool? Archived { get; set; }
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
    public string TriggerType { get; set; }
}