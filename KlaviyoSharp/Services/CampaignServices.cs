using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Infrastructure;
using KlaviyoSharp.Models;
using KlaviyoSharp.Models.Filters;

namespace KlaviyoSharp.Services;
/// <summary>
/// Klaviyo Campaign Services
/// </summary>
public class CampaignServices : KlaviyoServiceBase, ICampaignServices
{
    /// <summary>
    /// Constructor for Klaviyo Campaign Services
    /// </summary>
    /// <param name="revision"></param>
    /// <param name="klaviyoService"></param>
    public CampaignServices(string revision, KlaviyoApiBase klaviyoService) : base(revision, klaviyoService) { }
    /// <inheritdoc />
    public async Task<DataListObjectWithIncluded<Campaign>> GetCampaigns(IFilter filter, List<string> campaignFields = null, List<string> tagFields = null, List<string> includedRecords = null, string sort = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("campaign", campaignFields);
        query.AddFieldset("tag", tagFields);
        query.AddFilter(filter);
        query.AddIncludes(includedRecords);
        query.AddSort(sort);
        return await _klaviyoService.HTTP<DataListObjectWithIncluded<Campaign>>(HttpMethod.Get, "campaigns/", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<Campaign>> CreateCampaign(Campaign campaign, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<Campaign>>(HttpMethod.Post, "campaigns/", _revision, null, null, new DataObject<Campaign>(campaign), cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<Campaign>> GetCampaign(string campaignId, List<string> campaignFields = null, List<string> tagFields = null, List<string> includedRecords = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("campaign", campaignFields);
        query.AddFieldset("tag", tagFields);
        query.AddIncludes(includedRecords);
        return await _klaviyoService.HTTP<DataObject<Campaign>>(HttpMethod.Get, $"campaigns/{campaignId}/", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<Campaign>> UpdateCampaign(string campaignId, Campaign campaign, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<Campaign>>(new("PATCH"), $"campaigns/{campaignId}/", _revision, null, null, new DataObject<Campaign>(campaign), cancellationToken);
    }
    /// <inheritdoc />
    public async Task DeleteCampaign(string campaignId, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP(HttpMethod.Delete, $"campaigns/{campaignId}/", _revision, null, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<CampaignRecipientEstimation>> GetCampaignRecipientEstimation(string campaignId, List<string> campaignRecipientEstimationFields = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("campaign-recipient-estimation", campaignRecipientEstimationFields);
        return await _klaviyoService.HTTP<DataObject<CampaignRecipientEstimation>>(HttpMethod.Get, $"campaign-recipient-estimation/{campaignId}/", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<Campaign>> CreateCampaignClone(CampaignClone campaign, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<Campaign>>(HttpMethod.Post, "campaign-clone/", _revision, null, null, new DataObject<CampaignClone>(campaign), cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataListObject<Tag>> GetCampaignTags(string campaignId, List<string> tagFields = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("tag", tagFields);
        return await _klaviyoService.HTTP<DataListObject<Tag>>(HttpMethod.Get, $"campaigns/{campaignId}/tags/", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<CampaignMessage>> GetCampaignMessage(string campaignMessageId, List<string> campaignMessageFields = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("campaign-message", campaignMessageFields);
        return await _klaviyoService.HTTP<DataObject<CampaignMessage>>(HttpMethod.Get, $"campaign-messages/{campaignMessageId}/", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<CampaignMessage>> UpdateCampaignMessage(string campaignMessageId, CampaignMessage campaignMessage, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<CampaignMessage>>(new("PATCH"), $"campaign-messages/{campaignMessageId}/", _revision, null, null, new DataObject<CampaignMessage>(campaignMessage), cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<CampaignMessage>> AssignCampaignMessageTemplate(CampaignMessage campaignMessage, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<CampaignMessage>>(HttpMethod.Post, "campaign-message-assign-template/", _revision, null, null, new DataObject<CampaignMessage>(campaignMessage), cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<CampaignSendJob>> GetCampaignSendJob(string campaignSendJobId, List<string> campaignSendJobFields = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("campaign-send-job", campaignSendJobFields);
        return await _klaviyoService.HTTP<DataObject<CampaignSendJob>>(HttpMethod.Get, $"campaign-send-jobs/{campaignSendJobId}/", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task UpdateCampaignSendJob(string campaignSendJobId, CampaignSendJob campaignSendJob, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP(new("PATCH"), $"campaign-send-jobs/{campaignSendJobId}/", _revision, null, null, new DataObject<CampaignSendJob>(campaignSendJob), cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<CampaignRecipientEstimationJob>> GetCampaignRecipientEstimationJob(string campaignRecipientEstimationJobId, List<string> campaignRecipientEstimationJobFields = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("campaign-recipient-estimation-job", campaignRecipientEstimationJobFields);
        return await _klaviyoService.HTTP<DataObject<CampaignRecipientEstimationJob>>(HttpMethod.Get, $"campaign-recipient-estimation-jobs/{campaignRecipientEstimationJobId}/", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<CampaignSendJob>> CreateCampaignSendJob(CampaignSendJob campaignSendJob, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<CampaignSendJob>>(HttpMethod.Post, "campaign-send-jobs/", _revision, null, null, new DataObject<CampaignSendJob>(campaignSendJob), cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<CampaignRecipientEstimationJob>> CreateCampaignRecipientEstimationJob(CampaignRecipientEstimationJob campaignRecipientEstimationJob, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<CampaignRecipientEstimationJob>>(HttpMethod.Post, "campaign-recipient-estimation-jobs/", _revision, null, null, new DataObject<CampaignRecipientEstimationJob>(campaignRecipientEstimationJob), cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataListObject<GenericObject>> GetCampaignRelationshipsTags(string campaignId, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataListObject<GenericObject>>(HttpMethod.Get, $"campaigns/{campaignId}/relationships/tags/", _revision, null, null, null, cancellationToken);
    }
}
