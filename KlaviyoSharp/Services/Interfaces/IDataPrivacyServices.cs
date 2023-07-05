using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Models;

namespace KlaviyoSharp.Services;
/// <summary>
/// Interface for Klaviyo Data Privacy Services
/// </summary>
public interface IDataPrivacyServices
{
    /// <summary>
    /// Request a deletion for the profiles corresponding to one of the following identifiers: email, phone_number, or profile_id. If multiple identifiers are provided, we will return an error.
    /// All profiles that match the provided identifier will be deleted.
    /// The deletion occurs asynchronously; however, once it has completed, the deleted profile will appear on the <see href="https://www.klaviyo.com/account/deleted">Deleted Profiles</see> page.
    /// For more information on the deletion process, please refer to our <see href="https://help.klaviyo.com/hc/en-us/articles/360004217631-How-to-Handle-GDPR-Requests#record-gdpr-and-ccpa%20%20-deletion-requests2">Help Center docs on how to handle GDPR and CCPA deletion requests</see>.
    /// </summary>
    /// <param name="profileDeletionRequest"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task RequestProfileDeletion(ProfileDeletionRequest profileDeletionRequest, CancellationToken cancellationToken = default);
}