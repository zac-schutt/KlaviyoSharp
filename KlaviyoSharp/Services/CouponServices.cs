using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Infrastructure;
using KlaviyoSharp.Models;
using KlaviyoSharp.Models.Filters;

namespace KlaviyoSharp.Services;

/// <summary>
/// Klaviyo Coupon Services
/// </summary>
public class CouponServices : KlaviyoServiceBase, ICouponServices
{
    /// <summary>
    /// Constructor for Klaviyo Coupon Services
    /// </summary>
    /// <param name="revision"></param>
    /// <param name="klaviyoService"></param>
    public CouponServices(string revision, KlaviyoApiBase klaviyoService) : base(revision, klaviyoService) { }
    /// <inheritdoc />
    public async Task<DataListObject<Coupon>> GetCoupons(List<string> couponFields = null,
                                                         CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("coupon", couponFields);
        return await _klaviyoService.HTTP<DataListObject<Coupon>>(HttpMethod.Get, "coupons/", _revision, query, null,
                                                                  null, cancellationToken);
    }
    ///<inheritdoc />
    public async Task<DataObject<Coupon>> CreateCoupon(Coupon coupon,
                                                       CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<Coupon>>(HttpMethod.Post, "coupons/", _revision, null, null,
                                                              new DataObject<Coupon>(coupon), cancellationToken);
    }
    ///<inheritdoc />
    public async Task<DataObject<Coupon>> GetCoupon(string couponId,
                                                    List<string> couponFields = null,
                                                    CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("coupon", couponFields);
        return await _klaviyoService.HTTP<DataObject<Coupon>>(HttpMethod.Get, $"coupons/{couponId}/", _revision,
                                                               query, null, null, cancellationToken);

    }
    /// <inheritdoc />
    public async Task<DataObject<Coupon>> UpdateCoupon(string couponId,
                                                       Coupon coupon,
                                                       CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<Coupon>>(new("PATCH"), $"coupons/{couponId}/", _revision,
                                                              null, null, new DataObject<Coupon>(coupon),
                                                              cancellationToken);
    }
    /// <inheritdoc />
    public async Task DeleteCoupon(string couponId, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP(HttpMethod.Delete, $"coupons/{couponId}/", _revision, null, null, null,
                                   cancellationToken);
    }
    ///<inheritdoc />
    public async Task<DataListObject<CouponCode>> GetCouponCodes(List<string> couponCodeFields = null,
                                                                 List<string> couponFields = null,
                                                                 IFilter filter = null,
                                                                 List<string> includedRecords = null,
                                                                 CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("coupon-code", couponCodeFields);
        query.AddFieldset("coupon", couponFields);
        query.AddIncludes(includedRecords);
        query.AddFilter(filter);
        return await _klaviyoService.HTTP<DataListObject<CouponCode>>(HttpMethod.Get, "coupon-codes/", _revision, query, null,
                                                                      null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<CouponCode>> CreateCouponCode(CouponCode couponcode,
                                                               CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<CouponCode>>(HttpMethod.Post, "coupon-codes/", _revision, null, null,
                                                                  new DataObject<CouponCode>(couponcode), cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<CouponCode>> CreateCouponCode(CouponCode couponcode,
                                                               DataObject<Coupon> coupon,
                                                               CancellationToken cancellationToken = default)
    {
        couponcode.Relationships = new()
        {
            Coupon = new DataObjectRelated<GenericObject>(new(coupon.Data.Type, coupon.Data.Id))
        };

        return await _klaviyoService.HTTP<DataObject<CouponCode>>(HttpMethod.Post, "coupon-codes/", _revision, null, null,
                                                                  new DataObject<CouponCode>(couponcode), cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<CouponCode>> CreateCouponCode(CouponCode couponcode,
                                                               Coupon coupon,
                                                               CancellationToken cancellationToken = default)
    {
        var remote = await CreateCoupon(coupon);
        couponcode.Relationships = new()
        {
            Coupon = new DataObjectRelated<GenericObject>(new(remote.Data.Type, remote.Data.Id))
        };

        return await _klaviyoService.HTTP<DataObject<CouponCode>>(HttpMethod.Post, "coupon-codes/", _revision, null, null,
                                                                  new DataObject<CouponCode>(couponcode), cancellationToken);
    }
    ///<inheritdoc />
    public async Task<DataObject<CouponCode>> GetCouponCode(string couponCodeId,
                                                            List<string> couponCodeFields = null,
                                                            List<string> couponFields = null,
                                                            List<string> includedRecords = null,
                                                            CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("coupon-code", couponCodeFields);
        query.AddFieldset("coupon", couponFields);
        query.AddIncludes(includedRecords);
        return await _klaviyoService.HTTP<DataObject<CouponCode>>(HttpMethod.Get, $"coupon-codes/{couponCodeId}/", _revision,
                                                              query, null, null, cancellationToken);

    }
    /// <inheritdoc />
    public async Task<DataObject<CouponCode>> UpdateCouponCode(string couponCodeId,
                                                               CouponCode couponCode,
                                                               CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<CouponCode>>(new("PATCH"), $"coupon-codes/{couponCodeId}/", _revision,
                                                                  null, null, new DataObject<CouponCode>(couponCode),
                                                                  cancellationToken);
    }
    /// <inheritdoc />
    public async Task DeleteCouponCode(string couponCodeId, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP(HttpMethod.Delete, $"coupon-codes/{couponCodeId}/", _revision, null, null, null,
                                   cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataListObject<CouponCodeBulkJob>> GetCouponCodeBulkCreateJobs(List<string> couponCodeBulkCreateJobFields = null,
                                                                                     IFilter filter = null,
                                                                                     CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("coupon-code-bulk-create-jobs", couponCodeBulkCreateJobFields);
        query.AddFilter(filter);
        return await _klaviyoService.HTTP<DataListObject<CouponCodeBulkJob>>(HttpMethod.Get, "coupon-code-bulk-create-jobs/",
                                                                             _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<CouponCodeBulkJob>> SpawnCouponCodeBulkCreateJob(List<CouponCodeBulkJob> couponCodeBulkJob, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<CouponCodeBulkJob>>(HttpMethod.Post, "coupon-code-bulk-create-jobs/", _revision, null, null,
                                                                         new DataListObject<CouponCodeBulkJob>(couponCodeBulkJob), cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<CouponCodeBulkJob>> GetCouponCodeBulkCreateJob(string jobId,
                                                                                List<string> couponCodeBulkCreateJobFields = null,
                                                                                List<string> couponFields = null,
                                                                                List<string> includedRecords = null,
                                                                                CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("coupon-code-bulk-create-jobs", couponCodeBulkCreateJobFields);
        query.AddFieldset("coupon-code", couponFields);
        query.AddIncludes(includedRecords);
        return await _klaviyoService.HTTP<DataObject<CouponCodeBulkJob>>(HttpMethod.Get, $"coupon-code-bulk-create-jobs/{jobId}",
                                                                         _revision, query, null, null, cancellationToken);
    }
    ///<inheritdoc />
    public async Task<DataListObject<Coupon>> GetCouponForCouponCode(string couponCodeId,
                                                                     List<string> couponFields = null,
                                                                     CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("coupon", couponFields);
        return await _klaviyoService.HTTP<DataListObject<Coupon>>(HttpMethod.Get, $"coupon-codes/{couponCodeId}/coupon/", _revision,
                                                              query, null, null, cancellationToken);

    }
    /// <inheritdoc />
    public async Task<DataListObject<GenericObject>> GetCouponRelationshipsCouponCodes(string couponCodeId, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataListObject<GenericObject>>(HttpMethod.Get, $"coupon-codes/{couponCodeId}/relationships/coupon/",
                                                                         _revision, null, null, null, cancellationToken);

    }
    /// <inheritdoc />
    public async Task<DataListObject<CouponCode>> GetCouponCodesForCoupon(string couponId,
                                                                          List<string> couponCodeFields = null,
                                                                          IFilter filter = null,
                                                                          CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("coupon-code", couponCodeFields);
        query.AddFilter(filter);
        return await _klaviyoService.HTTP<DataListObject<CouponCode>>(HttpMethod.Get, $"coupon/{couponId}/coupon-codes/",
                                                                      _revision, query, null, null, cancellationToken);

    }
    /// <inheritdoc />
    public async Task<DataListObject<GenericObject>> GetCouponCodeRelationshipsCoupon(string couponId,
                                                                               CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataListObject<GenericObject>>(HttpMethod.Get, $"coupon/{couponId}/relationships/coupon-codes/",
                                                                         _revision, null, null, null, cancellationToken);

    }
}
