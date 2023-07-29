using System.Collections.Generic;
using Newtonsoft.Json;

namespace KlaviyoSharp.Models;
/// <summary>
/// Profile Unsubscription Request
/// </summary>
public class ProfileUnsubscriptionRequest : KlaviyoObject<ProfileUnsubscriptionAttributes, ProfileUnsubscriptionRelationships>
{
    /// <summary>
    /// Creates a new instance of the Profile Unsubscription Request class
    /// </summary>
    /// <returns></returns>
    public static new ProfileUnsubscriptionRequest Create()
    {
        return new ProfileUnsubscriptionRequest() { Type = "profile-subscription-bulk-delete-job" };
    }
}
/// <summary>
/// Relationships of a Profile Unsubscription Request
/// </summary>
public class ProfileUnsubscriptionRelationships
{
    /// <summary>
    /// The list to remove the profiles from
    /// </summary>
    [JsonProperty("list")]
    public DataObject<GenericObject> List { get; set; }
}

/// <summary>
/// Profile Unsubscription Attributes
/// </summary>
public class ProfileUnsubscriptionAttributes
{
    /// <summary>
    /// The profiles to unsubscribe
    /// </summary>
    [JsonProperty("profiles")]
    public DataListObject<Profile> Profiles { get; set; }
}