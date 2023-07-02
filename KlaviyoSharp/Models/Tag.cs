using Newtonsoft.Json;

namespace KlaviyoSharp.Models;

public class Tag : KlaviyoObject<TagAttributes>
{
    public static new Tag Create()
    {
        return new() { Type = "tag" };
    }

    [JsonProperty("relationships")]
    public TagRelationships Relationships { get; set; }
}

public class TagRelationships
{
    [JsonProperty("tag_group")]
    public DataListObjectRelated<GenericObject> TagGroup { get; set; }
    [JsonProperty("lists")]
    public DataListObjectRelated<GenericObject> Lists { get; set; }
    [JsonProperty("segments")]
    public DataListObjectRelated<GenericObject> Segments { get; set; }
    [JsonProperty("campaigns")]
    public DataListObjectRelated<GenericObject> Campaigns { get; set; }
    [JsonProperty("flows")]
    public DataListObjectRelated<GenericObject> Flows { get; set; }
}

public class TagAttributes
{
    [JsonProperty("name")]
    public string Name { get; set; }
}