using System.Collections.Generic;
using Newtonsoft.Json;

namespace KlaviyoSharp.Models;

public class DataObject
{
    public DataObject() { }
    public DataObject(string type, string id)
    {
        Type = type;
        Id = id;
    }
    [JsonProperty("type")]
    public string Type { get; set; }
    [JsonProperty("id")]
    public string Id { get; set; }

}
public class DataObject<T> : DataObject
{
    public DataObject(string type, T attributes) : base()
    {
        Type = type;
        Attributes = attributes;
    }
    public DataObject(string type, string id, T attributes) : base()
    {
        Type = type;
        Attributes = attributes;
        Id = id;
    }
    public DataObject() { }

    [JsonProperty("attributes")]
    public T Attributes { get; set; }

    [JsonProperty("relationships")]
    public Dictionary<string, Relationship> Relationships { get; set; }

    [JsonProperty("links")]
    public Links Links { get; set; }
}
