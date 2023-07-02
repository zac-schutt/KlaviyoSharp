using Newtonsoft.Json;

namespace KlaviyoSharp.Models.Links;

public class SelfLink
{
    [JsonProperty("self")]
    public string Self { get; set; }
}
public class RelatedLink : SelfLink
{
    [JsonProperty("related")]
    public string Related { get; set; }
}
public class NavLink: SelfLink
{
    [JsonProperty("first")]
    public string First { get; set; }
    [JsonProperty("last")]
    public string Last { get; set; }
    [JsonProperty("prev")]
    public string Prev { get; set; }
    [JsonProperty("next")]
    public string Next { get; set; }
}