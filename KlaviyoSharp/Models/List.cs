using System;
using Newtonsoft.Json;

namespace KlaviyoSharp.Models;
public class List : KlaviyoObject<ListAttributes>
{
    public static new List Create()
    {
        return new List() { Type = "list" };
    }
    [JsonProperty("relationships")]
    public ListRelationships Relationships { get; set; }
}

public class ListRelationships
{
    [JsonProperty("profiles")]
    public DataListObjectRelated<GenericObject> Profiles { get; set; }
    [JsonProperty("tags")]
    public DataListObjectRelated<GenericObject> Tags { get; set; }
}

public class ListAttributes
{
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("created")]
    public DateTime? Created { get; set; }
    [JsonProperty("updated")]
    public DateTime? Updated { get; set; }
}