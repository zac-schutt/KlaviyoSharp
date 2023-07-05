using System.Collections.Generic;
using Newtonsoft.Json;

namespace KlaviyoSharp.Models;
/// <summary>
/// Profile Unsubscription Request
/// </summary>
public class ProfileUnsubscriptionRequest : KlaviyoObjectBasic<ProfileUnsubscriptionAttributes>
{
    /// <summary>
    /// Creates a new instance of the Profile Unsubscription Request class
    /// </summary>
    /// <returns></returns>
    public static new ProfileUnsubscriptionRequest Create()
    {
        return new ProfileUnsubscriptionRequest() { Type = "profile-unsubscription-bulk-create-job" };
    }
}
/// <summary>
/// Profile Unsubscription Attributes
/// </summary>
public class ProfileUnsubscriptionAttributes
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