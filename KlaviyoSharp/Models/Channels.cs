using System.Collections.Generic;
using Newtonsoft.Json;

namespace KlaviyoSharp.Models;

public class Channels
{
    /// <summary>
    /// The communication types to subscribe to on the "EMAIL" Channel. Currently supports "MARKETING".
    /// </summary>
    [JsonProperty("email")]
    public List<string> Email { get; set; }
    /// <summary>
    /// The communication types to subscribe to on the "SMS" Channel. Currently supports "MARKETING".
    /// </summary>
    [JsonProperty("sms")]
    public List<string> Sms { get; set; }
}