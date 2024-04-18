namespace KlaviyoSharp.Models;

/// <summary>
/// Coupons returned from the API
/// </summary>
public class Coupon : KlaviyoObject<CouponAttributes>
{
    /// <summary>
    /// Creates a new instance of the Template class
    /// </summary>
    /// <returns></returns>
    public static new Coupon Create()
    {
        return new Coupon() { Type = "coupon" };
    }
}

/// <summary>
/// Coupon attributes
/// </summary>
public class CouponAttributes
{
    /// <summary>
    /// This is the id that is stored in an integration such as Shopify or Magento.
    /// </summary>
    public string ExternalId { get; set; }
    /// <summary>
    /// A description of the coupon.
    /// </summary>
    public string Description { get; set; }
}