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

    public async Task<DataListObject<Flow>> GetFlows(List<string> flowFields = null, List<string> flowActionFields = null, List<string> includedRecords = null, IFilter filter = null, string sort = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("flow", flowFields);
        query.AddFieldset("flow-action", flowActionFields);
        query.AddIncludes(includedRecords);
        query.AddFilters(filter);
        query.AddSort(sort);

        throw new NotImplementedException();

    }

    public async Task<DataObject<Flow>> GetFlow(string flowId, List<string> flowFields = null, List<string> flowActionFields = null, List<string> includedRecords = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("flow", flowFields);
        query.AddFieldset("flow-action", flowActionFields);
        query.AddIncludes(includedRecords);

        throw new NotImplementedException();
    }

    public async Task<DataObject<Flow>> UpdateFlowStatus(string flowId, Flow flow, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
    public async Task<DataObject<FlowAction>> GetFlowAction(string flowActionId, List<string> flowActionFields = null, List<string> flowMessageFields = null, List<string> flowFields = null, List<string> includedRecords = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("flow-action", flowActionFields);
        query.AddFieldset("flow-message", flowMessageFields);
        query.AddFieldset("flow", flowFields);
        query.AddIncludes(includedRecords);

        throw new NotImplementedException();
    }

    public async Task<DataObject<FlowMessage>> GetFlowMessage(string flowMessageId, List<string> flowActionFields = null, List<string> flowMessageFields = null, List<string> includedRecords = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("flow-action", flowActionFields);
        query.AddFieldset("flow-message", flowMessageFields);
        query.AddIncludes(includedRecords);

        throw new NotImplementedException();
    }

    public async Task<DataListObject<FlowAction>> GetFlowActionsForFlow(string flowId, List<string> flowActionFields = null, IFilter filter = null, string sort = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("flow-action", flowActionFields);
        query.AddFilters(filter);
        query.AddSort(sort);

        throw new NotImplementedException();
    }

    public async Task<DataListObject<Tag>> GetFlowTags(string flowId, List<string> tagFields = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("tag", tagFields);

        throw new NotImplementedException();
    }

    public async Task<DataListObject<Flow>> GetFlowsForFlowAction(string flowActionId, List<string> flowFields = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("flow", flowFields);

        throw new NotImplementedException();
    }

    public async Task<DataListObject<FlowMessage>> GetMessagesForFlowAction(string flowActionId, List<string> flowMessageFields = null, IFilter filter = null, string sort = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("flow-message", flowMessageFields);
        query.AddFilters(filter);
        query.AddSort(sort);

        throw new NotImplementedException();
    }

    public async Task<DataListObject<FlowAction>> GetFlowActionForMessage(string flowMessageId, List<string> flowActionFields = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("flow-action", flowActionFields);

        throw new NotImplementedException();
    }

    public async Task<DataListObject<GenericObject>> GetFlowRelationshipsFlowActions(string flowId, IFilter filter = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFilters(filter);

        throw new NotImplementedException();
    }
    public async Task<DataListObject<GenericObject>> GetFlowRelationshipsTags(string flowId, CancellationToken cancellationToken = default)
    {

        throw new NotImplementedException();
    }
    public async Task<DataListObject<GenericObject>> GetFlowActionRelationshipsFlow(string flowActionId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<DataListObject<GenericObject>> GetFlowActionRelationshipsMessages(string flowActionId, IFilter filter = null, string sort = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFilters(filter);
        query.AddSort(sort);

        throw new NotImplementedException();
    }

    public async Task<DataListObject<GenericObject>> GetFlowMessageRelationshipAction(string flowMessageId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
