namespace KlaviyoSharp.Models;

/// <summary>
/// Profile Unsubscription Request
/// </summary>
public class ProfileUnsubscriptionRequest : KlaviyoObject<ProfileUnsubAttributes, ProfileUnsubRelationships>
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
public class ProfileUnsubRelationships
{
    /// <summary>
    /// The list to remove the profiles from
    /// </summary>
    public DataObject<GenericObject> List { get; set; }
}

/// <summary>
/// Profile Unsubscription Attributes
/// </summary>
public class ProfileUnsubAttributes
{
    /// <summary>
    /// The profiles to unsubscribe
    /// </summary>
    public DataListObject<Profile> Profiles { get; set; }
}