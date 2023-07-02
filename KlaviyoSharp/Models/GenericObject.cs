using Newtonsoft.Json;

namespace KlaviyoSharp.Models;

public class GenericObject{
    [JsonProperty("type")]
    public string Type { get; set; }
    [JsonProperty("id")]
    public string Id { get; set; }
}