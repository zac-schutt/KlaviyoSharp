using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Models;

namespace KlaviyoSharp.Services;

/// <summary>
/// Interface for Klaviyo Client Services
/// </summary>
public interface IClientServices
{
    /// <summary>
    /// Create a new event to track a profile's activity.
    /// </summary>
    /// <param name="clientEvent"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task CreateEvent(EventRequest clientEvent, CancellationToken cancellationToken);

    /// <summary>
    /// Create and update properties about a profile without tracking an associated event.
    /// </summary>
    /// <param name="profile"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task UpsertProfile(ClientProfile profile, CancellationToken cancellationToken);

    /// <summary>
    /// Create a new subscription for the given list ID and channel. Must contain either email or phone_number.
    /// </summary>
    /// <param name="subscription"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task CreateSubscription(ClientSubscription subscription, CancellationToken cancellationToken);
    /// <summary>
    /// Subscribe a profile to receive back in stock notifications. Check out our Back in Stock API guide for
    /// more details.
    /// </summary>
    /// <param name="subscription"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task CreateClientBackInStockSubscription(BackInStockSubscription subscription, CancellationToken cancellationToken);
    /// <summary>
    /// Create or update a push token. This endpoint is designed to be called from our mobile SDKs (iOS and Android).
    /// You must have push notifications enabled to use this endpoint.
    /// </summary>
    /// <param name="pushToken"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task CreateOrUpdateClientPushToken(PushToken pushToken, CancellationToken cancellationToken);
    /// <summary>
    /// Unregister a push token. This endpoint is designed to be called from our mobile SDKs (iOS and Android).
    /// You must have push notifications enabled to use this endpoint.
    /// </summary>
    /// <param name="pushToken"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task UnregisterClientPushToken(PushTokenUnregister pushToken, CancellationToken cancellationToken);
    /// <summary>
    /// Create new events to track a profile's activity. Accepts a maximum of 1000 events per request.
    /// </summary>
    /// <param name="clientEventBulkCreate"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task BulkCreateClientEvents(ClientEventBulkCreate clientEventBulkCreate, CancellationToken cancellationToken);
}