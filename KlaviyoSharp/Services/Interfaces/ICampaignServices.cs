using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Models;
using KlaviyoSharp.Models.Filters;

namespace KlaviyoSharp.Services;
/// <summary>
/// Interface for Klaviyo Campaign Services
/// </summary>
public interface ICampaignServices
{
    /// <summary>
    /// Returns some or all campaigns based on [optional] filters
    /// </summary>
    /// <param name="campaignFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="tagFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="filter">For more information please visit <see href="https://developers.klaviyo.com/en/reference/api-overview#filtering" />. Allowed fields: name, status, archived, created_at, scheduled_at, updated_at</param>
    /// <param name="includedRecords">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#relationships</param>
    /// <param name="sort">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sorting</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObjectWithIncluded<Campaign>> GetCampaigns(List<string> campaignFields, List<string> tagFields, IFilter filter, List<string> includedRecords, string sort, CancellationToken cancellationToken);
    /// <summary>
    /// Creates a campaign given a set of parameters, then returns it.
    /// </summary>
    /// <param name="campaign">Creates a campaign from parameters</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<Campaign>> CreateCampaign(Campaign campaign, CancellationToken cancellationToken);
    /// <summary>
    /// Returns a specific campaign based on a required id.
    /// </summary>
    /// <param name="campaignId">The campaign ID to be retrieved</param>
    /// <param name="campaignFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="tagFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="includedRecords">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#relationships</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<Campaign>> GetCampaign(string campaignId, List<string> campaignFields, List<string> tagFields, List<string> includedRecords, CancellationToken cancellationToken);
    /// <summary>
    /// Delete a campaign with the given campaign ID.
    /// </summary>
    /// <param name="campaignId">The campaign ID to be deleted</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeleteCampaign(string campaignId, CancellationToken cancellationToken);
    /// <summary>
    /// Get the estimated recipient count for a campaign with the provided campaign ID. You can refresh this count by using the Create Campaign Recipient Estimation Job endpoint.
    /// </summary>
    /// <param name="campaignId">The ID of the campaign for which to get the estimated number of recipients</param>
    /// <param name="campaignRecipientEstimationFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<CampaignRecipientEstimation>> GetCampaignRecipientEstimation(string campaignId, List<string> campaignRecipientEstimationFields, CancellationToken cancellationToken);
    /// <summary>
    /// Clones an existing campaign, returning a new campaign based on the original with a new ID and name.
    /// </summary>
    /// <param name="campaign">Clones a campaign from an existing campaign</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<Campaign>> CreateCampaignClone(CampaignClone campaign, CancellationToken cancellationToken);
    /// <summary>
    /// Return all tags that belong to the given campaign.
    /// </summary>
    /// <param name="campaignId"></param>
    /// <param name="tagFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<Tag>> GetCampaignTags(string campaignId, List<string> tagFields, CancellationToken cancellationToken);
    /// <summary>
    /// Returns a specific message based on a required id.
    /// </summary>
    /// <param name="campaignMessageId">The message ID to be retrieved</param>
    /// <param name="campaignMessageFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<CampaignMessage>> GetCampaignMessage(string campaignMessageId, List<string> campaignMessageFields, CancellationToken cancellationToken);
    /// <summary>
    /// Update a campaign message
    /// </summary>
    /// <param name="campaignMessageId">The message ID to be retrieved</param>
    /// <param name="campaignMessage">Update a message and return it</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<CampaignMessage>> UpdateCampaignMessage(string campaignMessageId, CampaignMessage campaignMessage, CancellationToken cancellationToken);
    /// <summary>
    /// Get a campaign send job
    /// </summary>
    /// <param name="campaignSendJobId">The ID of the campaign to send</param>
    /// <param name="campaignSendJobFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<CampaignSendJob>> GetCampaignSendJob(string campaignSendJobId, List<string> campaignSendJobFields, CancellationToken cancellationToken);
    /// <summary>
    /// Permanently cancel the campaign, setting the status to CANCELED or revert the campaign, setting the status back to DRAFT
    /// </summary>
    /// <param name="campaignSendJobId">The ID of the currently sending campaign to cancel or revert</param>
    /// <param name="campaignSendJob">Permanently cancel the campaign, setting the status to CANCELED or revert the campaign, setting the status back to DRAFT</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task UpdateCampaignSendJob(string campaignSendJobId, CampaignSendJob campaignSendJob, CancellationToken cancellationToken);
    /// <summary>
    /// Retrieve the status of a recipient estimation job triggered with the Create Campaign Recipient Estimation Job endpoint.
    /// </summary>
    /// <param name="campaignRecipientEstimationJobId">The ID of the campaign to get recipient estimation status</param>
    /// <param name="campaignRecipientEstimationJobFields">For more information please visit https://developers.klaviyo.com/en/v2023-06-15/reference/api-overview#sparse-fieldsets</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<CampaignRecipientEstimationJob>> GetCampaignRecipientEstimationJob(string campaignRecipientEstimationJobId, List<string> campaignRecipientEstimationJobFields, CancellationToken cancellationToken);
    /// <summary>
    /// Trigger a campaign to send asynchronously
    /// </summary>
    /// <param name="campaignSendJob">Trigger the campaign to send asynchronously</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<CampaignSendJob>> CreateCampaignSendJob(CampaignSendJob campaignSendJob, CancellationToken cancellationToken);
    /// <summary>
    /// Trigger an asynchronous job to update the estimated number of recipients for the given campaign ID. Use the Get Campaign Recipient Estimation Job endpoint to retrieve the status of this estimation job. Use the Get Campaign Recipient Estimation endpoint to retrieve the estimated recipient count for a given campaign.
    /// </summary>
    /// <param name="campaignRecipientEstimationJob">Trigger an asynchronous job to update the estimated number of recipients for the given campaign ID. Use the Get Campaign Recipient Estimation Job endpoint to retrieve the status of this estimation job. Use the Get Campaign Recipient Estimation endpoint to retrieve the estimated recipient count for a given campaign.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<CampaignRecipientEstimationJob>> CreateCampaignRecipientEstimationJob(CampaignRecipientEstimationJob campaignRecipientEstimationJob, CancellationToken cancellationToken = default);
    /// <summary>
    /// Returns the IDs of all tags associated with the given campaign.
    /// </summary>
    /// <param name="campaignId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<GenericObject>> GetCampaignRelationshipsTags(string campaignId, CancellationToken cancellationToken);
}