using System.Collections.Generic;
using Newtonsoft.Json;

namespace KlaviyoSharp.Models;

/// <summary>
/// Request to Unsuppress a list of profiles
/// </summary>
public class ProfileUnsuppressionRequest : KlaviyoObjectBasic<ProfileUnsuppressionRequestAttributes>
{
    /// <summary>
    /// Creates a new instance of the Profile Unsuppression Request class
    /// </summary>
    /// <returns></returns>
    public static new ProfileUnsuppressionRequest Create()
    {
        return new ProfileUnsuppressionRequest() { Type = "profile-suppression-bulk-delete-job" };
    }
}
/// <summary>
/// Attributes of a Profile Unsuppression Request
/// </summary>
public class ProfileUnsuppressionRequestAttributes
{
    /// <summary>
    /// One or more profile to be unsupressed.
    /// </summary>
    [JsonProperty("profiles")]
    public DataListObject<Profile> Profiles { get; set; }
}
