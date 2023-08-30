using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using KlaviyoSharp.Infrastructure;
using KlaviyoSharp.Models;

namespace KlaviyoSharp.Services;

/// <summary>
/// Klaviyo Account Services
/// </summary>
public class AccountServices : KlaviyoServiceBase, IAccountServices
{
    /// <summary>
    /// Constructor for Klaviyo Account Services
    /// </summary>
    /// <param name="revision"></param>
    /// <param name="klaviyoService"></param>
    public AccountServices(string revision, KlaviyoApiBase klaviyoService) : base(revision, klaviyoService) { }
    /// <inheritdoc />
    public async Task<DataListObject<Account>> GetAccounts(List<string> accountFields = null,
                                                           CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("account", accountFields);
        return await _klaviyoService.HTTP<DataListObject<Account>>(HttpMethod.Get, "accounts/", _revision, query, null,
                                                                   null, cancellationToken);
    }
    ///<inheritdoc />
    public async Task<DataObject<Account>> GetAccount(string accountId,
                                                      List<string> accountFields = null,
                                                      CancellationToken cancellationToken = default)
    {
        QueryParams query = new();
        query.AddFieldset("account", accountFields);
        return await _klaviyoService.HTTP<DataObject<Account>>(HttpMethod.Get, $"accounts/{accountId}/", _revision,
                                                               query, null, null, cancellationToken);

    }
}
