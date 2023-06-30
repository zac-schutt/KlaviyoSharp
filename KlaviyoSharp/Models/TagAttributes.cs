using Newtonsoft.Json;

namespace KlaviyoSharp.Models;

public class TagAttributes : AttributesObject
{
    [JsonProperty("name")]
    public string Name { get; set; }
}