namespace KlaviyoSharp.Models;

/// <summary>
/// Lists returned from the Klaviyo API
/// </summary>
public class List : KlaviyoObject<ListAttributes, ListRelationships>
{
    /// <summary>
    /// Creates a new instance of the List class
    /// </summary>
    /// <returns></returns>
    public static new List Create()
    {
        return new List() { Type = "list" };
    }
}

/// <summary>
/// List Relationships
/// </summary>
public class ListRelationships
{
    /// <summary>
    /// Profiles associated with the List
    /// </summary>
    public DataListObjectRelated<GenericObject> Profiles { get; set; }
    /// <summary>
    /// Tags associated with the List
    /// </summary>
    public DataListObjectRelated<GenericObject> Tags { get; set; }
}

/// <summary>
/// List Attributes
/// </summary>
public class ListAttributes
{
    /// <summary>
    /// A helpful name to label the list
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Date and time when the list was created, in ISO 8601 format (YYYY-MM-DDTHH:MM:SS.mmmmmm)
    /// </summary>
    public DateTime? Created { get; set; }
    /// <summary>
    /// Date and time when the list was last updated, in ISO 8601 format (YYYY-MM-DDTHH:MM:SS.mmmmmm)
    /// </summary>
    public DateTime? Updated { get; set; }
}