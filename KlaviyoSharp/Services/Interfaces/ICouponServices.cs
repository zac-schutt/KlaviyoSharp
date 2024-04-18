using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Models;
using KlaviyoSharp.Models.Filters;

namespace KlaviyoSharp.Services;

/// <summary>
/// Interface for Klaviyo Coupon Services
/// </summary>
public interface ICouponServices
{
    /// <summary>
    /// Get all coupons in an account.
    /// 
    /// To learn more, see our <see href="https://developers.klaviyo.com/en/docs/use_klaviyos_coupons_api">Coupons API guide</see>.
    /// </summary>
    /// <param name="couponFields"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<Coupon>> GetCoupons(List<string> couponFields = null, CancellationToken cancellationToken = default);
    /// <summary>
    /// Creates a new coupon.
    /// </summary>
    /// <param name="coupon"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<Coupon>> CreateCoupon(Coupon coupon, CancellationToken cancellationToken = default);
    /// <summary>
    /// Get a specific coupon with the given coupon ID.
    /// </summary>
    /// <param name="couponId">The internal id of a Coupon is equivalent to its external id stored within an integration.</param>
    /// <param name="couponFields"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<Coupon>> GetCoupon(string couponId,
                                       List<string> couponFields = null,
                                       CancellationToken cancellationToken = default);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="couponId">The internal id of a Coupon is equivalent to its external id stored within an integration.</param>
    /// <param name="coupon"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<Coupon>> UpdateCoupon(string couponId,
                                          Coupon coupon,
                                          CancellationToken cancellationToken = default);
    /// <summary>
    /// Delete the coupon with the given coupon ID.
    /// </summary>
    /// <param name="couponId">The internal id of a Coupon is equivalent to its external id stored within an integration.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeleteCoupon(string couponId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a list of coupon codes associated with a coupon/coupons or a profile/profiles.
    /// A coupon/coupons or a profile/profiles must be provided as required filter params.
    /// </summary>
    /// <param name="couponCodeFields"></param>
    /// <param name="couponFields"></param>
    /// <param name="filter"></param>
    /// <param name="includedRecords"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<CouponCode>> GetCouponCodes(List<string> couponCodeFields = null,
                                                    List<string> couponFields = null,
                                                    IFilter filter = null,
                                                    List<string> includedRecords = null,
                                                    CancellationToken cancellationToken = default);
    /// <summary>
    /// Synchronously creates a coupon code for the given coupon.
    /// </summary>
    /// <param name="couponcode"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<CouponCode>> CreateCouponCode(CouponCode couponcode,
                                                  CancellationToken cancellationToken = default);
    /// <summary>
    /// Synchronously creates a coupon code for the given coupon.
    /// </summary>
    /// <param name="couponcode"></param>
    /// <param name="coupon"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<CouponCode>> CreateCouponCode(CouponCode couponcode,
                                                  Coupon coupon,
                                                  CancellationToken cancellationToken = default);
    /// <summary>
    /// Returns a Coupon Code specified by the given identifier.
    /// </summary>
    /// <param name="couponCodeId"></param>
    /// <param name="couponCodeFields"></param>
    /// <param name="couponFields"></param>
    /// <param name="includedRecords"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<CouponCode>> GetCouponCode(string couponCodeId,
                                               List<string> couponCodeFields = null,
                                               List<string> couponFields = null,
                                               List<string> includedRecords = null,
                                               CancellationToken cancellationToken = default);
    /// <summary>
    /// Updates a coupon code specified by the given identifier synchronously.
    /// We allow updating the 'status' and 'expires_at' of coupon codes.
    /// </summary>
    /// <param name="couponCodeId"></param>
    /// <param name="couponCode"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<CouponCode>> UpdateCouponCode(string couponCodeId,
                                                  CouponCode couponCode,
                                                  CancellationToken cancellationToken = default);
    /// <summary>
    /// Deletes a coupon code specified by the given identifier synchronously.
    /// If a profile has been assigned to the coupon code, an exception will be raised
    /// </summary>
    /// <param name="couponCodeId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeleteCouponCode(string couponCodeId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get all coupon code bulk create jobs.
    /// Returns a maximum of 100 jobs per request.
    /// </summary>
    /// <returns></returns>
    Task<DataListObject<CouponCodeBulkJob>> GetCouponCodeBulkCreateJobs(List<string> couponCodeBulkCreateJobFields = null,
                                                                        IFilter filter = null,
                                                                        CancellationToken cancellationToken = default);
    /// <summary>
    /// Create a coupon-code-bulk-create-job to bulk create a list of coupon codes.
    /// Max number of jobs queued at once we allow for is 100.
    /// </summary>
    /// <returns></returns>
    Task<DataObject<CouponCodeBulkJob>> SpawnCouponCodeBulkCreateJob(List<CouponCodeBulkJob> couponCodeBulkJob, CancellationToken cancellationToken = default);
    /// <summary>
    /// Get a coupon code bulk create job with the given job ID.
    /// </summary>
    /// <returns></returns>
    Task<DataObject<CouponCodeBulkJob>> GetCouponCodeBulkCreateJob(string jobId,
                                                                   List<string> couponCodeBulkCreateJobFields = null,
                                                                   List<string> couponFields = null,
                                                                   List<string> includedRecords = null,
                                                                   CancellationToken cancellationToken = default);
    /// <summary>
    /// Get the coupon associated with a given coupon code ID.
    /// </summary>
    /// <returns></returns>
    Task<DataListObject<Coupon>> GetCouponForCouponCode(string couponCodeId,
                                                        List<string> couponFields = null,
                                                        CancellationToken cancellationToken = default);
    /// <summary>
    /// Gets the coupon relationship associated with the given coupon code id
    /// </summary>
    /// <returns></returns>
    Task<DataListObject<GenericObject>> GetCouponRelationshipsCouponCodes(string couponCodeId, CancellationToken cancellationToken = default);
    /// <summary>
    /// Gets a list of coupon codes associated with the given coupon id
    /// </summary>
    /// <returns></returns>
    Task<DataListObject<CouponCode>> GetCouponCodesForCoupon(string couponId,
                                                             List<string> couponCodeFields = null,
                                                             IFilter filter = null,
                                                             CancellationToken cancellationToken = default);
    /// <summary>
    /// Gets a list of coupon code relationships associated with the given coupon id
    /// </summary>
    /// <returns></returns>
    Task<DataListObject<GenericObject>> GetCouponCodeRelationshipsCoupon(string couponId, CancellationToken cancellationToken = default);
}
