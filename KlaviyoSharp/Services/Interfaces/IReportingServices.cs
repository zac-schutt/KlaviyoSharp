using System.Net;
using System;
using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Models;
using KlaviyoSharp.Models.Filters;

namespace KlaviyoSharp.Services;

/// <summary>
/// Interface for Klaviyo Reporting Services
/// </summary>
public interface IReportingServices
{
    /// <summary>
    /// Returns the requested campaign analytics values data.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObjectWithNavigate<Reporting>> QueryCampaignValues(ReportingRequest request, CancellationToken cancellationToken = default);
    /// <summary>
    /// Returns the requested flow analytics values data.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObjectWithNavigate<Reporting>> QueryFlowValues(ReportingRequest request, CancellationToken cancellationToken = default);
    /// <summary>
    /// Returns the requested flow analytics series data.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObjectWithNavigate<Reporting>> QueryFlowSeries(ReportingRequest request, CancellationToken cancellationToken = default);
}