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
    /// The profile to delete.
    /// </summary>
    public DataObject<Profile> Profile { get; set; }
}