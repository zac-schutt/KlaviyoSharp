using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Infrastructure;
using KlaviyoSharp.Models;
using KlaviyoSharp.Models.Filters;

namespace KlaviyoSharp.Services;
/// <summary>
/// Klaviyo Event Services
/// </summary>
public class EventServices : KlaviyoServiceBase, IEventServices
{
    /// <summary>
    /// Constructor for Klaviyo Event Services
    /// </summary>
    /// <param name="revision"></param>
    /// <param name="klaviyoService"></param>
    public EventServices(string revision, KlaviyoApiBase klaviyoService) : base(revision, klaviyoService) { }
    /// <inheritdoc />
    public async Task<DataListObjectWithIncluded<Event>> GetEvents(List<string> eventFields = null, List<string> metricFields = null, List<string> profileFields = null, IFilter filter = null, List<string> includedObjects = null, string sort = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("event", eventFields);
        query.AddFieldset("metric", metricFields);
        query.AddFieldset("profile", profileFields);
        query.AddFilter(filter);
        query.AddSort(sort);
        query.AddIncludes(includedObjects);
        return await _klaviyoService.HTTPRecursiveWithIncluded<Event>(HttpMethod.Get, $"events/", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task CreateEvent(EventRequest eventObject, CancellationToken cancellationToken = default)
    {
        await _klaviyoService.HTTP<Event>(HttpMethod.Post, $"events/", _revision, null, null, new DataObject<EventRequest>(eventObject), cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObjectWithIncluded<Event>> GetEvent(string id, List<string> eventFields = null, List<string> metricFields = null, List<string> profileFields = null, List<string> includedObjects = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("event", eventFields);
        query.AddFieldset("metric", metricFields);
        query.AddFieldset("profile", profileFields);
        query.AddIncludes(includedObjects);
        return await _klaviyoService.HTTP<DataObjectWithIncluded<Event>>(HttpMethod.Get, $"events/{id}/", _revision, query, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<Metric>> GetEventMetric(string id, List<string> metricFields = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("metric", metricFields);
        return await _klaviyoService.HTTP<DataObject<Metric>>(HttpMethod.Get, $"events/{id}/metric/", _revision, query, null, null, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<DataObject<Profile>> GetEventProfile(string id, List<string> profileFields = null, List<string> additionalProfileFields = null, CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("profile", profileFields);
        query.AddAdditionalFields("profile", additionalProfileFields);
        return await _klaviyoService.HTTP<DataObject<Profile>>(HttpMethod.Get, $"events/{id}/profile/", _revision, query, null, null, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<DataObject<GenericObject>> GetEventRelationshipsMetric(string id, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<GenericObject>>(HttpMethod.Get, $"events/{id}/relationships/metric/", _revision, null, null, null, cancellationToken);
    }
    /// <inheritdoc />
    public async Task<DataObject<GenericObject>> GetEventRelationshipsProfile(string id, CancellationToken cancellationToken = default)
    {
        return await _klaviyoService.HTTP<DataObject<GenericObject>>(HttpMethod.Get, $"events/{id}/relationships/profile/", _revision, null, null, null, cancellationToken);
    }
}
