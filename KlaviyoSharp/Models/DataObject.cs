using Newtonsoft.Json;

namespace KlaviyoSharp.Models;

public abstract class DataObject
{
    [JsonProperty("type")]
    public string Type { get; set; }
}
public class DataObject<T> : DataObject where T : AttributesObject
{
    public DataObject(string type, T attributes) : base()
    {
        Type = type;
        Attributes = attributes;
    }
    [JsonProperty("attributes")]
    public T Attributes { get; set; }
}