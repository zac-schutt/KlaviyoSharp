namespace KlaviyoSharp.Models;

/// <summary>
/// A subscription to a list created for the client api
/// </summary>
public class ClientSubscription : KlaviyoObject<ClientSubscriptionAttributes, ClientSubscriptionRelationships>
{
    /// <summary>
    /// Creates a new instance of the ClientSubscription class
    /// </summary>
    /// <returns></returns>
    public static new ClientSubscription Create()
    {
        return new() { Type = "subscription" };
    }
}

/// <summary>
/// Relationships for a subscription to a list created for the client api
/// </summary>
public class ClientSubscriptionRelationships
{
    /// <summary>
    /// List to subscribe to.
    /// </summary>
    public DataObject<GenericObject> List { get; set; }
}

/// <summary>
/// Attributes for a subscription to a list created for the client api
/// </summary>
public class ClientSubscriptionAttributes
{
    /// <summary>
    /// A custom method detail or source to store on the consent records for this subscription.
    /// </summary>
    public string CustomSource { get; set; }
    /// <summary>
    /// The profile to subscribe.
    /// </summary>
    public DataObject<Profile> Profile { get; set; }
}