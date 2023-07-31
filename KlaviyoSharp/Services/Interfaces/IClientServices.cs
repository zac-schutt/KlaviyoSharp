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
    /// Subscribe a profile to receive back in stock notifications. Check out our Back in Stock API guide for more details.
    /// </summary>
    /// <param name="subscription"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task CreateClientBackInStockSubscription(BackInStockSubscription subscription, CancellationToken cancellationToken);
}