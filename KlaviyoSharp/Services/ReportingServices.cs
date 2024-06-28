using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Infrastructure;
using KlaviyoSharp.Models;
using KlaviyoSharp.Models.Filters;

namespace KlaviyoSharp.Services;

/// <summary>
/// Klaviyo Reporting Services
/// </summary>
public class ReportingServices : KlaviyoServiceBase, IReportingServices
{
    /// <summary>
    /// Constructor for Klaviyo Image Services
    /// </summary>
    /// <param name="revision"></param>
    /// <param name="klaviyoService"></param>
    public ReportingServices(string revision, KlaviyoApiBase klaviyoService) : base(revision, klaviyoService) { }
    /// <inheritdoc />
    public async Task<DataObjectWithNavigate<Reporting>> QueryCampaignValues(ReportingRequest request,
                                                                 CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObjectWithNavigate<Reporting>>(HttpMethod.Post, "campaign-values-reports/", _revision, null, null,
                                                                 new DataObject<ReportingRequest>(request), cancellationToken);
    }
    ///<inheritdoc />
    public async Task<DataObjectWithNavigate<Reporting>> QueryFlowValues(ReportingRequest request,
                                                             CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObjectWithNavigate<Reporting>>(HttpMethod.Post, "flow-values-reports/", _revision, null, null,
                                                                 new DataObject<ReportingRequest>(request), cancellationToken);
    }
    ///<inheritdoc />
    public async Task<DataObjectWithNavigate<Reporting>> QueryFlowSeries(ReportingRequest request,
                                                             CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObjectWithNavigate<Reporting>>(HttpMethod.Post, "flow-series-reports/", _revision, null, null,
                                                                 new DataObject<ReportingRequest>(request), cancellationToken);
    }
}
