namespace KlaviyoSharp.Models;

/// <summary>
/// Klaviyo Client Back In Stock Subscription
/// </summary>
public class BackInStockSubscription : KlaviyoObject<BackInStockSubAttributes, BackInStockSubRelationships>
{
    /// <summary>
    /// Creates a new instance of the Klaviyo Client Back In Stock Subscription with default values
    /// </summary>
    /// <returns></returns>
    public static new BackInStockSubscription Create() => new() { Type = "back-in-stock-subscription" };
}

/// <summary>
/// Klaviyo Client Back In Stock Subscription Relationships
/// </summary>
public class BackInStockSubRelationships
{
    /// <summary>
    /// Klaviyo Client Back In Stock Subscription Variants
    /// </summary>
    public DataObject<GenericObject> Variant { get; set; }
}

/// <summary>
/// Klaviyo Client Back In Stock Subscription Attributes
/// </summary>
public class BackInStockSubAttributes
{
    /// <summary>
    /// The channel(s) through which the profile would like to receive the back in stock notification. This can be
    /// leveraged within a back in stock flow to notify the subscriber through their preferred channel(s).
    /// </summary>
    public List<string> Channels { get; set; }
    /// <summary>
    /// Profile to subscribe. Only fields required are email, or phone_number, or external_id, or anonymous_id.
    /// </summary>
    public DataObject<Profile> Profile { get; set; }
}