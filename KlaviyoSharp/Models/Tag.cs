using Newtonsoft.Json;

namespace KlaviyoSharp.Models;
/// <summary>
/// Tags returned from the Klaviyo API
/// </summary>
public class Tag : KlaviyoObject<TagAttributes, TagRelationships>
{
    /// <summary>
    /// Creates a new instance of the Tag class
    /// </summary>
    /// <returns></returns>
    public static new Tag Create()
    {
        return new() { Type = "tag" };
    }
}
/// <summary>
/// Tag Relationships
/// </summary>
public class TagRelationships
{
    /// <summary>
    /// The tag group that this tag belongs to.
    /// </summary>
    [JsonProperty("tag_group")]
    public DataListObjectRelated<GenericObject> TagGroup { get; set; }
    /// <summary>
    /// Lists that this tag is applied to.
    /// </summary>
    [JsonProperty("lists")]
    public DataListObjectRelated<GenericObject> Lists { get; set; }
    /// <summary>
    /// Segments that this tag is applied to.
    /// </summary>
    [JsonProperty("segments")]
    public DataListObjectRelated<GenericObject> Segments { get; set; }
    /// <summary>
    /// Campaigns that this tag is applied to.
    /// </summary>
    [JsonProperty("campaigns")]
    public DataListObjectRelated<GenericObject> Campaigns { get; set; }
    /// <summary>
    /// Flows that this tag is applied to.
    /// </summary>
    [JsonProperty("flows")]
    public DataListObjectRelated<GenericObject> Flows { get; set; }
}
/// <summary>
/// Tag Attributes
/// </summary>
public class TagAttributes
{
    /// <summary>
    /// The Tag name
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }
    /// <summary>
    /// The ID of the Tag Group to associate the Tag with. If this field is not specified, the Tag will be associated with the company's Default Tag Group.
    /// </summary>
    [JsonProperty("tag_group_id")]
    public string TagGroupId { get; set; }
}