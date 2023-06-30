using System;
using Newtonsoft.Json;

namespace KlaviyoSharp.Models;

public class EmailSupression
{
    /// <summary>
    /// The reason the profile was suppressed from the list.
    /// </summary>
    [JsonProperty("reason")]
    public string Reason { get; set; }
    /// <summary>
    /// The timestamp when the profile was suppressed from the list, in ISO 8601 format (YYYY-MM-DDTHH:MM:SS.mmmmmm).
    /// </summary>
    [JsonProperty("timestamp")]
    public DateTime? Timestamp { get; set; }
}