namespace KlaviyoSharp.Models;

/// <summary>
/// Coupon Codes returned from the API
/// </summary>
public class CouponCode : KlaviyoObject<CouponCodeAttributes, CouponCodeRelationships>
{
    /// <summary>
    /// Creates a new instance of the Template class
    /// </summary>
    /// <returns></returns>
    public static new CouponCode Create()
    {
        return new CouponCode() { Type = "coupon-code" };
    }
}

/// <summary>
/// Coupon Codes relationships
/// </summary>
public class CouponCodeRelationships
{
    /// <summary>
    /// Coupon associated with the couponcode
    /// </summary>
    public DataObjectRelated<GenericObject> Coupon { get; set; }
    /// <summary>
    /// Profiles associated with the couponcode
    /// </summary>
    public CouponCodeRelationshipsProfile Profile { get; set; }
}

/// <summary>
/// Coupon Codes Profile Relationships
/// </summary>
public class CouponCodeRelationshipsProfile
{
    /// <summary>
    /// Link to related objects
    /// </summary>
    public Links.RelatedLink Links { get; set; }
}

/// <summary>
/// Coupon Codes attributes
/// </summary>
public class CouponCodeAttributes
{
    /// <summary>
    /// This is a unique string that will be or is assigned to each customer/profile and is associated with a coupon.
    /// </summary>
    public string UniqueCode { get; set; }
    /// <summary>
    /// The datetime when this coupon code will expire.
    /// If not specified or set to null, it will be automatically set to 1 year.
    /// </summary>
    public DateTime? ExpiresAt { get; set; }
    /// <summary>
    /// The current status of the coupon code.
    /// </summary>
    public string? Status { get; set; }
}