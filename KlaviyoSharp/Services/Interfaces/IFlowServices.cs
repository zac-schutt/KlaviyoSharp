using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Models;
using KlaviyoSharp.Models.Filters;

namespace KlaviyoSharp.Services;
/// <summary>
/// Interface for Klaviyo Flow Services
/// </summary>
public interface IFlowServices
{
    /// <summary>
    /// Get all flows in an account.
    /// </summary>
    /// <param name="flowFields">For more information please visit https://developers.klaviyo.com/en/i-overview#sparse-fieldsets</param>
    /// <param name="flowActionFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="includedRecords">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#relationships</param>
    /// <param name="filter">For more information please visit <see href="https://developers.klaviyo.com/en/reference/api-overview#filtering" />. Allowed fields: id, name, status, archived, created, updated, trigger_type</param>
    /// <param name="sort">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sorting</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObjectWithIncluded<Flow>> GetFlows(List<string> flowFields, List<string> flowActionFields, List<string> includedRecords, IFilter filter, string sort, CancellationToken cancellationToken);
    /// <summary>
    /// Get a flow with the given flow ID. Include parameters can be provided to get the following related resource data: flow-actions
    /// </summary>
    /// <param name="flowId">Flow ID</param>
    /// <param name="flowFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="flowActionFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="includedRecords">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#relationships</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObjectWithIncluded<Flow>> GetFlow(string flowId, List<string> flowFields, List<string> flowActionFields, List<string> includedRecords, CancellationToken cancellationToken);
    /// <summary>
    /// Update the status of a flow with the given flow ID, and all actions in that flow.
    /// </summary>
    /// <param name="flowId">ID of the Flow to update. Ex: XVTP5Q</param>
    /// <param name="flow">Update Parameters</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<Flow>> UpdateFlowStatus(string flowId, Flow flow, CancellationToken cancellationToken);
    /// <summary>
    /// Get a flow action from a flow with the given flow action ID. Include parameters can be provided to get the following related resource data: flows, flow-messages
    /// </summary>
    /// <param name="flowActionId">Flow Action ID</param>
    /// <param name="flowActionFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="flowMessageFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="flowFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="includedRecords">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#relationships</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<FlowAction>> GetFlowAction(string flowActionId, List<string> flowActionFields, List<string> flowMessageFields, List<string> flowFields, List<string> includedRecords, CancellationToken cancellationToken);
    /// <summary>
    /// Get the flow message of a flow with the given message ID. Include parameters can be provided to get the following related resource data: 'flow-actions'
    /// </summary>
    /// <param name="flowMessageId">Flow Message ID</param>
    /// <param name="flowActionFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="flowMessageFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="includedRecords">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#relationships</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<FlowMessage>> GetFlowMessage(string flowMessageId, List<string> flowActionFields, List<string> flowMessageFields, List<string> includedRecords, CancellationToken cancellationToken);
    /// <summary>
    /// Get all flow actions associated with the given flow ID.
    /// </summary>
    /// <param name="flowId">Flow ID</param>
    /// <param name="flowActionFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="filter">For more information please visit <see href="https://developers.klaviyo.com/en/reference/api-overview#filtering" />. Allowed fields: id, action_type, status, created, updated</param>
    /// <param name="sort">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sorting</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<FlowAction>> GetFlowActionsForFlow(string flowId, List<string> flowActionFields, IFilter filter, string sort, CancellationToken cancellationToken);
    /// <summary>
    /// Return all tags associated with the given flow ID.
    /// </summary>
    /// <param name="flowId">Flow ID</param>
    /// <param name="tagFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<Tag>> GetFlowTags(string flowId, List<string> tagFields, CancellationToken cancellationToken);
    /// <summary>
    /// Get the flow associated with the given action ID.
    /// </summary>
    /// <param name="flowActionId">Flow Action ID</param>
    /// <param name="flowFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<Flow>> GetFlowForFlowAction(string flowActionId, List<string> flowFields, CancellationToken cancellationToken);
    /// <summary>
    /// Get all flow messages associated with the given flow action ID.
    /// </summary>
    /// <param name="flowActionId">Flow Action ID</param>
    /// <param name="flowMessageFields">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="filter">For more information please visit <see href="https://developers.klaviyo.com/en/reference/api-overview#filtering" />. Allowed fields: id, name, created, updated</param>
    /// <param name="sort">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sorting</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<FlowMessage>> GetMessagesForFlowAction(string flowActionId, List<string> flowMessageFields, IFilter filter, string sort, CancellationToken cancellationToken);
    /// <summary>
    /// Get all relationships for flow actions associated with the given flow ID.
    /// </summary>
    /// <param name="flowId">Flow ID</param>
    /// <param name="filter">For more information please visit <see href="https://developers.klaviyo.com/en/reference/api-overview#filtering" />. Allowed fields: action_type, status, created, updated</param>
    /// <param name="sort">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sorting</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<GenericObject>> GetFlowRelationshipsFlowActions(string flowId, IFilter filter, string sort, CancellationToken cancellationToken);
    /// <summary>
    /// Return the tag IDs of all tags associated with the given flow.
    /// </summary>
    /// <param name="flowId">Flow ID</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<GenericObject>> GetFlowRelationshipsTags(string flowId, CancellationToken cancellationToken);
    /// <summary>
    /// Get the flow associated with the given action ID.
    /// </summary>
    /// <param name="flowActionId">Flow Action ID</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<GenericObject>> GetFlowActionRelationshipsFlow(string flowActionId, CancellationToken cancellationToken);
    /// <summary>
    /// Get all relationships for flow messages associated with the given flow action ID.
    /// </summary>
    /// <param name="flowActionId">Flow Action ID</param>
    /// <param name="filter">For more information please visit <see href="https://developers.klaviyo.com/en/reference/api-overview#filtering" />. Allowed fields: name, created, updated</param>
    /// <param name="sort">For more information please visit https://developers.klaviyo.com/en/reference/api-overview#sorting</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<GenericObject>> GetFlowActionRelationshipsMessages(string flowActionId, IFilter filter, string sort, CancellationToken cancellationToken);
    /// <summary>
    /// Get the relationship for a flow message's flow action, given the flow ID.
    /// </summary>
    /// <param name="flowMessageId">Flow Message ID</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<GenericObject>> GetFlowMessageRelationshipAction(string flowMessageId, CancellationToken cancellationToken);
}