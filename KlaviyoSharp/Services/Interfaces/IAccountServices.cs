using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Models;

namespace KlaviyoSharp.Services;
/// <summary>
/// Interface for Klaviyo Account Services
/// </summary>
public interface IAccountServices
{
    /// <summary>
    /// Retrieve the account(s) associated with a given private API key. This will return 1 account object within the list as an API key can only be associated with a single account. You can use this to retrieve account-specific data (contact information, timezone, currency, Public API key, etc.) or test if a Private API Key belongs to the correct account prior to performing subsequent actions with the API.
    /// </summary>
    /// <param name="accountFields">For more information please visit <see href="https://developers.klaviyo.com/en/v2023-06-15/reference/api-overview#sparse-fieldsets">Fieldsets overview</see></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataListObject<Account>> GetAccounts(List<string> accountFields = null, CancellationToken cancellationToken = default);
    /// <summary>
    /// Retrieve a single account object by its account ID. You can only request the account by which the private API key was generated.
    /// </summary>
    /// <param name="accountId">The ID of the account</param>
    /// <param name="accountFields">For more information please visit <see href="https://developers.klaviyo.com/en/v2023-06-15/reference/api-overview#sparse-fieldsets">Fieldsets overview</see></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DataObject<Account>> GetAccount(string accountId, List<string> accountFields = null, CancellationToken cancellationToken = default);
    }