using System.Collections.Generic;
using Newtonsoft.Json;

namespace KlaviyoSharp.Models;
/// <summary>
/// Request to suppress a list of profiles
/// </summary>
public class ProfileSuppressionRequest : KlaviyoObjectBasic<ProfileSuppressionRequestAttributes>
{
    /// <summary>
    /// Creates a new instance of the Profile Suppression Request class
    /// </summary>
    /// <returns></returns>
    public static new ProfileSuppressionRequest Create()
    {
        return new ProfileSuppressionRequest() { Type = "profile-suppression-bulk-create-job" };
    }
}
/// <summary>
///
/// </summary>
public class ProfileSuppressionRequestAttributes
{
    /// <summary>
    /// One or more suppressions to be created.
    /// </summary>
    [JsonProperty("suppressions")]
    public List<ProfileSuppressionRequestSuppressions> Suppressions { get; set; }
}
/// <summary>
/// Email Suppression to be added
/// </summary>
public class ProfileSuppressionRequestSuppressions
{
    /// <summary>
    /// The email of the profile to suppress / unsuppress.
    /// </summary>
    [JsonProperty("email")]
    public string Email { get; set; }
}