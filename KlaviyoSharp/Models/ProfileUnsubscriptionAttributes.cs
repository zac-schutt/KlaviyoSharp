using System.Collections.Generic;
using Newtonsoft.Json;

namespace KlaviyoSharp.Models;

public class ProfileUnsubscriptionAttributes : AttributesObject
{
    /// <summary>
    /// Optional, the list to remove the profiles from
    /// </summary>
    [JsonProperty("list_id")]
    public string ListId { get; set; }
    /// <summary>
    /// The emails to unsubscribe if any.
    /// </summary>
    [JsonProperty("emails")]
    public List<string> Emails { get; set; }
    /// <summary>
    /// The phone numbers to unsubscribe if any.
    /// </summary>
    [JsonProperty("phone_numbers")]
    public List<string> PhoneNumbers { get; set; }
}