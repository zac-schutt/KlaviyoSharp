using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Infrastructure;
using KlaviyoSharp.Models;
using KlaviyoSharp.Models.Filters;

namespace KlaviyoSharp.Services;
/// <summary>
/// Flow Services
/// </summary>
public class FlowServices : KlaviyoServiceBase, IFlowServices
{
    //TODO: Implement and document

    /// <summary>
    /// Constructor for Flow Services
    /// </summary>
    /// <param name="klaviyoService"></param>
    public FlowServices(KlaviyoApiBase klaviyoService) : base("2023-06-15", klaviyoService) { }

    /// <inheritdoc />
    public async Task<DataListObjectWithIncluded<Flow>> GetFlows(List<string> flowFields = null, List<string> flowActionFields = null, List<string> includedRecords = null, IFilter filter = null, string sort = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("flow", flowFields);
        query.AddFieldset("flow-action", flowActionFields);
        query.AddIncludes(includedRecords);
        query.AddFilter(filter);
        query.AddSort(sort);
        return await _klaviyoService.HTTPRecursiveWithIncluded<Flow>(HttpMethod.Get, "flows", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObjectWithIncluded<Flow>> GetFlow(string flowId, List<string> flowFields = null, List<string> flowActionFields = null, List<string> includedRecords = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("flow", flowFields);
        query.AddFieldset("flow-action", flowActionFields);
        query.AddIncludes(includedRecords);
        return await _klaviyoService.HTTP<DataObjectWithIncluded<Flow>>(HttpMethod.Get, $"flows/{flowId}", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<Flow>> UpdateFlowStatus(string flowId, Flow flow, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<Flow>>(new("PATCH"), $"flows/{flowId}", _revision, null, null, new DataObject<Flow>(flow), cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<FlowAction>> GetFlowAction(string flowActionId, List<string> flowActionFields = null, List<string> flowMessageFields = null, List<string> flowFields = null, List<string> includedRecords = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("flow-action", flowActionFields);
        query.AddFieldset("flow-message", flowMessageFields);
        query.AddFieldset("flow", flowFields);
        query.AddIncludes(includedRecords);
        return await _klaviyoService.HTTP<DataObject<FlowAction>>(HttpMethod.Get, $"flow-actions/{flowActionId}", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<FlowMessage>> GetFlowMessage(string flowMessageId, List<string> flowActionFields = null, List<string> flowMessageFields = null, List<string> includedRecords = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("flow-action", flowActionFields);
        query.AddFieldset("flow-message", flowMessageFields);
        query.AddIncludes(includedRecords);
        return await _klaviyoService.HTTP<DataObject<FlowMessage>>(HttpMethod.Get, $"flow-messages/{flowMessageId}", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataListObject<FlowAction>> GetFlowActionsForFlow(string flowId, List<string> flowActionFields = null, IFilter filter = null, string sort = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("flow-action", flowActionFields);
        query.AddFilter(filter);
        query.AddSort(sort);
        return await _klaviyoService.HTTPRecursive<FlowAction>(HttpMethod.Get, $"flows/{flowId}/flow-actions", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataListObject<Tag>> GetFlowTags(string flowId, List<string> tagFields = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("tag", tagFields);
        return await _klaviyoService.HTTP<DataListObject<Tag>>(HttpMethod.Get, $"flows/{flowId}/tags", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<Flow>> GetFlowForFlowAction(string flowActionId, List<string> flowFields = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("flow", flowFields);
        return await _klaviyoService.HTTP<DataObject<Flow>>(HttpMethod.Get, $"flow-actions/{flowActionId}/flow/", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataListObject<FlowMessage>> GetMessagesForFlowAction(string flowActionId, List<string> flowMessageFields = null, IFilter filter = null, string sort = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("flow-message", flowMessageFields);
        query.AddFilter(filter);
        query.AddSort(sort);
        return await _klaviyoService.HTTPRecursive<FlowMessage>(HttpMethod.Get, $"flow-actions/{flowActionId}/flow-messages", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<FlowAction>> GetFlowActionForMessage(string flowMessageId, List<string> flowActionFields = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("flow-action", flowActionFields);
        return await _klaviyoService.HTTP<DataObject<FlowAction>>(HttpMethod.Get, $"flow-messages/{flowMessageId}/flow-action/", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataListObject<GenericObject>> GetFlowRelationshipsFlowActions(string flowId, IFilter filter = null, string sort = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFilter(filter);
        query.AddSort(sort);
        return await _klaviyoService.HTTP<DataListObject<GenericObject>>(HttpMethod.Get, $"flows/{flowId}/relationships/flow-actions", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataListObject<GenericObject>> GetFlowRelationshipsTags(string flowId, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataListObject<GenericObject>>(HttpMethod.Get, $"flows/{flowId}/relationships/tags", _revision, null, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataListObject<GenericObject>> GetFlowActionRelationshipsFlow(string flowActionId, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataListObject<GenericObject>>(HttpMethod.Get, $"flow-actions/{flowActionId}/relationships/flow", _revision, null, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataListObject<GenericObject>> GetFlowActionRelationshipsMessages(string flowActionId, IFilter filter = null, string sort = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFilter(filter);
        query.AddSort(sort);
        return await _klaviyoService.HTTPRecursive<GenericObject>(HttpMethod.Get, $"flow-actions/{flowActionId}/relationships/flow-messages", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataListObject<GenericObject>> GetFlowMessageRelationshipAction(string flowMessageId, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataListObject<GenericObject>>(HttpMethod.Get, $"flow-messages/{flowMessageId}/relationships/flow-action", _revision, null, null, null, cancellationToken);
    }
}
