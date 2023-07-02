using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Models;

namespace KlaviyoSharp.Services;

public interface IClientServices
{
    /// <summary>
    /// Create a new event to track a profile's activity.
    /// </summary>
    /// <param name="clientEvent"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task CreateEvent(ClientEvent clientEvent, CancellationToken cancellationToken = default);

    /// <summary>
    /// Create and update properties about a profile without tracking an associated event.
    /// </summary>
    /// <param name="profile"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task UpsertProfile(ClientProfile profile, CancellationToken cancellationToken = default);

    /// <summary>
    /// Create a new subscription for the given list ID and channel. Must contain either email or phone_number.
    /// </summary>
    /// <param name="subscription"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task CreateSubscription(ClientSubscription subscription, CancellationToken cancellationToken = default);
}