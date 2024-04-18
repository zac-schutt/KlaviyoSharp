using KlaviyoSharp.Models;
using KlaviyoSharp.Models.Filters;

namespace KlaviyoSharp.Tests;

[Trait("Category", "CouponServices")]
public class CouponServices_Tests : IClassFixture<CouponServices_Tests_Fixture>
{
    private CouponServices_Tests_Fixture Fixture { get; }
    public CouponServices_Tests(CouponServices_Tests_Fixture fixture)
    {
        Fixture = fixture;
    }

    [Fact]
    public async Task GetCoupons()
    {
        var result = await Fixture.AdminApi.CouponServices.GetCoupons();
        Assert.NotEmpty(result.Data);
        var res = await Fixture.AdminApi.CouponServices.GetCoupon(result.Data[0].Id);
        Assert.Equal(result.Data[0].Id, res.Data.Id);

    }
    [Fact]
    public async Task CreateAndUpdateCoupon()
    {
        var result = await Fixture.AdminApi.CouponServices.CreateCoupon(Fixture.NewCoupon);
        Assert.NotNull(result);
        string NewDescription = $"{Config.Random}OFF";
        var update = Coupon.Create();
        update.Attributes = new() { Description = NewDescription };
        update.Id = result.Data.Id;
        var updated = await Fixture.AdminApi.CouponServices.UpdateCoupon(result.Data.Id, update);
        Assert.Equal(NewDescription, updated.Data.Attributes.Description);
    }

    [Fact]
    public async Task GetCouponCodes()
    {
        var couponData = Fixture.NewCoupon;
        var coupon = await Fixture.AdminApi.CouponServices.CreateCoupon(couponData);
        Assert.Equal(couponData.Attributes.ExternalId, coupon.Data.Attributes.ExternalId);

        var couponCodeData = Fixture.NewCouponCode;
        var remote = await Fixture.AdminApi.CouponServices.CreateCouponCode(couponCodeData, coupon);

        var filter = new Filter(FilterOperation.Equals, "coupon.id", coupon.Data.Id);

        var result = await Fixture.AdminApi.CouponServices.GetCouponCodes(filter: filter);
        Assert.NotEmpty(result.Data);
        var res = await Fixture.AdminApi.CouponServices.GetCouponCode(result.Data[0].Id);
        Assert.Equal(result.Data[0].Id, res.Data.Id);
        Assert.Equal(result.Data[0].Id, remote.Data.Id);
    }

    [Fact]
    public async Task CreateAndUpdateCouponCode()
    {
        var coupon = await Fixture.AdminApi.CouponServices.CreateCoupon(Fixture.NewCoupon);
        CouponCode output = Fixture.NewCouponCode;
        output.Relationships = new()
        {
            Coupon = new DataObjectRelated<GenericObject>(new(coupon.Data.Type, coupon.Data.Id))
        };

        var result = await Fixture.AdminApi.CouponServices.CreateCouponCode(output);
        Assert.NotNull(result);
        DateTime NewExpiresAt = DateTime.Now.Date.AddDays(100);
        var update = CouponCode.Create();
        update.Attributes = new() {
            ExpiresAt = NewExpiresAt,
        };
        update.Id = result.Data.Id;
        var updated = await Fixture.AdminApi.CouponServices.UpdateCouponCode(result.Data.Id, update);
        Assert.Equal(NewExpiresAt, updated.Data.Attributes.ExpiresAt);
    }

}

public class CouponServices_Tests_Fixture : IAsyncLifetime
{
    public KlaviyoAdminApi AdminApi { get; } = new(Config.ApiKey);
    public readonly int SleepTime = 10 * 1000; //10 Seconds
    public readonly int Retries = 3;
    public Coupon NewCoupon
    {
        get
        {
            Coupon output = Coupon.Create();
            output.Attributes = new()
            {
                ExternalId = $"test{Config.Random}",
                Description = $"Test {Config.Random}",
            };
            return output;
        }
    }

    public CouponCode NewCouponCode
    {
        get
        {
            //Coupon coupon = NewCoupon;
            CouponCode output = CouponCode.Create();
            output.Attributes = new()
            {
                UniqueCode = $"test{Config.Random}",
            };

            return output;
        }
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }
    public Task InitializeAsync()
    {
        return Task.CompletedTask;
    }
}