using Newtonsoft.Json;

namespace KlaviyoSharp.Models;
/// <summary>
/// Tag Groups returned from the Klaviyo API
/// </summary>
public class TagGroup : KlaviyoObject<TagGroupAttributes, TagGroupRelationships>
{
    /// <summary>
    /// Creates a new instance of the Tag Group class
    /// </summary>
    /// <returns></returns>
    public static new TagGroup Create()
    {
        return new() { Type = "tag-group" };
    }
}
/// <summary>
/// Tag Group Relationships
/// </summary>
public class TagGroupRelationships
{
    /// <summary>
    /// The tags that belong to this tag group.
    /// </summary>
    [JsonProperty("tags")]
    public DataListObjectRelated<GenericObject> Tags { get; set; }
}
/// <summary>
/// Tag Group Attributes
/// </summary>
public class TagGroupAttributes
{
    /// <summary>
    /// The Tag Group name
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }
    /// <summary>
    /// If a tag group is non-exclusive, any given related resource (campaign, flow, etc.) can be linked to multiple tags from that tag group. If a tag group is exclusive, any given related resource can only be linked to one tag from that tag group.
    /// </summary>
    [JsonProperty("exclusive")]
    public bool? Exclusive { get; set; }
    /// <summary>
    /// Every company automatically has one Default Tag Group. The Default Tag Group cannot be deleted, and no other Default Tag Groups can be created. This value is true for the Default Tag Group and false for all other Tag Groups.
    /// </summary>
    [JsonProperty("default")]
    public bool? Default { get; set; }
}