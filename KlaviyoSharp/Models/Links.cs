using Newtonsoft.Json;

namespace KlaviyoSharp.Models.Links;
/// <summary>
/// Links returned from the Klaviyo API
/// </summary>
public class SelfLink
{
    /// <summary>
    /// Link to this object
    /// </summary>
    [JsonProperty("self")]
    public string Self { get; set; }
}
/// <summary>
/// Links returned from the Klaviyo API (with related link)
/// </summary>
public class RelatedLink : SelfLink
{
    /// <summary>
    /// Link to related objects
    /// </summary>
    [JsonProperty("related")]
    public string Related { get; set; }
}
/// <summary>
/// Links returned from the Klaviyo API (with pagination links)
/// </summary>
public class NavLink: SelfLink
{
    /// <summary>
    /// Link to first page of objects
    /// </summary>
    [JsonProperty("first")]
    public string First { get; set; }
    /// <summary>
    /// Link to last page of objects
    /// </summary>
    [JsonProperty("last")]
    public string Last { get; set; }
    /// <summary>
    /// Link to previous page of objects
    /// </summary>
    [JsonProperty("prev")]
    public string Prev { get; set; }
    /// <summary>
    /// Link to next page of objects
    /// </summary>
    [JsonProperty("next")]
    public string Next { get; set; }
}