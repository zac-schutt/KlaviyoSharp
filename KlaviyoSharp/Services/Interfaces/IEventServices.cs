using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Models;
using KlaviyoSharp.Models.Filters;

namespace KlaviyoSharp.Services;

internal interface IEventServices
{
    /// <summary>
    ///Get all events in an account
    /// Requests can be sorted by the following fields: datetime, timestamp
    /// Include parameters can be provided to get the following related resource data: metrics, profiles
    /// </summary>
    /// <param name="eventFields">For more information please visit
    /// https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="metricFields">For more information please visit
    /// https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="profileFields">For more information please visit
    /// https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="filter">For more information please visit
    /// <see href="https://developers.klaviyo.com/en/reference/api-overview#filtering" />
    /// Allowed field(s): metric_id, profile_id, datetime, timestamp</param>
    /// <param name="includedObjects">For more information please visit
    /// https://developers.klaviyo.com/en/reference/api-overview#relationships</param>
    /// <param name="sort">For more information please visit
    /// https://developers.klaviyo.com/en/reference/api-overview#sorting</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObjectWithIncluded<Event>> GetEvents(List<string> eventFields,
                                                      List<string> metricFields,
                                                      List<string> profileFields,
                                                      IFilter filter,
                                                      List<string> includedObjects,
                                                      string sort,
                                                      CancellationToken cancellationToken);
    /// <summary>
    ///Get an event with the given event ID. Include parameters can be provided to get the following related resource
    ///data: metrics, profiles
    /// </summary>
    /// <param name="id">ID of the event</param>
    /// <param name="eventFields">For more information please visit
    /// https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="metricFields">For more information please visit
    /// https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="profileFields">For more information please visit
    /// https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="includedObjects">For more information please visit
    /// https://developers.klaviyo.com/en/reference/api-overview#relationships</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObjectWithIncluded<Event>> GetEvent(string id,
                                                 List<string> eventFields,
                                                 List<string> metricFields,
                                                 List<string> profileFields,
                                                 List<string> includedObjects,
                                                 CancellationToken cancellationToken);
    /// <summary>
    /// Create an event. Events are created asynchronously. Successful response indicates that the event was validated
    /// and submitted for processing, but does not guarantee that processing is complete.
    /// </summary>
    /// <param name="eventObject">Event to create.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task CreateEvent(EventRequest eventObject, CancellationToken cancellationToken);
    /// <summary>
    /// Get the metric for an event with the given event ID.
    /// </summary>
    /// <param name="id">Event Id</param>
    /// <param name="metricFields">For more information please visit
    /// https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<Metric>> GetEventMetric(string id,
                                            List<string> metricFields,
                                            CancellationToken cancellationToken);
    /// <summary>
    /// Get the profile associated with an event with the given event ID.
    /// </summary>
    /// <param name="id">Event Id</param>
    /// <param name="profileFields">For more information please visit
    /// https://developers.klaviyo.com/en/reference/api-overview#sparse-fieldsets</param>
    /// <param name="additionalProfileFields">Request additional fields not included by default in the response.
    /// Supported values: 'predictive_analytics'</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<Profile>> GetEventProfile(string id,
                                              List<string> profileFields,
                                              List<string> additionalProfileFields,
                                              CancellationToken cancellationToken);
    /// <summary>
    /// Get a list of related Metrics for an Event
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<GenericObject>> GetEventRelationshipsMetric(string id, CancellationToken cancellationToken);
    /// <summary>
    /// Get profile relationships for an event with the given event ID.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<GenericObject>> GetEventRelationshipsProfile(string id, CancellationToken cancellationToken);
}