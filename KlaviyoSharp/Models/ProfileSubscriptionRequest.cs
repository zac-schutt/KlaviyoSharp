namespace KlaviyoSharp.Models;

/// <summary>
/// Request to subscribe a list of profiles
/// </summary>
public class ProfileSubscriptionRequest : KlaviyoObject<ProfileSubAttributes,ProfileSubRequestRelationships>{
    /// <summary>
    /// Creates a new instance of the Profile Subscription Request class
    /// </summary>
    /// <returns></returns>
    public static new ProfileSubscriptionRequest Create()
    {
        return new ProfileSubscriptionRequest() { Type = "profile-subscription-bulk-create-job" };
    }
}

/// <summary>
/// Relationships of a Profile Subscription Request
/// </summary>
public class ProfileSubRequestRelationships
{
    /// <summary>
    /// The list to add the newly subscribed profiles to
    /// </summary>
    public DataObject<GenericObject> List { get; set; }
}

/// <summary>
/// Attributes of a Profile Subscription Request
/// </summary>
public class ProfileSubAttributes
{
    /// <summary>
    /// A custom method detail or source to store on the consent records.
    /// </summary>
    public string CustomSource { get; set; }
    /// <summary>
    /// The profiles to subscribe
    /// </summary>
    public DataListObject<Profile> Profiles { get; set; }
}

/// <summary>
/// Subscription to be created
/// </summary>
public class ProfileSubscriptionRequestSubscription
{
    /// <summary>
    /// When provided, this will provide consent for the indicated message types on the specified channels. If omitted,
    /// we will subscribe the profile to all message types on the channels corresponding to the provided identifiers.
    /// </summary>
    public ProfileSubscriptionRequestSubscriptionChannels Channels { get; set; }
    /// <summary>
    /// The email address to subscribe or to set on the profile if channels is specified and the email channel is
    /// omitted.
    /// </summary>
    public string Email { get; set; }
    /// <summary>
    /// The phone number to subscribe or to set on the profile if channels is specified and the SMS channel is omitted.
    /// </summary>
    public string PhoneNumber { get; set; }
    /// <summary>
    /// The ID of the profile to subscribe. If provided, this will be used to perform the lookup.
    /// </summary>
    public string ProfileId { get; set; }
}

/// <summary>
/// The communication types to subscribe
/// </summary>
public class ProfileSubscriptionRequestSubscriptionChannels
{
    /// <summary>
    /// The communication types to subscribe to on the "EMAIL" Channel. Currently supports "MARKETING".
    /// </summary>
    public List<string> Email { get; set; }
    /// <summary>
    /// The communication types to subscribe to on the "SMS" Channel. Currently supports "MARKETING".
    /// </summary>
    public List<string> Sms { get; set; }
}
