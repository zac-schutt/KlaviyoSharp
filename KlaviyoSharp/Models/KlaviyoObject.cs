using Newtonsoft.Json;

namespace KlaviyoSharp.Models;

public class KlaviyoObject<T>
{
    [JsonProperty("type")]
    public string Type { get; set; }
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("attributes")]
    public T Attributes { get; set; }
    [JsonProperty("links")]
    public Links Links { get; set; }
}