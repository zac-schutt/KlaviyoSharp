using Newtonsoft.Json;

namespace KlaviyoSharp.Models;
/// <summary>
/// Request to delete a profile
/// </summary>
public class ProfileDeletionRequest : KlaviyoObjectBasic<ProfileDeletionRequestAttributes>
{
    /// <summary>
    /// Creates a new instance of the Profile Deletion Request class
    /// </summary>
    /// <returns></returns>
    public static new ProfileDeletionRequest Create()
    {
        return new() { Type = "data-privacy-deletion-job" };
    }
}
/// <summary>
/// Attributes of a Profile Deletion Request
/// </summary>
public class ProfileDeletionRequestAttributes
{
    /// <summary>
    /// The email address of the profile to delete.
    /// </summary>
    [JsonProperty("email")]
    public string Email { get; set; }
    /// <summary>
    /// The ID of the profile to delete. This is the id field on the profile object.
    /// </summary>
    [JsonProperty("profile_id")]
    public string ProfileId { get; set; }
    /// <summary>
    /// The phone number of the profile to delete.
    /// </summary>
    [JsonProperty("phone_number")]
    public string PhoneNumber { get; set; }
}