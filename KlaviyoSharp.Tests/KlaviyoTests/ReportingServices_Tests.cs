using KlaviyoSharp.Models;
using KlaviyoSharp.Models.Filters;

namespace KlaviyoSharp.Tests;

[Trait("Category", "ReportingServices")]
public class ReportingServices_Tests : IClassFixture<ReportingServices_Tests_Fixture>
{
    private ReportingServices_Tests_Fixture Fixture { get; }
    public ReportingServices_Tests(ReportingServices_Tests_Fixture fixture)
    {
        Fixture = fixture;
    }

    [Fact]
    public async Task QueryCampaignValues()
    {
        var metricList = await Fixture.AdminApi.MetricServices.GetMetrics();
        var metric = metricList.Data.First(x => x.Attributes.Name == "Received Email");

        ReportingRequest output = ReportingRequest.CreateCampaignValuesReport();
        output.Attributes = new()
        {
            Statistics = ["opens", "open_rate"],
            ConversionMetricId = metric.Id,
            Timeframe = new()
            {
                Key = "last_12_months",
            }
        };

        var result = await Fixture.AdminApi.ReportingServices.QueryCampaignValues(output);
        Assert.NotNull(result.Data);
    }

    [Fact]
    public async Task QueryFlowValues()
    {
        var metricList = await Fixture.AdminApi.MetricServices.GetMetrics();
        var metric = metricList.Data.First(x => x.Attributes.Name == "Received Email");

        ReportingRequest output = ReportingRequest.CreateFlowValuesReport();
        output.Attributes = new()
        {
            Statistics = ["opens", "open_rate"],
            ConversionMetricId = metric.Id,
            Timeframe = new()
            {
                Key = "last_12_months",
            }
        };

        var result = await Fixture.AdminApi.ReportingServices.QueryFlowValues(output);
        Assert.NotNull(result.Data);
    }

    [Fact]
    public async Task QueryFlowSeries()
    {
        var metricList = await Fixture.AdminApi.MetricServices.GetMetrics();
        var metric = metricList.Data.First(x => x.Attributes.Name == "Received Email");

        ReportingRequest output = ReportingRequest.CreateFlowSeriesReport();
        output.Attributes = new()
        {
            Statistics = ["opens", "open_rate"],
            ConversionMetricId = metric.Id,
            Interval = "monthly",
            Timeframe = new()
            {
                Key = "last_12_months",
            }
        };

        var result = await Fixture.AdminApi.ReportingServices.QueryFlowSeries(output);
        Assert.NotNull(result.Data);
    }
}

public class ReportingServices_Tests_Fixture : IAsyncLifetime
{
    public KlaviyoAdminApi AdminApi { get; } = new(Config.ApiKey);
    public readonly int SleepTime = 10 * 1000; //10 Seconds
    public readonly int Retries = 3;
    public ReportingRequest NewCampaignValuesReport
    {
        get
        {
            ReportingRequest output = ReportingRequest.CreateCampaignValuesReport();
            output.Attributes = new()
            {
                Statistics = ["opens", "open_rate"],
                Filter = new FilterList() {
                    //new Filter(FilterOperation.Equals, "campaign.id", "abc22"),
                    //new Filter(FilterOperation.Contains, "send_channel", ["email", "sms"])
                },
                Timeframe = new()
                {
                    Key = "last_12_months",
                }
            };
            return output;
        }
    }

    public ReportingRequest NewFlowValuesReport
    {
        get
        {
            ReportingRequest output = ReportingRequest.CreateFlowValuesReport();
            output.Attributes = new()
            {
                Filter = new FilterList()
                {
                    //new Filter(FilterOperation.Equals, "campaign.id", "abc22"),
                    //new Filter(FilterOperation.Contains, "send_channel", ["email", "sms"])
                },
                Timeframe = new()
                {
                    Key = "last_12_months",
                }
            };
            return output;
        }
    }

    public ReportingRequest NewFlowSeriesReport
    {
        get
        {
            ReportingRequest output = ReportingRequest.CreateFlowSeriesReport();
            output.Attributes = new()
            {
                Filter = new FilterList()
                {
                    //new Filter(FilterOperation.Equals, "campaign.id", "abc22"),
                    //new Filter(FilterOperation.Contains, "send_channel", ["email", "sms"])
                },
                Timeframe = new()
                {
                    Key = "last_12_months",
                },
                Interval = "weekly"
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