using Newtonsoft.Json;

namespace KlaviyoSharp.Models;

public class Links
{
    [JsonProperty("self")]
    public string Self { get; set; }
    [JsonProperty("related")]
    public string Related { get; set; }
    [JsonProperty("first")]
    public string First { get; set; }
    [JsonProperty("last")]
    public string Last { get; set; }
    [JsonProperty("prev")]
    public string Prev { get; set; }
    [JsonProperty("next")]
    public string Next { get; set; }
}