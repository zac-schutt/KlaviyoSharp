using Newtonsoft.Json;

namespace KlaviyoSharp.Models;

public class ListSupression : EmailSupression
{
    /// <summary>
    /// The ID of list to which the suppression applies.
    /// </summary>
    [JsonProperty("list_id")]
    public string ListId { get; set; }
}