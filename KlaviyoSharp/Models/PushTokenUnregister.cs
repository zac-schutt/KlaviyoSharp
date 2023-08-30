namespace KlaviyoSharp.Models;

/// <summary>
/// Klaviyo Push Token
/// </summary>
public class PushTokenUnregister : KlaviyoObject<PushTokenUnregisterAttributes>
{
    /// <summary>
    /// Creates a new instance of a Klaviyo Push Token with the Type property set to "push-token"
    /// </summary>
    /// <returns></returns>
    public static new PushTokenUnregister Create() => new() { Type = "push-token-unregister" };
}

/// <summary>
/// Klaviyo Push Token Attributes
/// </summary>
public class PushTokenUnregisterAttributes
{
    /// <summary>
    /// A push token from APNS or FCM.
    /// </summary>
    public string Token { get; set; }
    /// <summary>
    /// The platform on which the push token was created.
    /// </summary>
    public string Platform { get; set; }
    /// <summary>
    /// The vendor of the push token.
    /// </summary>
    public string Vendor { get; set; }
    /// <summary>
    /// The profile associated with the push token to create/update
    /// </summary>
    public DataObject<Profile> Profile { get; set; }
}
