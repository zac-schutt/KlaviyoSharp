using System;
using Newtonsoft.Json;

namespace KlaviyoSharp.Models;
/// <summary>
/// Lists returned from the Klaviyo API
/// </summary>
public class List : KlaviyoObject<ListAttributes>
{
    /// <summary>
    /// Creates a new instance of the List class
    /// </summary>
    /// <returns></returns>
    public static new List Create()
    {
        return new List() { Type = "list" };
    }
    /// <summary>
    /// Related objects for the List
    /// </summary>
    [JsonProperty("relationships")]
    public ListRelationships Relationships { get; set; }
}
/// <summary>
/// List Relationships
/// </summary>
public class ListRelationships
{
    /// <summary>
    /// Profiles associated with the List
    /// </summary>
    [JsonProperty("profiles")]
    public DataListObjectRelated<GenericObject> Profiles { get; set; }
    /// <summary>
    /// Tags associated with the List
    /// </summary>
    [JsonProperty("tags")]
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
    [JsonProperty("name")]
    public string Name { get; set; }
    /// <summary>
    /// Date and time when the list was created, in ISO 8601 format (YYYY-MM-DDTHH:MM:SS.mmmmmm)
    /// </summary>
    [JsonProperty("created")]
    public DateTime? Created { get; set; }
    /// <summary>
    /// Date and time when the list was last updated, in ISO 8601 format (YYYY-MM-DDTHH:MM:SS.mmmmmm)
    /// </summary>
    [JsonProperty("updated")]
    public DateTime? Updated { get; set; }
}