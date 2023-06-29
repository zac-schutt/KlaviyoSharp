using Newtonsoft.Json;

namespace KlaviyoSharp.Models;

public class ProfileDeletionAttributes : AttributesObject
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