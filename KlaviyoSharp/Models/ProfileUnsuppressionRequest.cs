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
        return new ProfileUnsuppressionRequest() { Type = "profile-unsuppression-bulk-create-job" };
    }
}
/// <summary>
/// Attributes of a Profile Unsuppression Request
/// </summary>
public class ProfileUnsuppressionRequestAttributes
{
    /// <summary>
    /// One or more suppressions to be removed.
    /// </summary>
    [JsonProperty("suppressions")]
    public List<ProfileUnsuppressionRequestSuppressions> Suppressions { get; set; }
}
/// <summary>
/// Email Suppression to be removed
/// </summary>
public class ProfileUnsuppressionRequestSuppressions
{
    /// <summary>
    /// The email of the profile to suppress / unsuppress.
    /// </summary>
    [JsonProperty("email")]
    public string Email { get; set; }
}